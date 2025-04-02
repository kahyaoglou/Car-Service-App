namespace Car_Service_App
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
            txtPlaka = new TextBox();
            label2 = new Label();
            txtIsim = new TextBox();
            groupBox1 = new GroupBox();
            chkDtcOff = new CheckBox();
            chkOnOff = new CheckBox();
            chkStage2 = new CheckBox();
            btnAra = new Button();
            txtAra = new TextBox();
            chkStage1 = new CheckBox();
            chkEGR = new CheckBox();
            chkDPF = new CheckBox();
            chkAnahtarKopyalama = new CheckBox();
            chkAdBlue = new CheckBox();
            btnKaydet = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            btnTemizle = new Button();
            dgvMusteriler = new DataGridView();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 11);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 0;
            label1.Text = "Plaka";
            // 
            // txtPlaka
            // 
            txtPlaka.Location = new Point(78, 8);
            txtPlaka.Name = "txtPlaka";
            txtPlaka.Size = new Size(194, 23);
            txtPlaka.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 46);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "İsim";
            // 
            // txtIsim
            // 
            txtIsim.Location = new Point(78, 43);
            txtIsim.Name = "txtIsim";
            txtIsim.Size = new Size(194, 23);
            txtIsim.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkDtcOff);
            groupBox1.Controls.Add(chkOnOff);
            groupBox1.Controls.Add(chkStage2);
            groupBox1.Controls.Add(btnAra);
            groupBox1.Controls.Add(txtAra);
            groupBox1.Controls.Add(chkStage1);
            groupBox1.Controls.Add(chkEGR);
            groupBox1.Controls.Add(chkDPF);
            groupBox1.Controls.Add(chkAnahtarKopyalama);
            groupBox1.Controls.Add(chkAdBlue);
            groupBox1.Location = new Point(43, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(603, 153);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Yapılan İşlemler";
            // 
            // chkDtcOff
            // 
            chkDtcOff.AutoSize = true;
            chkDtcOff.Location = new Point(151, 97);
            chkDtcOff.Name = "chkDtcOff";
            chkDtcOff.Size = new Size(67, 19);
            chkDtcOff.TabIndex = 9;
            chkDtcOff.Text = "DTC Off";
            chkDtcOff.UseVisualStyleBackColor = true;
            // 
            // chkOnOff
            // 
            chkOnOff.AutoSize = true;
            chkOnOff.Location = new Point(151, 72);
            chkOnOff.Name = "chkOnOff";
            chkOnOff.Size = new Size(70, 19);
            chkOnOff.TabIndex = 8;
            chkOnOff.Text = "On - Off";
            chkOnOff.UseVisualStyleBackColor = true;
            // 
            // chkStage2
            // 
            chkStage2.AutoSize = true;
            chkStage2.Location = new Point(151, 47);
            chkStage2.Name = "chkStage2";
            chkStage2.Size = new Size(64, 19);
            chkStage2.TabIndex = 7;
            chkStage2.Text = "Stage 2";
            chkStage2.UseVisualStyleBackColor = true;
            // 
            // btnAra
            // 
            btnAra.Location = new Point(477, 22);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(75, 23);
            btnAra.TabIndex = 6;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // txtAra
            // 
            txtAra.Location = new Point(326, 20);
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(132, 23);
            txtAra.TabIndex = 5;
            txtAra.TextChanged += txtAra_TextChanged;
            // 
            // chkStage1
            // 
            chkStage1.AutoSize = true;
            chkStage1.Location = new Point(151, 22);
            chkStage1.Name = "chkStage1";
            chkStage1.Size = new Size(64, 19);
            chkStage1.TabIndex = 4;
            chkStage1.Text = "Stage 1";
            chkStage1.UseVisualStyleBackColor = true;
            // 
            // chkEGR
            // 
            chkEGR.AutoSize = true;
            chkEGR.Location = new Point(6, 97);
            chkEGR.Name = "chkEGR";
            chkEGR.Size = new Size(47, 19);
            chkEGR.TabIndex = 3;
            chkEGR.Text = "EGR";
            chkEGR.UseVisualStyleBackColor = true;
            // 
            // chkDPF
            // 
            chkDPF.AutoSize = true;
            chkDPF.Location = new Point(6, 72);
            chkDPF.Name = "chkDPF";
            chkDPF.Size = new Size(47, 19);
            chkDPF.TabIndex = 2;
            chkDPF.Text = "DPF";
            chkDPF.UseVisualStyleBackColor = true;
            // 
            // chkAnahtarKopyalama
            // 
            chkAnahtarKopyalama.AutoSize = true;
            chkAnahtarKopyalama.Location = new Point(6, 47);
            chkAnahtarKopyalama.Name = "chkAnahtarKopyalama";
            chkAnahtarKopyalama.Size = new Size(130, 19);
            chkAnahtarKopyalama.TabIndex = 1;
            chkAnahtarKopyalama.Text = "Anahtar Kopyalama";
            chkAnahtarKopyalama.UseVisualStyleBackColor = true;
            // 
            // chkAdBlue
            // 
            chkAdBlue.AutoSize = true;
            chkAdBlue.Location = new Point(6, 22);
            chkAdBlue.Name = "chkAdBlue";
            chkAdBlue.Size = new Size(64, 19);
            chkAdBlue.TabIndex = 0;
            chkAdBlue.Text = "AdBlue";
            chkAdBlue.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(43, 231);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(75, 23);
            btnKaydet.TabIndex = 5;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(218, 231);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(75, 23);
            btnSil.TabIndex = 6;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(401, 231);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(75, 23);
            btnGuncelle.TabIndex = 7;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Location = new Point(571, 231);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(75, 23);
            btnTemizle.TabIndex = 8;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            // 
            // dgvMusteriler
            // 
            dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMusteriler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMusteriler.Location = new Point(43, 260);
            dgvMusteriler.Name = "dgvMusteriler";
            dgvMusteriler.Size = new Size(603, 227);
            dgvMusteriler.TabIndex = 9;
            dgvMusteriler.SelectionChanged += dgvMusteriler_SelectionChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.simpliers_miracotoelektronikanahtar;
            pictureBox1.Location = new Point(369, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(277, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 521);
            Controls.Add(pictureBox1);
            Controls.Add(dgvMusteriler);
            Controls.Add(btnTemizle);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnKaydet);
            Controls.Add(groupBox1);
            Controls.Add(txtIsim);
            Controls.Add(label2);
            Controls.Add(txtPlaka);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Miraç Oto Anahtar & Elektronik";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPlaka;
        private Label label2;
        private TextBox txtIsim;
        private GroupBox groupBox1;
        private CheckBox chkStage1;
        private CheckBox chkEGR;
        private CheckBox chkDPF;
        private CheckBox chkAnahtarKopyalama;
        private CheckBox chkAdBlue;
        private Button btnKaydet;
        private Button btnSil;
        private Button btnGuncelle;
        private Button btnTemizle;
        private DataGridView dgvMusteriler;
        private Button btnAra;
        private TextBox txtAra;
        private CheckBox chkDtcOff;
        private CheckBox chkOnOff;
        private CheckBox chkStage2;
        private PictureBox pictureBox1;
    }
}
