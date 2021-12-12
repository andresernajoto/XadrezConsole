using XadrezConsole.Quadro.Enums;

namespace XadrezConsole.Quadro {
    class Peca {
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
    }
}
