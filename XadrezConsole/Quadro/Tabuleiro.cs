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
    }
}
