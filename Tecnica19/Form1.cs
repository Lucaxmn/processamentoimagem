using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica19
{
    public partial class Form1 : Form
    {
        private Bitmap? imagemOriginal;
        private Bitmap? imagemResultado;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Selecione uma imagem",
                Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemOriginal = new Bitmap(dlg.FileName);
            imagemResultado = null;

            picOriginal.Image = imagemOriginal;
            picOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            lblOriginal.Text = $"Original: {imagemOriginal.Width}x{imagemOriginal.Height}px";

            picResultado.Image = null;
            lblResultado.Text = "Clique em Aplicar Gaussiano";
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (imagemOriginal == null)
            {
                MessageBox.Show("Carregue uma imagem primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tamanho = (int)nudTamanho.Value;
            if (tamanho % 2 == 0) tamanho++;  // garante ímpar
            double sigma = (double)nudSigma.Value;

            imagemResultado = FiltroGaussiano(imagemOriginal, tamanho, sigma);

            picResultado.Image = imagemResultado;
            picResultado.SizeMode = PictureBoxSizeMode.Zoom;
            lblResultado.Text = $"Resultado: {imagemResultado.Width}x{imagemResultado.Height}px  |  Kernel {tamanho}×{tamanho}  σ={sigma:F1}";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imagemResultado == null)
            {
                MessageBox.Show("Aplique o filtro primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dlg = new SaveFileDialog
            {
                Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg",
                FileName = "gaussiano"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemResultado.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }

        // Gera o kernel gaussiano N×N com desvio-padrão sigma e normaliza para soma = 1.
        // f(x,y) = (1 / (2πσ²)) * exp(-(x²+y²) / (2σ²))
        private static double[,] CriarKernel(int tamanho, double sigma)
        {
            var kernel = new double[tamanho, tamanho];
            int meio = tamanho / 2;
            double doisSig2 = 2.0 * sigma * sigma;
            double soma = 0;

            for (int ky = -meio; ky <= meio; ky++)
            {
                for (int kx = -meio; kx <= meio; kx++)
                {
                    double v = Math.Exp(-(kx * kx + ky * ky) / doisSig2) / (Math.PI * doisSig2);
                    kernel[ky + meio, kx + meio] = v;
                    soma += v;
                }
            }

            for (int y = 0; y < tamanho; y++)
                for (int x = 0; x < tamanho; x++)
                    kernel[y, x] /= soma;

            return kernel;
        }

        private static Bitmap FiltroGaussiano(Bitmap img, int tamanho, double sigma)
        {
            int w = img.Width, h = img.Height;
            var resultado = new Bitmap(w, h);
            int meio = tamanho / 2;
            double[,] kernel = CriarKernel(tamanho, sigma);

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    double r = 0, g = 0, b = 0;

                    for (int ky = 0; ky < tamanho; ky++)
                    {
                        for (int kx = 0; kx < tamanho; kx++)
                        {
                            int px = Math.Clamp(x + kx - meio, 0, w - 1);
                            int py = Math.Clamp(y + ky - meio, 0, h - 1);
                            var p = img.GetPixel(px, py);
                            double peso = kernel[ky, kx];
                            r += p.R * peso;
                            g += p.G * peso;
                            b += p.B * peso;
                        }
                    }

                    resultado.SetPixel(x, y, Color.FromArgb(
                        Math.Clamp((int)Math.Round(r), 0, 255),
                        Math.Clamp((int)Math.Round(g), 0, 255),
                        Math.Clamp((int)Math.Round(b), 0, 255)));
                }
            }

            return resultado;
        }
    }
}
