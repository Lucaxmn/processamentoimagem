namespace Tecnica19
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnCarregar  = new Button();
            btnAplicar   = new Button();
            btnSalvar    = new Button();
            picOriginal  = new PictureBox();
            picResultado = new PictureBox();
            lblOriginal  = new Label();
            lblResultado = new Label();
            lblTitulo    = new Label();
            lblDescricao = new Label();
            lblTamanho   = new Label();
            nudTamanho   = new NumericUpDown();
            lblSigma     = new Label();
            nudSigma     = new NumericUpDown();

            // ===== FORM =====
            Text          = "Técnica 19 - Filtro Gaussiano";
            ClientSize    = new Size(1100, 580);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor     = Color.FromArgb(245, 245, 245);
            Font          = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text      = "Filtro Gaussiano";
            lblTitulo.Font      = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location  = new Point(20, 10);
            lblTitulo.Size      = new Size(400, 28);

            lblDescricao.Text      = "Convolução com kernel gaussiano N×N. O desvio-padrão σ controla o grau de suavização.  f(x,y) = (1/2πσ²) · exp(−(x²+y²)/2σ²)";
            lblDescricao.Font      = new Font("Segoe UI", 9f, FontStyle.Italic);
            lblDescricao.ForeColor = Color.FromArgb(70, 70, 70);
            lblDescricao.Location  = new Point(20, 40);
            lblDescricao.Size      = new Size(1060, 20);

            // ===== BOTÕES =====
            btnCarregar.Text                       = "Carregar Imagem";
            btnCarregar.Location                   = new Point(20, 70);
            btnCarregar.Size                       = new Size(155, 34);
            btnCarregar.BackColor                  = Color.FromArgb(0, 120, 215);
            btnCarregar.ForeColor                  = Color.White;
            btnCarregar.FlatStyle                  = FlatStyle.Flat;
            btnCarregar.FlatAppearance.BorderSize  = 0;
            btnCarregar.Click                     += btnCarregar_Click;

            btnAplicar.Text                        = "Aplicar Gaussiano";
            btnAplicar.Location                    = new Point(190, 70);
            btnAplicar.Size                        = new Size(155, 34);
            btnAplicar.BackColor                   = Color.FromArgb(50, 130, 50);
            btnAplicar.ForeColor                   = Color.White;
            btnAplicar.FlatStyle                   = FlatStyle.Flat;
            btnAplicar.FlatAppearance.BorderSize   = 0;
            btnAplicar.Click                      += btnAplicar_Click;

            btnSalvar.Text                         = "Salvar Resultado";
            btnSalvar.Location                     = new Point(360, 70);
            btnSalvar.Size                         = new Size(155, 34);
            btnSalvar.BackColor                    = Color.FromArgb(180, 80, 0);
            btnSalvar.ForeColor                    = Color.White;
            btnSalvar.FlatStyle                    = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize    = 0;
            btnSalvar.Click                       += btnSalvar_Click;

            // ===== PARÂMETROS =====
            lblTamanho.Text      = "Tamanho (N):";
            lblTamanho.Location  = new Point(540, 78);
            lblTamanho.Size      = new Size(90, 20);
            lblTamanho.ForeColor = Color.FromArgb(30, 30, 30);

            ((System.ComponentModel.ISupportInitialize)nudTamanho).BeginInit();
            nudTamanho.Minimum   = 3;
            nudTamanho.Maximum   = 21;
            nudTamanho.Increment = 2;
            nudTamanho.Value     = 5;
            nudTamanho.Location  = new Point(635, 74);
            nudTamanho.Size      = new Size(55, 23);
            ((System.ComponentModel.ISupportInitialize)nudTamanho).EndInit();

            lblSigma.Text      = "σ (sigma):";
            lblSigma.Location  = new Point(710, 78);
            lblSigma.Size      = new Size(70, 20);
            lblSigma.ForeColor = Color.FromArgb(30, 30, 30);

            ((System.ComponentModel.ISupportInitialize)nudSigma).BeginInit();
            nudSigma.Minimum       = new decimal(new int[] { 1, 0, 0, 65536 }); // 0.1
            nudSigma.Maximum       = 20;
            nudSigma.Increment     = new decimal(new int[] { 5, 0, 0, 65536 }); // 0.5
            nudSigma.DecimalPlaces = 1;
            nudSigma.Value         = new decimal(new int[] { 10, 0, 0, 65536 }); // 1.0
            nudSigma.Location      = new Point(785, 74);
            nudSigma.Size          = new Size(70, 23);
            ((System.ComponentModel.ISupportInitialize)nudSigma).EndInit();

            // ===== PICTURE BOX ORIGINAL =====
            ((System.ComponentModel.ISupportInitialize)picOriginal).BeginInit();
            picOriginal.Location    = new Point(20, 118);
            picOriginal.Size        = new Size(520, 400);
            picOriginal.BorderStyle = BorderStyle.FixedSingle;
            picOriginal.BackColor   = Color.White;
            ((System.ComponentModel.ISupportInitialize)picOriginal).EndInit();

            lblOriginal.Text      = "Antes";
            lblOriginal.Location  = new Point(20, 525);
            lblOriginal.Size      = new Size(520, 22);
            lblOriginal.ForeColor = Color.DimGray;
            lblOriginal.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblOriginal.TextAlign = ContentAlignment.MiddleCenter;

            // ===== PICTURE BOX RESULTADO =====
            ((System.ComponentModel.ISupportInitialize)picResultado).BeginInit();
            picResultado.Location    = new Point(560, 118);
            picResultado.Size        = new Size(520, 400);
            picResultado.BorderStyle = BorderStyle.FixedSingle;
            picResultado.BackColor   = Color.White;
            ((System.ComponentModel.ISupportInitialize)picResultado).EndInit();

            lblResultado.Text      = "Depois";
            lblResultado.Location  = new Point(560, 525);
            lblResultado.Size      = new Size(520, 22);
            lblResultado.ForeColor = Color.FromArgb(0, 100, 0);
            lblResultado.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblResultado.TextAlign = ContentAlignment.MiddleCenter;

            // ===== ADICIONAR AO FORM =====
            Controls.Add(lblTitulo);
            Controls.Add(lblDescricao);
            Controls.Add(btnCarregar);
            Controls.Add(btnAplicar);
            Controls.Add(btnSalvar);
            Controls.Add(lblTamanho);
            Controls.Add(nudTamanho);
            Controls.Add(lblSigma);
            Controls.Add(nudSigma);
            Controls.Add(picOriginal);
            Controls.Add(lblOriginal);
            Controls.Add(picResultado);
            Controls.Add(lblResultado);
        }

        private Button btnCarregar, btnAplicar, btnSalvar;
        private PictureBox picOriginal, picResultado;
        private Label lblOriginal, lblResultado, lblTitulo, lblDescricao, lblTamanho, lblSigma;
        private NumericUpDown nudTamanho, nudSigma;
    }
}
