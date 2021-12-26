using System;
using System.Collections.Generic;
using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;
using XadrezConsole.Xadrez;

namespace XadrezConsole {
    class Tela {
        // método que imprime os dados da partida, como turno e jogador atual
        public static void ImprimirPartida(PartidaDeXadrez partida) {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);

            Console.WriteLine();
            Console.WriteLine("Turno: {0}", partida.Turno);

            if (!partida.Terminada) {
                Console.WriteLine("Aguardando jogada: {0}", partida.JogadorAtual);

                if (partida.Xeque) {
                    Console.WriteLine();
                    Console.WriteLine("XEQUE!");
                }
            } else {
                Console.WriteLine();
                Console.WriteLine("XEQUE MATE!");
                Console.WriteLine("Vencedor: {0}", partida.JogadorAtual);
            }
        }

        // método que imprime o conjunto das peças capturadas separadas por cores
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }

        // método que imprime o conjunto das peças
        public static void ImprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            
            foreach (Peca peca in conjunto) {
                Console.Write(peca + " ");
            }

            Console.Write("]");
            Console.WriteLine();
        }

        /* método estático que mostra as peças 
         no tabuleiro e utiliza o método 
        ImprimirPecas para mostrar as peças */
        public static void ImprimirTabuleiro(Tabuleiro tab) {
            for (int i = 0; i < tab.Linhas; i++) {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.Colunas; j++) {
                    ImprimirPeca(tab.Peca(i, j));
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        /* sobrecarga do método acima, mostrando as possíveis
         jogadas para determinada peça do tabuleiro */
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++) {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.Colunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    } else {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        // método que faz a leitura das posições das peças
        public static PosicaoXadrez LerPosicaoXadrez() {
            string posicao = Console.ReadLine();
            char coluna = posicao[0];
            int linha = int.Parse(posicao[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        /* método que imprime as peças brancas e atribui
         a cor amarela para as peças pretas. Também
        verifica se existem peças no tabuleiro */
        public static void ImprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("- ");
            }
            else {
                if (peca.Cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }
        }
    }
}
