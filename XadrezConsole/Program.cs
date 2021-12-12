using System;
using XadrezConsole.Xadrez;
using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;
using XadrezConsole.Quadro.Exceptions;

namespace XadrezConsole {
    class Program {
        static void Main(string[] args) {

            PosicaoXadrez posXadrez = new PosicaoXadrez('c', 7);

            Console.WriteLine(posXadrez);
            Console.WriteLine(posXadrez.ConverterPosicao());
        }
    }
}
