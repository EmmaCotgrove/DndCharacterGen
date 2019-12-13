using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DnDCharacterGen
{
    public partial class MagicCasterForm : Form
    {
        public MagicCasterForm(string dndClass, string dndRace)
        {
            InitializeComponent();
            ClassLabel.Text = dndClass;
            RaceLabel.Text = dndRace;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void changeMod(Label label, NumericUpDown numericMod)
        {
            label.ResetText();
            int strMod = Convert.ToInt32(numericMod.Value);
            if (strMod > 20) { numericMod.Value = 20; strMod = 20; }
            int modifier;
            modifier = (strMod - 10) / 2;
            if (strMod >= 9)
            {
                label.Text = ("+" + modifier.ToString());
            }
            else
            {
                label.Text = (modifier.ToString());
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            changeMod(strMod, numericUpDown1);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            changeMod(dexMod, numericUpDown2);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            changeMod(conMod, numericUpDown3);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            changeMod(wisMod, numericUpDown4);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            changeMod(intMod, numericUpDown5);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            changeMod(chaMod, numericUpDown6);
        }

        private void ACNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (ACNumeric.Value > 20)
            {
                ACNumeric.Value = 20;
            }
        }

        private void SaveBtnMagic_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine($"Race: {RaceLabel.Text}\n");
                    sw.Write($"Race: {RaceLabel.Text}\n");
                    sw.Write($"Class: {ClassLabel.Text}\n\n");

                    sw.Write($"Strength: {numericUpDown1.Value}, Modifier: {strMod.Text}\n");
                    sw.Write($"Dexterity: {numericUpDown2.Value}, Modifier: {dexMod.Text}\n");
                    sw.Write($"Constitution: {numericUpDown3.Value}, Modifier: {conMod.Text}\n");
                    sw.Write($"Wisdown: {numericUpDown4.Value}, Modifier: {wisMod.Text}\n");
                    sw.Write($"Intelligence: {numericUpDown5.Value}, Modifier: {intMod.Text}\n");
                    sw.Write($"Charisma: {numericUpDown6.Value}, Modifier: {chaMod.Text}\n\n");

                    sw.Write($"AC: {ACNumeric.Value}\n");
                    sw.Write($"Hit Points: {numericUpDown8.Value}\n");
                    sw.Write($"Hit Dice: {HitDiceBox.Text}\n");

                    sw.Write($"Other Information\n {otherInfoLbl.Text}");
                    sw.Dispose();
                }
            }
        }
    }
}
