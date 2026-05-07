namespace Tecnica14
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
            btnCarregar      = new Button();
            btnEqualizar     = new Button();
            btnSalvar        = new Button();
            picOriginal      = new PictureBox();
            picEqualizada    = new PictureBox();
            picHistOriginal  = new PictureBox();
            picHistEqualizada= new PictureBox();
            lblOriginal      = new Label();
            lblEqualizada    = new Label();
            lblTitulo        = new Label();
            lblPassos        = new Label();

            // ===== FORM =====
            Text = "Técnica 14 - Equalização de Histograma";
            ClientSize = new Size(1100, 680);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text = "Equalização de Histograma";
            lblTitulo.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Size = new Size(500, 28);

            lblPassos.Text = "Passo 1: Histograma  →  Passo 2: CFD  →  Passo 3: h(v) = floor( (CFD(v) − CFD_min) / (MxN − CFD_min) × (L−1) )";
            lblPassos.Font = new Font("Segoe UI", 9f, FontStyle.Italic);
            lblPassos.ForeColor = Color.FromArgb(70, 70, 70);
            lblPassos.Location = new Point(20, 40);
            lblPassos.Size = new Size(1060, 20);

            // ===== BOTÕES =====
            btnCarregar.Text = "Carregar Imagem";
            btnCarregar.Location = new Point(20, 70);
            btnCarregar.Size = new Size(155, 34);
            btnCarregar.BackColor = Color.FromArgb(0, 120, 215);
            btnCarregar.ForeColor = Color.White;
            btnCarregar.FlatStyle = FlatStyle.Flat;
            btnCarregar.FlatAppearance.BorderSize = 0;
            btnCarregar.Click += btnCarregar_Click;

            btnEqualizar.Text = "Equalizar";
            btnEqualizar.Location = new Point(190, 70);
            btnEqualizar.Size = new Size(155, 34);
            btnEqualizar.BackColor = Color.FromArgb(50, 150, 50);
            btnEqualizar.ForeColor = Color.White;
            btnEqualizar.FlatStyle = FlatStyle.Flat;
            btnEqualizar.FlatAppearance.BorderSize = 0;
            btnEqualizar.Click += btnEqualizar_Click;

            btnSalvar.Text = "Salvar Resultado";
            btnSalvar.Location = new Point(360, 70);
            btnSalvar.Size = new Size(155, 34);
            btnSalvar.BackColor = Color.FromArgb(180, 80, 0);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.Click += btnSalvar_Click;

            // ===== LADO ESQUERDO — ORIGINAL =====
            ((System.ComponentModel.ISupportInitialize)picOriginal).BeginInit();
            picOriginal.Location = new Point(20, 118);
            picOriginal.Size = new Size(520, 350);
            picOriginal.BorderStyle = BorderStyle.FixedSingle;
            picOriginal.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picOriginal).EndInit();

            lblOriginal.Text = "Imagem Original (escala de cinza)";
            lblOriginal.Location = new Point(20, 475);
            lblOriginal.Size = new Size(520, 20);
            lblOriginal.ForeColor = Color.DimGray;
            lblOriginal.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblOriginal.TextAlign = ContentAlignment.MiddleCenter;

            ((System.ComponentModel.ISupportInitialize)picHistOriginal).BeginInit();
            picHistOriginal.Location = new Point(20, 500);
            picHistOriginal.Size = new Size(520, 160);
            picHistOriginal.BorderStyle = BorderStyle.FixedSingle;
            picHistOriginal.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picHistOriginal).EndInit();

            // ===== LADO DIREITO — EQUALIZADA =====
            ((System.ComponentModel.ISupportInitialize)picEqualizada).BeginInit();
            picEqualizada.Location = new Point(560, 118);
            picEqualizada.Size = new Size(520, 350);
            picEqualizada.BorderStyle = BorderStyle.FixedSingle;
            picEqualizada.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picEqualizada).EndInit();

            lblEqualizada.Text = "Imagem Equalizada";
            lblEqualizada.Location = new Point(560, 475);
            lblEqualizada.Size = new Size(520, 20);
            lblEqualizada.ForeColor = Color.FromArgb(0, 100, 0);
            lblEqualizada.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblEqualizada.TextAlign = ContentAlignment.MiddleCenter;

            ((System.ComponentModel.ISupportInitialize)picHistEqualizada).BeginInit();
            picHistEqualizada.Location = new Point(560, 500);
            picHistEqualizada.Size = new Size(520, 160);
            picHistEqualizada.BorderStyle = BorderStyle.FixedSingle;
            picHistEqualizada.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picHistEqualizada).EndInit();

            // ===== ADICIONAR AO FORM =====
            Controls.Add(lblTitulo);
            Controls.Add(lblPassos);
            Controls.Add(btnCarregar);
            Controls.Add(btnEqualizar);
            Controls.Add(btnSalvar);
            Controls.Add(picOriginal);
            Controls.Add(lblOriginal);
            Controls.Add(picHistOriginal);
            Controls.Add(picEqualizada);
            Controls.Add(lblEqualizada);
            Controls.Add(picHistEqualizada);
        }

        private Button btnCarregar, btnEqualizar, btnSalvar;
        private PictureBox picOriginal, picEqualizada, picHistOriginal, picHistEqualizada;
        private Label lblOriginal, lblEqualizada, lblTitulo, lblPassos;
    }
}
