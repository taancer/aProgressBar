using System;
using System.Drawing;
using System.Windows.Forms;

namespace aProgressBar_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            aProgressBarTest.Value = Convert.ToInt32(numericUpDown1.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            aProgressBarTest.Text = textBox1.Text;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            aProgressBarTest.TextMargin = new Point( Convert.ToInt32(numericUpDown2.Value)
                                                   , Convert.ToInt32(numericUpDown2.Value)
                                                   );
        }
    }
}
