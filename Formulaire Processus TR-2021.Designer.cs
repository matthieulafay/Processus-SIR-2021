namespace Processus_SIR_2021
{
    partial class frmProcessus
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessus));
            this.tmrProcess = new System.Windows.Forms.Timer(this.components);
            this.VanneCuve = new System.Windows.Forms.PictureBox();
            this.Moteur_Broyeur = new System.Windows.Forms.PictureBox();
            this.BP_conditions_initiales = new System.Windows.Forms.Button();
            this.BP_depart_cycle = new System.Windows.Forms.Button();
            this.Caisse = new System.Windows.Forms.Panel();
            this.Bar_remplissage = new System.Windows.Forms.TrackBar();
            this.BroyeurTimer = new System.Windows.Forms.Label();
            this.tmrBroyeur = new System.Windows.Forms.Timer(this.components);
            this.Moteur_Melangeur = new System.Windows.Forms.PictureBox();
            this.tmrMelangeur = new System.Windows.Forms.Timer(this.components);
            this.MelangeurTimer = new System.Windows.Forms.Label();
            this.Train = new System.Windows.Forms.PictureBox();
            this.Moteur_Convoyeur = new System.Windows.Forms.PictureBox();
            this.tmr_Convoyeur = new System.Windows.Forms.Timer(this.components);
            this.tmr_Train = new System.Windows.Forms.Timer(this.components);
            this.Convoyeur = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.VanneCuve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Moteur_Broyeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_remplissage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Moteur_Melangeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Train)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Moteur_Convoyeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Convoyeur)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrProcess
            // 
            this.tmrProcess.Interval = 1;
            this.tmrProcess.Tick += new System.EventHandler(this.tmrProcess_Tick);
            // 
            // VanneCuve
            // 
            this.VanneCuve.Image = ((System.Drawing.Image)(resources.GetObject("VanneCuve.Image")));
            this.VanneCuve.Location = new System.Drawing.Point(448, 259);
            this.VanneCuve.Name = "VanneCuve";
            this.VanneCuve.Size = new System.Drawing.Size(30, 30);
            this.VanneCuve.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.VanneCuve.TabIndex = 29;
            this.VanneCuve.TabStop = false;
            // 
            // Moteur_Broyeur
            // 
            this.Moteur_Broyeur.Image = ((System.Drawing.Image)(resources.GetObject("Moteur_Broyeur.Image")));
            this.Moteur_Broyeur.Location = new System.Drawing.Point(622, 227);
            this.Moteur_Broyeur.Name = "Moteur_Broyeur";
            this.Moteur_Broyeur.Size = new System.Drawing.Size(59, 56);
            this.Moteur_Broyeur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Moteur_Broyeur.TabIndex = 30;
            this.Moteur_Broyeur.TabStop = false;
            // 
            // BP_conditions_initiales
            // 
            this.BP_conditions_initiales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BP_conditions_initiales.Location = new System.Drawing.Point(50, 175);
            this.BP_conditions_initiales.Margin = new System.Windows.Forms.Padding(2);
            this.BP_conditions_initiales.Name = "BP_conditions_initiales";
            this.BP_conditions_initiales.Size = new System.Drawing.Size(188, 51);
            this.BP_conditions_initiales.TabIndex = 31;
            this.BP_conditions_initiales.Text = "Conditions Initiales ";
            this.BP_conditions_initiales.UseVisualStyleBackColor = true;
            this.BP_conditions_initiales.Click += new System.EventHandler(this.BP_conditions_initiales_Click);
            // 
            // BP_depart_cycle
            // 
            this.BP_depart_cycle.BackColor = System.Drawing.SystemColors.Control;
            this.BP_depart_cycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BP_depart_cycle.Location = new System.Drawing.Point(50, 240);
            this.BP_depart_cycle.Margin = new System.Windows.Forms.Padding(2);
            this.BP_depart_cycle.Name = "BP_depart_cycle";
            this.BP_depart_cycle.Size = new System.Drawing.Size(188, 51);
            this.BP_depart_cycle.TabIndex = 32;
            this.BP_depart_cycle.Text = "Départ Cycle";
            this.BP_depart_cycle.UseVisualStyleBackColor = false;
            this.BP_depart_cycle.Click += new System.EventHandler(this.BP_depart_cycle_Click);
            // 
            // Caisse
            // 
            this.Caisse.BackColor = System.Drawing.Color.Lime;
            this.Caisse.Location = new System.Drawing.Point(190, 345);
            this.Caisse.Margin = new System.Windows.Forms.Padding(2);
            this.Caisse.Name = "Caisse";
            this.Caisse.Size = new System.Drawing.Size(50, 78);
            this.Caisse.TabIndex = 33;
            // 
            // Bar_remplissage
            // 
            this.Bar_remplissage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(209)))));
            this.Bar_remplissage.Enabled = false;
            this.Bar_remplissage.Location = new System.Drawing.Point(444, 93);
            this.Bar_remplissage.Maximum = 100;
            this.Bar_remplissage.Name = "Bar_remplissage";
            this.Bar_remplissage.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Bar_remplissage.Size = new System.Drawing.Size(45, 110);
            this.Bar_remplissage.TabIndex = 10;
            this.Bar_remplissage.TickFrequency = 10;
            this.Bar_remplissage.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Bar_remplissage.Value = 100;
            // 
            // BroyeurTimer
            // 
            this.BroyeurTimer.AutoSize = true;
            this.BroyeurTimer.BackColor = System.Drawing.SystemColors.ControlText;
            this.BroyeurTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BroyeurTimer.ForeColor = System.Drawing.Color.Red;
            this.BroyeurTimer.Location = new System.Drawing.Point(520, 259);
            this.BroyeurTimer.Name = "BroyeurTimer";
            this.BroyeurTimer.Size = new System.Drawing.Size(19, 13);
            this.BroyeurTimer.TabIndex = 34;
            this.BroyeurTimer.Text = "00";
            // 
            // tmrBroyeur
            // 
            this.tmrBroyeur.Interval = 1000;
            this.tmrBroyeur.Tick += new System.EventHandler(this.tmrBroyeur_Tick);
            // 
            // Moteur_Melangeur
            // 
            this.Moteur_Melangeur.Image = ((System.Drawing.Image)(resources.GetObject("Moteur_Melangeur.Image")));
            this.Moteur_Melangeur.Location = new System.Drawing.Point(907, 399);
            this.Moteur_Melangeur.Name = "Moteur_Melangeur";
            this.Moteur_Melangeur.Size = new System.Drawing.Size(59, 56);
            this.Moteur_Melangeur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Moteur_Melangeur.TabIndex = 35;
            this.Moteur_Melangeur.TabStop = false;
            // 
            // tmrMelangeur
            // 
            this.tmrMelangeur.Interval = 1000;
            this.tmrMelangeur.Tick += new System.EventHandler(this.tmrMelangeur_Tick);
            // 
            // MelangeurTimer
            // 
            this.MelangeurTimer.AutoSize = true;
            this.MelangeurTimer.BackColor = System.Drawing.SystemColors.ControlText;
            this.MelangeurTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MelangeurTimer.ForeColor = System.Drawing.Color.Red;
            this.MelangeurTimer.Location = new System.Drawing.Point(730, 467);
            this.MelangeurTimer.Name = "MelangeurTimer";
            this.MelangeurTimer.Size = new System.Drawing.Size(19, 13);
            this.MelangeurTimer.TabIndex = 36;
            this.MelangeurTimer.Text = "00";
            // 
            // Train
            // 
            this.Train.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Train.BackgroundImage")));
            this.Train.InitialImage = ((System.Drawing.Image)(resources.GetObject("Train.InitialImage")));
            this.Train.Location = new System.Drawing.Point(733, 629);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(1443, 111);
            this.Train.TabIndex = 37;
            this.Train.TabStop = false;
            // 
            // Moteur_Convoyeur
            // 
            this.Moteur_Convoyeur.Image = ((System.Drawing.Image)(resources.GetObject("Moteur_Convoyeur.Image")));
            this.Moteur_Convoyeur.Location = new System.Drawing.Point(244, 454);
            this.Moteur_Convoyeur.Name = "Moteur_Convoyeur";
            this.Moteur_Convoyeur.Size = new System.Drawing.Size(59, 56);
            this.Moteur_Convoyeur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Moteur_Convoyeur.TabIndex = 38;
            this.Moteur_Convoyeur.TabStop = false;
            // 
            // tmr_Convoyeur
            // 
            this.tmr_Convoyeur.Interval = 1;
            this.tmr_Convoyeur.Tick += new System.EventHandler(this.tmr_Convoyeur_Tick);
            // 
            // tmr_Train
            // 
            this.tmr_Train.Tick += new System.EventHandler(this.tmr_Train_Tick);
            // 
            // Convoyeur
            // 
            this.Convoyeur.Image = ((System.Drawing.Image)(resources.GetObject("Convoyeur.Image")));
            this.Convoyeur.Location = new System.Drawing.Point(216, 424);
            this.Convoyeur.Name = "Convoyeur";
            this.Convoyeur.Size = new System.Drawing.Size(495, 18);
            this.Convoyeur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Convoyeur.TabIndex = 39;
            this.Convoyeur.TabStop = false;
            // 
            // frmProcessus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1194, 761);
            this.Controls.Add(this.Convoyeur);
            this.Controls.Add(this.Moteur_Convoyeur);
            this.Controls.Add(this.Train);
            this.Controls.Add(this.MelangeurTimer);
            this.Controls.Add(this.Moteur_Melangeur);
            this.Controls.Add(this.BroyeurTimer);
            this.Controls.Add(this.Bar_remplissage);
            this.Controls.Add(this.Caisse);
            this.Controls.Add(this.BP_depart_cycle);
            this.Controls.Add(this.BP_conditions_initiales);
            this.Controls.Add(this.Moteur_Broyeur);
            this.Controls.Add(this.VanneCuve);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProcessus";
            this.Text = "PROJET programmation .NET 2021 (C#)";
            this.Load += new System.EventHandler(this.frmProcessus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VanneCuve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Moteur_Broyeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_remplissage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Moteur_Melangeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Train)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Moteur_Convoyeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Convoyeur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
               
        internal System.Windows.Forms.Timer tmrProcess;
        internal System.Windows.Forms.PictureBox VanneCuve;
        internal System.Windows.Forms.PictureBox Moteur_Broyeur;
        private System.Windows.Forms.Button BP_conditions_initiales;
        private System.Windows.Forms.Button BP_depart_cycle;
        private System.Windows.Forms.Panel Caisse;
        private System.Windows.Forms.TrackBar Bar_remplissage;
        private System.Windows.Forms.Label BroyeurTimer;
        private System.Windows.Forms.Timer tmrBroyeur;
        internal System.Windows.Forms.PictureBox Moteur_Melangeur;
        private System.Windows.Forms.Timer tmrMelangeur;
        private System.Windows.Forms.Label MelangeurTimer;
        private System.Windows.Forms.PictureBox Train;
        internal System.Windows.Forms.PictureBox Moteur_Convoyeur;
        private System.Windows.Forms.Timer tmr_Convoyeur;
        private System.Windows.Forms.Timer tmr_Train;
        internal System.Windows.Forms.PictureBox Convoyeur;
    }
}

