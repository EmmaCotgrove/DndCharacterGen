using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
