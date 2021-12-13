using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;
using XadrezConsole.Quadro.Exceptions;

namespace XadrezConsole.Xadrez {
    class PartidaDeXadrez {
        // declaração das propriedades da classe
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        /* construtor que recebe um tabuleiro de ordem 8,
         começando no turno 1 e o primeiro jogador a se
        movimentar é o que possui as peças brancas */
        
        /* o fim da partida começa em falso e nos é
         permitido colocar peças pelo construtor */
        public PartidaDeXadrez() {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }

        /* faz a peça receber um movimento, saindo de sua
         posição de origem, e se movimentando para a de
        destino */
        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca peca = Tab.RetirarPeca(origem);
            //peca.IncrementarMovimento();

            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(peca, destino);
        }

        // método que altera o turno e permite as jogadas
        public void RealizaJogada(Posicao origem, Posicao destino) {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        // método que verifica as possíveis jogadas da posição de origem
        public void ValidarOrigem(Posicao posicao) {
            if (Tab.peca(posicao) == null) {
                throw new TabuleiroException("Não existe peça nesta posição de origem!");
            }

            if (JogadorAtual != Tab.peca(posicao).Cor) {
                throw new TabuleiroException("A peça de origem é de outro jogador!");
            }

            if (!Tab.peca(posicao).ExisteMovimentoPossivel()) {
                throw new TabuleiroException("Não há movimentos possíveis para esta peça de origem!");
            }
        }

        /* método que verifica se a peça na posição
         de origem pode se mover para a de destino */
        public void ValidarDestino(Posicao origem, Posicao destino) {
            if (!Tab.peca(origem).PodeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        // método que altera o jogador após a movimentação das peças
        private void MudaJogador() {
            if (JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            } else {
                JogadorAtual = Cor.Branca;
            }
        }

        // método que coloca todas as peças no tabuleiro
        private void ColocarPecas() {
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 1).ConverterPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d', 1).ConverterPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ConverterPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 2).ConverterPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d', 2).ConverterPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 2).ConverterPosicao());

            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 8).ConverterPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('d', 8).ConverterPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 8).ConverterPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 7).ConverterPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d', 7).ConverterPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 7).ConverterPosicao());
        }
    }
}
