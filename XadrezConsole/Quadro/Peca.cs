using XadrezConsole.Quadro.Enums;

namespace XadrezConsole.Quadro {
    class Peca {

        // declaração das propriedades da classe
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        // construtor que recebe as propriedades e inicia com o movimento em 0
        public Peca(Posicao posicao, Cor cor, Tabuleiro tab) {
            Posicao = posicao;
            Cor = cor;
            Tab = tab;
            QtdeMovimentos = 0;
        }
    }
}
