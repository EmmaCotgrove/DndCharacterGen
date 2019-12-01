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
    public partial class BasicCreateForm : Form
    {
        public BasicCreateForm(string dndClass, string dndRace)
        {
            InitializeComponent();
            ClassLabel.Text = dndClass;
            RaceLabel.Text = dndRace;
            if (dndClass == "Fighter")
            {
                StrLabel.Text = "Add 1 to Str";
                HitDiceBox.Text = "1d10";
                ACLabel.Text = "Defense Fighting Style ONLY: +1 Bonus whilst wearing Armor";
                otherInfoLbl.Text = "Level 1: Second Wind: Bonus action to gain 1d10 HP back. Used once. Recharge on short/long rest";

            } else if (dndClass == "Rogue")
            {
                HitDiceBox.Text = "1d8";
                otherInfoLbl.Text = "Level 1: Expertise: choose either two skill proficiencies or one of the skill" +
                    " proficiencies and and your proficiency with thieves tools. Your proficiency bonus " +
                    "is doubled for any ability check with these." +
                    "\n Level 1: Sneak attack: Once per turn can deal extra 1d6 damage to one creature on an attack roll if " +
                    "you have advantage on the attack roll.";
            } else if (dndClass == "Monk")
            {
                HitDiceBox.Text = "1d8";
                otherInfoLbl.Text = "Level 1: Martial Arts: Can use Dex instead of Str for attacking." +
                    "\nWhen you use attack action with unarmed strike or a monk weapon" +
                    " you can make one unarmed attack as a bonus action." +
                    "\nCan roll 1d4 in place of normal damage.";
                ACLabel.Text = "If no armor or shield: AC is 10+Dex+Wis";
            } else if (dndClass == "Barbarian")
            {
                HitDiceBox.Text = "1d12";
                ACLabel.Text = "If no armor or shield: Ac is 10+Dex+Cons";
                otherInfoLbl.Text = "Level 1: Rage: You can enter a rage as a bonus action. " +
                    "Whilst raging you have advantage on STR saving throws and STR checks. Resistance to " +
                    "bludgeoning, piercing and slashing damage. When you attack with STR you gain bonus to " +
                    "damage roll as per barbarian table.";
            }
            

        }

        private void BasicCreateForm_Load(object sender, EventArgs e)
        {

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
            label.Text = ("+"+modifier.ToString());
        }

        private void strMod_Click(object sender, EventArgs e)
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
    }
}
