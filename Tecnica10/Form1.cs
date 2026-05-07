using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica10
{
    public partial class Form1 : Form
    {
        private Bitmap? imagemP;
        private Bitmap? imagemQ;
        private Bitmap? imagemR;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarregarP_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecione a Imagem P";
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemP = new Bitmap(dlg.FileName);
            picP.Image = imagemP;
            picP.SizeMode = PictureBoxSizeMode.Zoom;
            lblP.Text = $"P: {imagemP.Width}x{imagemP.Height}";
        }

        private void btnCarregarQ_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecione a Imagem Q";
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemQ = new Bitmap(dlg.FileName);
            picQ.Image = imagemQ;
            picQ.SizeMode = PictureBoxSizeMode.Zoom;
            lblQ.Text = $"Q: {imagemQ.Width}x{imagemQ.Height}";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (imagemP == null || imagemQ == null)
            {
                MessageBox.Show("Carregue as duas imagens (P e Q) primeiro.", "Aviso");
                return;
            }

            int largura = Math.Min(imagemP.Width, imagemQ.Width);
            int altura  = Math.Min(imagemP.Height, imagemQ.Height);

            imagemR = new Bitmap(largura, altura);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Color p = imagemP.GetPixel(x, y);
                    Color q = imagemQ.GetPixel(x, y);

                    // R(i,j) = ( P(i,j) + Q(i,j) ) / 2
                    int r = (p.R + q.R) / 2;
                    int g = (p.G + q.G) / 2;
                    int b = (p.B + q.B) / 2;

                    imagemR.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            picR.Image = imagemR;
            picR.SizeMode = PictureBoxSizeMode.Zoom;
            lblR.Text = $"R = (P + Q) / 2   |   {largura}x{altura} px";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imagemR == null)
            {
                MessageBox.Show("Calcule a média primeiro.", "Aviso");
                return;
            }

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Salvar imagem resultante";
            dlg.Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg";
            dlg.FileName = "media";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemR.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }
    }
}
