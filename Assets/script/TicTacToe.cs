using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimaxSpace;

public class TicTacToe : MonoBehaviour
{

    public UnityEngine.Object[] pecas;
    public Int32[,] matrix;
    public EnumEstado jogador;

    // Start is called before the first frame update
    void Start()
    {

        MinMax alg = new MinMax();
        TOEstado estadoInicial;

        estadoInicial = new TOEstado();
        estadoInicial.Estado = EnumEstado.MAX;
        matrix = new Int32[3, 3] { { 1, -1, 1 }, { -1, 1, -1 }, { -1, 0, 0 } }; //{ { 1, 0, -1 }, { 0, 1, 0 }, { -1, 0, -1 } };
        estadoInicial.Tabuleiro = matrix;
        Debug.Log("Estado Final? "+estadoInicial.EhEstadoFinal());
        alg.GeraProximosEstados(estadoInicial);

        TOEstado estadoProx = alg.MinmaxAvaliacao(estadoInicial);
        alg.PrintarMtrix(estadoProx.Tabuleiro);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
