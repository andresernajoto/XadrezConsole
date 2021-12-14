using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;

namespace XadrezConsole.Xadrez {
    // herdado de Peca
    class Peao : Peca {
        // utiliza as propriedades herdade
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        // atribui um nome a peça
        public override string ToString() {
            return "P";
        }

        /* método que verifica se existe uma peça inimiga
         ocupando determinada posição no tabuleiro */
        private bool ExisteInimigo(Posicao posicao) {
            Peca peca = Tab.peca(posicao);
            return peca != null || peca.Cor != Cor;
        }

        /* método que indica que a peça pode se mover
         caso a posição do tabuleiro esteja livre */
        private bool PodeMover(Posicao posicao) {
            return Tab.peca(posicao) == null;
        }

        // método que aplica os possíveis movimentos da Torre
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao posicao = new Posicao(0, 0);

            if (Cor == Cor.Branca) {
                // uma casa acima
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                // duas casas acima se não tiver se movido antes
                posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.PosicaoValida(posicao) && PodeMover(posicao) && QtdeMovimentos == 0) {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                // captura uma peça à nordeste
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(posicao) && ExisteInimigo(posicao)) {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                // captura uma peça à noroeste
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(posicao) && ExisteInimigo(posicao)) {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
            } else {
                // uma casa abaixo
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                // duas casas abaixo se não tiver se movido antes
                posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.PosicaoValida(posicao) && PodeMover(posicao) && QtdeMovimentos == 0) {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                // captura uma peça à sudeste
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(posicao) && ExisteInimigo(posicao)) {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                // captura uma peça à sudoeste
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(posicao) && ExisteInimigo(posicao)) {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
            }

            return mat;
        }
    }
}
