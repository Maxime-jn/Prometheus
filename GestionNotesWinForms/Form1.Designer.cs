namespace GestionNotesWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabControl;
        private TabPage tabEleves, tabCours, tabNotes;

        private TextBox txtNomEleve, txtNomCours, txtValeurNote, txtPonderation;
        private Button btnAddEleve, btnAddCours, btnAddNote, btnAfficherMoyennes;
        private ComboBox cmbEleves, cmbCours;
        private DataGridView dgvMoyennes;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabEleves = new TabPage();
            lblNomEleve = new Label();
            txtNomEleve = new TextBox();
            btnAddEleve = new Button();
            tabCours = new TabPage();
            lblNomCours = new Label();
            txtNomCours = new TextBox();
            btnAddCours = new Button();
            tabNotes = new TabPage();
            cmbEleves = new ComboBox();
            cmbCours = new ComboBox();
            txtValeurNote = new TextBox();
            txtPonderation = new TextBox();
            btnAddNote = new Button();
            btnAfficherMoyennes = new Button();
            dgvMoyennes = new DataGridView();
            lblStatus = new Label();
            lblEleve = new Label();
            lblCours = new Label();
            label1 = new Label();
            label2 = new Label();
            tabControl.SuspendLayout();
            tabEleves.SuspendLayout();
            tabCours.SuspendLayout();
            tabNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMoyennes).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabEleves);
            tabControl.Controls.Add(tabCours);
            tabControl.Controls.Add(tabNotes);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 470);
            tabControl.TabIndex = 0;
            // 
            // tabEleves
            // 
            tabEleves.BackColor = Color.White;
            tabEleves.Controls.Add(lblNomEleve);
            tabEleves.Controls.Add(txtNomEleve);
            tabEleves.Controls.Add(btnAddEleve);
            tabEleves.Location = new Point(4, 26);
            tabEleves.Name = "tabEleves";
            tabEleves.Size = new Size(792, 440);
            tabEleves.TabIndex = 0;
            tabEleves.Text = "Élèves";
            // 
            // lblNomEleve
            // 
            lblNomEleve.BackColor = Color.White;
            lblNomEleve.ForeColor = Color.Black;
            lblNomEleve.Location = new Point(284, 144);
            lblNomEleve.Name = "lblNomEleve";
            lblNomEleve.Size = new Size(227, 23);
            lblNomEleve.TabIndex = 0;
            lblNomEleve.Text = "Insérer Le nom de l'élève";
            // 
            // txtNomEleve
            // 
            txtNomEleve.BackColor = Color.White;
            txtNomEleve.ForeColor = Color.Black;
            txtNomEleve.Location = new Point(284, 170);
            txtNomEleve.Name = "txtNomEleve";
            txtNomEleve.Size = new Size(227, 25);
            txtNomEleve.TabIndex = 1;
            txtNomEleve.TextChanged += txtNomEleve_TextChanged;
            // 
            // btnAddEleve
            // 
            btnAddEleve.BackColor = Color.White;
            btnAddEleve.ForeColor = Color.Black;
            btnAddEleve.Location = new Point(284, 213);
            btnAddEleve.Name = "btnAddEleve";
            btnAddEleve.Size = new Size(227, 26);
            btnAddEleve.TabIndex = 2;
            btnAddEleve.Text = "Ajouter l'élève";
            btnAddEleve.UseVisualStyleBackColor = false;
            btnAddEleve.Click += btnAddEleve_Click;
            // 
            // tabCours
            // 
            tabCours.BackColor = Color.White;
            tabCours.Controls.Add(lblNomCours);
            tabCours.Controls.Add(txtNomCours);
            tabCours.Controls.Add(btnAddCours);
            tabCours.Location = new Point(4, 26);
            tabCours.Name = "tabCours";
            tabCours.Size = new Size(792, 440);
            tabCours.TabIndex = 1;
            tabCours.Text = "Cours";
            // 
            // lblNomCours
            // 
            lblNomCours.BackColor = Color.White;
            lblNomCours.ForeColor = Color.Black;
            lblNomCours.Location = new Point(304, 136);
            lblNomCours.Name = "lblNomCours";
            lblNomCours.Size = new Size(171, 23);
            lblNomCours.TabIndex = 0;
            lblNomCours.Text = "Insérer un nouveau cours";
            // 
            // txtNomCours
            // 
            txtNomCours.BackColor = Color.White;
            txtNomCours.ForeColor = Color.Black;
            txtNomCours.Location = new Point(304, 175);
            txtNomCours.Name = "txtNomCours";
            txtNomCours.Size = new Size(171, 25);
            txtNomCours.TabIndex = 1;
            // 
            // btnAddCours
            // 
            btnAddCours.BackColor = Color.White;
            btnAddCours.ForeColor = Color.Black;
            btnAddCours.Location = new Point(304, 216);
            btnAddCours.Name = "btnAddCours";
            btnAddCours.Size = new Size(171, 27);
            btnAddCours.TabIndex = 2;
            btnAddCours.Text = "Ajouter le cours";
            btnAddCours.UseVisualStyleBackColor = false;
            btnAddCours.Click += btnAddCours_Click;
            // 
            // tabNotes
            // 
            tabNotes.BackColor = Color.White;
            tabNotes.BorderStyle = BorderStyle.Fixed3D;
            tabNotes.Controls.Add(label2);
            tabNotes.Controls.Add(label1);
            tabNotes.Controls.Add(lblCours);
            tabNotes.Controls.Add(lblEleve);
            tabNotes.Controls.Add(cmbEleves);
            tabNotes.Controls.Add(cmbCours);
            tabNotes.Controls.Add(txtValeurNote);
            tabNotes.Controls.Add(txtPonderation);
            tabNotes.Controls.Add(btnAddNote);
            tabNotes.Controls.Add(btnAfficherMoyennes);
            tabNotes.Controls.Add(dgvMoyennes);
            tabNotes.Location = new Point(4, 26);
            tabNotes.Name = "tabNotes";
            tabNotes.Size = new Size(792, 440);
            tabNotes.TabIndex = 2;
            tabNotes.Text = "Notes";
            // 
            // cmbEleves
            // 
            cmbEleves.Location = new Point(33, 48);
            cmbEleves.Name = "cmbEleves";
            cmbEleves.Size = new Size(121, 25);
            cmbEleves.TabIndex = 1;
            // 
            // cmbCours
            // 
            cmbCours.Location = new Point(173, 48);
            cmbCours.Name = "cmbCours";
            cmbCours.Size = new Size(121, 25);
            cmbCours.TabIndex = 3;
            // 
            // txtValeurNote
            // 
            txtValeurNote.Location = new Point(322, 48);
            txtValeurNote.Name = "txtValeurNote";
            txtValeurNote.Size = new Size(100, 25);
            txtValeurNote.TabIndex = 5;
            // 
            // txtPonderation
            // 
            txtPonderation.Location = new Point(452, 48);
            txtPonderation.Name = "txtPonderation";
            txtPonderation.Size = new Size(100, 25);
            txtPonderation.TabIndex = 7;
            // 
            // btnAddNote
            // 
            btnAddNote.Location = new Point(604, 38);
            btnAddNote.Name = "btnAddNote";
            btnAddNote.Size = new Size(75, 46);
            btnAddNote.TabIndex = 8;
            btnAddNote.Text = "Ajouter Note";
            btnAddNote.Click += btnAddNote_Click;
            // 
            // btnAfficherMoyennes
            // 
            btnAfficherMoyennes.Location = new Point(694, 38);
            btnAfficherMoyennes.Name = "btnAfficherMoyennes";
            btnAfficherMoyennes.Size = new Size(80, 46);
            btnAfficherMoyennes.TabIndex = 9;
            btnAfficherMoyennes.Text = "Afficher Moyenne";
            btnAfficherMoyennes.Click += btnAfficherMoyennes_Click;
            // 
            // dgvMoyennes
            // 
            dgvMoyennes.Location = new Point(6, 108);
            dgvMoyennes.Name = "dgvMoyennes";
            dgvMoyennes.Size = new Size(776, 327);
            dgvMoyennes.TabIndex = 10;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 1;
            // 
            // lblEleve
            // 
            lblEleve.AutoSize = true;
            lblEleve.Location = new Point(33, 26);
            lblEleve.Name = "lblEleve";
            lblEleve.Size = new Size(46, 19);
            lblEleve.TabIndex = 11;
            lblEleve.Text = "Eleves";
            // 
            // lblCours
            // 
            lblCours.AutoSize = true;
            lblCours.Location = new Point(173, 26);
            lblCours.Name = "lblCours";
            lblCours.Size = new Size(45, 19);
            lblCours.TabIndex = 12;
            lblCours.Text = "Cours";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(322, 26);
            label1.Name = "label1";
            label1.Size = new Size(39, 19);
            label1.TabIndex = 13;
            label1.Text = "Note";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(452, 26);
            label2.Name = "label2";
            label2.Size = new Size(83, 19);
            label2.TabIndex = 14;
            label2.Text = "Pondération";
            // 
            // Form1
            // 
            BackColor = Color.White;
            ClientSize = new Size(800, 470);
            Controls.Add(tabControl);
            Controls.Add(lblStatus);
            Name = "Form1";
            Text = "Gestion Notes - WinForms";
            tabControl.ResumeLayout(false);
            tabEleves.ResumeLayout(false);
            tabEleves.PerformLayout();
            tabCours.ResumeLayout(false);
            tabCours.PerformLayout();
            tabNotes.ResumeLayout(false);
            tabNotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMoyennes).EndInit();
            ResumeLayout(false);
        }

        private Label lblNomEleve;
        private Label lblNomCours;
        private Label label2;
        private Label label1;
        private Label lblCours;
        private Label lblEleve;
    }
}
