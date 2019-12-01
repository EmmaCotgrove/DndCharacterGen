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
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dndClass = ClassCombo.Text;
            string dndRace = RaceCombo.Text;

            if (dndClass=="Fighter" || dndClass=="Monk" || dndClass =="Rogue" || dndClass == "Barbarian")
            {
                Console.WriteLine("Basic");
                BasicCreateForm basicCharacters = new BasicCreateForm(dndClass, dndRace);
                basicCharacters.Show();
            } else
            {
                Console.WriteLine("Magic caster");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
