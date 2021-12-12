using XadrezConsole.Quadro;

namespace XadrezConsole.Xadrez {
    class PosicaoXadrez {
        // declaração das propriedades da classe
        public char Coluna { get; set; }
        public int Linha { get; set; }

        // construtor que recebe uma letra para a coluna e um número para linha
        public PosicaoXadrez(char coluna, int linha) {
            Coluna = coluna;
            Linha = linha;
        }

        // método que converte as posições da matriz para as do tabuleiro de xadrez
        public Posicao ConverterPosicao() {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        // override da impressão das propriedades
        public override string ToString() {
            return "" + Coluna + Linha;
        }
    }
}
