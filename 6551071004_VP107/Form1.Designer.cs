namespace _6551071004_VP107
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing)
            {
                db?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtMa = new TextBox();
            txtTen = new TextBox();
            txtTinChi = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            dgvDanhSach = new DataGridView();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(164, 25);
            label1.TabIndex = 0;
            label1.Text = "Thông tin môn học";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(117, 25);
            label2.TabIndex = 1;
            label2.Text = "Mã môn học:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 2;
            label3.Text = "Tên môn học";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 189);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 3;
            label4.Text = "Số tín chỉ";
            // 
            // txtMa
            // 
            txtMa.Location = new Point(12, 72);
            txtMa.MaxLength = 10;
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(225, 31);
            txtMa.TabIndex = 4;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(12, 143);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(225, 31);
            txtTen.TabIndex = 5;
            // 
            // txtTinChi
            // 
            txtTinChi.Location = new Point(12, 217);
            txtTinChi.MaxLength = 5;
            txtTinChi.Name = "txtTinChi";
            txtTinChi.Size = new Size(225, 31);
            txtTinChi.TabIndex = 6;
            txtTinChi.KeyPress += txtTinChi_KeyPress;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(12, 266);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(114, 80);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(132, 266);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(114, 80);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(12, 358);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(114, 80);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(132, 358);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(114, 80);
            btnThoat.TabIndex = 10;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dgvDanhSach
            // 
            dgvDanhSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSach.Location = new Point(290, 53);
            dgvDanhSach.Name = "dgvDanhSach";
            dgvDanhSach.RowHeadersWidth = 62;
            dgvDanhSach.Size = new Size(498, 385);
            dgvDanhSach.TabIndex = 11;
            dgvDanhSach.CellClick += dgvDanhSach_CellClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(290, 9);
            label5.Name = "label5";
            label5.Size = new Size(170, 25);
            label5.TabIndex = 12;
            label5.Text = "Danh sách môn học";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(dgvDanhSach);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtTinChi);
            Controls.Add(txtTen);
            Controls.Add(txtMa);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Quản lý môn học";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtMa;
        private TextBox txtTen;
        private TextBox txtTinChi;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private DataGridView dgvDanhSach;
        private Label label5;
    }
}
