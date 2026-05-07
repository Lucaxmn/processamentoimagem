using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica18
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
            lblResultado.Text = "Clique em Aplicar Suavização";
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (imagemOriginal == null)
            {
                MessageBox.Show("Carregue uma imagem primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            imagemResultado = SuavizacaoConservativa(imagemOriginal);

            picResultado.Image = imagemResultado;
            picResultado.SizeMode = PictureBoxSizeMode.Zoom;
            lblResultado.Text = $"Resultado: {imagemResultado.Width}x{imagemResultado.Height}px";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imagemResultado == null)
            {
                MessageBox.Show("Aplique a suavização primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dlg = new SaveFileDialog
            {
                Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg",
                FileName = "suavizacao_conservativa"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemResultado.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }

        // Suavização Conservativa (vizinhança 3x3):
        // Para cada canal: se cp > max(vizinhos) → cp = max; se cp < min(vizinhos) → cp = min; senão mantém.
        private static Bitmap SuavizacaoConservativa(Bitmap img)
        {
            int w = img.Width, h = img.Height;
            var resultado = new Bitmap(w, h);

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    var cp = img.GetPixel(x, y);

                    int minR = 255, maxR = 0;
                    int minG = 255, maxG = 0;
                    int minB = 255, maxB = 0;

                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            if (dx == 0 && dy == 0) continue;
                            int nx = x + dx, ny = y + dy;
                            if (nx < 0 || nx >= w || ny < 0 || ny >= h) continue;

                            var n = img.GetPixel(nx, ny);
                            if (n.R < minR) minR = n.R; if (n.R > maxR) maxR = n.R;
                            if (n.G < minG) minG = n.G; if (n.G > maxG) maxG = n.G;
                            if (n.B < minB) minB = n.B; if (n.B > maxB) maxB = n.B;
                        }
                    }

                    int r = cp.R > maxR ? maxR : cp.R < minR ? minR : cp.R;
                    int g = cp.G > maxG ? maxG : cp.G < minG ? minG : cp.G;
                    int b = cp.B > maxB ? maxB : cp.B < minB ? minB : cp.B;

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return resultado;
        }
    }
}
