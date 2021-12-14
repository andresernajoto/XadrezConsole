using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;

namespace XadrezConsole.Xadrez {
    // herdado de Peca
    class Bispo : Peca {
        // utiliza as propriedades herdade
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        // atribui um nome a peça
        public override string ToString() {
            return "B";
        }

        /* método que indica que uma peça pode se mover
         se o quadrado do tabuleiro está livre ou se há
        uma peça inimigo ao seu redor */
        private bool PodeMover(Posicao posicao) {
            Peca peca = Tab.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        // método que aplica os possíveis movimentos do Bispo
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // nordeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.peca(posicao) != null && Tab.peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            }

            // noroeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.peca(posicao) != null && Tab.peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            }

            // sudeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.peca(posicao) != null && Tab.peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            }

            // sudoeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.peca(posicao) != null && Tab.peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            }

            return mat;
        }
    }
}
