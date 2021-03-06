using XadrezConsole.Quadro.Enums;

namespace XadrezConsole.Quadro {
    abstract class Peca {
        // declaração das propriedades da classe
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        // construtor que recebe as propriedades e inicia com o movimento em 0 e a posição nula
        public Peca(Tabuleiro tab, Cor cor) {
            Posicao = null;
            Tab = tab;
            Cor = cor;
            QtdeMovimentos = 0;
        }

        // método que aumenta a quantidade de movimentos em 1
        public void IncrementarMovimento() {
            QtdeMovimentos++;
        }

        // método que diminui a quantidade de movimentos em 1
        public void DecrementarMovimento() {
            QtdeMovimentos--;
        }

        // método que verifica se há movimento possível para determinada peça
        public bool ExisteMovimentoPossivel() {
            bool[,] mat = MovimentosPossiveis();

            for (int i = 0; i < Tab.Linhas; i++) {
                for (int j = 0; j < Tab.Colunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        /* método que verifica se a posição é
         um movimento possível a ser jogado */
        public bool MovimentoPossivel(Posicao posicao) {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        // método abstrato que retorna os possíveis movimentos de uma peça
        public abstract bool[,] MovimentosPossiveis();

    }
}
