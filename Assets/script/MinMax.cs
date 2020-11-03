using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimaxSpace;
using UnityEngine.Events;
using Unity.Mathematics;

namespace MinimaxSpace
{
    public class MinMax
    {

        public TOEstado MinMaxV2(TOEstado estadoAtual, EnumEstado jogadorAtual, int i)
        {
                        
            if (estadoAtual.EhEstadoFinal())
            {
                return  estadoAtual;
            }

            List<TOEstado> estados = null;
            TOEstado melhorEstado = null; ;
            Int16 aval = 0;

            if (jogadorAtual == EnumEstado.MIN)
            {
                estados = this.GeraEstados(estadoAtual, EnumEstado.MIN);
                foreach (TOEstado filho in estados)
                {
                    TOEstado avaliacao = MinMaxV2(filho, EnumEstado.MAX, i + 1);
                    filho.Ganhador = avaliacao.Ganhador;

                    if (((Int16)avaliacao.Ganhador) <= aval)
                    {
                        melhorEstado =  filho;
                        aval = (Int16)avaliacao.Ganhador;
                    }
                }
            }
            else if (jogadorAtual == EnumEstado.MAX)
            {
                estados = this.GeraEstados(estadoAtual, EnumEstado.MAX);
                foreach (TOEstado filho in estados)
                {
                    TOEstado avaliacao = MinMaxV2(filho, EnumEstado.MIN, i + 1);
                    filho.Ganhador = avaliacao.Ganhador;
                    if (((Int16)avaliacao.Ganhador) >= aval)
                    {
                        melhorEstado = filho;
                        aval = (Int16)avaliacao.Ganhador;
                    }
                }               
            }

            return melhorEstado == null ? estados[0]: melhorEstado ;

        }

        public List<TOEstado> GeraEstados(TOEstado estadoAtual, EnumEstado jogador)
        {
            List<TOEstado> filhos = new List<TOEstado>();
            Int32[,] matrizEstado = estadoAtual.Tabuleiro;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if (matrizEstado[i, j] == 0)
                    {
                        Int32[,] novo = copiaMatriz(matrizEstado);
                        TOEstado novoEstado = new TOEstado();

                        novo[i, j] = (Int32)jogador;
                        novoEstado.Tabuleiro = novo;
                        filhos.Add(novoEstado);
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
