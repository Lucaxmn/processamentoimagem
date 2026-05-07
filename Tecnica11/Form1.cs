using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica11
{
    public partial class Form1 : Form
    {
        private Bitmap? imagemX;
        private Bitmap? imagemY;
        private Bitmap? resultado;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarregarX_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecione a Imagem X";
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemX = Binarizar(new Bitmap(dlg.FileName));
            picX.Image = imagemX;
            picX.SizeMode = PictureBoxSizeMode.Zoom;
            lblX.Text = $"X (binarizada): {imagemX.Width}x{imagemX.Height}";
        }

        private void btnCarregarY_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecione a Imagem Y";
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemY = Binarizar(new Bitmap(dlg.FileName));
            picY.Image = imagemY;
            picY.SizeMode = PictureBoxSizeMode.Zoom;
            lblY.Text = $"Y (binarizada): {imagemY.Width}x{imagemY.Height}";
        }

        private void btnAnd_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            AplicarOperacao((px, py) => (byte)(px & py), "X AND Y");
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            AplicarOperacao((px, py) => (byte)(px | py), "X OR Y");
        }

        private void btnXor_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            AplicarOperacao((px, py) => (byte)(px ^ py), "X XOR Y");
        }

        private void btnNotX_Click(object sender, EventArgs e)
        {
            if (imagemX == null) { MessageBox.Show("Carregue a imagem X primeiro.", "Aviso"); return; }
            AplicarNot(imagemX, "NOT X");
        }

        private void btnNotY_Click(object sender, EventArgs e)
        {
            if (imagemY == null) { MessageBox.Show("Carregue a imagem Y primeiro.", "Aviso"); return; }
            AplicarNot(imagemY, "NOT Y");
        }

        private void btnNotXAndY_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            AplicarOperacao((px, py) => (byte)((~px) & py), "(NOT X) AND Y");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (resultado == null)
            {
                MessageBox.Show("Aplique uma operação primeiro.", "Aviso");
                return;
            }

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg";
            dlg.FileName = "resultado_logico";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            resultado.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }

        // Converte para binário: pixel médio < 128 → preto (0), senão → branco (255)
        private Bitmap Binarizar(Bitmap original)
        {
            Bitmap bin = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color c = original.GetPixel(x, y);
                    int media = (c.R + c.G + c.B) / 3;
                    int val = media < 128 ? 0 : 255;
                    bin.SetPixel(x, y, Color.FromArgb(val, val, val));
                }
            }

            return bin;
        }

        // Aplica operação bit a bit entre X e Y usando a função passada
        private void AplicarOperacao(Func<byte, byte, byte> operacao, string nome)
        {
            int largura = Math.Min(imagemX!.Width, imagemY!.Width);
            int altura  = Math.Min(imagemX.Height, imagemY.Height);

            resultado = new Bitmap(largura, altura);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    byte px = imagemX.GetPixel(x, y).R;
                    byte py = imagemY.GetPixel(x, y).R;

                    byte val = operacao(px, py);
                    // Garante que o resultado seja binário (0 ou 255)
                    val = val == 0 ? (byte)0 : (byte)255;

                    resultado.SetPixel(x, y, Color.FromArgb(val, val, val));
                }
            }

            picResultado.Image = resultado;
            picResultado.SizeMode = PictureBoxSizeMode.Zoom;
            lblResultado.Text = nome;
        }

        private void AplicarNot(Bitmap img, string nome)
        {
            resultado = new Bitmap(img.Width, img.Height);

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    byte val = img.GetPixel(x, y).R;
                    byte inv = val == 0 ? (byte)255 : (byte)0;
                    resultado.SetPixel(x, y, Color.FromArgb(inv, inv, inv));
                }
            }

            picResultado.Image = resultado;
            picResultado.SizeMode = PictureBoxSizeMode.Zoom;
            lblResultado.Text = nome;
        }

        private bool ValidarDuas()
        {
            if (imagemX == null || imagemY == null)
            {
                MessageBox.Show("Carregue as duas imagens (X e Y) primeiro.", "Aviso");
                return false;
            }
            return true;
        }
    }
}
