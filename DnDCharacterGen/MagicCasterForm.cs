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
            BardCantrips.Hide();
            BardCantrips2.Hide();
            BardL1_1.Hide();
            BardL1_2.Hide();
            ClericCantrips.Hide();
            ClericCantrips2.Hide();
            ClericCantrips3.Hide();
            ClericL1_1.Hide();
            ClericL1_2.Hide();
            DruidCantrips.Hide();
            DruidCantrips2.Hide();
            DruidL1_1.Hide();
            DruidL1_2.Hide();
            
            if (dndClass=="Bard")
            {
                BardL1_2.Show();
                BardL1_1.Show();
                BardCantrips.Show();
                BardCantrips2.Show();
                HitDiceBox.Text = "1d8";
                otherInfoLbl.Text = "Start with Spellcasting. Bardic Inspiration: Use a bonus action to inspire another creature within 60 feet. That creature" +
                    "gains 1d6 inspiration die. This lasts 10 mins, and can be added to one ability check, attack roll or saving throw. The creature can" +
                    "wait until after it rolls the d20 but before the DM announces the result.";
                SpellSaveDCINFO.Text = "8 + Proficiency Modifier + Charisma Modifier";
            } else if (dndClass == "Cleric")
            {
                ClericCantrips.Show();
                ClericCantrips2.Show();
                ClericCantrips3.Show();
                ClericL1_1.Show();
                ClericL1_2.Show();
                HitDiceBox.Text = "1d8";
                otherInfoLbl.Text = "Start with Spellcasting. Divine Domain: Choose a domain linked to your Deity which grants domain spells and " +
                    "other features";
                SpellSaveDCINFO.Text = "8 + Proficiency Modifier + Wisdom Modifier";
            } else if (dndClass == "Druid")
            {
                DruidCantrips.Show();
                DruidCantrips2.Show();
                DruidL1_1.Show();
                DruidL1_2.Show();
                HitDiceBox.Text = "1d8";
                otherInfoLbl.Text = "Start with Spellcasting. You know Druidic the secret Language of the Druids.";
                SpellSaveDCINFO.Text = "8 + Proficiency Modifier + Wisdom Modifier";
            }
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
                    sw.Write($"Character name: {CharacterName.Text}\n");
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
                    sw.Write($"Hit Dice: {HitDiceBox.Text}\n\n");

                    sw.Write($"Spell Caster Stats:\n");
                    sw.Write($"Spell Save DC: {SpellSaveDCNum.Value}\n Spell Attack Modifier: {SpellAttkModNum.Value}\n\n");
                    sw.Write("Spell List\n");
                    if (ClassLabel.Text=="Bard")
                    {
                        sw.Write($"Cantrips: \n{BardCantrips.Text}\n{BardCantrips2.Text}\n");
                        sw.Write($"Level 1: \n{BardL1_1.Text}\n{BardL1_2.Text}\n\n");
                    }

                    sw.Write($"Other Information\n {otherInfoLbl.Text}");
                    sw.Dispose();
                }
            }
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            if (SpellAttkModNum.Value > 10)
            {
                SpellAttkModNum.Value = 10;
            }
        }

        private void SpellSaveDCNum_ValueChanged(object sender, EventArgs e)
        {
            if (SpellSaveDCNum.Value > 20)
            {
                SpellSaveDCNum.Value = 20;
            }
        }
    }
}
