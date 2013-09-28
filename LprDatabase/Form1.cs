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
using Emgu.CV;
using Emgu.CV.Structure;
using System.Threading;

namespace LprDatabase
{
    
    public partial class Form1 : Form
    {
        static string[] files;
        static int file_index;
        static Image<Bgr, byte> current_image;
        static DbParser db;
        static int selected_idx;
        
        

        public Form1()
        {
            file_index = 0;
            db = new DbParser();

            InitializeComponent();
            
            setDgvParams();

            selected_idx = -1; // default value

            btNext.Enabled = false;
            btPrev.Enabled = false;

        }

        /// <summary>
        /// 
        /// set different parameters for the DataGrid
        /// 
        /// </summary>
        private void setDgvParams()
        {
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        /// <summary>
        /// Choose directory callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOpen_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = Directory.GetFiles(folderBrowserDialog1.SelectedPath,"*.jpg");
                displayImage();

                btNext.Enabled = true;
                btPrev.Enabled = true;
            }
        }

        /// <summary>
        /// Clear the datagrid and display image when browsing directory
        /// </summary>
        private void displayImage()
        {
            clearDgv();

            current_image = new Image<Bgr, byte>(files[file_index]);

            imageBox1.Image = current_image;
            
            // read data

            string dataFile = files[file_index].Split('.')[0] + ".data";
            db.parseFile(dataFile);

            current_image.Draw(db.plate, new Bgr(0, 0, 255), 2);

            for (int c = 0; c < db.characters.Count(); c++)
            {
                fillDvg(db.characters[c], c);
            }

            current_image.ROI = new Rectangle(0, 0, 640, 480);
        }

        /// <summary>
        /// Fill up the DataGrid with character value (Rectangle for position and char value)
        /// </summary>
        /// <param name="r"></param>
        /// <param name="idx"></param>
        private void fillDvg(Character r, int idx)
        {
            dataGridView1.Rows.Add();

            dataGridView1.Rows[idx].Height = 40;

            current_image.ROI = r.rec;

            // image
            dataGridView1.Rows[idx].Cells[0].Value = current_image.Bitmap;

            dataGridView1.Rows[idx].Cells[1].Value = r.rec.Top;
            dataGridView1.Rows[idx].Cells[2].Value = r.rec.Left;
            dataGridView1.Rows[idx].Cells[3].Value = r.rec.Right;
            dataGridView1.Rows[idx].Cells[4].Value = r.rec.Bottom;
            dataGridView1.Rows[idx].Cells[5].Value = r.val;
            
        }
        
        private void showRectangle(Rectangle r)
        {
            current_image.Draw(r, new Bgr(0, 0, 255), 2);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            
            file_index++;
            displayImage();
            checkButtonState();
           
        }

        private void btPrev_Click(object sender, EventArgs e)
        {
            file_index--;
            displayImage();
            checkButtonState();
        }

        /// <summary>
        /// Enable / Disable navigation buttons (Prev, Next)
        /// </summary>
        private void checkButtonState()
        {
            if (file_index == 0)
            {
                btPrev.Enabled = false;
            }
            else
            {
                btPrev.Enabled = true;
            }

            if (file_index == (files.Count() - 1))
            {
                btNext.Enabled = false;
            }
            else
            {
                btNext.Enabled = true;
            }

        }


