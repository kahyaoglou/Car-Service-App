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
            btnAra = new Button();
            txtAra = new TextBox();
            chkArizaTespiti = new CheckBox();
            chkLastikDegisimi = new CheckBox();
            chkYagDegisimi = new CheckBox();
            chkAnahtarKopyalama = new CheckBox();
            chkAdBlue = new CheckBox();
            btnKaydet = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            btnTemizle = new Button();
            dgvMusteriler = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).BeginInit();
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
            groupBox1.Controls.Add(btnAra);
            groupBox1.Controls.Add(txtAra);
            groupBox1.Controls.Add(chkArizaTespiti);
            groupBox1.Controls.Add(chkLastikDegisimi);
            groupBox1.Controls.Add(chkYagDegisimi);
            groupBox1.Controls.Add(chkAnahtarKopyalama);
            groupBox1.Controls.Add(chkAdBlue);
            groupBox1.Location = new Point(43, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(603, 153);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Yapılan İşlemler";
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
            // chkArizaTespiti
            // 
            chkArizaTespiti.AutoSize = true;
            chkArizaTespiti.Location = new Point(6, 122);
            chkArizaTespiti.Name = "chkArizaTespiti";
            chkArizaTespiti.Size = new Size(89, 19);
            chkArizaTespiti.TabIndex = 4;
            chkArizaTespiti.Text = "Arıza Tespiti";
            chkArizaTespiti.UseVisualStyleBackColor = true;
            // 
            // chkLastikDegisimi
            // 
            chkLastikDegisimi.AutoSize = true;
            chkLastikDegisimi.Location = new Point(6, 97);
            chkLastikDegisimi.Name = "chkLastikDegisimi";
            chkLastikDegisimi.Size = new Size(105, 19);
            chkLastikDegisimi.TabIndex = 3;
            chkLastikDegisimi.Text = "Lastik Değişimi";
            chkLastikDegisimi.UseVisualStyleBackColor = true;
            // 
            // chkYagDegisimi
            // 
            chkYagDegisimi.AutoSize = true;
            chkYagDegisimi.Location = new Point(6, 72);
            chkYagDegisimi.Name = "chkYagDegisimi";
            chkYagDegisimi.Size = new Size(94, 19);
            chkYagDegisimi.TabIndex = 2;
            chkYagDegisimi.Text = "Yağ Değişimi";
            chkYagDegisimi.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 521);
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
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPlaka;
        private Label label2;
        private TextBox txtIsim;
        private GroupBox groupBox1;
        private CheckBox chkArizaTespiti;
        private CheckBox chkLastikDegisimi;
        private CheckBox chkYagDegisimi;
        private CheckBox chkAnahtarKopyalama;
        private CheckBox chkAdBlue;
        private Button btnKaydet;
        private Button btnSil;
        private Button btnGuncelle;
        private Button btnTemizle;
        private DataGridView dgvMusteriler;
        private Button btnAra;
        private TextBox txtAra;
    }
}
