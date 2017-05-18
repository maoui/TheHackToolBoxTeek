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

namespace EexPumpTeek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPump_Click(object sender, EventArgs e)
        {
            try
            {
                if (!System.IO.File.Exists(textBoxPump.Text))
                {
                    textBoxPump.Clear();
                    buttonPump.Enabled = true;
                    MessageBox.Show("The filename is incorrect", "Error filename", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    buttonPump.Enabled = false;

                    var filePump = System.IO.File.OpenWrite(textBoxPump.Text);
                    var sizePump = filePump.Seek(0, SeekOrigin.End);
                    decimal bite = 0;

                    if (radioButtonKo.Checked)
                    {
                        bite = numericUpDownKo.Value * 1048;
                    }
                    else if (radioButtonMo.Checked)
                    {
                        bite = numericUpDownMo.Value * 1048576;
                    }

                    while (sizePump < bite)
                    {
                        sizePump++;
                        filePump.WriteByte(0);
                    }
                    filePump.Close();
                    textBoxPump.Clear();

                    numericUpDownKo.Enabled = false;
                    numericUpDownMo.Enabled = false;
                    radioButtonKo.Checked = false;
                    radioButtonMo.Checked = false;
                    numericUpDownKo.Value = 1;
                    numericUpDownMo.Value = 1;
                    textBoxPump.Enabled = false;
                    buttonBrowsePump.Enabled = false;
                    buttonPump.Enabled = false;

                    MessageBox.Show("Done !", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Failed", "Error", MessageBoxButtons.OK);
            }


        }

        private void buttonBrowsePump_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogPump = new OpenFileDialog();

            openFileDialogPump.DefaultExt = "exe";
            openFileDialogPump.Filter = "exe files (*.exe)|*.exe";
            openFileDialogPump.FilterIndex = 1;

            if (openFileDialogPump.ShowDialog(this) == DialogResult.OK)
            {
                textBoxPump.Text = string.Empty;
                textBoxPump.Text = openFileDialogPump.FileName;
            }
        }

        private void textBoxPump_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonKo_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMo.Enabled = false;
            numericUpDownKo.Enabled = true;
            activePumpKioOrMoi();
        }

        private void activePumpKioOrMoi()
        {
            textBoxPump.Enabled = true;
            buttonBrowsePump.Enabled = true;
        }

        private void radioButtonMo_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownKo.Enabled = false;
            numericUpDownMo.Enabled = true;
            activePumpKioOrMoi();
        }
    }
}
