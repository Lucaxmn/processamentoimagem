namespace Tecnica10
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
            btnCarregarP = new Button();
            btnCarregarQ = new Button();
            btnCalcular  = new Button();
            btnSalvar    = new Button();

            picP = new PictureBox();
            picQ = new PictureBox();
            picR = new PictureBox();

            lblP         = new Label();
            lblQ         = new Label();
            lblR         = new Label();
            lblTitulo    = new Label();
            lblFormula   = new Label();
            lblMais      = new Label();
            lblIgual     = new Label();

            // ===== FORM =====
            Text = "Técnica 10 - Combinação Linear (Média de Duas Imagens)";
            ClientSize = new Size(1050, 530);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text = "Média de duas imagens";
            lblTitulo.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Size = new Size(400, 28);

            lblFormula.Text = "R(i,j)  =  ( P(i,j)  +  Q(i,j) )  /  2";
            lblFormula.Font = new Font("Segoe UI", 11f, FontStyle.Italic);
            lblFormula.ForeColor = Color.FromArgb(80, 80, 80);
            lblFormula.Location = new Point(20, 40);
            lblFormula.Size = new Size(500, 24);

            // ===== BOTÕES =====
            CriarBotao(btnCarregarP, "Carregar P", 20,  78, Color.FromArgb(0, 120, 215), btnCarregarP_Click);
            CriarBotao(btnCarregarQ, "Carregar Q", 190, 78, Color.FromArgb(0, 120, 215), btnCarregarQ_Click);
            CriarBotao(btnCalcular,  "Calcular Média", 360, 78, Color.FromArgb(50, 150, 50), btnCalcular_Click);
            CriarBotao(btnSalvar,    "Salvar", 540, 78, Color.FromArgb(180, 80, 0), btnSalvar_Click);

            // ===== PICTURE BOX P =====
            CriarPic(picP, 20, 125, 290, 310);
            CriarLabel(lblP, "P (imagem 1)", 20, 442, 290, Color.DimGray);

            // ===== SINAL + =====
            lblMais.Text = "+";
            lblMais.Font = new Font("Segoe UI", 28f, FontStyle.Bold);
            lblMais.ForeColor = Color.FromArgb(0, 120, 215);
            lblMais.Location = new Point(322, 265);
            lblMais.Size = new Size(40, 45);
            lblMais.TextAlign = ContentAlignment.MiddleCenter;

            // ===== PICTURE BOX Q =====
            CriarPic(picQ, 370, 125, 290, 310);
            CriarLabel(lblQ, "Q (imagem 2)", 370, 442, 290, Color.DimGray);

            // ===== SINAL = =====
            lblIgual.Text = "÷2";
            lblIgual.Font = new Font("Segoe UI", 20f, FontStyle.Bold);
            lblIgual.ForeColor = Color.FromArgb(0, 120, 215);
            lblIgual.Location = new Point(672, 265);
            lblIgual.Size = new Size(55, 45);
            lblIgual.TextAlign = ContentAlignment.MiddleCenter;

            // ===== PICTURE BOX R =====
            CriarPic(picR, 735, 125, 290, 310);
            CriarLabel(lblR, "R = (P + Q) / 2", 735, 442, 290, Color.FromArgb(0, 100, 0));

            // ===== ADICIONAR AO FORM =====
            Controls.Add(lblTitulo);
            Controls.Add(lblFormula);
            Controls.Add(btnCarregarP);
            Controls.Add(btnCarregarQ);
            Controls.Add(btnCalcular);
            Controls.Add(btnSalvar);
            Controls.Add(picP);
            Controls.Add(lblP);
            Controls.Add(lblMais);
            Controls.Add(picQ);
            Controls.Add(lblQ);
            Controls.Add(lblIgual);
            Controls.Add(picR);
            Controls.Add(lblR);
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

        private Button btnCarregarP, btnCarregarQ, btnCalcular, btnSalvar;
        private PictureBox picP, picQ, picR;
        private Label lblP, lblQ, lblR, lblTitulo, lblFormula, lblMais, lblIgual;
    }
}
