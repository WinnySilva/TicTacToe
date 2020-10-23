﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimaxSpace
{
    public class TOEstado
    {
        private int[,] tabuleiro;
        private int valorAvaliacao;
        private EnumEstado estado;
        private EnumEstado ganhador;

        public int[,] Tabuleiro { get => tabuleiro; set => tabuleiro = value; }
        public int ValorAvaliacao { get => valorAvaliacao; set => valorAvaliacao = value; }
        public EnumEstado Estado { get => estado; set => estado = value; }
        public EnumEstado Ganhador { get => ganhador; }



        public Boolean EhEstadoFinal()
        {
            Int32[] diag = new Int32[] { 0, 0 };
            Int32[] linha = new Int32[] { 0, 0, 0 };
            Int32[] coluna = new Int32[] { 0, 0, 0 };

            Int32[,] matrix = this.tabuleiro;
            Boolean semEspaco = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        diag[0] += matrix[i, j];
                    }
                    if (i == j)
                    {
                        diag[1] += matrix[i, j];
                    }

                    if (matrix[i, j] == 0)
                    {
                        semEspaco = false;
                    }

                    linha[i] += matrix[i, j];
                    coluna[j] += matrix[i, j];
                }
            }
            diag[1] = matrix[0, 2] + matrix[1, 1] + matrix[2, 0];

            for (int i = 0; i < 3; i++)
            {
                if (linha[i] == 3 || coluna[i] == 3)
                {
                    this.ganhador = EnumEstado.MAX;
                    return true;
                }

                if (coluna[i] == -3 || linha[i] == -3)
                {
                    this.ganhador = EnumEstado.MIN;
                    return true;
                }

            }

            for (int i = 0; i < 2; i++)
            {
                if (diag[i] == 3)
                {
                    this.ganhador = EnumEstado.MAX;
                    return true;
                }

                if (diag[i] == -3)
                {
                    this.ganhador = EnumEstado.MIN;
                    return true;
                }
            }



            return semEspaco;
        }


    }

    public enum EnumEstado
    {
        MIN = -1,// O
        MAX = 1, // X
        Empate

    }

}