using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;

namespace XadrezConsole.Xadrez {
    // herdado de Peca
    class Torre : Peca {
        // utiliza as propriedades herdade
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        // atribui um nome a peça
        public override string ToString() {
            return "T";
        }

        /* método que indica que uma peça pode se mover
         se o quadrado do tabuleiro está livre ou se há
        uma peça inimigo ao seu redor */
        private bool PodeMover(Posicao posicao) {
            Peca peca = Tab.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        // método que aplica os possíveis movimentos do Rei
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // acima
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.peca(posicao) != null && Tab.peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.Linha = posicao.Linha - 1;
            }

            // direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.peca(posicao) != null && Tab.peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.Coluna = posicao.Coluna + 1;
            }

            // abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.peca(posicao) != null && Tab.peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.Linha = posicao.Linha + 1;
            }

            // esquerda
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tab.peca(posicao) != null && Tab.peca(posicao).Cor != Cor) {
                    break;
                }

                posicao.Coluna = posicao.Coluna - 1;
            }

            return mat;
        }
    }
}
