using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica05
{
    public partial class Form1 : Form
    {
        private Bitmap? imagemOriginal;
        private Bitmap? imagemCinza;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecione uma imagem colorida";
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemOriginal = new Bitmap(dlg.FileName);
            picOriginal.Image = imagemOriginal;
            picOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            lblOriginal.Text = $"Original: {imagemOriginal.Width}x{imagemOriginal.Height} px";

            // Limpa resultado anterior
            picCinza.Image = null;
            lblCinza.Text = "Clique em Converter para ver o resultado";
            imagemCinza = null;
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            if (imagemOriginal == null)
            {
                MessageBox.Show("Carregue uma imagem primeiro.", "Aviso");
                return;
            }

            imagemCinza = ConverterParaCinza(imagemOriginal);

            picCinza.Image = imagemCinza;
            picCinza.SizeMode = PictureBoxSizeMode.Zoom;
            lblCinza.Text = $"Escala de Cinza: {imagemCinza.Width}x{imagemCinza.Height} px  |  Fórmula: I = (R+G+B)/3";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imagemCinza == null)
            {
                MessageBox.Show("Converta a imagem primeiro.", "Aviso");
                return;
            }

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Salvar imagem em escala de cinza";
            dlg.Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg";
            dlg.FileName = "cinza";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemCinza.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }

        // Fórmula do slide: I = (R + G + B) / 3
        private Bitmap ConverterParaCinza(Bitmap original)
        {
            Bitmap resultado = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixel = original.GetPixel(x, y);

                    int intensidade = (pixel.R + pixel.G + pixel.B) / 3;

                    // Aplica o mesmo valor nos três canais para ficar cinza
                    Color cinza = Color.FromArgb(intensidade, intensidade, intensidade);
                    resultado.SetPixel(x, y, cinza);
                }
            }

            return resultado;
        }
    }
}
