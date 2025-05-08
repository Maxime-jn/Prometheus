using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionNotesWinForms
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            ConnectToDatabase();
            LoadEleves();
            LoadCours();
        }

        private void ConnectToDatabase()
        {
            try
            {
                string connStr = "server=localhost;user=gestion_note;database=gestion_notes;port=3306;password=Super";
                connection = new MySqlConnection(connStr);
                connection.Open();
                lblStatus.Text = "Connecté à la base de données";
            }
            catch (Exception ex)
            {
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
        }

        private void LoadCours()
        {
            cmbCours.Items.Clear();
            var cmd = new MySqlCommand("SELECT id, nom FROM cours", connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                cmbCours.Items.Add(new ComboBoxItem(reader.GetString("nom"), reader.GetInt32("id")));
            reader.Close();
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
