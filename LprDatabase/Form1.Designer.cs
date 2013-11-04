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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpBottom = new System.Windows.Forms.TextBox();
            this.tbpRight = new System.Windows.Forms.TextBox();
            this.tbpLeft = new System.Windows.Forms.TextBox();
            this.tbpTop = new System.Windows.Forms.TextBox();
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
            this.btRefresh = new System.Windows.Forms.Button();
            this.lbMouse = new System.Windows.Forms.Label();
            this.btNext = new System.Windows.Forms.Button();
            this.btPrev = new System.Windows.Forms.Button();
            this.btOpen = new System.Windows.Forms.Button();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbRatio = new System.Windows.Forms.Label();
            this.lbFileName = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.lbNav = new System.Windows.Forms.Label();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbPlateShow = new System.Windows.Forms.CheckBox();
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
            this.splitContainer1.Panel2.Controls.Add(this.lbHeight);
            this.splitContainer1.Panel2.Controls.Add(this.lbRatio);
            this.splitContainer1.Panel2.Controls.Add(this.lbFileName);
            this.splitContainer1.Panel2.Controls.Add(this.btDelete);
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
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.tbpBottom);
            this.splitContainer2.Panel1.Controls.Add(this.tbpRight);
            this.splitContainer2.Panel1.Controls.Add(this.tbpLeft);
            this.splitContainer2.Panel1.Controls.Add(this.tbpTop);
            this.splitContainer2.Panel1.Controls.Add(this.lbRight);
            this.splitContainer2.Panel1.Controls.Add(this.lbLeft);
            this.splitContainer2.Panel1.Controls.Add(this.lbMinus);
            this.splitContainer2.Panel1.Controls.Add(this.lbPlus);
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cbPlateShow);
            this.splitContainer2.Panel2.Controls.Add(this.btRefresh);
            this.splitContainer2.Panel2.Controls.Add(this.lbMouse);
            this.splitContainer2.Panel2.Controls.Add(this.btNext);
            this.splitContainer2.Panel2.Controls.Add(this.btPrev);
            this.splitContainer2.Panel2.Controls.Add(this.btOpen);
            this.splitContainer2.Size = new System.Drawing.Size(411, 628);
            this.splitContainer2.SplitterDistance = 448;
            this.splitContainer2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 33);
            this.label2.TabIndex = 13;
            this.label2.Text = "Do";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 33);
            this.label1.TabIndex = 12;
            this.label1.Text = "Up";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbpBottom
            // 
            this.tbpBottom.Location = new System.Drawing.Point(174, 355);
            this.tbpBottom.Name = "tbpBottom";
            this.tbpBottom.Size = new System.Drawing.Size(32, 20);
            this.tbpBottom.TabIndex = 11;
            // 
            // tbpRight
            // 
            this.tbpRight.Location = new System.Drawing.Point(122, 355);
            this.tbpRight.Name = "tbpRight";
            this.tbpRight.Size = new System.Drawing.Size(32, 20);
            this.tbpRight.TabIndex = 10;
            // 
            // tbpLeft
            // 
            this.tbpLeft.Location = new System.Drawing.Point(71, 355);
            this.tbpLeft.Name = "tbpLeft";
            this.tbpLeft.Size = new System.Drawing.Size(32, 20);
            this.tbpLeft.TabIndex = 9;
            // 
            // tbpTop
            // 
            this.tbpTop.Location = new System.Drawing.Point(15, 355);
            this.tbpTop.Name = "tbpTop";
            this.tbpTop.Size = new System.Drawing.Size(32, 20);
            this.tbpTop.TabIndex = 8;
            this.tbpTop.TextChanged += new System.EventHandler(this.tbpTop_TextChanged);
            // 
            // lbRight
            // 
            this.lbRight.AutoSize = true;
            this.lbRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight.Location = new System.Drawing.Point(351, 370);
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
            this.lbLeft.Location = new System.Drawing.Point(231, 370);
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
            this.lbMinus.Location = new System.Drawing.Point(120, 395);
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
            this.lbPlus.Location = new System.Drawing.Point(65, 398);
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
            // btRefresh
            // 
            this.btRefresh.BackColor = System.Drawing.Color.AliceBlue;
            this.btRefresh.Location = new System.Drawing.Point(85, 139);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(223, 32);
            this.btRefresh.TabIndex = 3;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
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
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeight.Location = new System.Drawing.Point(18, 516);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(56, 20);
            this.lbHeight.TabIndex = 6;
            this.lbHeight.Text = "Height";
            // 
            // lbRatio
            // 
            this.lbRatio.AutoSize = true;
            this.lbRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRatio.Location = new System.Drawing.Point(18, 550);
            this.lbRatio.Name = "lbRatio";
            this.lbRatio.Size = new System.Drawing.Size(47, 20);
            this.lbRatio.TabIndex = 5;
            this.lbRatio.Text = "Ratio";
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFileName.Location = new System.Drawing.Point(432, 594);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(74, 20);
            this.lbFileName.TabIndex = 4;
            this.lbFileName.Text = "Filename";
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(13, 581);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(139, 34);
            this.btDelete.TabIndex = 3;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // lbNav
            // 
            this.lbNav.AutoSize = true;
            this.lbNav.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNav.Location = new System.Drawing.Point(172, 581);
            this.lbNav.Name = "lbNav";
            this.lbNav.Size = new System.Drawing.Size(223, 37);
            this.lbNav.TabIndex = 3;
            this.lbNav.Text = "Current / Total";
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
            // cbPlateShow
            // 
            this.cbPlateShow.AutoSize = true;
            this.cbPlateShow.Checked = true;
            this.cbPlateShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPlateShow.Location = new System.Drawing.Point(330, 148);
            this.cbPlateShow.Name = "cbPlateShow";
            this.cbPlateShow.Size = new System.Drawing.Size(50, 17);
            this.cbPlateShow.TabIndex = 4;
            this.cbPlateShow.Text = "Plate";
            this.cbPlateShow.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.Label lbRatio;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.TextBox tbpBottom;
        private System.Windows.Forms.TextBox tbpRight;
        private System.Windows.Forms.TextBox tbpLeft;
        private System.Windows.Forms.TextBox tbpTop;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbPlateShow;
    }
}

