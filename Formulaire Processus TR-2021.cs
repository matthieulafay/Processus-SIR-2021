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
        const int temps_broyeur = 5;                 // en secondes - temps de durée du broyeur
        const int temps_melangeur = 10;              // en secondes - temps de durée du mélangeur
        const int temps_timer_remplissage = 20;      // en millisecondes - temps pour chaque activation du timer de remplissage
        const int temps_timer_convoyeur = 1;         // en millisecondes - temps pour chaque activation du timer du convoyeur
        const int temps_timer_train = 1;             // en millisecondes - temps pour chaque activation du timer du train
        const int pasRemplissage = 2;                // en pixels - pas de vidage de la cuve à chaque activation du timer de remplissage
        const int pasDeplacementConvoyeur = 2;       // en pixels - pas de déplacement du convoyeur à chaque activation du timer du convoyeur
        const int pasDeplacementTrain = 10;          // en pixels - pas de déplacement du train à chaque activation du timer du train
        const int niveau_convoyeur_remplissage = 50; // en % de la taille du convoyeur - % où le convoyeur s'arrête pour le remplissage
        const int niveau_convoyeur_broyeur = 75;     // en % de la taille du convoyeur - % où le convoyeur s'arrête pour le broyeur
        const int niveau_convoyeur_melangeur = 100;  // en % de la taille du convoyeur - % où le convoyeur s'arrête pour le mélangeur
        const int niveau_train_melangeur = 60;       // en % de la taille de la fenêtre - % où le train s'arrête pour le mélangeur


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
        etatMachine etatProcess;                            // état de la machine à états
        static bool etatCycle = ARRET;                      // le cycle est en marche

        public PrivateFontCollection fontFromFile;          // variable pour l'impémentation de la police des comptes à rebourds

        private int compteur_Broyeur = temps_broyeur;       // compte à rebourd du broyeur
        private int compteur_Melangeur = temps_melangeur;   // compte à rebourd du mélangeur
        private bool debut_Remplissage = true;              // Initialisation du remplissage
        private bool debut_Broyeur = true;                  // Initialisation du broyeur
        private bool fin_Broyeur = false;                   // Aboutissage du broyeur
        private bool fin_Melangeur = false;                 // Aboutissage du mélangeur
        private bool debut_deplacement_Convoyeur = true;    // Initialisation de l'activation du convoyeur
        private bool debut_deplacement_Train = true;        // Initialisation du déplacement du train
        private bool fin_deplacement_Train = false;         // Aboutissage du déplacement du train
        private int Progression_Convoyeur = 0;              // progression du convoyeur en %
        private int Progression_Train = 0;                  // progression du train en %
        private bool Pause = false;                         // le cycle est en pause

        // Initialisation du processus
        public frmProcessus()
        {
            InitializeComponent();
        }

        private void frmProcessus_Load(object sender, EventArgs e)
        {
            // Initialisation du temps des timers
            tmrRemplissage.Interval = temps_timer_remplissage;
            tmr_Convoyeur.Interval = temps_timer_convoyeur;
            tmr_Train.Interval = temps_timer_train;

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
            lblTempoBroueur.Font = fontProcess;
            lblTempoMelangeur.Font = fontProcess;

            // Réinitialisation du cycle
            Reinitialisation();

            // Activation du timer systeme
            tmrProcess.Interval = 1;
            tmrProcess.Start();
        }

        // Fonction exécuté à chaque activation du timer du système
        private void tmrProcess_Tick(object sender, EventArgs e)
        {
            // Exécution de la machine à état si le cycle n'est pas en pause
            if (Pause == false)
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
        }

        // Fonction correspondant à l'état INIT
        private void frmProcessus_INIT()
        {
            // Affichage de la caisse
            pnlCaisse.Visible = true;

            // Attente d'une seconde pour prendre le temps de se préparer au spectacle
            System.Threading.Thread.Sleep(1000);

            // Changement d'état
            etatProcess = etatMachine.DEPLACE_CAISSE_REMPLISSAGE;
        }

        // Fonction correspondant à l'état DEPLACE_CAISSE_REMPLISSAGE
        private void frmProcessus_DEPLACE_CAISSE_REMPLISSAGE()
        {
            // Initialisation du déplacement de la caisse
            if ((debut_deplacement_Convoyeur == true) && (Progression_Convoyeur < niveau_convoyeur_remplissage))
            {
                tmr_Convoyeur.Start();
                picMoteurConvoyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur ON.png");
                debut_deplacement_Convoyeur = false;
            }
            // Aboutissage du déplacement de la caisse
            else if (Progression_Convoyeur >= niveau_convoyeur_remplissage)
            {
                tmr_Convoyeur.Stop();
                picMoteurConvoyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
                debut_deplacement_Convoyeur = true;
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
                picVanneRemplissage.Image = Image.FromFile(@"..\..\..\ressources\vanneO.bmp");

                // Désactivation de l'initialisation du remplissage
                debut_Remplissage = false;

                tmrRemplissage.Start();
            }
            // Aboutissage du remplissage
            else if (trkNiveau.Value == 0)
            {
                tmrRemplissage.Stop();

                // Changement de texture du moteur pour montrer son arrêt
                picVanneRemplissage.Image = Image.FromFile(@"..\..\..\ressources\vanneF.bmp");

                // On passe à l'état suivant si le remplissage a fini
                etatProcess = etatMachine.DEPLACE_CAISSE_BROYEUR;
            }
        } 

        // Fonction correspondant à l'état DEPLACE_CAISSE_BROYEUR
        private void frmProcessus_DEPLACE_CAISSE_BROYEUR()
        {
            // Initialisation déplacement caisse
            if ((debut_deplacement_Convoyeur == true) && (Progression_Convoyeur < niveau_convoyeur_broyeur))
            {
                tmr_Convoyeur.Start();
                picMoteurConvoyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur ON.png");
                debut_deplacement_Convoyeur = false;
            }
            // Aboutissage déplacement caisse
            else if (Progression_Convoyeur >= niveau_convoyeur_broyeur)
            {
                tmr_Convoyeur.Stop();
                picMoteurConvoyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
                debut_deplacement_Convoyeur = true;
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
                picMoteurBroyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur ON.png");

                // Démarrage du timer du mélangeur
                tmrBroyeur.Start();

                // Affichage du bon nombre sur l'afficheur
                compteur_Broyeur--;
                lblTempoBroueur.Text = compteur_Broyeur.ToString("00");

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
                lblTempoBroueur.Text = compteur_Broyeur.ToString("00");
            }
            else
            {
                // Arrêt du timer du mélangeur si le compte à rebourd est à 0
                tmrBroyeur.Stop();

                // Changement de la texture du moteur pour montrer son arrêt
                picMoteurBroyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
                fin_Broyeur = true;
            }
        }

        // Fonction correspondant à l'état DEPLACE_CAISSE_MELANGEUR
        private void frmProcessus_DEPLACE_CAISSE_MELANGEUR()
        {
            // Initialisation déplacement caisse
            if ((debut_deplacement_Convoyeur == true) && (Progression_Convoyeur < niveau_convoyeur_melangeur))
            {
                tmr_Convoyeur.Start();
                picMoteurConvoyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur ON.png");
                debut_deplacement_Convoyeur = false;
            }
            // Aboutissage déplacement caisse
            else if (Progression_Convoyeur >= niveau_convoyeur_melangeur)
            {
                tmr_Convoyeur.Stop();
                picMoteurConvoyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
                debut_deplacement_Convoyeur = true;
                etatProcess = etatMachine.MELANGEUR;
            }
        }

        // Fonction correspondant à l'état MELANGEUR
        private void frmProcessus_MELANGEUR()
        {
            // Changement de texture du moteur pour montrer son fonctionnement
            picMoteurMelangeur.Image = Image.FromFile(@"..\..\..\ressources\moteur ON.png");

            // Démarrage du timer du mélangeur
            tmrMelangeur.Start();

            // Affichage du bon nombre sur l'afficheur
            compteur_Melangeur--;
            lblTempoMelangeur.Text = compteur_Melangeur.ToString("00");

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
                lblTempoMelangeur.Text = compteur_Melangeur.ToString("00");
            }
            else
            {
                // Arrêt du timer du mélangeur si le compte à rebourd est à 0
                tmrMelangeur.Stop();

                // Changement de la texture du moteur pour montrer son arrêt
                picMoteurMelangeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
                fin_Melangeur = true;
            }
        }

        // Fonction correspondant à l'état DEPLACE_TRAIN_CHARGEMENT
        private void frmProcessus_DEPLACE_TRAIN_CHARGEMENT()
        {
            // Initialisation déplacement train
            if ((debut_deplacement_Train == true) && (Progression_Train < niveau_train_melangeur))
            {
                tmr_Train.Start();
                debut_deplacement_Train = false;
            }
            // Aboutissage déplacement train
            else if ((Progression_Train >= niveau_train_melangeur) && (fin_deplacement_Train == false))
            {
                tmr_Train.Stop();
                fin_deplacement_Train = true;
            }
            // Aboutissage mélangeur et déplacement train
            else if ((fin_deplacement_Train == true) && (fin_Melangeur == true))
            {
                debut_deplacement_Train = true;
                fin_deplacement_Train = false;
                etatProcess = etatMachine.DEPLACE_TRAIN_FIN;
            }
        }

        // Fonction correspondant à l'état DEPLACE_TRAIN_FIN
        private void frmProcessus_DEPLACE_TRAIN_FIN()
        {
            // Initialisation déplacement train
            if ((debut_deplacement_Train == true) && (Progression_Train < 100))
            {
                tmr_Train.Start();
                debut_deplacement_Train = false;
            }
            // Aboutissage déplacement train
            else if (Progression_Train >= 100)
            {
                tmr_Train.Stop();
                debut_deplacement_Train = true;
                etatProcess = etatMachine.FIN;
            }
        }

        // Fonction correspondant à l'état FIN
        private void frmProcessus_FIN()
        {
            // Réinitialisation du cycle
            Reinitialisation();
        }

        // Réinitialisation du cycle lors d'un appuye sur le bouton de conditions initiales
        private void BP_conditions_initiales_Click(object sender, EventArgs e)
        {
            Reinitialisation();
        }

        private void BP_depart_cycle_Click(object sender, EventArgs e)
        {
            // Démarre le cycle si le cycle n'est pas déjà activé
            if(etatCycle == ARRET)
            {
                etatCycle = MARCHE;
                btnCycle.BackColor = Color.Lime;
                etatProcess = etatMachine.INIT;
            }
            // Gestion de la pause du cycle si le cycle est déjà activé
            else
            {
                // Mise en pause du cycle s'il ne l'est pas déjà en desactivant tous les timers
                if (Pause == false)
                {
                    Pause = true;
                    btnCycle.BackColor = Color.OrangeRed;
                    tmrBroyeur.Stop();
                    tmrMelangeur.Stop();
                    tmr_Convoyeur.Stop();
                    tmr_Train.Stop();
                    tmrRemplissage.Stop();
                    picMoteurConvoyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
                    picVanneRemplissage.Image = Image.FromFile(@"..\..\..\ressources\vanneF.bmp");
                    picMoteurBroyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
                    picMoteurMelangeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
                }
                // Reactivation du cycle s'il est en pause en redémarrant l'étape en cours
                else
                {
                    if(etatProcess == etatMachine.DEPLACE_TRAIN_CHARGEMENT)
                    {
                        etatProcess = etatMachine.MELANGEUR;
                    }
                    btnCycle.BackColor = Color.Lime;
                    debut_Remplissage = true;
                    debut_Broyeur = true;
                    fin_Broyeur = false;
                    fin_Melangeur = false;
                    debut_deplacement_Convoyeur = true;
                    debut_deplacement_Train = true;
                    fin_deplacement_Train = false;
                    Pause = false;
                }
            }
        }

        // Fonction de remise à l'état initial
        private void Reinitialisation()
        {
            // Arrêt de des timers
            tmrBroyeur.Stop();
            tmrMelangeur.Stop();
            tmr_Convoyeur.Stop();
            tmr_Train.Stop();
            tmrRemplissage.Stop();

            // Repositionnement des objets
            pnlCaisse.Location = new Point(190, pnlCaisse.Location.Y);
            pnlCaisse.Visible = false;
            picTrain.Location = new Point(-1443, picTrain.Location.Y);

            // Reset des variables utilisées
            etatCycle = ARRET;
            debut_Remplissage = true;
            compteur_Broyeur = temps_broyeur;
            compteur_Melangeur = temps_melangeur;
            trkNiveau.Value = 100;
            debut_Broyeur = true;
            fin_Broyeur = false;
            fin_Melangeur = false;
            debut_deplacement_Convoyeur = true;
            debut_deplacement_Train = true;
            fin_deplacement_Train = false;
            Pause = false;
            Progression_Convoyeur = 0;
            Progression_Train = 0;
            etatProcess = etatMachine.INIT;

            // Reset des textures
            picMoteurConvoyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
            picVanneRemplissage.Image = Image.FromFile(@"..\..\..\ressources\vanneF.bmp");
            picMoteurBroyeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
            picMoteurMelangeur.Image = Image.FromFile(@"..\..\..\ressources\moteur OFF.png");
            lblTempoBroueur.Text = compteur_Broyeur.ToString("00");
            lblTempoMelangeur.Text = compteur_Melangeur.ToString("00");
            btnCycle.BackColor = SystemColors.Control;
        }

        // Avancement de la caisse quand le timer du convoyeur est activé
        private void tmr_Convoyeur_Tick(object sender, EventArgs e)
        {
            pnlCaisse.Left += pasDeplacementConvoyeur;
            Progression_Convoyeur = (pnlCaisse.Left + pnlCaisse.Width / 2 - picConvoyeur.Left) * 100 / picConvoyeur.Width;
        }

        // Avancement du train quand le timer du train est activé
        private void tmr_Train_Tick(object sender, EventArgs e)
        {
            picTrain.Left += pasDeplacementTrain;
            Progression_Train = picTrain.Left * 100 / Image.FromFile(@"..\..\..\ressources\Synoptique Processus 2021.png").Width;
        }

        // Diminution du niveau de la cuve quand le timer de remplissage est activé
        private void tmrRemplissage_Tick(object sender, EventArgs e)
        {
            trkNiveau.Value -= pasRemplissage;
        }
    }
}