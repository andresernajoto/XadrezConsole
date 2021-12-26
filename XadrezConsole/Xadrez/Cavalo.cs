using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;

namespace XadrezConsole.Xadrez {
    // herdado de Peca
    class Cavalo : Peca {
        // utiliza as propriedades herdade
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        // atribui um nome a peça
        public override string ToString() {
            return "C";
        }

        /* método que indica que uma peça pode se mover
         se o quadrado do tabuleiro está livre ou se há
        uma peça inimigo ao seu redor */
        private bool PodeMover(Posicao posicao) {
            Peca peca = Tab.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        // método que aplica os possíveis movimentos do Bispo
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // sobe direita
            posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // sobe esquerda
            posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // direita sobe
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // direita desce
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // desce direita
            posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // desce esquerda
            posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // esquerda sobe
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // esquerda desce
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            return mat;
        }
    }
}
