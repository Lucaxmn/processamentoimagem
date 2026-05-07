namespace Tecnica13
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
            btnNegativo  = new Button();
            btnSalvar    = new Button();
            picOriginal  = new PictureBox();
            picNegativa  = new PictureBox();
            lblOriginal  = new Label();
            lblNegativa  = new Label();
            lblTitulo    = new Label();
            lblFormula   = new Label();

            // ===== FORM =====
            Text = "Técnica 13 - Negativo da Imagem";
            ClientSize = new Size(980, 560);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text = "Negativo da Imagem";
            lblTitulo.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Size = new Size(400, 28);

            lblFormula.Text = "G(x, y)  =  255  −  F(x, y)";
            lblFormula.Font = new Font("Segoe UI", 13f, FontStyle.Italic);
            lblFormula.ForeColor = Color.FromArgb(60, 60, 60);
            lblFormula.Location = new Point(20, 42);
            lblFormula.Size = new Size(420, 28);

            // ===== BOTÕES =====
            btnCarregar.Text = "Carregar Imagem";
            btnCarregar.Location = new Point(20, 82);
            btnCarregar.Size = new Size(155, 34);
            btnCarregar.BackColor = Color.FromArgb(0, 120, 215);
            btnCarregar.ForeColor = Color.White;
            btnCarregar.FlatStyle = FlatStyle.Flat;
            btnCarregar.FlatAppearance.BorderSize = 0;
            btnCarregar.Click += btnCarregar_Click;

            btnNegativo.Text = "Gerar Negativo";
            btnNegativo.Location = new Point(190, 82);
            btnNegativo.Size = new Size(155, 34);
            btnNegativo.BackColor = Color.FromArgb(50, 150, 50);
            btnNegativo.ForeColor = Color.White;
            btnNegativo.FlatStyle = FlatStyle.Flat;
            btnNegativo.FlatAppearance.BorderSize = 0;
            btnNegativo.Click += btnNegativo_Click;

            btnSalvar.Text = "Salvar Resultado";
            btnSalvar.Location = new Point(360, 82);
            btnSalvar.Size = new Size(155, 34);
            btnSalvar.BackColor = Color.FromArgb(180, 80, 0);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.Click += btnSalvar_Click;

            // ===== PICTURE BOX ORIGINAL =====
            ((System.ComponentModel.ISupportInitialize)picOriginal).BeginInit();
            picOriginal.Location = new Point(20, 130);
            picOriginal.Size = new Size(460, 380);
            picOriginal.BorderStyle = BorderStyle.FixedSingle;
            picOriginal.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picOriginal).EndInit();

            lblOriginal.Text = "Imagem Original  F(x,y)";
            lblOriginal.Location = new Point(20, 517);
            lblOriginal.Size = new Size(460, 22);
            lblOriginal.ForeColor = Color.DimGray;
            lblOriginal.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblOriginal.TextAlign = ContentAlignment.MiddleCenter;

            // ===== PICTURE BOX NEGATIVA =====
            ((System.ComponentModel.ISupportInitialize)picNegativa).BeginInit();
            picNegativa.Location = new Point(500, 130);
            picNegativa.Size = new Size(460, 380);
            picNegativa.BorderStyle = BorderStyle.FixedSingle;
            picNegativa.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picNegativa).EndInit();

            lblNegativa.Text = "Negativo  G(x,y) = 255 − F(x,y)";
            lblNegativa.Location = new Point(500, 517);
            lblNegativa.Size = new Size(460, 22);
            lblNegativa.ForeColor = Color.FromArgb(0, 100, 0);
            lblNegativa.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblNegativa.TextAlign = ContentAlignment.MiddleCenter;

            // ===== ADICIONAR AO FORM =====
            Controls.Add(lblTitulo);
            Controls.Add(lblFormula);
            Controls.Add(btnCarregar);
            Controls.Add(btnNegativo);
            Controls.Add(btnSalvar);
            Controls.Add(picOriginal);
            Controls.Add(lblOriginal);
            Controls.Add(picNegativa);
            Controls.Add(lblNegativa);
        }

        private Button btnCarregar, btnNegativo, btnSalvar;
        private PictureBox picOriginal, picNegativa;
        private Label lblOriginal, lblNegativa, lblTitulo, lblFormula;
    }
}
