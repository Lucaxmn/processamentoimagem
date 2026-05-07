namespace Tecnica09
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
            btnCarregarA = new Button();
            btnCarregarB = new Button();
            btnMisturar  = new Button();
            btnSalvar    = new Button();

            picA         = new PictureBox();
            picB         = new PictureBox();
            picResultado = new PictureBox();

            lblA         = new Label();
            lblB         = new Label();
            lblResultado = new Label();
            lblTitulo    = new Label();
            lblAlpha     = new Label();
            lblSliderMin = new Label();
            lblSliderMax = new Label();

            trackAlpha   = new TrackBar();

            // ===== FORM =====
            Text = "Técnica 09 - Combinação Linear (Blending)";
            ClientSize = new Size(1050, 580);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text = "E = α × A  +  (1 - α) × B";
            lblTitulo.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Size = new Size(500, 30);

            // ===== BOTÕES =====
            CriarBotao(btnCarregarA, "Carregar A", 20,  50, Color.FromArgb(0, 120, 215), btnCarregarA_Click);
            CriarBotao(btnCarregarB, "Carregar B", 190, 50, Color.FromArgb(0, 120, 215), btnCarregarB_Click);
            CriarBotao(btnMisturar,  "Misturar",   360, 50, Color.FromArgb(50, 150, 50), btnMisturar_Click);
            CriarBotao(btnSalvar,    "Salvar",      530, 50, Color.FromArgb(180, 80, 0),  btnSalvar_Click);

            // ===== SLIDER ALPHA =====
            ((System.ComponentModel.ISupportInitialize)trackAlpha).BeginInit();
            trackAlpha.Location = new Point(20, 100);
            trackAlpha.Size = new Size(600, 45);
            trackAlpha.Minimum = 0;
            trackAlpha.Maximum = 100;
            trackAlpha.Value = 50;
            trackAlpha.TickFrequency = 10;
            trackAlpha.Scroll += trackAlpha_Scroll;
            ((System.ComponentModel.ISupportInitialize)trackAlpha).EndInit();

            lblSliderMin.Text = "α = 0.00\n(100% B)";
            lblSliderMin.Location = new Point(20, 148);
            lblSliderMin.Size = new Size(80, 35);
            lblSliderMin.ForeColor = Color.DimGray;
            lblSliderMin.Font = new Font("Segoe UI", 8f);

            lblSliderMax.Text = "α = 1.00\n(100% A)";
            lblSliderMax.Location = new Point(548, 148);
            lblSliderMax.Size = new Size(80, 35);
            lblSliderMax.ForeColor = Color.DimGray;
            lblSliderMax.Font = new Font("Segoe UI", 8f);
            lblSliderMax.TextAlign = ContentAlignment.TopRight;

            lblAlpha.Text = "α = 0.50   →   Imagem A: 50%   |   Imagem B: 50%";
            lblAlpha.Location = new Point(20, 188);
            lblAlpha.Size = new Size(650, 22);
            lblAlpha.ForeColor = Color.FromArgb(0, 80, 160);
            lblAlpha.Font = new Font("Segoe UI", 10f, FontStyle.Bold);

            // ===== PICTURE BOX A =====
            CriarPic(picA, 20, 220, 300, 280);
            CriarLabel(lblA, "A (original)", 20, 507, 300, Color.DimGray);

            // ===== PICTURE BOX B =====
            CriarPic(picB, 340, 220, 300, 280);
            CriarLabel(lblB, "B (original)", 340, 507, 300, Color.DimGray);

            // ===== PICTURE BOX RESULTADO =====
            CriarPic(picResultado, 660, 220, 370, 280);
            CriarLabel(lblResultado, "E = α × A + (1-α) × B", 660, 507, 370, Color.FromArgb(0, 100, 0));

            // ===== ADICIONAR AO FORM =====
            Controls.Add(lblTitulo);
            Controls.Add(btnCarregarA);
            Controls.Add(btnCarregarB);
            Controls.Add(btnMisturar);
            Controls.Add(btnSalvar);
            Controls.Add(trackAlpha);
            Controls.Add(lblSliderMin);
            Controls.Add(lblSliderMax);
            Controls.Add(lblAlpha);
            Controls.Add(picA);
            Controls.Add(picB);
            Controls.Add(picResultado);
            Controls.Add(lblA);
            Controls.Add(lblB);
            Controls.Add(lblResultado);
        }

        private void CriarBotao(Button btn, string texto, int x, int y, Color cor, EventHandler handler)
        {
            btn.Text = texto;
            btn.Location = new Point(x, y);
            btn.Size = new Size(155, 34);
            btn.BackColor = cor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += handler;
        }

        private void CriarPic(PictureBox pic, int x, int y, int w, int h)
        {
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            pic.Location = new Point(x, y);
            pic.Size = new Size(w, h);
            pic.BorderStyle = BorderStyle.FixedSingle;
            pic.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
        }

        private void CriarLabel(Label lbl, string texto, int x, int y, int w, Color cor)
        {
            lbl.Text = texto;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(w, 22);
            lbl.ForeColor = cor;
            lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
        }

        private Button btnCarregarA, btnCarregarB, btnMisturar, btnSalvar;
        private PictureBox picA, picB, picResultado;
        private Label lblA, lblB, lblResultado, lblTitulo, lblAlpha, lblSliderMin, lblSliderMax;
        private TrackBar trackAlpha;
    }
}
