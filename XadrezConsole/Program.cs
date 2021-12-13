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
                    try {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ConverterPosicao();
                        partida.ValidarOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ConverterPosicao();
                        partida.ValidarDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    } catch (TabuleiroException e) {
                        Console.WriteLine();
                        Console.WriteLine("Erro na jogada: {0}", e.Message);
                        Console.ReadLine();
                    }
                }
            } catch (TabuleiroException e) {
                Console.WriteLine();
                Console.WriteLine("Erro de posicionamento: {0}", e.Message);
            } 
        }
    }
}
