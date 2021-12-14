﻿using System.Collections.Generic;
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
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        /* construtor que recebe um tabuleiro de ordem 8,
         começando no turno 1 e o primeiro jogador a se
        movimentar é o que possui as peças brancas */

        /* o fim da partida e o xeque começam em falso e as
         peças são salvas numa lista, assim como as capturadas */
        public PartidaDeXadrez() {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        /* faz a peça receber um movimento, saindo de sua
         posição de origem e se movimentando para a de
        destino. Também adiciona uma peça capturada  à lista */
        public Peca ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca peca = Tab.RetirarPeca(origem);
            peca.IncrementarMovimento();

            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(peca, destino);

            if (pecaCapturada != null) {
                Capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }

        // método que desfaz o movimento de uma peça caso ela esteja em xeque
        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca peca = Tab.RetirarPeca(destino);
            peca.DecrementarMovimento();

            if (pecaCapturada != null) {
                Tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }

            Tab.ColocarPeca(peca, origem);
        }

        /* método que realiza a jogada e indica qual jogador está em xeque.
         Caso o jogador atual esteja em xeque, este não poderá se mover */
        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual)) {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual))) {
                Xeque = true;
            } else {
                Xeque = false;
            }

            // encerra a partida se o jogador estiver em xeque mate
            if (TesteXequeMate(Adversaria(JogadorAtual))) {
                Terminada = true;
            } else {
                Turno++;
                MudaJogador();
            }   
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
            if (!Tab.peca(origem).MovimentoPossivel(destino)) {
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

        // método que verifica a cor da peça capturada e adiciona à lista de Capturadas
        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Capturadas) {
                if (peca.Cor == cor) {
                    aux.Add(peca);
                }
            }

            return aux;
        }

        // método que retira as peças capturadas do tabuleiro
        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Pecas) {
                if (peca.Cor == cor) {
                    aux.Add(peca);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        // método que indica quem é a peça adversária à jogar no momento
        private Cor Adversaria(Cor cor) {
            if (cor == Cor.Branca) {
                return Cor.Preta;
            } else {
                return Cor.Branca;
            }
        }

        // método que retorna a peça sendo o Rei
        private Peca Rei(Cor cor) {
            foreach (Peca peca in PecasEmJogo(cor)) {
                if (peca is Rei) {
                    return peca;
                }
            }

            return null;
        }

        /* método que diz quando o rei está em xeque 
         e quais seus movimentos possíveis */
        public bool EstaEmXeque(Cor cor) {
            Peca rei = Rei(cor);

            if (rei == null) {
                throw new TabuleiroException("Não existe um rei da cor " +  cor + " no tabuleiro");
            }

            foreach (Peca peca in PecasEmJogo(Adversaria(cor))) {
                bool[,] mat = peca.MovimentosPossiveis();

                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna]) {
                    return true;
                }
            }

            return false;
        }

        /* faz um teste com todas os movimentos possíveis de uma peça do tabuleiro,
         se acaso ao capturar uma peça deixe seu próprio rei em xeque, desfará o
        movimento. Se por ventura isso não ocorrer, será xeque mate */
        public bool TesteXequeMate(Cor cor) {
            if (!EstaEmXeque(cor)) {
                return false;
            }

            foreach (Peca peca in PecasEmJogo(cor)) {
                bool[,] mat = peca.MovimentosPossiveis();

                for (int i = 0; i < Tab.Linhas; i++) {
                    for (int j = 0; j < Tab.Colunas; j++) {
                        if (mat[i, j]) {
                            Posicao origem = peca.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);

                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque) {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        // método que adiciona uma nova peça à partida
        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ConverterPosicao());
            Pecas.Add(peca);
        }

        // método que coloca todas as peças no tabuleiro
        private void ColocarPecas() {
            /*ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));*/

            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));
            ColocarNovaPeca('h', 7, new Torre(Tab, Cor.Branca));

            ColocarNovaPeca('a', 8, new Rei(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Torre(Tab, Cor.Preta));
        }
    }
}
