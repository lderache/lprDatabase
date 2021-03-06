﻿using System;
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

                lbNav.Text = (file_index + 1) + " / " + files.Count();
                lbFileName.Text = files[file_index];
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

            // plate rectangle data
            tbpTop.Text = db.plate.Top.ToString();
            tbpLeft.Text = db.plate.Left.ToString();
            tbpRight.Text = db.plate.Right.ToString();
            tbpBottom.Text = db.plate.Bottom.ToString();


            double plRatio = (double)db.plate.Width / db.plate.Height;
            lbRatio.Text = (plRatio).ToString();

            if (cbPlateShow.Checked)
            {
                if (plRatio < 2 || plRatio > 8)
                {
                    drawPlateRectangle(new Bgr(0, 0, 255));
                }
                else
                {
                    drawPlateRectangle(new Bgr(0, 255, 0));
                }
            }

            lbHeight.Text = db.plate.Height.ToString();


            for (int c = 0; c < db.characters.Count(); c++)
            {
                fillDvg(db.characters[c], c);
            }

            //db = null;

            current_image.ROI = new Rectangle(0, 0, 640, 480);
        }


        private bool isPlateDataOk()
        {
            if (tbpTop.Text.Equals("")
                || tbpRight.Text.Equals("")
                || tbpLeft.Text.Equals("")
                || tbpBottom.Text.Equals(""))
                return false;

            return true;
            
        }

        private Rectangle getPlateRectangle()
        {
            if (isPlateDataOk())
            {
                int x = int.Parse(tbpLeft.Text);
                int y = int.Parse(tbpTop.Text);
                int width = int.Parse(tbpRight.Text) - int.Parse(tbpLeft.Text);
                int height = int.Parse(tbpBottom.Text) - int.Parse(tbpTop.Text);

                return new Rectangle(x, y, width, height);
            }

            return new Rectangle();
        }

        private void drawPlateRectangle(Bgr color)
        {
            current_image.Draw(getPlateRectangle(), color, 2);      
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
        
        /// <summary>
        /// Display the rectangle around the license plate
        /// </summary>
        /// <param name="r"></param>
        /*private void showRectangle(Rectangle r)
        {
            current_image.Draw(r, new Bgr(0, 0, 255), 2);
        }*/

        /// <summary>
        /// Navigate to next image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btNext_Click(object sender, EventArgs e)
        {
            db.plate = getPlateRectangle();

            // Save first
            if (files != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                //Thread.Sleep(100);
                string file = files[file_index].Split('.')[0] + ".data";
                db.saveFile(file);
                Cursor.Current = Cursors.Default;

                //db = null;
                //db = new DbParser();
            }

            file_index++;
            displayImage();
            checkButtonState();

            lbNav.Text = (file_index + 1) + " / " + files.Count();

            lbFileName.Text = files[file_index];

            // Force for Mono...
            dataGridView1_CellMouseClick(null, null);
           
        }

        /// <summary>
        /// Navigate to previous image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPrev_Click(object sender, EventArgs e)
        {
            db.plate = getPlateRectangle();


            // save first
            if (files != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Thread.Sleep(100);
                string file = files[file_index].Split('.')[0] + ".data";
                db.saveFile(file);
                Cursor.Current = Cursors.Default;

                //db = null;
                //db = new DbParser();

            }
            
            file_index--;
            displayImage();
            checkButtonState();

            lbNav.Text = (file_index + 1) + " / " + files.Count();
            lbFileName.Text = files[file_index];

            // Force for Mono...
            dataGridView1_CellMouseClick(null, null);
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
            int dvCount = dataGridView1.Rows.Count;

            // just set the count to zero to clear the dgv 
            // (iterating through the rows raise exception under mono
            // system.invalidoperationexception list has changed)
            dataGridView1.RowCount = 0;
           
        }

        /// <summary>
        /// Show mouse point coordinate when moving hover the picture (adjusted to zoom value)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (e == null)
                {
                    if (dataGridView1.Rows.Count > 0) // only if the dgv contains data
                    {
                        selected_idx = 0;
                        drawCharRectangle();
                    }
                }
                else
                {
                    selected_idx = e.RowIndex;
                    if (selected_idx != -1)
                        drawCharRectangle();
                }
            }
        }

        /// <summary>
        /// Draw character rectangle on the picture
        /// </summary>
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

        /// <summary>
        /// Pop up the context menu when right click happends on DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Generic method to add row before/after in the DataGrid
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="idxOri"></param>
        /// <param name="isBefore"></param>
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

        /// <summary>
        /// Add before event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addRowBefore(object sender, EventArgs e)
        {
            int dgvCount = dataGridView1.Rows.Count;
            for (int i = 0; i < dgvCount; i++)
            {
                DataGridViewRow r = dataGridView1.Rows[i];
                if (r.Selected)
                {
                    Console.WriteLine("insert new row at index: " + r.Index);

                    // force unselect to avoid infinite loop
                    r.Selected = false;

                    int idx = r.Index; // insert after

                    addRowAtIndex(r.Index, r.Index, true);
                }
            }

            /*
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
             */
        }

        /// <summary>
        /// Add after event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addRowAfter(object sender, EventArgs e)
        {
            int dgvCount = dataGridView1.Rows.Count;
            for (int i = 0; i < dgvCount; i++)
            {
                DataGridViewRow r = dataGridView1.Rows[i];
                if (r.Selected)
                {
                    Console.WriteLine("insert new row at index: " + r.Index);

                    // force unselect to avoid infinite loop
                    r.Selected = false;

                    int idx = r.Index + 1; // insert after

                    addRowAtIndex(r.Index + 1, r.Index, false);
                }
            }

            /* Bug on Mono
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
             */
        }

        /// <summary>
        /// Delete row event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteSelectedRow(object sender, EventArgs e)
        {
            int dgvCount = dataGridView1.Rows.Count;
            for (int i = 0; i < dgvCount; i++)
            {
                DataGridViewRow r = dataGridView1.Rows[i];
                if (r.Selected)
                {
                    int index = r.Index;
                    dataGridView1.Rows.Remove(r);
                    Console.WriteLine("delete row index: " + index);
                    dataGridView1.Refresh();

                    // Also delete associated character 
                    Character rec = db.characters.ElementAt(index);
                    db.characters.Remove(rec);
                    return;

                }
            }
            /*
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
             */
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        /// <summary>
        /// Save picture event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// End edit on DataGrid event handler. Will update the data in memory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        
        /// <summary>
        /// Make the rectangle larger on the character and change coordinates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Make the rectangle smaller on the character and change coordinates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Make the rectangle move left change coordinates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Make the rectangle move right change coordinates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void btDelete_Click(object sender, EventArgs e)
        {
            // Save file info first
            int sav_index = file_index;
            string data_file = files[sav_index].Split('.')[0] + ".data";
            string jpeg_file = files[sav_index];

            // Go to next
            //btNext_Click(null,null);

            File.Delete(jpeg_file);
            File.Delete(data_file);

            // dirty array list. Should i use list from begining, probably...
            var files_list = new List<string>(files);
            files_list.RemoveAt(sav_index);
            files = files_list.ToArray();

            displayImage();

            lbNav.Text = (file_index + 1) + " / " + files.Count();
            lbFileName.Text = files[file_index];

        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            db.plate = getPlateRectangle();

            // Save first
            if (files != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Thread.Sleep(100);
                string file = files[file_index].Split('.')[0] + ".data";
                db.saveFile(file);
                Cursor.Current = Cursors.Default;

            }

            displayImage();
        }

        private void tbpTop_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    r.Cells[1].Value = (int)r.Cells[1].Value - 1;
                    r.Cells[4].Value = (int)r.Cells[4].Value - 1;

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

        private void label2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    r.Cells[1].Value = (int)r.Cells[1].Value + 1;
                    r.Cells[4].Value = (int)r.Cells[4].Value + 1;

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
