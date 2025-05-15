using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Prometheus;

namespace GestionNotesWinForms
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;

        // Métriques Prometheus
        private readonly Counter errorCounter = Metrics.CreateCounter("error_count", "Nombre d'erreurs dans l'application");
        private readonly Gauge eleveCount = Metrics.CreateGauge("eleve_count", "Nombre total d'élèves");
        private readonly Gauge coursCount = Metrics.CreateGauge("cours_count", "Nombre total de cours");
        private readonly Gauge noteCount = Metrics.CreateGauge("note_count", "Nombre total de notes");
        private readonly Gauge moyenneGlobale = Metrics.CreateGauge("moyenne_globale_ponderee", "Moyenne pondérée de la classe");

        public Form1()
        {
            InitializeComponent();

            // Serveur Prometheus
            var metricServer = new KestrelMetricServer(port: 1234);
            metricServer.Start();

            ConnectToDatabase();
            LoadEleves();
            LoadCours();
            UpdateNoteStats(); // mise à jour initiale
        }

        private void ConnectToDatabase()
        {
            try
            {
                string connStr = "server=localhost;user=zackaryist;database=gestion_notes;port=3306;password=Super";
                connection = new MySqlConnection(connStr);
                connection.Open();
                lblStatus.Text = "Connecté à la base de données";
            }
            catch (Exception ex)
            {
                errorCounter.Inc();
                lblStatus.Text = "Erreur: " + ex.Message;
            }
        }

        private void LoadEleves()
        {
            cmbEleves.Items.Clear();
            var cmd = new MySqlCommand("SELECT id, nom FROM eleves", connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                cmbEleves.Items.Add(new ComboBoxItem(reader.GetString("nom"), reader.GetInt32("id")));
            reader.Close();

            eleveCount.Set(cmbEleves.Items.Count);
        }

        private void LoadCours()
        {
            cmbCours.Items.Clear();
            var cmd = new MySqlCommand("SELECT id, nom FROM cours", connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                cmbCours.Items.Add(new ComboBoxItem(reader.GetString("nom"), reader.GetInt32("id")));
            reader.Close();

            coursCount.Set(cmbCours.Items.Count);
        }

        private void btnAddEleve_Click(object sender, EventArgs e)
        {
            if (txtNomEleve.Text.Trim() == "") return;
            var cmd = new MySqlCommand("INSERT INTO eleves (nom) VALUES (@nom)", connection);
            cmd.Parameters.AddWithValue("@nom", txtNomEleve.Text);
            cmd.ExecuteNonQuery();
            txtNomEleve.Clear();
            LoadEleves();
        }

        private void btnAddCours_Click(object sender, EventArgs e)
        {
            if (txtNomCours.Text.Trim() == "") return;
            var cmd = new MySqlCommand("INSERT INTO cours (nom) VALUES (@nom)", connection);
            cmd.Parameters.AddWithValue("@nom", txtNomCours.Text);
            cmd.ExecuteNonQuery();
            txtNomCours.Clear();
            LoadCours();
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (cmbEleves.SelectedItem is not ComboBoxItem eleve || cmbCours.SelectedItem is not ComboBoxItem cours) return;
            if (!double.TryParse(txtValeurNote.Text, out double valeur)) return;
            if (!int.TryParse(txtPonderation.Text, out int pond) || pond < 1 || pond > 5) return;

            var cmd = new MySqlCommand("INSERT INTO notes (eleve_id, cours_id, valeur, ponderation) VALUES (@eid, @cid, @val, @pond)", connection);
            cmd.Parameters.AddWithValue("@eid", eleve.Value);
            cmd.Parameters.AddWithValue("@cid", cours.Value);
            cmd.Parameters.AddWithValue("@val", valeur);
            cmd.Parameters.AddWithValue("@pond", pond);
            cmd.ExecuteNonQuery();

            txtValeurNote.Clear();
            txtPonderation.Clear();

            UpdateNoteStats();
        }

        private void btnAfficherMoyennes_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT 
                    e.nom AS Eleve,
                    c.nom AS Cours,
                    ROUND(SUM(n.valeur * n.ponderation) / SUM(n.ponderation), 2) AS Moyenne
                FROM notes n
                JOIN eleves e ON n.eleve_id = e.id
                JOIN cours c ON n.cours_id = c.id
                GROUP BY e.nom, c.nom;";

            var adapter = new MySqlDataAdapter(query, connection);
            var table = new DataTable();
            adapter.Fill(table);
            dgvMoyennes.DataSource = table;
        }

        private void UpdateNoteStats()
        {
            var cmd = new MySqlCommand("SELECT COUNT(*) FROM notes", connection);
            noteCount.Set(Convert.ToDouble(cmd.ExecuteScalar()));

            cmd = new MySqlCommand("SELECT SUM(valeur * ponderation) / SUM(ponderation) FROM notes", connection);
            var result = cmd.ExecuteScalar();
            moyenneGlobale.Set(result != DBNull.Value ? Convert.ToDouble(result) : 0);
        }

        private void txtNomEleve_TextChanged(object sender, EventArgs e)
        {
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }
        public override string ToString() => Text;
    }
}
