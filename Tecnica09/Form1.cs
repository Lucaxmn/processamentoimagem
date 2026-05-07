using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica09
{
    public partial class Form1 : Form
    {
        private Bitmap? imagemA;
        private Bitmap? imagemB;
        private Bitmap? imagemResultado;

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

        private void btnMisturar_Click(object sender, EventArgs e)
        {
            if (imagemA == null || imagemB == null)
            {
                MessageBox.Show("Carregue as duas imagens primeiro.", "Aviso");
                return;
            }

            double alpha = (double)trackAlpha.Value / 100.0;
            AplicarBlending(alpha);
        }

        // Atualiza o resultado em tempo real conforme o slider muda
        private void trackAlpha_Scroll(object sender, EventArgs e)
        {
            double alpha = (double)trackAlpha.Value / 100.0;
            lblAlpha.Text = $"α = {alpha:F2}   →   Imagem A: {alpha:P0}   |   Imagem B: {(1 - alpha):P0}";

            if (imagemA != null && imagemB != null)
                AplicarBlending(alpha);
        }

        private void AplicarBlending(double alpha)
        {
            int largura = Math.Min(imagemA!.Width, imagemB!.Width);
            int altura  = Math.Min(imagemA.Height, imagemB.Height);

            imagemResultado = new Bitmap(largura, altura);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Color a = imagemA.GetPixel(x, y);
                    Color b = imagemB.GetPixel(x, y);

                    // E = α * A + (1 - α) * B
                    int r = (int)(alpha * a.R + (1 - alpha) * b.R);
                    int g = (int)(alpha * a.G + (1 - alpha) * b.G);
                    int bv = (int)(alpha * a.B + (1 - alpha) * b.B);

                    // Garante que fique entre 0 e 255
                    r  = Math.Max(0, Math.Min(255, r));
                    g  = Math.Max(0, Math.Min(255, g));
                    bv = Math.Max(0, Math.Min(255, bv));

                    imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, bv));
                }
            }

            picResultado.Image = imagemResultado;
            picResultado.SizeMode = PictureBoxSizeMode.Zoom;
            lblResultado.Text = $"E = {alpha:F2} × A + {(1 - alpha):F2} × B";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imagemResultado == null)
            {
                MessageBox.Show("Aplique o blending primeiro.", "Aviso");
                return;
            }

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Salvar imagem resultante";
            dlg.Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg";
            dlg.FileName = "blending";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemResultado.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }
    }
}
