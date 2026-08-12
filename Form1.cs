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

        private void BtnAnalysis_Click(object sender, EventArgs e)
        {
            int result = 0;
            Brett.gewonnen = false;
            Brett.Tiefe = 0;

            if (rbRot.Checked)
                result = Brett.Analysis(Brett.Farbe.Rot, Brett.Tiefe);                                    // Rot = 1
            else
                result = Brett.Analysis(Brett.Farbe.Gelb, Brett.Tiefe);                                   // Gelb = -1

            if (result == -1000)
            {
                MessageBox.Show("ROT hat gewonnen");
            }
            
            MessageBox.Show("... FERTIG ...");
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            // Load File
            Brett.LoadingFile(textBoxFileName.Text);
            MessageBox.Show("Geladen");
        }
    }
}
