namespace Car_Service_App
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            label1 = new Label();
            txtPlaka = new TextBox();
            groupBox1 = new GroupBox();
            btnTuningliVeriKaydet = new Button();
            btnOrijinalVeriKaydet = new Button();
            chkDtcOff = new CheckBox();
            chkOnOff = new CheckBox();
            chkStage2 = new CheckBox();
            chkStage1 = new CheckBox();
            chkEGR = new CheckBox();
            chkDPF = new CheckBox();
            chkAnahtarKopyalama = new CheckBox();
            chkAdBlue = new CheckBox();
            txtAra = new TextBox();
            btnKaydet = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            btnTemizle = new Button();
            dgvMusteriler = new DataGridView();
            pictureBox1 = new PictureBox();
            groupBox2 = new GroupBox();
            pictureBox2 = new PictureBox();
            btnExit = new PictureBox();
            lblTitle = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnExit).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // txtPlaka
            // 
            resources.ApplyResources(txtPlaka, "txtPlaka");
            txtPlaka.BackColor = Color.AntiqueWhite;
            txtPlaka.Name = "txtPlaka";
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(btnTuningliVeriKaydet);
            groupBox1.Controls.Add(btnOrijinalVeriKaydet);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // btnTuningliVeriKaydet
            // 
            resources.ApplyResources(btnTuningliVeriKaydet, "btnTuningliVeriKaydet");
            btnTuningliVeriKaydet.BackColor = Color.IndianRed;
            btnTuningliVeriKaydet.Name = "btnTuningliVeriKaydet";
            btnTuningliVeriKaydet.UseVisualStyleBackColor = false;
            btnTuningliVeriKaydet.Click += btnTuningliVeriKaydet_Click;
            // 
            // btnOrijinalVeriKaydet
            // 
            resources.ApplyResources(btnOrijinalVeriKaydet, "btnOrijinalVeriKaydet");
            btnOrijinalVeriKaydet.BackColor = Color.IndianRed;
            btnOrijinalVeriKaydet.Name = "btnOrijinalVeriKaydet";
            btnOrijinalVeriKaydet.UseVisualStyleBackColor = false;
            btnOrijinalVeriKaydet.Click += btnOrijinalVeriKaydet_Click;
            // 
            // chkDtcOff
            // 
            resources.ApplyResources(chkDtcOff, "chkDtcOff");
            chkDtcOff.Name = "chkDtcOff";
            chkDtcOff.UseVisualStyleBackColor = true;
            // 
            // chkOnOff
            // 
            resources.ApplyResources(chkOnOff, "chkOnOff");
            chkOnOff.Name = "chkOnOff";
            chkOnOff.UseVisualStyleBackColor = true;
            // 
            // chkStage2
            // 
            resources.ApplyResources(chkStage2, "chkStage2");
            chkStage2.Name = "chkStage2";
            chkStage2.UseVisualStyleBackColor = true;
            // 
            // chkStage1
            // 
            resources.ApplyResources(chkStage1, "chkStage1");
            chkStage1.Name = "chkStage1";
            chkStage1.UseVisualStyleBackColor = true;
            // 
            // chkEGR
            // 
            resources.ApplyResources(chkEGR, "chkEGR");
            chkEGR.Name = "chkEGR";
            chkEGR.UseVisualStyleBackColor = true;
            // 
            // chkDPF
            // 
            resources.ApplyResources(chkDPF, "chkDPF");
            chkDPF.Name = "chkDPF";
            chkDPF.UseVisualStyleBackColor = true;
            // 
            // chkAnahtarKopyalama
            // 
            resources.ApplyResources(chkAnahtarKopyalama, "chkAnahtarKopyalama");
            chkAnahtarKopyalama.Name = "chkAnahtarKopyalama";
            chkAnahtarKopyalama.UseVisualStyleBackColor = true;
            // 
            // chkAdBlue
            // 
            resources.ApplyResources(chkAdBlue, "chkAdBlue");
            chkAdBlue.Name = "chkAdBlue";
            chkAdBlue.UseVisualStyleBackColor = true;
            // 
            // txtAra
            // 
            resources.ApplyResources(txtAra, "txtAra");
            txtAra.BackColor = Color.AntiqueWhite;
            txtAra.Name = "txtAra";
            txtAra.Click += txtAra_Click;
            txtAra.TextChanged += txtAra_TextChanged;
            // 
            // btnKaydet
            // 
            resources.ApplyResources(btnKaydet, "btnKaydet");
            btnKaydet.BackColor = Color.Orange;
            btnKaydet.Name = "btnKaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnSil
            // 
            resources.ApplyResources(btnSil, "btnSil");
            btnSil.BackColor = Color.Orange;
            btnSil.Name = "btnSil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            resources.ApplyResources(btnGuncelle, "btnGuncelle");
            btnGuncelle.BackColor = Color.Orange;
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnTemizle
            // 
            resources.ApplyResources(btnTemizle, "btnTemizle");
            btnTemizle.BackColor = Color.Orange;
            btnTemizle.Name = "btnTemizle";
            btnTemizle.UseVisualStyleBackColor = false;
            // 
            // dgvMusteriler
            // 
            resources.ApplyResources(dgvMusteriler, "dgvMusteriler");
            dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMusteriler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMusteriler.Name = "dgvMusteriler";
            dgvMusteriler.SelectionChanged += dgvMusteriler_SelectionChanged;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Image = Properties.Resources.simpliers_miracotoelektronikanahtar;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(pictureBox2);
            groupBox2.Controls.Add(chkDtcOff);
            groupBox2.Controls.Add(txtPlaka);
            groupBox2.Controls.Add(chkOnOff);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(chkStage2);
            groupBox2.Controls.Add(btnSil);
            groupBox2.Controls.Add(chkStage1);
            groupBox2.Controls.Add(btnTemizle);
            groupBox2.Controls.Add(chkEGR);
            groupBox2.Controls.Add(btnKaydet);
            groupBox2.Controls.Add(chkDPF);
            groupBox2.Controls.Add(btnGuncelle);
            groupBox2.Controls.Add(chkAnahtarKopyalama);
            groupBox2.Controls.Add(chkAdBlue);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // btnExit
            // 
            resources.ApplyResources(btnExit, "btnExit");
            btnExit.Cursor = Cursors.Hand;
            btnExit.Name = "btnExit";
            btnExit.TabStop = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.Name = "lblTitle";
            // 
            // MainPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitle);
            Controls.Add(btnExit);
            Controls.Add(groupBox2);
            Controls.Add(pictureBox1);
            Controls.Add(dgvMusteriler);
            Controls.Add(txtAra);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "MainPage";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnExit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPlaka;
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
        private TextBox txtAra;
        private CheckBox chkDtcOff;
        private CheckBox chkOnOff;
        private CheckBox chkStage2;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private PictureBox btnExit;
        private PictureBox pictureBox2;
        private Label lblTitle;
        private Button btnTuningliVeriKaydet;
        private Button btnOrijinalVeriKaydet;
    }
}
