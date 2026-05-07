using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica08
{
    public partial class Form1 : Form
    {
        private Bitmap? imagemA;
        private Bitmap? imagemB;
        private Bitmap? imagemC; // C = A - B
        private Bitmap? imagemD; // D = B - A
        private Bitmap? imagemE; // E = C + D

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarregarA_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecione a Imagem A";
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemA = new Bitmap(dlg.FileName);
            picA.Image = imagemA;
            picA.SizeMode = PictureBoxSizeMode.Zoom;
            lblA.Text = $"A: {imagemA.Width}x{imagemA.Height}";
        }

        private void btnCarregarB_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecione a Imagem B";
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemB = new Bitmap(dlg.FileName);
            picB.Image = imagemB;
            picB.SizeMode = PictureBoxSizeMode.Zoom;
            lblB.Text = $"B: {imagemB.Width}x{imagemB.Height}";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (imagemA == null || imagemB == null)
            {
                MessageBox.Show("Carregue as duas imagens (A e B) primeiro.", "Aviso");
                return;
            }

            int largura = Math.Min(imagemA.Width, imagemB.Width);
            int altura  = Math.Min(imagemA.Height, imagemB.Height);

            imagemC = new Bitmap(largura, altura);
            imagemD = new Bitmap(largura, altura);
            imagemE = new Bitmap(largura, altura);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Color a = imagemA.GetPixel(x, y);
                    Color b = imagemB.GetPixel(x, y);

                    // C = A - B  (UNDERFLOW → trava em 0)
                    int cr = Math.Max(a.R - b.R, 0);
                    int cg = Math.Max(a.G - b.G, 0);
                    int cb = Math.Max(a.B - b.B, 0);

                    // D = B - A  (UNDERFLOW → trava em 0)
                    int dr = Math.Max(b.R - a.R, 0);
                    int dg = Math.Max(b.G - a.G, 0);
                    int db = Math.Max(b.B - a.B, 0);

                    // E = C + D  (OVERFLOW → trava em 255)
                    int er = Math.Min(cr + dr, 255);
                    int eg = Math.Min(cg + dg, 255);
                    int eb = Math.Min(cb + db, 255);

                    imagemC.SetPixel(x, y, Color.FromArgb(cr, cg, cb));
                    imagemD.SetPixel(x, y, Color.FromArgb(dr, dg, db));
                    imagemE.SetPixel(x, y, Color.FromArgb(er, eg, eb));
                }
            }

            picC.Image = imagemC;
            picC.SizeMode = PictureBoxSizeMode.Zoom;

            picD.Image = imagemD;
            picD.SizeMode = PictureBoxSizeMode.Zoom;

            picE.Image = imagemE;
            picE.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imagemC == null || imagemD == null || imagemE == null)
            {
                MessageBox.Show("Calcule a diferença primeiro.", "Aviso");
                return;
            }

            using FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Escolha a pasta para salvar os resultados";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            string pasta = dlg.SelectedPath;
            imagemC.Save(System.IO.Path.Combine(pasta, "C_A-B.png"));
            imagemD.Save(System.IO.Path.Combine(pasta, "D_B-A.png"));
            imagemE.Save(System.IO.Path.Combine(pasta, "E_C+D.png"));

            MessageBox.Show("Imagens C, D e E salvas com sucesso!", "Salvo");
        }
    }
}
