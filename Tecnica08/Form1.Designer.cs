namespace Tecnica08
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
            btnCalcular  = new Button();
            btnSalvar    = new Button();

            picA = new PictureBox();
            picB = new PictureBox();
            picC = new PictureBox();
            picD = new PictureBox();
            picE = new PictureBox();

            lblA = new Label();
            lblB = new Label();
            lblC = new Label();
            lblD = new Label();
            lblE = new Label();

            lblTitulo = new Label();

            // ===== FORM =====
            Text = "Técnica 08 - Diferença entre Duas Imagens";
            ClientSize = new Size(1100, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text = "C = A - B     D = B - A     E = C + D";
            lblTitulo.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Size = new Size(500, 28);

            // ===== BOTÕES =====
            CriarBotao(btnCarregarA, "Carregar A", 20,  48, Color.FromArgb(0, 120, 215), btnCarregarA_Click);
            CriarBotao(btnCarregarB, "Carregar B", 190, 48, Color.FromArgb(0, 120, 215), btnCarregarB_Click);
            CriarBotao(btnCalcular,  "Calcular C, D e E", 360, 48, Color.FromArgb(50, 150, 50),  btnCalcular_Click);
            CriarBotao(btnSalvar,    "Salvar Resultados", 560, 48, Color.FromArgb(180, 80, 0),   btnSalvar_Click);

            // ===== LINHA 1: A e B =====
            CriarPic(picA, 20,  100, 220, 220);
            CriarPic(picB, 260, 100, 220, 220);

            CriarLabel(lblA, "A (original)", 20,  328, 220, Color.DimGray);
            CriarLabel(lblB, "B (original)", 260, 328, 220, Color.DimGray);

            // ===== LINHA 2: C, D e E =====
            CriarPic(picC, 20,  370, 220, 220);
            CriarPic(picD, 260, 370, 220, 220);
            CriarPic(picE, 500, 370, 220, 220);

            CriarLabel(lblC, "C = A - B", 20,  598, 220, Color.FromArgb(0, 100, 0));
            CriarLabel(lblD, "D = B - A", 260, 598, 220, Color.FromArgb(0, 100, 0));
            CriarLabel(lblE, "E = C + D", 500, 598, 220, Color.FromArgb(0, 100, 0));

            // ===== ADICIONAR AO FORM =====
            Controls.Add(lblTitulo);
            Controls.Add(btnCarregarA);
            Controls.Add(btnCarregarB);
            Controls.Add(btnCalcular);
            Controls.Add(btnSalvar);
            Controls.Add(picA);
            Controls.Add(picB);
            Controls.Add(picC);
            Controls.Add(picD);
            Controls.Add(picE);
            Controls.Add(lblA);
            Controls.Add(lblB);
            Controls.Add(lblC);
            Controls.Add(lblD);
            Controls.Add(lblE);
        }

        private void CriarBotao(Button btn, string texto, int x, int y, Color cor, EventHandler handler)
        {
            btn.Text = texto;
            btn.Location = new Point(x, y);
            btn.Size = new Size(160, 34);
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
            lbl.Size = new Size(w, 20);
            lbl.ForeColor = cor;
            lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
        }

        private Button btnCarregarA, btnCarregarB, btnCalcular, btnSalvar;
        private PictureBox picA, picB, picC, picD, picE;
        private Label lblA, lblB, lblC, lblD, lblE, lblTitulo;
    }
}
