using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NoteProject
{
    public partial class Form1 : Form
    {
        string path;
        public Form1()
        {
            path = null;
            InitializeComponent();
            
        }
       

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open= new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK) 
            { 
                richTB.LoadFile(open.FileName);
                path= open.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == null)
            {
                saveAsToolStripMenuItem_Click(null, null);

            }
            else
            {
                richTB.SaveFile(path);
                richTB.Clear();
                path = null;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFd.ShowDialog() == DialogResult.OK)
            {
                richTB.SaveFile(SaveFd.FileName);
                path= SaveFd.FileName;
                richTB.Clear();
         
            }
   
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit","Exit" ,MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }

        }
        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTB.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTB.Redo();

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTB.Cut();

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTB.Copy();

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTB.Paste();

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTB.SelectAll();

        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTB.SelectedText != "")
                    richTB.SelectionBackColor = colorDialog1.Color;
                else
                    richTB.BackColor= colorDialog1.Color;   
            }
        }

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTB.SelectedText != "")
                    richTB.SelectionColor = colorDialog1.Color;
                else
                    richTB.ForeColor= colorDialog1.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                if(richTB.SelectedText!= "")
                {
                   richTB.SelectionFont = fontDialog1.Font;
                }
                else
                {
                    richTB.Font = fontDialog1.Font;
                }
                
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = richTB.Font.Size;
            currentSize += 2.0F;
            richTB.Font = new Font(richTB.Font.Name, currentSize, richTB.Font.Style, richTB.Font.Unit);
        }
        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = richTB.Font.Size;
            currentSize -= 2.0F;
            richTB.Font = new Font(richTB.Font.Name, currentSize, richTB.Font.Style, richTB.Font.Unit);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTB.SelectedText != "")
            {
                richTB.SelectedText = "";
            }
            else
            {
                richTB.Clear();
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new Form2();
            aboutForm.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == null)
            {
                if(MessageBox.Show("you want to save first", "Save As", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(null, null);

                }
            }
            else
            {
                if(MessageBox.Show("you want to save first", "Save and Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                    path = null;
                }
            }
           

            
        }
    }
}