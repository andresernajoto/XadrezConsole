﻿using XadrezConsole.Quadro.Exceptions;

namespace XadrezConsole.Quadro {
    class Tabuleiro {
        // declaração das propriedades da classe
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        /* construtor que define quantas linhas e colunas terão no tabuleiro,
         passando as linhas e colunas para as peçãs também */
        public Tabuleiro(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        // método que permite o acesso das peças e suas posições
        public Peca Peca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }

        // método que recebe as posições exatas das peças
        public Peca peca(Posicao posicao) {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        // método que verifica se existe uma peça na posição informada
        public bool ExistePeca(Posicao posicao) {
            ValidarPosicao(posicao);
            return peca(posicao) != null;
        }

        /* método que coloca as peças no tabuleiro e lança
         uma exceção se a posição já estiver ocupada */
        public void ColocarPeca(Peca peca, Posicao posicao) {
            if (ExistePeca(posicao)) {
                throw new TabuleiroException("Posição já ocupada por outra peça!");
            }
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        // método que verifica se a posição digitada é válida
        public bool PosicaoValida(Posicao posicao) {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas) {
                return false;
            }

            return true;
        }

        /* método que lança uma exceção caso a
         posição informada não seja válida */
        public void ValidarPosicao(Posicao posicao) {
            if (!PosicaoValida(posicao)) {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}