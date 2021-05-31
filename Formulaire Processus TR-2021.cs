// Polytech LYON SIR 3A 
// Programamtion .NET
// 2021
//
// #{xx54ACFA454E}# (ne pas effacer) 
//
// Etudiant 1 : Pyrat Raphaël
// Etudiant 2 : Lafay Matthieu

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Processus_SIR_2021
{
    public partial class frmProcessus : Form
    {
        // Définition des constantes du processus
        const bool MARCHE = true;
        const bool ARRET = false;

        // Définition des états du processus (FSM state machine) dans l'ordre des états
        enum etatMachine
        { 
            INIT,
            DEPLACE_CAISSE_REMPLISSAGE,
            REMPLISSAGE,
            DEPLACE_CAISSE_BROYEUR,
            BROYEUR,
            DEPLACE_CAISSE_MELANGEUR,
            MELANGEUR,
            DEPLACE_TRAIN_CHARGEMENT,
            DEPLACE_TRAIN_FIN,
            FIN
        };

        // Déclaration des variables globales du processus
        etatMachine etatProcess;
        static bool etatCycle = ARRET;

        public int pasDeplacementCaisse = 2;
        public int pasDeplacementTrain = 5;

        public PrivateFontCollection fontFromFile;

        private int compteur_Broyeur = 5;
        private int compteur_Melangeur = 10;
        private bool debut_Remplissage = true;
        private bool debut_Broyeur = true;
        private bool fin_Broyeur = false;
        private bool fin_Melangeur = false;
        private int Progression_Convoyeur = 0;
        private int Progression_Train = 0;

        public frmProcessus()
        {
            InitializeComponent();
        }

        private void frmProcessus_Load(object sender, EventArgs e)
        {
            // Disparition de la caisse
            Caisse.Visible = false;

            // Cachage du train
            Train.Location = new Point(-1443,Train.Location.Y);

            // Ajout de la police des comptes à roubourds
            Font fontProcess;
            fontFromFile = new PrivateFontCollection();
            try
            {
                fontFromFile.AddFontFile(@"..\..\..\ressources\7segment.otf");
                fontProcess = new Font(fontFromFile.Families[0], 20, FontStyle.Regular);
            }
            catch
            {
                MessageBox.Show("Police non trouvée !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fontProcess = new Font("Calibri", 20);
            }


            this.DoubleBuffered = true;         // pour éviter scintillement    

            // Affichage des comptes à rebourds
            BroyeurTimer.Font = fontProcess;
            BroyeurTimer.Text = compteur_Broyeur.ToString("00");
            MelangeurTimer.Font = fontProcess;
            MelangeurTimer.Text = compteur_Melangeur.ToString("00");

            // Activation du timer système
            tmrProcess.Interval = 1;
            tmrProcess.Start();

            //posCAISSE_REMPLISSAGE = ...;

            //posTRAIN_CHARGEMENT = (int) (this.Width * 0.6);


            //etatProcess = ...;

        }

        // Fonction exécuté à chaque activation du timer du système
        private void tmrProcess_Tick(object sender, EventArgs e)
        {
            // Exécution de la fonction correspondante à l'état du système si le cycle est en marche
            if (etatCycle == MARCHE)
            {
                switch (etatProcess)
                {
                    case etatMachine.INIT:
                        frmProcessus_INIT();
                        break;
                    case etatMachine.DEPLACE_CAISSE_REMPLISSAGE:
                        frmProcessus_DEPLACE_CAISSE_REMPLISSAGE();
                        break;
                    case etatMachine.REMPLISSAGE:
                        frmProcessus_REMPLISSAGE();
                        break;
                    case etatMachine.DEPLACE_CAISSE_BROYEUR:
                        frmProcessus_DEPLACE_CAISSE_BROYEUR();
                        break;
                    case etatMachine.BROYEUR:
                        frmProcessus_BROYEUR();
                        break;
                    case etatMachine.DEPLACE_CAISSE_MELANGEUR:
                        frmProcessus_DEPLACE_CAISSE_MELANGEUR();
                        break;
                    case etatMachine.MELANGEUR:
                        frmProcessus_MELANGEUR();
                        break;
                    case etatMachine.DEPLACE_TRAIN_CHARGEMENT:
                        frmProcessus_DEPLACE_TRAIN_CHARGEMENT();
                        break;
                    case etatMachine.DEPLACE_TRAIN_FIN:
                        frmProcessus_DEPLACE_TRAIN_FIN();
                        break;
                    case etatMachine.FIN:
                        frmProcessus_FIN();
                        break;
                }
            }
        }

        // Fonction correspondant à l'état INIT
        private void frmProcessus_INIT()
        {
            // Affichage de la caisse
            Caisse.Visible = true;

            // Attente d'une seconde pour prendre le temps de se préparer au spectacle
            System.Threading.Thread.Sleep(1000);

            // Changement d'état
            etatProcess = etatMachine.DEPLACE_CAISSE_REMPLISSAGE;
        }

        // Fonction correspondant à l'état DEPLACE_CAISSE_REMPLISSAGE
        private void frmProcessus_DEPLACE_CAISSE_REMPLISSAGE()
        {
            // Déplace la caisse vers la droite tant qu'elle n'a pas attend la coordonnée définie
            // (tant que la caisse n'est pas en dessous du remplissage)
            if (Caisse.Location.X < 436)
            {
                Moteur_Convoyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur ON.png");
                Caisse.Location = new Point(Caisse.Location.X + pasDeplacementCaisse, Caisse.Location.Y);
            }
            // Changement d'état si la caisse est arrivé à la bonne coordonnée
            else
            {
                etatProcess = etatMachine.REMPLISSAGE;
            }
        }

        // Fonction correspondant à l'état REMPLISSAGE
        private void frmProcessus_REMPLISSAGE()
        {
            // Initialisation du remplissage
            if (debut_Remplissage == true)
            {
                // Changement de texture du moteur pour montrer son fonctionnement
                VanneCuve.Image = Image.FromFile(@"..\..\..\ressources\vanneO.bmp");

                // Désactivation de l'initialisation du remplissage
                debut_Remplissage = false;
            }
            // Diminution du niveau de la cuve si son niveau n'est pas déjà à 0
            else if ((debut_Remplissage == false) && (Bar_remplissage.Value > 0))
            {
                Bar_remplissage.Value -= 1;
                System.Threading.Thread.Sleep(20);
            }
            // Aboutissage du remplissage
            else if (Bar_remplissage.Value == 0)
            {
                // Changement de texture du moteur pour montrer son arrêt
                VanneCuve.Image = Image.FromFile(@"..\..\..\ressources\vanneF.bmp");
                // On passe à l'état suivant si le remplissage a fini
                etatProcess = etatMachine.DEPLACE_CAISSE_BROYEUR;
            }
        } 

        // Fonction correspondant à l'état DEPLACE_CAISSE_BROYEUR
        private void frmProcessus_DEPLACE_CAISSE_BROYEUR()
        {
            // Déplace la caisse vers la droite tant qu'elle n'a pas attend la coordonnée définie
            // (tant que la caisse n'est pas en dessous du broyeur)
            if (Caisse.Location.X < 560)
            {
                Caisse.Location = new Point(Caisse.Location.X + pasDeplacementCaisse, Caisse.Location.Y);
            }
            // Changement d'état si la caisse est arrivé à la bonne coordonnée
            else
            {
                etatProcess = etatMachine.BROYEUR;
            }
        }

        // Fonction correspondant à l'état BROYEUR
        private void frmProcessus_BROYEUR()
        {
            // Initialisation du broyeur
            if (debut_Broyeur == true)
            {
                // Changement de texture du moteur pour montrer son fonctionnement
                Moteur_Broyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur ON.png");

                // Démarrage du timer du mélangeur
                tmrBroyeur.Start();

                // Affichage du bon nombre sur l'afficheur
                compteur_Broyeur--;
                BroyeurTimer.Text = compteur_Broyeur.ToString("00");

                // Désactivation de l'initialisation du broyeur
                debut_Broyeur = false;
            }
            // Aboutissage du broyeur
            else if (fin_Broyeur == true)
            {
                // On passe à l'état suivant si le broyeur a fini
                etatProcess = etatMachine.DEPLACE_CAISSE_MELANGEUR;
            }
        }

        // Fonction exécuté à chaque activation du timer du broyeur
        private void tmrBroyeur_Tick(object sender, EventArgs e)
        {
            if (compteur_Broyeur > 0)
            {
                // Diminuion du compte à rebourd du broyeur s'il est supéreur à 0
                compteur_Broyeur--;
                BroyeurTimer.Text = compteur_Broyeur.ToString("00");
            }
            else
            {
                // Arrêt du timer du mélangeur si le compte à rebourd est à 0
                tmrBroyeur.Stop();

                // Changement de la texture du moteur pour montrer son arrêt
                Moteur_Broyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
                fin_Broyeur = true;
            }
        }

        // Fonction correspondant à l'état DEPLACE_CAISSE_MELANGEUR
        private void frmProcessus_DEPLACE_CAISSE_MELANGEUR()
        {
            // Déplace la caisse vers la droite tant qu'il n'a pas attend la coordonnée définit
            // (tant que la caisse n'est pas en dessus du mélangeur)
            if (Caisse.Location.X < 705)
            {
                Caisse.Location = new Point(Caisse.Location.X + pasDeplacementCaisse, Caisse.Location.Y);
            }
            // Changement d'état si la caisse est arrivé à la bonne coordonnée
            else
            {
                etatProcess = etatMachine.MELANGEUR;
            }
        }

        // Fonction correspondant à l'état MELANGEUR
        private void frmProcessus_MELANGEUR()
        {
            // Changement de texture du moteur pour montrer son fonctionnement
            Moteur_Melangeur.Image = Image.FromFile(@"..\..\..\ressources\moteur ON.png");

            // Démarrage du timer du mélangeur
            tmrMelangeur.Start();

            // Affichage du bon nombre sur l'afficheur
            compteur_Melangeur--;
            MelangeurTimer.Text = compteur_Melangeur.ToString("00");

            // On passe à l'état suivant
            etatProcess = etatMachine.DEPLACE_TRAIN_CHARGEMENT;
        }

        // Fonction exécuté à chaque activation du timer du mélangeur
        private void tmrMelangeur_Tick(object sender, EventArgs e)
        {
            if (compteur_Melangeur > 0)
            {
                // Diminuion du compte à rebourd du mélangeur s'il est supéreur à 0
                compteur_Melangeur--;
                MelangeurTimer.Text = compteur_Melangeur.ToString("00");
            }
            else
            {
                // Arrêt du timer du mélangeur si le compte à rebourd est à 0
                tmrMelangeur.Stop();

                // Changement de la texture du moteur pour montrer son arrêt
                Moteur_Melangeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
                fin_Melangeur = true;
            }
        }

        // Fonction correspondant à l'état DEPLACE_TRAIN_CHARGEMENT
        private void frmProcessus_DEPLACE_TRAIN_CHARGEMENT()
        {
            // Déplace le train vers la droite tant qu'il n'a pas attend la coordonnée définit
            // (tant que le dernier wagon n'est pas en dessous du mélangeur)
            if (Train.Location.X < 730)
            {
                Train.Location = new Point(Train.Location.X + pasDeplacementTrain, Train.Location.Y);
            }
            // Changement d'état si le train est arrivé à la bonne coordonnée et si le mélangeur a fini
            else if ((Train.Location.X >= 730)&&(fin_Melangeur == true))
            {
                etatProcess = etatMachine.DEPLACE_TRAIN_FIN;
            }
        }

        // Fonction correspondant à l'état DEPLACE_TRAIN_FIN
        private void frmProcessus_DEPLACE_TRAIN_FIN()
        {
            // Déplace le train vers la droite tant qu'il n'a pas attend la coordonnée définit
            // (tant que le train n'est pas sortie de l'écran)
            if (Train.Location.X < 1200)
            {
                Train.Location = new Point(Train.Location.X + pasDeplacementTrain, Train.Location.Y);
            }
            // Changement d'état si le train est arrivé à la bonne coordonnée
            else
            {
                etatProcess = etatMachine.FIN;
            }
        }

        // Fonction correspondant à l'état FIN
        private void frmProcessus_FIN()
        {
            // Réinitialisation du système
            Reinitialisation();
        }

        private void BP_conditions_initiales_Click(object sender, EventArgs e)
        {
            frmProcessus_FIN();
        }

        private void BP_depart_cycle_Click(object sender, EventArgs e)
        {
            // Démarre le cycle si le cycle n'est pas déjà activé
            if(etatCycle == ARRET)
            {
                etatCycle = MARCHE;
                BP_depart_cycle.BackColor = Color.Lime;
                etatProcess = etatMachine.INIT;
            }
        }

        // Fonction de remise à l'état initial
        private void Reinitialisation()
        {
            // Arrêt de des timers
            tmrBroyeur.Stop();
            tmrMelangeur.Stop();

            // Repositionnement des objets
            Caisse.Location = new Point(190, Caisse.Location.Y);
            Caisse.Visible = false;
            Train.Location = new Point(-1443, Train.Location.Y);

            // Reset des variables utilisées
            etatCycle = ARRET;
            debut_Remplissage = true;
            compteur_Broyeur = 5;
            compteur_Melangeur = 10;
            Bar_remplissage.Value = 100;
            debut_Broyeur = true;
            fin_Broyeur = false;
            fin_Melangeur = false;
            etatProcess = etatMachine.INIT;

            // Reset des textures
            VanneCuve.Image = Image.FromFile(@"..\..\..\ressources\vanneF.bmp");
            Moteur_Broyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
            Moteur_Melangeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
            BroyeurTimer.Text = compteur_Melangeur.ToString("00");
            MelangeurTimer.Text = compteur_Melangeur.ToString("00");
            BP_depart_cycle.BackColor = SystemColors.Control;
        }

        private void tmr_Convoyeur_Tick(object sender, EventArgs e)
        {
            Caisse.Location = new Point(Caisse.Location.X + pasDeplacementCaisse, Caisse.Location.Y);
            Progression_Convoyeur = ( (Caisse.Location.X + Caisse.Width - Convoyeur.Location.X) / Image.FromFile(@"..\..\..\ressources\convoyeur.png").Width)  * 100
        }

        private void tmr_Train_Tick(object sender, EventArgs e)
        {
            Train.Location = new Point(Train.Location.X + pasDeplacementTrain, Train.Location.Y);
            Progression_Train = ((Train.Location.X + 160 ) / );
        }
    }
}