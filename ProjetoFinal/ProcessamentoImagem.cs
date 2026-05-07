using System;
using System.Drawing;

namespace ProjetoFinal
{
    public static class ProcessamentoImagem
    {
        // Garante que o valor fica entre 0 e 255
        private static int Travar(int v) => v < 0 ? 0 : v > 255 ? 255 : v;

        // Retorna a menor dimensão entre duas imagens
        private static (int w, int h) Minimo(Bitmap a, Bitmap b) =>
            (Math.Min(a.Width, b.Width), Math.Min(a.Height, b.Height));

        // Técnica 2 — armazena pixels em matriz Color[linha, coluna]
        public static Color[,] ParaMatriz(Bitmap bmp)
        {
            var m = new Color[bmp.Height, bmp.Width];
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                    m[y, x] = bmp.GetPixel(x, y);
            return m;
        }

        // Técnica 11 — RGB para escala de cinza: I = (R+G+B)/3
        public static Bitmap ConverterCinza(Bitmap img)
        {
            var r = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                {
                    var c = img.GetPixel(x, y);
                    int i = (c.R + c.G + c.B) / 3;
                    r.SetPixel(x, y, Color.FromArgb(i, i, i));
                }
            return r;
        }

        // Técnica 3 — somar duas imagens (OVERFLOW → trava em 255)
        public static Bitmap SomarImagens(Bitmap a, Bitmap b)
        {
            var (w, h) = Minimo(a, b);
            var r = new Bitmap(w, h);
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    var ca = a.GetPixel(x, y);
                    var cb = b.GetPixel(x, y);
                    r.SetPixel(x, y, Color.FromArgb(
                        Travar(ca.R + cb.R),
                        Travar(ca.G + cb.G),
                        Travar(ca.B + cb.B)));
                }
            return r;
        }

        // Técnica 4 — somar constante em cada pixel (aumentar brilho)
        public static Bitmap SomarConstante(Bitmap img, int c)
        {
            var r = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                {
                    var p = img.GetPixel(x, y);
                    r.SetPixel(x, y, Color.FromArgb(
                        Travar(p.R + c), Travar(p.G + c), Travar(p.B + c)));
                }
            return r;
        }

