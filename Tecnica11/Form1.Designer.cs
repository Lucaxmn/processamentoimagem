namespace Tecnica11
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
            btnCarregarX  = new Button();
            btnCarregarY  = new Button();
            btnAnd        = new Button();
            btnOr         = new Button();
            btnXor        = new Button();
            btnNotX       = new Button();
            btnNotY       = new Button();
            btnNotXAndY   = new Button();
            btnSalvar     = new Button();

            picX          = new PictureBox();
            picY          = new PictureBox();
            picResultado  = new PictureBox();

            lblX          = new Label();
            lblY          = new Label();
            lblResultado  = new Label();
            lblTitulo     = new Label();
            lblOps        = new Label();

            // ===== FORM =====
            Text = "Técnica 11 - Operações Lógicas em Imagens Binárias";
            ClientSize = new Size(1100, 600);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text = "Operações Lógicas Pixel a Pixel — AND | OR | NOT | XOR";
            lblTitulo.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Size = new Size(700, 26);

            // ===== BOTÕES CARREGAR =====
            CriarBotao(btnCarregarX, "Carregar X", 20,  46, Color.FromArgb(0, 120, 215), btnCarregarX_Click);
            CriarBotao(btnCarregarY, "Carregar Y", 190, 46, Color.FromArgb(0, 120, 215), btnCarregarY_Click);
            CriarBotao(btnSalvar,    "Salvar Resultado", 800, 46, Color.FromArgb(180, 80, 0), btnSalvar_Click);

            // ===== IMAGENS X e Y =====
            CriarPic(picX, 20,  90, 280, 280);
            CriarPic(picY, 320, 90, 280, 280);

            CriarLabel(lblX, "X (binarizada)", 20,  377, 280, Color.DimGray);
            CriarLabel(lblY, "Y (binarizada)", 320, 377, 280, Color.DimGray);

            // ===== RESULTADO =====
            CriarPic(picResultado, 620, 90, 460, 280);
            CriarLabel(lblResultado, "Resultado da operação", 620, 377, 460, Color.FromArgb(0, 100, 0));

            // ===== PAINEL OPERAÇÕES =====
            lblOps.Text = "Operações:";
            lblOps.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            lblOps.Location = new Point(20, 415);
            lblOps.Size = new Size(120, 22);
            lblOps.ForeColor = Color.FromArgb(40, 40, 40);

            CriarBotaoOp(btnAnd,      "AND  (X ∧ Y)",       20,  445);
            CriarBotaoOp(btnOr,       "OR   (X ∨ Y)",       20,  490);
            CriarBotaoOp(btnXor,      "XOR  (X ⊕ Y)",      220,  445);
            CriarBotaoOp(btnNotX,     "NOT X  (¬X)",        220,  490);
            CriarBotaoOp(btnNotY,     "NOT Y  (¬Y)",        420,  445);
            CriarBotaoOp(btnNotXAndY, "(NOT X) AND Y",      420,  490);

            btnAnd.Click      += btnAnd_Click;
            btnOr.Click       += btnOr_Click;
            btnXor.Click      += btnXor_Click;
            btnNotX.Click     += btnNotX_Click;
            btnNotY.Click     += btnNotY_Click;
            btnNotXAndY.Click += btnNotXAndY_Click;

            // ===== ADICIONAR AO FORM =====
            Controls.Add(lblTitulo);
            Controls.Add(btnCarregarX);
            Controls.Add(btnCarregarY);
            Controls.Add(btnSalvar);
            Controls.Add(picX);
            Controls.Add(picY);
            Controls.Add(picResultado);
            Controls.Add(lblX);
            Controls.Add(lblY);
            Controls.Add(lblResultado);
            Controls.Add(lblOps);
            Controls.Add(btnAnd);
            Controls.Add(btnOr);
            Controls.Add(btnXor);
            Controls.Add(btnNotX);
            Controls.Add(btnNotY);
            Controls.Add(btnNotXAndY);
        }

        private void CriarBotao(Button btn, string texto, int x, int y, Color cor, EventHandler handler)
        {
            btn.Text = texto;
            btn.Location = new Point(x, y);
            btn.Size = new Size(155, 32);
            btn.BackColor = cor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += handler;
        }

        private void CriarBotaoOp(Button btn, string texto, int x, int y)
        {
            btn.Text = texto;
            btn.Location = new Point(x, y);
            btn.Size = new Size(185, 34);
            btn.BackColor = Color.FromArgb(60, 100, 170);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5f);
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

        private Button btnCarregarX, btnCarregarY, btnSalvar;
        private Button btnAnd, btnOr, btnXor, btnNotX, btnNotY, btnNotXAndY;
        private PictureBox picX, picY, picResultado;
        private Label lblX, lblY, lblResultado, lblTitulo, lblOps;
    }
}
