namespace Tecnica12
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnCarregar  = new Button();
            btnSalvar    = new Button();
            picOriginal  = new PictureBox();
            picBinaria   = new PictureBox();
            lblOriginal  = new Label();
            lblBinaria   = new Label();
            lblTitulo    = new Label();
            lblFormula   = new Label();
            lblLimiar    = new Label();
            lblSliderMin = new Label();
            lblSliderMax = new Label();
            trackLimiar  = new TrackBar();

            // ===== FORM =====
            Text = "Técnica 12 - Limiarização (Thresholding)";
            ClientSize = new Size(980, 590);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text = "Limiarização — Thresholding";
            lblTitulo.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Size = new Size(400, 28);

            lblFormula.Text = "G(x,y) = 1 (branco)  se  I(x,y) ≥ T     |     G(x,y) = 0 (preto)  se  I(x,y) < T";
            lblFormula.Font = new Font("Segoe UI", 10f, FontStyle.Italic);
            lblFormula.ForeColor = Color.FromArgb(70, 70, 70);
            lblFormula.Location = new Point(20, 40);
            lblFormula.Size = new Size(700, 22);

            // ===== BOTÕES =====
            btnCarregar.Text = "Carregar Imagem";
            btnCarregar.Location = new Point(20, 72);
            btnCarregar.Size = new Size(155, 34);
            btnCarregar.BackColor = Color.FromArgb(0, 120, 215);
            btnCarregar.ForeColor = Color.White;
            btnCarregar.FlatStyle = FlatStyle.Flat;
            btnCarregar.FlatAppearance.BorderSize = 0;
            btnCarregar.Click += btnCarregar_Click;

            btnSalvar.Text = "Salvar Resultado";
            btnSalvar.Location = new Point(190, 72);
            btnSalvar.Size = new Size(155, 34);
            btnSalvar.BackColor = Color.FromArgb(180, 80, 0);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.Click += btnSalvar_Click;

            // ===== SLIDER LIMIAR =====
            ((System.ComponentModel.ISupportInitialize)trackLimiar).BeginInit();
            trackLimiar.Location = new Point(20, 120);
            trackLimiar.Size = new Size(940, 45);
            trackLimiar.Minimum = 0;
            trackLimiar.Maximum = 255;
            trackLimiar.Value = 128;
            trackLimiar.TickFrequency = 25;
            trackLimiar.Scroll += trackLimiar_Scroll;
            ((System.ComponentModel.ISupportInitialize)trackLimiar).EndInit();

            lblSliderMin.Text = "T = 0";
            lblSliderMin.Location = new Point(20, 168);
            lblSliderMin.Size = new Size(55, 18);
            lblSliderMin.ForeColor = Color.DimGray;
            lblSliderMin.Font = new Font("Segoe UI", 8f);

            lblSliderMax.Text = "T = 255";
            lblSliderMax.Location = new Point(905, 168);
            lblSliderMax.Size = new Size(60, 18);
            lblSliderMax.ForeColor = Color.DimGray;
            lblSliderMax.Font = new Font("Segoe UI", 8f);

            lblLimiar.Text = "Limiar T = 128   →   pixels ≥ 128 ficam brancos (1),  pixels < 128 ficam pretos (0)";
            lblLimiar.Location = new Point(20, 190);
            lblLimiar.Size = new Size(940, 22);
            lblLimiar.ForeColor = Color.FromArgb(0, 80, 160);
            lblLimiar.Font = new Font("Segoe UI", 10f, FontStyle.Bold);

            // ===== PICTURE BOXES =====
            ((System.ComponentModel.ISupportInitialize)picOriginal).BeginInit();
            picOriginal.Location = new Point(20, 225);
            picOriginal.Size = new Size(460, 310);
            picOriginal.BorderStyle = BorderStyle.FixedSingle;
            picOriginal.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picOriginal).EndInit();

            lblOriginal.Text = "Imagem em escala de cinza (original)";
            lblOriginal.Location = new Point(20, 542);
            lblOriginal.Size = new Size(460, 20);
            lblOriginal.ForeColor = Color.DimGray;
            lblOriginal.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblOriginal.TextAlign = ContentAlignment.MiddleCenter;

            ((System.ComponentModel.ISupportInitialize)picBinaria).BeginInit();
            picBinaria.Location = new Point(500, 225);
            picBinaria.Size = new Size(460, 310);
            picBinaria.BorderStyle = BorderStyle.FixedSingle;
            picBinaria.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picBinaria).EndInit();

            lblBinaria.Text = "Resultado binarizado (limiarizado)";
            lblBinaria.Location = new Point(500, 542);
            lblBinaria.Size = new Size(460, 20);
            lblBinaria.ForeColor = Color.FromArgb(0, 100, 0);
            lblBinaria.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblBinaria.TextAlign = ContentAlignment.MiddleCenter;

            // ===== ADICIONAR AO FORM =====
            Controls.Add(lblTitulo);
            Controls.Add(lblFormula);
            Controls.Add(btnCarregar);
            Controls.Add(btnSalvar);
            Controls.Add(trackLimiar);
            Controls.Add(lblSliderMin);
            Controls.Add(lblSliderMax);
            Controls.Add(lblLimiar);
            Controls.Add(picOriginal);
            Controls.Add(lblOriginal);
            Controls.Add(picBinaria);
            Controls.Add(lblBinaria);
        }

        private Button btnCarregar, btnSalvar;
        private PictureBox picOriginal, picBinaria;
        private Label lblOriginal, lblBinaria, lblTitulo, lblFormula, lblLimiar, lblSliderMin, lblSliderMax;
        private TrackBar trackLimiar;
    }
}