        /// <summary>
        /// Clear the dataGrid
        /// </summary>
        private void clearDgv()
        {
            do
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                    catch (Exception) { }
                }
            } while (dataGridView1.Rows.Count > 0);
        }


        private void imageBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (current_image != null)
            {
                int offsetX = (int)(e.Location.X / imageBox1.ZoomScale);
                int offsetY = (int)(e.Location.Y / imageBox1.ZoomScale);
                int horizontalScrollBarValue = imageBox1.HorizontalScrollBar.Visible ? (int)imageBox1.HorizontalScrollBar.Value : 0;
                int verticalScrollBarValue = imageBox1.VerticalScrollBar.Visible ? (int)imageBox1.VerticalScrollBar.Value : 0;
                lbMouse.Text = "X: " + 
                    Convert.ToString(offsetX + horizontalScrollBarValue) + 
                    " Y: " + Convert.ToString(offsetY + verticalScrollBarValue);
            }
        }

        

        /// <summary>
        /// DataGrid cell mouse click event handler, draw character rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (current_image != null)
            {
                selected_idx = e.RowIndex;
                if(selected_idx != -1)
                    drawCharRectangle();
            }
        }

        private void drawCharRectangle()
        {
            Rectangle r = db.characters[selected_idx].rec;
            Image<Bgr,byte> img =  current_image.Copy();
            
            img.Draw(r, new Bgr(51, 255, 204), 2);
            imageBox1.Image = img;
        }


        private void selectOnlyOneRowDgv(int row)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Index == row)
                    r.Selected = true;
                else
                    r.Selected = false;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {   
            if (e.Button == MouseButtons.Right && dataGridView1.Rows.Count > 0)
            {
                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                // select the row where click happens
                selectOnlyOneRowDgv(currentMouseOverRow);

                ContextMenu m = new ContextMenu();   
                m.MenuItems.Add("Delete",new EventHandler(deleteSelectedRow));
                m.MenuItems.Add("Add before", new EventHandler(addRowBefore));
                m.MenuItems.Add("Add after", new EventHandler(addRowAfter));
                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void addRowAtIndex(int idx, int idxOri, bool isBefore)
        {
            // Compute new char parameters
            int top = db.characters[idxOri].rec.Top; // same as previous one
            int bottom = db.characters[idxOri].rec.Bottom; // idem

            // Put the new rectangle with same heigh, width as previous one
            int height = db.characters[idxOri].rec.Bottom - db.characters[idxOri].rec.Top;
            int width = db.characters[idxOri].rec.Right - db.characters[idxOri].rec.Left;

            int left=0, right=0;

            if (isBefore)
            {
                // right and left move to the right from width pixels
                left = db.characters[idxOri].rec.Left - width;
                right = db.characters[idxOri].rec.Right - width;
            }
            else
            {
                // right and left move to the right from width pixels
                left = db.characters[idxOri].rec.Left + width;
                right = db.characters[idxOri].rec.Right + width;
            }

            int x = left;
            int y = top;


            Character c = new Character();
            Rectangle rec = new Rectangle(
                x,
                y,
                width,
                height);

            c.rec = rec;
            c.val = 'U';

            current_image.ROI = c.rec;
            dataGridView1.Rows.Insert(idx, current_image.Bitmap, top, left, right, bottom, "0");
            current_image.ROI = new Rectangle(0, 0, 640, 480);

            db.characters.Insert(idx, c);
            dataGridView1.Refresh();
        }

        private void addRowBefore(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    Console.WriteLine("insert new row at index: " + r.Index);

                    // force unselect to avoid infinite loop
                    r.Selected = false;

                    int idx = r.Index; // insert after

                    addRowAtIndex(r.Index, r.Index, true);
                    
                }
            }
        }

        private void addRowAfter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    Console.WriteLine("insert new row at index: " + r.Index);
                    
                    // force unselect to avoid infinite loop
                    r.Selected = false;

                    int idx = r.Index + 1; // insert after

                    addRowAtIndex(r.Index + 1, r.Index, false);
                }
            }
        }

        private void deleteSelectedRow(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    int index = r.Index;
                    dataGridView1.Rows.Remove(r);
                    Console.WriteLine("delete row index: " + index);
                    dataGridView1.Refresh();

                    // Also delete associated character 
                    Character rec = db.characters.ElementAt(index);
                    db.characters.Remove(rec);
                    
                }
            }
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (files != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Thread.Sleep(300);
                string file = files[file_index].Split('.')[0] + ".data";
                db.saveFile(file);
                Cursor.Current = Cursors.Default;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                int x = int.Parse(r.Cells[2].Value.ToString());
                int y = int.Parse(r.Cells[1].Value.ToString());

                int width = int.Parse(r.Cells[3].Value.ToString()) - int.Parse(r.Cells[2].Value.ToString());
                int height = int.Parse(r.Cells[4].Value.ToString()) - int.Parse(r.Cells[1].Value.ToString());

                db.characters[r.Index].val =  char.Parse(r.Cells[5].Value.ToString());
                db.characters[r.Index].rec = new Rectangle(
                    x,y,width,height);

            }
        }

        private DataGridViewRow getSelectedRow()
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    return r;
                }
            }

            return null;
        }

        private void lbPlus_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    r.Cells[2].Value = (int)r.Cells[2].Value - 1;
                    r.Cells[3].Value = (int)r.Cells[3].Value + 1;

                    int x = int.Parse(r.Cells[2].Value.ToString());
                    int y = int.Parse(r.Cells[1].Value.ToString());

                    int width = int.Parse(r.Cells[3].Value.ToString()) - int.Parse(r.Cells[2].Value.ToString());
                    int height = int.Parse(r.Cells[4].Value.ToString()) - int.Parse(r.Cells[1].Value.ToString());

                    //width += 10;
                    db.characters[r.Index].val = char.Parse(r.Cells[5].Value.ToString());
                    db.characters[r.Index].rec = new Rectangle(
                        x, y, width, height);

                    // redraw the rectangle
                    drawCharRectangle();
                }

            }
        }

        private void lbMinus_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    r.Cells[2].Value = (int)r.Cells[2].Value + 1;
                    r.Cells[3].Value = (int)r.Cells[3].Value - 1;

                    int x = int.Parse(r.Cells[2].Value.ToString());
                    int y = int.Parse(r.Cells[1].Value.ToString());

                    int width = int.Parse(r.Cells[3].Value.ToString()) - int.Parse(r.Cells[2].Value.ToString());
                    int height = int.Parse(r.Cells[4].Value.ToString()) - int.Parse(r.Cells[1].Value.ToString());

                    //width += 10;
                    db.characters[r.Index].val = char.Parse(r.Cells[5].Value.ToString());
                    db.characters[r.Index].rec = new Rectangle(
                        x, y, width, height);

                    // redraw the rectangle
                    drawCharRectangle();
                }

            }
        }

        private void lbLeft_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    r.Cells[2].Value = (int)r.Cells[2].Value - 1;
                    r.Cells[3].Value = (int)r.Cells[3].Value - 1;

                    int x = int.Parse(r.Cells[2].Value.ToString());
                    int y = int.Parse(r.Cells[1].Value.ToString());

                    int width = int.Parse(r.Cells[3].Value.ToString()) - int.Parse(r.Cells[2].Value.ToString());
                    int height = int.Parse(r.Cells[4].Value.ToString()) - int.Parse(r.Cells[1].Value.ToString());

                    //width += 10;
                    db.characters[r.Index].val = char.Parse(r.Cells[5].Value.ToString());
                    db.characters[r.Index].rec = new Rectangle(
                        x, y, width, height);

                    // redraw the rectangle
                    drawCharRectangle();
                }

            }
        }

        private void lbRight_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    r.Cells[2].Value = (int)r.Cells[2].Value + 1;
                    r.Cells[3].Value = (int)r.Cells[3].Value + 1;

                    int x = int.Parse(r.Cells[2].Value.ToString());
                    int y = int.Parse(r.Cells[1].Value.ToString());

                    int width = int.Parse(r.Cells[3].Value.ToString()) - int.Parse(r.Cells[2].Value.ToString());
                    int height = int.Parse(r.Cells[4].Value.ToString()) - int.Parse(r.Cells[1].Value.ToString());

                    //width += 10;
                    db.characters[r.Index].val = char.Parse(r.Cells[5].Value.ToString());
                    db.characters[r.Index].rec = new Rectangle(
                        x, y, width, height);

                    // redraw the rectangle
                    drawCharRectangle();
                }

            }
             
        }

        
    }
}
