namespace LprDatabase
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbRight = new System.Windows.Forms.Label();
            this.lbLeft = new System.Windows.Forms.Label();
            this.lbMinus = new System.Windows.Forms.Label();
            this.lbPlus = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dvColImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.dvTop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvBottom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvCharValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbMouse = new System.Windows.Forms.Label();
            this.btNext = new System.Windows.Forms.Button();
            this.btPrev = new System.Windows.Forms.Button();
            this.btOpen = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lbNav = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbNav);
            this.splitContainer1.Panel2.Controls.Add(this.imageBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1239, 628);
            this.splitContainer1.SplitterDistance = 411;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbRight);
            this.splitContainer2.Panel1.Controls.Add(this.lbLeft);
            this.splitContainer2.Panel1.Controls.Add(this.lbMinus);
            this.splitContainer2.Panel1.Controls.Add(this.lbPlus);
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbMouse);
            this.splitContainer2.Panel2.Controls.Add(this.btNext);
            this.splitContainer2.Panel2.Controls.Add(this.btPrev);
            this.splitContainer2.Panel2.Controls.Add(this.btOpen);
            this.splitContainer2.Size = new System.Drawing.Size(411, 628);
            this.splitContainer2.SplitterDistance = 448;
            this.splitContainer2.TabIndex = 0;
            // 
            // lbRight
            // 
            this.lbRight.AutoSize = true;
            this.lbRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight.Location = new System.Drawing.Point(282, 378);
            this.lbRight.Name = "lbRight";
            this.lbRight.Size = new System.Drawing.Size(38, 39);
            this.lbRight.TabIndex = 7;
            this.lbRight.Text = ">";
            this.lbRight.Click += new System.EventHandler(this.lbRight_Click);
            // 
            // lbLeft
            // 
            this.lbLeft.AutoSize = true;
            this.lbLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft.Location = new System.Drawing.Point(238, 378);
            this.lbLeft.Name = "lbLeft";
            this.lbLeft.Size = new System.Drawing.Size(38, 39);
            this.lbLeft.TabIndex = 6;
            this.lbLeft.Text = "<";
            this.lbLeft.Click += new System.EventHandler(this.lbLeft_Click);
            // 
            // lbMinus
            // 
            this.lbMinus.AutoSize = true;
            this.lbMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinus.Location = new System.Drawing.Point(148, 375);
            this.lbMinus.Name = "lbMinus";
            this.lbMinus.Size = new System.Drawing.Size(30, 39);
            this.lbMinus.TabIndex = 5;
            this.lbMinus.Text = "-";
            this.lbMinus.Click += new System.EventHandler(this.lbMinus_Click);
            // 
            // lbPlus
            // 
            this.lbPlus.AutoSize = true;
            this.lbPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlus.Location = new System.Drawing.Point(93, 378);
            this.lbPlus.Name = "lbPlus";
            this.lbPlus.Size = new System.Drawing.Size(38, 39);
            this.lbPlus.TabIndex = 4;
            this.lbPlus.Text = "+";
            this.lbPlus.Click += new System.EventHandler(this.lbPlus_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dvColImage,
            this.dvTop,
            this.dvLeft,
            this.dvRight,
            this.dvBottom,
            this.dvCharValue});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(406, 339);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // dvColImage
            // 
            this.dvColImage.HeaderText = "Image";
            this.dvColImage.Name = "dvColImage";
            this.dvColImage.ReadOnly = true;
            this.dvColImage.Width = 50;
            // 
            // dvTop
            // 
            this.dvTop.HeaderText = "Top";
            this.dvTop.Name = "dvTop";
            this.dvTop.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dvTop.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dvTop.Width = 50;
            // 
            // dvLeft
            // 
            this.dvLeft.HeaderText = "Left";
            this.dvLeft.Name = "dvLeft";
            this.dvLeft.Width = 50;
            // 
            // dvRight
            // 
            this.dvRight.HeaderText = "Right";
            this.dvRight.Name = "dvRight";
            this.dvRight.Width = 50;
            // 
            // dvBottom
            // 
            this.dvBottom.HeaderText = "Bottom";
            this.dvBottom.Name = "dvBottom";
            this.dvBottom.Width = 50;
            // 
            // dvCharValue
            // 
            this.dvCharValue.HeaderText = "Char value";
            this.dvCharValue.Name = "dvCharValue";
            this.dvCharValue.Width = 50;
            // 
            // lbMouse
            // 
            this.lbMouse.AutoSize = true;
            this.lbMouse.Location = new System.Drawing.Point(3, 153);
            this.lbMouse.Name = "lbMouse";
            this.lbMouse.Size = new System.Drawing.Size(44, 13);
            this.lbMouse.TabIndex = 0;
            this.lbMouse.Text = "Position";
            // 
            // btNext
            // 
            this.btNext.BackColor = System.Drawing.Color.AliceBlue;
            this.btNext.Location = new System.Drawing.Point(220, 86);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(88, 32);
            this.btNext.TabIndex = 2;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = false;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btPrev
            // 
            this.btPrev.BackColor = System.Drawing.Color.AliceBlue;
            this.btPrev.Location = new System.Drawing.Point(85, 85);
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(93, 33);
            this.btPrev.TabIndex = 1;
            this.btPrev.Text = "Prev.";
            this.btPrev.UseVisualStyleBackColor = false;
            this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(3, 3);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(403, 54);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "Choose dir.";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox1.Location = new System.Drawing.Point(0, 0);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(822, 626);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            this.imageBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseMove);
            // 
            // lbNav
            // 
            this.lbNav.AutoSize = true;
            this.lbNav.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNav.Location = new System.Drawing.Point(302, 581);
            this.lbNav.Name = "lbNav";
            this.lbNav.Size = new System.Drawing.Size(223, 37);
            this.lbNav.TabIndex = 3;
            this.lbNav.Text = "Current / Total";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 628);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LPR Database Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btOpen;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btPrev;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lbMouse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn dvColImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvBottom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvCharValue;
        private System.Windows.Forms.Label lbPlus;
        private System.Windows.Forms.Label lbMinus;
        private System.Windows.Forms.Label lbRight;
        private System.Windows.Forms.Label lbLeft;
        private System.Windows.Forms.Label lbNav;
    }
}

