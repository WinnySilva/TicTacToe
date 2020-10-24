using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimaxSpace;

public class TicTacToe : MonoBehaviour
{

    public UnityEngine.GameObject[] pecas;
    public EnumEstado jogadorAtual;
    TOEstado tabuleiroAtual;

    // Start is called before the first frame update
    void Start()
    {

        MinMax alg = new MinMax();
        TabuleiroInicial();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TabuleiroInicial()
    {
        tabuleiroAtual = new TOEstado();
        //Proximo a jogar eh o Min
        tabuleiroAtual.Estado = EnumEstado.MAX;
        tabuleiroAtual.Tabuleiro = new Int32[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        MatrixParaTabuleiro(tabuleiroAtual.Tabuleiro);
    }


    private void MatrixParaTabuleiro(Int32[,] matrix)
    {
        EnumEstado estado;
        BotaoPeca peca;
        int iPecas = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                estado = (EnumEstado)matrix[i, j];
                peca = pecas[iPecas++].GetComponent<BotaoPeca>();
                peca.PosicionarPeca(estado);
            }
        }
    }

}
