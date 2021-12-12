using System;
using XadrezConsole.Quadro;

namespace XadrezConsole {
    class Tela {
        /* método estático que mostra as peças 
         no tabuleiro, caso exista uma peça nele */
        public static void ImprimirTabuleiro(Tabuleiro tab) {
            for (int i = 0; i < tab.Linhas; i++) {
                for (int j = 0; j < tab.Colunas; j++) {
                    if (tab.Peca(i, j) == null) {
                        Console.Write("- ");
                    } else {
                        Console.Write(tab.Peca(i, j) + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
