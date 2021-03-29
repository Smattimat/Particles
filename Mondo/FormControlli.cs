using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mondo {
    public partial class FormControlli : Form {
        public Dati datiMondo { get; init; }
        private Timer watchDog;
        public FormControlli() {
            InitializeComponent();
        }
        private void FormControlli_Load(object sender, EventArgs e) {
            watchDog = new Timer();
            watchDog.Interval = 1500;
            watchDog.Tick += WatchDog_Tick;
            watchDog.Start();
        }
        private void WatchDog_Tick(object sender, EventArgs e) {
            if (datiMondo.programmaAttivo == false) Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show("Test", "Avviso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        }


    }
}
