namespace XadrezConsole.Quadro {
    class Posicao {
        // declaração das propriedades da classe
        public int Linha { get; set; }
        public int Coluna { get; set; }

        // construtor que recebe a posição das peças
        public Posicao(int linha, int coluna) {
            Linha = linha;
            Coluna = coluna;
        }

        // método que define a linha e coluna de uma peça
        public void DefinirValores(int linha, int coluna) {
            Linha = linha;
            Coluna = coluna;
        }

        // override para mostrar a posição
        public override string ToString() {
            return Linha + ", " + Coluna;
        }
    }
}
