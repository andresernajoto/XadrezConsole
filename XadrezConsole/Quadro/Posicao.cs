namespace XadrezConsole.Quadro {
    class Posicao {
        // declaração das propriedades da classe
        public int Linha { get; set; }
        public int Coluna { get; set; }

        // construtor com a posição das Peças
        public Posicao(int linha, int coluna) {
            Linha = linha;
            Coluna = coluna;
        }

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
