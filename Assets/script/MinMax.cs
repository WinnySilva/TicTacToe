using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimaxSpace;

namespace MinimaxSpace
{
    public class MinMax
    {

        public TOEstado MinmaxAvaliacao(TOEstado estadoAtual)
        {
            if (estadoAtual.EhEstadoFinal())
            {
                return estadoAtual;
            }

            EnumEstado jogadorProximo = estadoAtual.Estado == EnumEstado.MAX ? EnumEstado.MIN : EnumEstado.MAX;
            List<TOEstado> filhos = GeraProximosEstados(estadoAtual);

            List<TOEstado> boaJogada = new List<TOEstado>();
            List<TOEstado> empates = new List<TOEstado>();
            List<TOEstado> jogadaRuim = new List<TOEstado>();
            foreach (TOEstado filho in filhos)
            {
                TOEstado avaliacao = MinmaxAvaliacao(filho);

                if (avaliacao.Estado == EnumEstado.Empate)
                {
                    empates.Add(avaliacao);
                }
                else if (avaliacao.Estado == jogadorProximo)
                {
                    boaJogada.Add(avaliacao);
                }
                else
                {
                    jogadaRuim.Add(avaliacao);
                }

            }
            TOEstado estadoEscolhido;
            if (boaJogada.Count != 0)
            {
                estadoEscolhido = boaJogada[0];
            }
            else if (empates.Count != 0)
            {
                estadoEscolhido = empates[0];
            }
            else
            {
                estadoEscolhido = jogadaRuim[0];
            }

            return estadoEscolhido;
        }

        public List<TOEstado> GeraProximosEstados(TOEstado estadoAtual)
        {
            List<TOEstado> filhos = new List<TOEstado>();
            Int32[,] matrizEstado = estadoAtual.Tabuleiro;
            EnumEstado jogadorProximo = estadoAtual.Estado == EnumEstado.MAX ? EnumEstado.MIN : EnumEstado.MAX;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if (matrizEstado[i, j] == 0)
                    {
                        Int32[,] novo = copiaMatriz(matrizEstado);
                        TOEstado novoEstado = new TOEstado();

                        novo[i, j] = (Int32)jogadorProximo;
                        novoEstado.Tabuleiro = novo;
                        novoEstado.Estado = jogadorProximo;
                        filhos.Add(novoEstado);
                        //PrintarMtrix(novo);
                    }

                }
            }

            return filhos;
        }

        Int32[,] copiaMatriz(Int32[,] matrizEstado)
        {
            Int32[,] novo = new Int32[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    novo[i, j] = matrizEstado[i, j];

                }
            }

            return novo;
        }

        public void PrintarMtrix(Int32[,] matrizEstado)
        {
            String print = String.Empty;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    print += matrizEstado[i, j] + " ";

                }
                print += "\n";
            }

            Debug.Log(print);
        }

    }
}
