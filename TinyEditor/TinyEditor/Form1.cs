using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Variante 1) FileStream

            //FileStream stream = new FileStream("demo.txt", FileMode.Open);
            //byte[] data = new byte[stream.Length];
            //for (int i = 0; i < stream.Length; i++)
            //{
            //    data[i] = (byte)stream.ReadByte();
            //}
            //stream.Close();

            //textBoxEingabe.Text = Encoding.Default.GetString(data);

            // Variante 2) StreamReader
            //StreamReader sr = new StreamReader("demo2.txt");
            //textBoxEingabe.Text = sr.ReadToEnd();
            //sr.Close();

            // Variante 3) File
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Textdokument|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
                textBoxEingabe.Text = File.ReadAllText(dlg.FileName);
        }

        private void SpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Variante 1) FileStream

            //FileStream stream = new FileStream("demo.txt", FileMode.Create);
            //byte[] data =  Encoding.Default.GetBytes(textBoxEingabe.Text);
            //stream.Write(data, 0, data.Length);

            //stream.Flush();
            //stream.Close();

            //MessageBox.Show("Die Datei wurde erfolgreich gespeichert");

            // Variante 2) StreamWriter
            //StreamWriter sw = new StreamWriter("demo2.txt");
            //sw.Write(textBoxEingabe.Text);
            //sw.Flush();
            //sw.Close();

            //MessageBox.Show("Die Datei wurde erfolgreich gespeichert");

            // Variante 3) File
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Textdokument|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dlg.FileName, textBoxEingabe.Text);
                MessageBox.Show("Die Datei wurde erfolgreich gespeichert");
            }
        }

        private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
