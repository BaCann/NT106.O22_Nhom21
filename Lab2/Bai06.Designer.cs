namespace LAB2
{
    partial class Bai06
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
            this.buttonRandom = new System.Windows.Forms.Button();
            this.textBoxMon = new System.Windows.Forms.TextBox();
            this.buttonDSMon = new System.Windows.Forms.Button();
            this.buttonNguoi = new System.Windows.Forms.Button();
            this.listViewDSMon = new System.Windows.Forms.ListView();
            this.IDMonAn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenMon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NguoiCungCap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewDSNguoi = new System.Windows.Forms.ListView();
            this.IDNCC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HoVaTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuyenHan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNguoi = new System.Windows.Forms.TextBox();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(448, 217);
            this.buttonRandom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(132, 35);
            this.buttonRandom.TabIndex = 5;
            this.buttonRandom.Text = "Hôm nay ăn gì?";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // textBoxMon
            // 
            this.textBoxMon.Location = new System.Drawing.Point(138, 274);
            this.textBoxMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMon.Name = "textBoxMon";
            this.textBoxMon.Size = new System.Drawing.Size(326, 22);
            this.textBoxMon.TabIndex = 6;
            // 
            // buttonDSMon
            // 
            this.buttonDSMon.Location = new System.Drawing.Point(34, 10);
            this.buttonDSMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDSMon.Name = "buttonDSMon";
            this.buttonDSMon.Size = new System.Drawing.Size(189, 30);
            this.buttonDSMon.TabIndex = 27;
            this.buttonDSMon.Text = "Xem DS Món ăn";
            this.buttonDSMon.UseVisualStyleBackColor = true;
            this.buttonDSMon.Click += new System.EventHandler(this.buttonDSMon_Click);
            // 
            // buttonNguoi
            // 
            this.buttonNguoi.Location = new System.Drawing.Point(569, 10);
            this.buttonNguoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNguoi.Name = "buttonNguoi";
            this.buttonNguoi.Size = new System.Drawing.Size(189, 30);
            this.buttonNguoi.TabIndex = 28;
            this.buttonNguoi.Text = "Xem DS Người cung cấp";
            this.buttonNguoi.UseVisualStyleBackColor = true;
            this.buttonNguoi.Click += new System.EventHandler(this.buttonNguoi_Click);
            // 
            // listViewDSMon
            // 
            this.listViewDSMon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDMonAn,
            this.TenMon,
            this.NguoiCungCap});
            this.listViewDSMon.HideSelection = false;
            this.listViewDSMon.Location = new System.Drawing.Point(34, 44);
            this.listViewDSMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewDSMon.Name = "listViewDSMon";
            this.listViewDSMon.Size = new System.Drawing.Size(430, 159);
            this.listViewDSMon.TabIndex = 29;
            this.listViewDSMon.UseCompatibleStateImageBehavior = false;
            this.listViewDSMon.View = System.Windows.Forms.View.Details;
            // 
            // IDMonAn
            // 
            this.IDMonAn.Text = "ID";
            this.IDMonAn.Width = 90;
            // 
            // TenMon
            // 
            this.TenMon.Text = "Tên món ăn";
            this.TenMon.Width = 160;
            // 
            // NguoiCungCap
            // 
            this.NguoiCungCap.Text = "Người cung cấp";
            this.NguoiCungCap.Width = 128;
            // 
            // listViewDSNguoi
            // 
            this.listViewDSNguoi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDNCC,
            this.HoVaTen,
            this.QuyenHan});
            this.listViewDSNguoi.HideSelection = false;
            this.listViewDSNguoi.Location = new System.Drawing.Point(569, 46);
            this.listViewDSNguoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewDSNguoi.Name = "listViewDSNguoi";
            this.listViewDSNguoi.Size = new System.Drawing.Size(431, 158);
            this.listViewDSNguoi.TabIndex = 30;
            this.listViewDSNguoi.UseCompatibleStateImageBehavior = false;
            this.listViewDSNguoi.View = System.Windows.Forms.View.Details;
            // 
            // IDNCC
            // 
            this.IDNCC.Text = "ID";
            this.IDNCC.Width = 79;
            // 
            // HoVaTen
            // 
            this.HoVaTen.Text = "HoVaTen";
            this.HoVaTen.Width = 215;
            // 
            // QuyenHan
            // 
            this.QuyenHan.Text = "QuyenHan";
            this.QuyenHan.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Tên món ăn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(566, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Người cung cấp";
            // 
            // textBoxNguoi
            // 
            this.textBoxNguoi.Location = new System.Drawing.Point(674, 274);
            this.textBoxNguoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNguoi.Name = "textBoxNguoi";
            this.textBoxNguoi.Size = new System.Drawing.Size(326, 22);
            this.textBoxNguoi.TabIndex = 32;
            // 
            // buttonThoat
            // 
            this.buttonThoat.Location = new System.Drawing.Point(903, 315);
            this.buttonThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(96, 28);
            this.buttonThoat.TabIndex = 34;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = true;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // Bai06
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 365);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNguoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewDSNguoi);
            this.Controls.Add(this.listViewDSMon);
            this.Controls.Add(this.buttonNguoi);
            this.Controls.Add(this.buttonDSMon);
            this.Controls.Add(this.textBoxMon);
            this.Controls.Add(this.buttonRandom);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Bai06";
            this.Text = "Bai06";
            this.Load += new System.EventHandler(this.Bai06_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.TextBox textBoxMon;
        private System.Windows.Forms.Button buttonDSMon;
        private System.Windows.Forms.Button buttonNguoi;
        private System.Windows.Forms.ListView listViewDSMon;
        private System.Windows.Forms.ColumnHeader IDMonAn;
        private System.Windows.Forms.ColumnHeader TenMon;
        private System.Windows.Forms.ColumnHeader NguoiCungCap;
        private System.Windows.Forms.ListView listViewDSNguoi;
        private System.Windows.Forms.ColumnHeader IDNCC;
        private System.Windows.Forms.ColumnHeader HoVaTen;
        private System.Windows.Forms.ColumnHeader QuyenHan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNguoi;
        private System.Windows.Forms.Button buttonThoat;
    }
}