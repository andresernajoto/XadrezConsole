using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;

namespace XadrezConsole.Xadrez {
    // herdado de Peca
    class Dama : Peca {
        // utiliza as propriedades herdade
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        // atribui um nome a peça
        public override string ToString() {
            return "D";
        }

        /* método que indica que uma peça pode se mover
         se o quadrado do tabuleiro está livre ou se há
        uma peça inimigo ao seu redor */
        private bool PodeMover(Posicao posicao) {
            Peca peca = Tab.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        // método que aplica os possíveis movimentos da Torre
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // acima
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            }

            // direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            }

            // abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            }

            // esquerda
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            }

            // nordeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
            }

            // noroeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
            }

            // sudeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
            }

            // sudoeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
            }

            return mat;
        }
    }
}
