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
            if (strMod > 10) { modifier = (strMod - 10) / 2; } else { modifier = 0; }
            label.Text = ("+" + modifier.ToString());
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
                BinaryWriter bw = new BinaryWriter(File.Create(path));
                bw.Write($"Race: {RaceLabel.Text}\n");
                bw.Write($"Class: {ClassLabel.Text}\n\n");

                bw.Write($"Strength: {numericUpDown1.Value}, Modifier: {strMod.Text}\n");
                bw.Write($"Dexterity: {numericUpDown2.Value}, Modifier: {dexMod.Text}\n");
                bw.Write($"Constitution: {numericUpDown3.Value}, Modifier: {conMod.Text}\n");
                bw.Write($"Wisdown: {numericUpDown4.Value}, Modifier: {wisMod.Text}\n");
                bw.Write($"Intelligence: {numericUpDown5.Value}, Modifier: {intMod.Text}\n");
                bw.Write($"Charisma: {numericUpDown6.Value}, Modifier: {chaMod.Text}\n\n");

                bw.Write($"AC: {ACNumeric.Value}\n");
                bw.Write($"Hit Points: {numericUpDown8.Value}\n");
                bw.Write($"Hit Dice: {HitDiceBox.Text}\n");
                bw.Dispose();
            }
        }
    }
}
