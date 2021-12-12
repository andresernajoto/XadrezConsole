﻿using System;
using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;
using XadrezConsole.Xadrez;

namespace XadrezConsole {
    class Tela {
        /* método estático que mostra as peças 
         no tabuleiro, caso exista uma peça nele
        e aplica também uma cor definida no método
        ImprimirPeca */
        public static void ImprimirTabuleiro(Tabuleiro tab) {
            for (int i = 0; i < tab.Linhas; i++) {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.Colunas; j++) {
                    if (tab.Peca(i, j) == null) {
                        Console.Write("- ");
                    } else {
                        ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        // método que faz a leitura das posições das peças
        public static PosicaoXadrez LerPosicaoXadrez() {
            string posicao = Console.ReadLine();
            char coluna = posicao[0];
            int linha = int.Parse(posicao[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        /* método que imprime as peças brancas e atribui
         a cor amarela para as peças pretas */
        public static void ImprimirPeca(Peca peca) {
            if (peca.Cor == Cor.Branca) {
                Console.Write(peca);
            } else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
