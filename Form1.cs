using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win4Gewinnt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Brett initi...
            Brett.Init();
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            if (textBoxX.Text.Length == 0)
            {
                textBoxX.Focus();
                return;
            }

            if (textBoxY.Text.Length == 0)
            {
                textBoxY.Focus();
                return;
            }

            int valueX;
            int valueY;

            try
            {
                valueX = Convert.ToInt32(textBoxX.Text);
            }
            catch (Exception)
            {
                textBoxX.Focus();
                MessageBox.Show("Zahl {X} fehlerhaft");
                return;
            }

            try
            {
                valueY = Convert.ToInt32(textBoxY.Text);
            }
            catch (Exception) 
            {
                textBoxY.Focus();
                MessageBox.Show("Zahl {Y}  fehlerhaft"); 
                return;
            }

            // Stein setzen
            Brett.SetValue(valueX, valueY, Brett.Spieler);
        }


        //--------------------------------------------------------------
        // Rot : Hat POSITIVE Werte
        // Gelb: Hat NEGATIVE Werte
        //--------------------------------------------------------------
        private void BtnAnalysis_Click(object sender, EventArgs e)
        {
            int result = 0;            
            Brett.Tiefe = 0;

            if (rbRot.Checked)
                result = Brett.Analysis(Brett.Farbe.Rot, Brett.Tiefe);                                    // Rot = 1
            else
                result = Brett.Analysis(Brett.Farbe.Gelb, Brett.Tiefe);                                   // Gelb = -1

            if (result == 1000)
            {
                MessageBox.Show("ROT hat gewonnen");
            }
            
            MessageBox.Show("... FERTIG ...");
        }


        //-------------------------------------------------------------
        // Hier wird eine Datei mit vordefinierten Stellung geladen
        //-------------------------------------------------------------
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            // Load File
            Brett.LoadingFile(textBoxFileName.Text);
            MessageBox.Show("Geladen");
        }


        //-------------------------------------------------------------
        // 20260812:
        //    Die Funktion = x1^2 ist gegeben. X Minimum = 0 und Y Maximum = 10.
        //    Gesucht ist der Wert = 71. 
        //    Hier ist herauszubekommen, wie der Wert von X sein muss, um den Wert = 71 
        //    zu berechnen. 
        //    Die Funktion nährt sich langsam den Wert, indem es die
        //    Differenze zwischen X Maximum und X Minumum berechnet.
        //--------------------------------------------------------------
        private void btnRechnen_Click(object sender, EventArgs e)
        {
            //
            double x1, x2, diff;
            double vx1 = 0, vx2 = 0;
            double search = 71;

            x1 = 0; x2 = 10; diff = 0;

            vx1 = Math.Pow(x1, 2);
            vx2 = Math.Pow(x2, 2);

            // Auf 5 Nachkommastellen runden
            vx1 = Math.Round(vx1, 5);
            vx2 = Math.Round(vx2, 5);

            do
            {
                // Differenz berechnen
                diff = (x2 - x1) / 2;

                if (vx1 == search)
                {
                    MessageBox.Show("Geschafft");
                    break;
                }
                else if (vx1 < search)
                {
                    vx1 = Math.Pow(diff + x1, 2);
                    vx1 = Math.Round(vx1, 5);
                    
                    if (vx1 < search)
                        x1 = diff + x1;
                    else if (vx1 > search)
                        x2 = x2 - diff;
                    else { MessageBox.Show("Geschafft"); break; }                    
                }
                else if (vx1 > search)
                {
                    vx2 = Math.Pow(x2 - diff, 2);
                    vx2 = Math.Round(vx2, 5);
                    
                    if (vx2 < search)
                        x1 = diff + x1;
                    else if (vx2 > search)
                        x2 = x2 - diff;
                    else { MessageBox.Show("Geschafft"); break; }                    
                }
            } while (true);            
        }


        //----------------------------------------------------------------------
        // 20260812:
        //   Finde anhand der festgelegten Wetten den besten Einsatz heraus.
        //   Wichtig ist, dass man mit 100€ so wenig wie möglich VERLUSTE macht.
        //   Man muss so geschickt auf die jeweiligen Wetten geld eingesetzen,
        //    letzendlich bei VERLUST der gerinste Betrag herauskommt
        //----------------------------------------------------------------------
        private void btnWetten_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            double vx1, vx2, vx3;
            double w1, w2, w3;
            
            w1 = 1.58; w2 = 3.8; w3 = 6.33;

            for (int x1 = 100; x1 >= 0; x1--)
            {
                for (int x2 = (100-x1); x2 >= 0; x2--)
                {
                    for (int x3 = (100 - x1 - x2); x3 >= 0; x3--)
                    {
                        if ((x1 + x2 + x3) < 100)
                            break;

                        vx1 = (x1 * w1);
                        vx2 = (x2 * w2);
                        vx3 = (x3 * w3);

                        sb.Append(x1.ToString() +
                                 ";" + x2.ToString() +
                                 ";" + x3.ToString() +
                                 ";" + vx1.ToString() +
                                 ";" + vx2.ToString() +
                                 ";" + vx3.ToString() + Environment.NewLine);
                    }
                }
            }


            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"d:\Wetten.csv"))
            {
                file.WriteLine(sb.ToString()); // "sb" is the StringBuilder
            }
        }
    }
}
