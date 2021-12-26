using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;

namespace XadrezConsole.Xadrez {
    // herdado de Peca
    class Rei : Peca {

        // declaração da propriedade da classe
        private PartidaDeXadrez Partida;

        // utiliza as propriedades herdade
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            Partida = partida;
        }

        // atribui um nome a peça
        public override string ToString() {
            return "R";
        }

        /* método que indica que uma peça pode se mover
         se o quadrado do tabuleiro está livre ou se há
        uma peça inimigo ao seu redor */
        private bool PodeMover(Posicao posicao) {
            Peca peca = Tab.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        /* método que faz o teste com a peça para saber
         se ela é elegível para realizar o roque */
        private bool TesteTorreParaRoque(Posicao posicao) {
            Peca peca = Tab.Peca(posicao);
            return peca != null && peca is Torre && peca.Cor == Cor && peca.QtdeMovimentos == 0;
        }

        // método que aplica os possíveis movimentos do Rei
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // acima
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // nordeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // sudeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // sudoeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // esquerda
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // noroeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao)) {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // # jogada especial: Roque #
            if (QtdeMovimentos == 0 && !Partida.Xeque) {
                // Roque Pequeno
                Posicao posicaoT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posicaoT1)) {
                    Posicao posicao1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao posicao2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tab.Peca(posicao1) == null && Tab.Peca(posicao2) == null) {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // Roque Grande
                Posicao posicaoT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posicaoT2)) {
                    Posicao posicao1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao posicao2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao posicao3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tab.Peca(posicao1) == null && Tab.Peca(posicao2) == null && Tab.Peca(posicao3) == null) {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
