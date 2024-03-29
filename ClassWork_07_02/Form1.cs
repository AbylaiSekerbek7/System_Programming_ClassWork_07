using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassWork_07_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Сбор вдохного файла";
            dlg.Filter = "Файлы текста (*.txt)|*.txt|" +
                         "Файлы word (*.doc)|*.doc;*.docx" +
                         "Все файлы (*,*)|*.*";
            dlg.FilterIndex = 0;
            dlg.Multiselect = false;
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                txtInput.Text = dlg.FileName;
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Файл для сохранение";
            dlg.Filter = "Файлы текста (*.txt)|*.txt|" +
                     "Файлы word (*.doc)|*.doc;*.docx" +
                     "Все файлы (*,*)|*.*";
            dlg.FilterIndex = 0;
            dlg.CheckPathExists = true;
            dlg.OverwritePrompt = true;

        }
    }
}
