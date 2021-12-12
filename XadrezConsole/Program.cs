using System;
using XadrezConsole.Xadrez;
using XadrezConsole.Quadro;
using XadrezConsole.Quadro.Enums;
using XadrezConsole.Quadro.Exceptions;

namespace XadrezConsole {
    class Program {
        static void Main(string[] args) {

            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada) {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ConverterPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ConverterPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }
            } catch (TabuleiroException e) {
                Console.WriteLine("Erro de posicionamento: {0}", e.Message);
            }
        }
    }
}
