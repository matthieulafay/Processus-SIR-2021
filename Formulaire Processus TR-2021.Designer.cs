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
            this.picVanneRemplissage = new System.Windows.Forms.PictureBox();
            this.picMoteurBroyeur = new System.Windows.Forms.PictureBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnCycle = new System.Windows.Forms.Button();
            this.pnlCaisse = new System.Windows.Forms.Panel();
            this.trkNiveau = new System.Windows.Forms.TrackBar();
            this.lblTempoBroueur = new System.Windows.Forms.Label();
            this.tmrBroyeur = new System.Windows.Forms.Timer(this.components);
            this.picMoteurMelangeur = new System.Windows.Forms.PictureBox();
            this.tmrMelangeur = new System.Windows.Forms.Timer(this.components);
            this.lblTempoMelangeur = new System.Windows.Forms.Label();
            this.picTrain = new System.Windows.Forms.PictureBox();
            this.picMoteurConvoyeur = new System.Windows.Forms.PictureBox();
            this.tmr_Convoyeur = new System.Windows.Forms.Timer(this.components);
            this.tmr_Train = new System.Windows.Forms.Timer(this.components);
            this.picConvoyeur = new System.Windows.Forms.PictureBox();
            this.tmrRemplissage = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picVanneRemplissage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoteurBroyeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkNiveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoteurMelangeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoteurConvoyeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConvoyeur)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrProcess
            // 
            this.tmrProcess.Interval = 1;
            this.tmrProcess.Tick += new System.EventHandler(this.tmrProcess_Tick);
            // 
            // picVanneRemplissage
            // 
            this.picVanneRemplissage.Image = ((System.Drawing.Image)(resources.GetObject("picVanneRemplissage.Image")));
            this.picVanneRemplissage.Location = new System.Drawing.Point(448, 259);
            this.picVanneRemplissage.Name = "picVanneRemplissage";
            this.picVanneRemplissage.Size = new System.Drawing.Size(30, 30);
            this.picVanneRemplissage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picVanneRemplissage.TabIndex = 29;
            this.picVanneRemplissage.TabStop = false;
            // 
            // picMoteurBroyeur
            // 
            this.picMoteurBroyeur.Image = ((System.Drawing.Image)(resources.GetObject("picMoteurBroyeur.Image")));
            this.picMoteurBroyeur.Location = new System.Drawing.Point(622, 227);
            this.picMoteurBroyeur.Name = "picMoteurBroyeur";
            this.picMoteurBroyeur.Size = new System.Drawing.Size(59, 56);
            this.picMoteurBroyeur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMoteurBroyeur.TabIndex = 30;
            this.picMoteurBroyeur.TabStop = false;
            // 
            // btnInit
            // 
            this.btnInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnInit.Location = new System.Drawing.Point(50, 175);
            this.btnInit.Margin = new System.Windows.Forms.Padding(2);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(188, 51);
            this.btnInit.TabIndex = 31;
            this.btnInit.Text = "Conditions Initiales ";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.BP_conditions_initiales_Click);
            // 
            // btnCycle
            // 
            this.btnCycle.BackColor = System.Drawing.SystemColors.Control;
            this.btnCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCycle.Location = new System.Drawing.Point(50, 240);
            this.btnCycle.Margin = new System.Windows.Forms.Padding(2);
            this.btnCycle.Name = "btnCycle";
            this.btnCycle.Size = new System.Drawing.Size(188, 51);
            this.btnCycle.TabIndex = 32;
            this.btnCycle.Text = "Départ Cycle";
            this.btnCycle.UseVisualStyleBackColor = false;
            this.btnCycle.Click += new System.EventHandler(this.BP_depart_cycle_Click);
            // 
            // pnlCaisse
            // 
            this.pnlCaisse.BackColor = System.Drawing.Color.Lime;
            this.pnlCaisse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlCaisse.BackgroundImage")));
            this.pnlCaisse.Location = new System.Drawing.Point(186, 363);
            this.pnlCaisse.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCaisse.Name = "pnlCaisse";
            this.pnlCaisse.Size = new System.Drawing.Size(60, 60);
            this.pnlCaisse.TabIndex = 33;
            // 
            // trkNiveau
            // 
            this.trkNiveau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(209)))));
            this.trkNiveau.Enabled = false;
            this.trkNiveau.Location = new System.Drawing.Point(444, 93);
            this.trkNiveau.Maximum = 100;
            this.trkNiveau.Name = "trkNiveau";
            this.trkNiveau.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkNiveau.Size = new System.Drawing.Size(45, 110);
            this.trkNiveau.TabIndex = 10;
            this.trkNiveau.TickFrequency = 10;
            this.trkNiveau.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkNiveau.Value = 100;
            // 
            // lblTempoBroueur
            // 
            this.lblTempoBroueur.AutoSize = true;
            this.lblTempoBroueur.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblTempoBroueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTempoBroueur.ForeColor = System.Drawing.Color.Red;
            this.lblTempoBroueur.Location = new System.Drawing.Point(520, 259);
            this.lblTempoBroueur.Name = "lblTempoBroueur";
            this.lblTempoBroueur.Size = new System.Drawing.Size(19, 13);
            this.lblTempoBroueur.TabIndex = 34;
            this.lblTempoBroueur.Text = "00";
            // 
            // tmrBroyeur
            // 
            this.tmrBroyeur.Interval = 1000;
            this.tmrBroyeur.Tick += new System.EventHandler(this.tmrBroyeur_Tick);
            // 
            // picMoteurMelangeur
            // 
            this.picMoteurMelangeur.Image = ((System.Drawing.Image)(resources.GetObject("picMoteurMelangeur.Image")));
            this.picMoteurMelangeur.Location = new System.Drawing.Point(907, 399);
            this.picMoteurMelangeur.Name = "picMoteurMelangeur";
            this.picMoteurMelangeur.Size = new System.Drawing.Size(59, 56);
            this.picMoteurMelangeur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMoteurMelangeur.TabIndex = 35;
            this.picMoteurMelangeur.TabStop = false;
            // 
            // tmrMelangeur
            // 
            this.tmrMelangeur.Interval = 1000;
            this.tmrMelangeur.Tick += new System.EventHandler(this.tmrMelangeur_Tick);
            // 
            // lblTempoMelangeur
            // 
            this.lblTempoMelangeur.AutoSize = true;
            this.lblTempoMelangeur.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblTempoMelangeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTempoMelangeur.ForeColor = System.Drawing.Color.Red;
            this.lblTempoMelangeur.Location = new System.Drawing.Point(730, 467);
            this.lblTempoMelangeur.Name = "lblTempoMelangeur";
            this.lblTempoMelangeur.Size = new System.Drawing.Size(19, 13);
            this.lblTempoMelangeur.TabIndex = 36;
            this.lblTempoMelangeur.Text = "00";
            // 
            // picTrain
            // 
            this.picTrain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picTrain.BackgroundImage")));
            this.picTrain.InitialImage = ((System.Drawing.Image)(resources.GetObject("picTrain.InitialImage")));
            this.picTrain.Location = new System.Drawing.Point(733, 629);
            this.picTrain.Name = "picTrain";
            this.picTrain.Size = new System.Drawing.Size(1443, 111);
            this.picTrain.TabIndex = 37;
            this.picTrain.TabStop = false;
            // 
            // picMoteurConvoyeur
            // 
            this.picMoteurConvoyeur.Image = ((System.Drawing.Image)(resources.GetObject("picMoteurConvoyeur.Image")));
            this.picMoteurConvoyeur.Location = new System.Drawing.Point(244, 454);
            this.picMoteurConvoyeur.Name = "picMoteurConvoyeur";
            this.picMoteurConvoyeur.Size = new System.Drawing.Size(59, 56);
            this.picMoteurConvoyeur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMoteurConvoyeur.TabIndex = 38;
            this.picMoteurConvoyeur.TabStop = false;
            // 
            // tmr_Convoyeur
            // 
            this.tmr_Convoyeur.Interval = 1;
            this.tmr_Convoyeur.Tick += new System.EventHandler(this.tmr_Convoyeur_Tick);
            // 
            // tmr_Train
            // 
            this.tmr_Train.Interval = 1;
            this.tmr_Train.Tick += new System.EventHandler(this.tmr_Train_Tick);
            // 
            // picConvoyeur
            // 
            this.picConvoyeur.Image = ((System.Drawing.Image)(resources.GetObject("picConvoyeur.Image")));
            this.picConvoyeur.Location = new System.Drawing.Point(216, 424);
            this.picConvoyeur.Name = "picConvoyeur";
            this.picConvoyeur.Size = new System.Drawing.Size(495, 18);
            this.picConvoyeur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picConvoyeur.TabIndex = 39;
            this.picConvoyeur.TabStop = false;
            // 
            // tmrRemplissage
            // 
            this.tmrRemplissage.Interval = 20;
            this.tmrRemplissage.Tick += new System.EventHandler(this.tmrRemplissage_Tick);
            // 
            // frmProcessus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1194, 761);
            this.Controls.Add(this.picConvoyeur);
            this.Controls.Add(this.picMoteurConvoyeur);
            this.Controls.Add(this.picTrain);
            this.Controls.Add(this.lblTempoMelangeur);
            this.Controls.Add(this.picMoteurMelangeur);
            this.Controls.Add(this.lblTempoBroueur);
            this.Controls.Add(this.trkNiveau);
            this.Controls.Add(this.pnlCaisse);
            this.Controls.Add(this.btnCycle);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.picMoteurBroyeur);
            this.Controls.Add(this.picVanneRemplissage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProcessus";
            this.Text = "PROJET programmation .NET 2021 (C#)";
            this.Load += new System.EventHandler(this.frmProcessus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVanneRemplissage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoteurBroyeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkNiveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoteurMelangeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoteurConvoyeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConvoyeur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
               
        internal System.Windows.Forms.Timer tmrProcess;
        internal System.Windows.Forms.PictureBox picVanneRemplissage;
        internal System.Windows.Forms.PictureBox picMoteurBroyeur;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnCycle;
        private System.Windows.Forms.Panel pnlCaisse;
        private System.Windows.Forms.TrackBar trkNiveau;
        private System.Windows.Forms.Label lblTempoBroueur;
        private System.Windows.Forms.Timer tmrBroyeur;
        internal System.Windows.Forms.PictureBox picMoteurMelangeur;
        private System.Windows.Forms.Timer tmrMelangeur;
        private System.Windows.Forms.Label lblTempoMelangeur;
        private System.Windows.Forms.PictureBox picTrain;
        internal System.Windows.Forms.PictureBox picMoteurConvoyeur;
        private System.Windows.Forms.Timer tmr_Convoyeur;
        private System.Windows.Forms.Timer tmr_Train;
        internal System.Windows.Forms.PictureBox picConvoyeur;
        private System.Windows.Forms.Timer tmrRemplissage;
    }
}

