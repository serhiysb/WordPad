using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5.WordPad
{
    public partial class Form1 : Form
    {
        private void ChangeLanguage(string language)
        {
            foreach (Control item in this.Controls)
            {
                ComponentResourceManager manager = new ComponentResourceManager(typeof(Form1));
                manager.ApplyResources(item, item.Name, new System.Globalization.CultureInfo(language));
            }
        }
        private string style = "Regular";
        public Form1()
        {
            InitializeComponent();

            richTextBox1.AllowDrop = true;
            richTextBox1.DragDrop += RichTextBox1_DragDrop;
            richTextBox1.DragEnter += RichTextBox1_DragEnter;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("uk-UA");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("uk-UA");

            foreach (var item in FontFamily.Families)
            {
                toolStripComboBox1.Items.Add(item.Name);
            }
            toolStripComboBox1.SelectedItem = "Times New Roman";
            toolStripComboBox2.SelectedItem = "12";
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName);
                }
                catch
                {
                    using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                    {
                        richTextBox1.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold == true)
            {
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Regular);
                style = "Regular";
            }
            else
            {
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Bold);
                style = "Bold";
            }
        }

        private void toolStripButton10_Click_1(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Italic == true)
            {
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Regular);
                style = "Regular";
            }
            else
            {
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Italic);
                style = "Italic";
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Underline == true)
            {
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Regular);
                style = "Regular";
            }
            else
            {
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Underline);
                style = "Underline";
            }
        }

        private void toolStripButton13_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionBackColor = colorDialog1.Color;
        }

        private void зберегтиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName);
                }
                catch
                {
                    using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                    {
                        richTextBox1.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (style == "Regular")
            {
                if (toolStripComboBox1.SelectedIndex != -1 && toolStripComboBox2.SelectedIndex != -1)
                    richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Regular);
            }
            if (style == "Bold")
            {
                if (toolStripComboBox1.SelectedIndex != -1 && toolStripComboBox2.SelectedIndex != -1)
                    richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Bold);
            }
            if (style == "Italic")
            {
                if (toolStripComboBox1.SelectedIndex != -1 && toolStripComboBox2.SelectedIndex != -1)
                    richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Italic);
            }
            if (style == "Underline")
            {
                if (toolStripComboBox1.SelectedIndex != -1 && toolStripComboBox2.SelectedIndex != -1)
                    richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Underline);
            }
        }

        private void toolStripComboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (style == "Regular")
            {
                if (toolStripComboBox1.SelectedIndex != -1 && toolStripComboBox2.SelectedIndex != -1)
                    richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Regular);
            }
            if (style == "Bold")
            {
                if (toolStripComboBox1.SelectedIndex != -1 && toolStripComboBox2.SelectedIndex != -1)
                    richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Bold);
            }
            if (style == "Italic")
            {
                if (toolStripComboBox1.SelectedIndex != -1 && toolStripComboBox2.SelectedIndex != -1)
                    richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Italic);
            }
            if (style == "Underline")
            {
                if (toolStripComboBox1.SelectedIndex != -1 && toolStripComboBox2.SelectedIndex != -1)
                    richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), int.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Underline);
            }
        }

        private void українськаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChangeLanguage("en-US");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("uk-UA");
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var item in file)
            {
                StreamReader reader = new StreamReader(item);
                richTextBox1.Text = reader.ReadToEnd();

            }
        }

        private void RichTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var item in file)
            {
                StreamReader reader = new StreamReader(item);
                richTextBox1.Text = reader.ReadToEnd();

            }
        }

    }
}