        // Técnica 5 — subtrair duas imagens (UNDERFLOW → trava em 0)
        public static Bitmap SubtrairImagens(Bitmap a, Bitmap b)
        {
            var (w, h) = Minimo(a, b);
            var r = new Bitmap(w, h);
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    var ca = a.GetPixel(x, y);
                    var cb = b.GetPixel(x, y);
                    r.SetPixel(x, y, Color.FromArgb(
                        Travar(ca.R - cb.R),
                        Travar(ca.G - cb.G),
                        Travar(ca.B - cb.B)));
                }
            return r;
        }

        // Técnica 6 — subtrair constante de cada pixel (diminuir brilho)
        public static Bitmap SubtrairConstante(Bitmap img, int c)
        {
            var r = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                {
                    var p = img.GetPixel(x, y);
                    r.SetPixel(x, y, Color.FromArgb(
                        Travar(p.R - c), Travar(p.G - c), Travar(p.B - c)));
                }
            return r;
        }

        // Técnica 7 — multiplicar constante (contraste)
        public static Bitmap MultiplicarConstante(Bitmap img, double fator)
        {
            var r = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                {
                    var p = img.GetPixel(x, y);
                    r.SetPixel(x, y, Color.FromArgb(
                        Travar((int)(p.R * fator)),
                        Travar((int)(p.G * fator)),
                        Travar((int)(p.B * fator))));
                }
            return r;
        }

        // Técnica 8 — dividir constante (contraste)
        public static Bitmap DividirConstante(Bitmap img, double fator)
        {
            if (fator == 0) fator = 1;
            var r = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                {
                    var p = img.GetPixel(x, y);
                    r.SetPixel(x, y, Color.FromArgb(
                        Travar((int)(p.R / fator)),
                        Travar((int)(p.G / fator)),
                        Travar((int)(p.B / fator))));
                }
            return r;
        }

        // Técnica 12 — inverter da esquerda para a direita
        public static Bitmap InvertarHorizontal(Bitmap img)
        {
            var r = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                    r.SetPixel(img.Width - 1 - x, y, img.GetPixel(x, y));
            return r;
        }

        // Técnica 13 — inverter de cima para baixo
        public static Bitmap InvertarVertical(Bitmap img)
        {
            var r = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                    r.SetPixel(x, img.Height - 1 - y, img.GetPixel(x, y));
            return r;
        }

        // Técnica 14 — diferença entre duas imagens: E = (A-B) + (B-A)
        public static Bitmap DiferencaImagens(Bitmap a, Bitmap b)
        {
            var c = SubtrairImagens(a, b);
            var d = SubtrairImagens(b, a);
            return SomarImagens(c, d);
        }

        // Técnica 15 — blending: E = alpha*A + (1-alpha)*B
        public static Bitmap Blending(Bitmap a, Bitmap b, double alpha)
        {
            var (w, h) = Minimo(a, b);
            var r = new Bitmap(w, h);
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    var ca = a.GetPixel(x, y);
                    var cb = b.GetPixel(x, y);
                    r.SetPixel(x, y, Color.FromArgb(
                        Travar((int)(alpha * ca.R + (1 - alpha) * cb.R)),
                        Travar((int)(alpha * ca.G + (1 - alpha) * cb.G)),
                        Travar((int)(alpha * ca.B + (1 - alpha) * cb.B))));
                }
            return r;
        }

        // Técnica 16 — média de duas imagens: R = (A+B)/2
        public static Bitmap Media(Bitmap a, Bitmap b)
        {
            var (w, h) = Minimo(a, b);
            var r = new Bitmap(w, h);
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    var ca = a.GetPixel(x, y);
                    var cb = b.GetPixel(x, y);
                    r.SetPixel(x, y, Color.FromArgb(
                        (ca.R + cb.R) / 2,
                        (ca.G + cb.G) / 2,
                        (ca.B + cb.B) / 2));
                }
            return r;
        }

        // Converte para imagem binária antes das operações lógicas
        private static Bitmap Binarizar(Bitmap img)
        {
            var r = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                {
                    var c = img.GetPixel(x, y);
                    int med = (c.R + c.G + c.B) / 3;
                    int v = med < 128 ? 0 : 255;
                    r.SetPixel(x, y, Color.FromArgb(v, v, v));
                }
            return r;
        }

        // Técnica 17 — AND lógico bit a bit
        public static Bitmap And(Bitmap a, Bitmap b)
        {
            var ba = Binarizar(a);
            var bb = Binarizar(b);
            var (w, h) = Minimo(ba, bb);
            var r = new Bitmap(w, h);
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    int v = ba.GetPixel(x, y).R & bb.GetPixel(x, y).R;
                    v = v == 0 ? 0 : 255;
                    r.SetPixel(x, y, Color.FromArgb(v, v, v));
                }
            return r;
        }

        // Técnica 17 — OR lógico bit a bit
        public static Bitmap Or(Bitmap a, Bitmap b)
        {
            var ba = Binarizar(a);
            var bb = Binarizar(b);
            var (w, h) = Minimo(ba, bb);
            var r = new Bitmap(w, h);
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    int v = ba.GetPixel(x, y).R | bb.GetPixel(x, y).R;
                    v = v == 0 ? 0 : 255;
                    r.SetPixel(x, y, Color.FromArgb(v, v, v));
                }
            return r;
        }

        // Técnica 17 — XOR lógico bit a bit
        public static Bitmap Xor(Bitmap a, Bitmap b)
        {
            var ba = Binarizar(a);
            var bb = Binarizar(b);
            var (w, h) = Minimo(ba, bb);
            var r = new Bitmap(w, h);
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    int v = ba.GetPixel(x, y).R ^ bb.GetPixel(x, y).R;
                    v = v == 0 ? 0 : 255;
                    r.SetPixel(x, y, Color.FromArgb(v, v, v));
                }
            return r;
        }

        // Técnica 17 — NOT lógico
        public static Bitmap Not(Bitmap img)
        {
            var bin = Binarizar(img);
            var r = new Bitmap(bin.Width, bin.Height);
            for (int y = 0; y < bin.Height; y++)
                for (int x = 0; x < bin.Width; x++)
                {
                    int v = bin.GetPixel(x, y).R == 0 ? 255 : 0;
                    r.SetPixel(x, y, Color.FromArgb(v, v, v));
                }
            return r;
        }

        // Técnica 18 — limiarização: G(x,y) = 1 se I >= T, senão 0
        public static Bitmap Limiarizar(Bitmap img, int t)
        {
            var cinza = ConverterCinza(img);
            var r = new Bitmap(cinza.Width, cinza.Height);
            for (int y = 0; y < cinza.Height; y++)
                for (int x = 0; x < cinza.Width; x++)
                {
                    int v = cinza.GetPixel(x, y).R >= t ? 255 : 0;
                    r.SetPixel(x, y, Color.FromArgb(v, v, v));
                }
            return r;
        }

        // Técnica 19 — negativo: G(x,y) = 255 - F(x,y)
        public static Bitmap Negativo(Bitmap img)
        {
            var r = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                {
                    var c = img.GetPixel(x, y);
                    r.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            return r;
        }

        // Técnica 22 — filtro gaussiano: kernel N×N com desvio-padrão sigma, normalizado, aplicado por convolução
        public static Bitmap FiltroGaussiano(Bitmap img, int tamanho, double sigma)
        {
            if (tamanho % 2 == 0) tamanho++;
            int w = img.Width, h = img.Height;
            var resultado = new Bitmap(w, h);
            int meio = tamanho / 2;

            var kernel = new double[tamanho, tamanho];
            double doisSig2 = 2.0 * sigma * sigma;
            double soma = 0;
            for (int ky = -meio; ky <= meio; ky++)
                for (int kx = -meio; kx <= meio; kx++)
                {
                    double v = Math.Exp(-(kx * kx + ky * ky) / doisSig2) / (Math.PI * doisSig2);
                    kernel[ky + meio, kx + meio] = v;
                    soma += v;
                }
            for (int ky = 0; ky < tamanho; ky++)
                for (int kx = 0; kx < tamanho; kx++)
                    kernel[ky, kx] /= soma;

            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    double r = 0, g = 0, b = 0;
                    for (int ky = 0; ky < tamanho; ky++)
                        for (int kx = 0; kx < tamanho; kx++)
                        {
                            int px = Math.Clamp(x + kx - meio, 0, w - 1);
                            int py = Math.Clamp(y + ky - meio, 0, h - 1);
                            var p = img.GetPixel(px, py);
                            double peso = kernel[ky, kx];
                            r += p.R * peso; g += p.G * peso; b += p.B * peso;
                        }
                    resultado.SetPixel(x, y, Color.FromArgb(
                        Math.Clamp((int)Math.Round(r), 0, 255),
                        Math.Clamp((int)Math.Round(g), 0, 255),
                        Math.Clamp((int)Math.Round(b), 0, 255)));
                }
            return resultado;
        }

        // Técnica 21 — suavização conservativa: cp > max → max; cp < min → min; senão mantém
        public static Bitmap SuavizacaoConservativa(Bitmap img)
        {
            int w = img.Width, h = img.Height;
            var result = new Bitmap(w, h);
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    var cp = img.GetPixel(x, y);
                    int minR = 255, maxR = 0;
                    int minG = 255, maxG = 0;
                    int minB = 255, maxB = 0;
                    for (int dy = -1; dy <= 1; dy++)
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
                    int r = cp.R > maxR ? maxR : cp.R < minR ? minR : cp.R;
                    int g = cp.G > maxG ? maxG : cp.G < minG ? minG : cp.G;
                    int b = cp.B > maxB ? maxB : cp.B < minB ? minB : cp.B;
                    result.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            return result;
        }

        // Técnica 20 — equalização de histograma
        // Passo 1: histograma | Passo 2: CFD | Passo 3: h(v) = floor((CFD(v)-CFDmin)/(MxN-CFDmin)*(L-1))
        public static Bitmap EqualizarHistograma(Bitmap img)
        {
            var cinza = ConverterCinza(img);
            int total = cinza.Width * cinza.Height;

            int[] hist = new int[256];
            for (int y = 0; y < cinza.Height; y++)
                for (int x = 0; x < cinza.Width; x++)
                    hist[cinza.GetPixel(x, y).R]++;

            int[] cfd = new int[256];
            cfd[0] = hist[0];
            for (int i = 1; i < 256; i++)
                cfd[i] = cfd[i - 1] + hist[i];

            int cfdMin = 0;
            for (int i = 0; i < 256; i++)
                if (cfd[i] > 0) { cfdMin = cfd[i]; break; }

            int[] lut = new int[256];
            int denom = total - cfdMin;
            for (int v = 0; v < 256; v++)
                lut[v] = denom == 0 ? 0 : Travar((int)Math.Floor((double)(cfd[v] - cfdMin) / denom * 255));

            var r = new Bitmap(cinza.Width, cinza.Height);
            for (int y = 0; y < cinza.Height; y++)
                for (int x = 0; x < cinza.Width; x++)
                {
                    int nv = lut[cinza.GetPixel(x, y).R];
                    r.SetPixel(x, y, Color.FromArgb(nv, nv, nv));
                }
            return r;
        }
    }
}
