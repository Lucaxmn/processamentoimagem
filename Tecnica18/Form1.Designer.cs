namespace Tecnica18
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
            btnCarregar   = new Button();
            btnAplicar    = new Button();
            btnSalvar     = new Button();
            picOriginal   = new PictureBox();
            picResultado  = new PictureBox();
            lblOriginal   = new Label();
            lblResultado  = new Label();
            lblTitulo     = new Label();
            lblDescricao  = new Label();

            // ===== FORM =====
            Text          = "Técnica 18 - Suavização Conservativa";
            ClientSize    = new Size(1100, 580);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor     = Color.FromArgb(245, 245, 245);
            Font          = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text      = "Suavização Conservativa";
            lblTitulo.Font      = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location  = new Point(20, 10);
            lblTitulo.Size      = new Size(500, 28);

            lblDescricao.Text      = "Vizinhança 3×3: se cp > max(vizinhos) → cp = max;  se cp < min(vizinhos) → cp = min;  caso contrário, mantém.";
            lblDescricao.Font      = new Font("Segoe UI", 9f, FontStyle.Italic);
            lblDescricao.ForeColor = Color.FromArgb(70, 70, 70);
            lblDescricao.Location  = new Point(20, 40);
            lblDescricao.Size      = new Size(1060, 20);

            // ===== BOTÕES =====
            btnCarregar.Text                        = "Carregar Imagem";
            btnCarregar.Location                    = new Point(20, 70);
            btnCarregar.Size                        = new Size(155, 34);
            btnCarregar.BackColor                   = Color.FromArgb(0, 120, 215);
            btnCarregar.ForeColor                   = Color.White;
            btnCarregar.FlatStyle                   = FlatStyle.Flat;
            btnCarregar.FlatAppearance.BorderSize   = 0;
            btnCarregar.Click                      += btnCarregar_Click;

            btnAplicar.Text                         = "Aplicar Suavização";
            btnAplicar.Location                     = new Point(190, 70);
            btnAplicar.Size                         = new Size(155, 34);
            btnAplicar.BackColor                    = Color.FromArgb(50, 130, 50);
            btnAplicar.ForeColor                    = Color.White;
            btnAplicar.FlatStyle                    = FlatStyle.Flat;
            btnAplicar.FlatAppearance.BorderSize    = 0;
            btnAplicar.Click                       += btnAplicar_Click;

            btnSalvar.Text                          = "Salvar Resultado";
            btnSalvar.Location                      = new Point(360, 70);
            btnSalvar.Size                          = new Size(155, 34);
            btnSalvar.BackColor                     = Color.FromArgb(180, 80, 0);
            btnSalvar.ForeColor                     = Color.White;
            btnSalvar.FlatStyle                     = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize     = 0;
            btnSalvar.Click                        += btnSalvar_Click;

            // ===== PICTURE BOX ORIGINAL (esquerda) =====
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

            // ===== PICTURE BOX RESULTADO (direita) =====
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
            Controls.Add(picOriginal);
            Controls.Add(lblOriginal);
            Controls.Add(picResultado);
            Controls.Add(lblResultado);
        }

        private Button btnCarregar, btnAplicar, btnSalvar;
        private PictureBox picOriginal, picResultado;
        private Label lblOriginal, lblResultado, lblTitulo, lblDescricao;
    }
}
