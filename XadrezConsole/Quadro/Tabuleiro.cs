namespace XadrezConsole.Quadro {
    class Tabuleiro {
        // declaração das propriedades da classe
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        // construtor que define quantas linhas e colunas terão no tabuleiro
        public Tabuleiro(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        // método que permite o acesso das peças e suas posições
        public Peca Peca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }

        // método que permite colocar as peças no tabuleiro
        public void ColocarPeca(Peca peca, Posicao posicao) {
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }
    }
}
