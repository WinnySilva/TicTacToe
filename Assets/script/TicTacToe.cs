using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimaxSpace;
using System.Dynamic;

public class TicTacToe : MonoBehaviour
{

    public UnityEngine.GameObject[] pecas;
    public EnumEstado jogadorAtual;
    public EnumEstadoPartida estadoPartida;
    public BotaoPeca UltimaJogada { get; set; }
    private TOEstado tabuleiroAtual;
    private MinMax algo;

    // Start is called before the first frame update
    void Start()
    {

        MinMax alg = new MinMax();
        estadoPartida = EnumEstadoPartida.INICIO;
        algo = new MinMax();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Estado: " + estadoPartida);
        switch (estadoPartida)
        {
            case EnumEstadoPartida.INICIO:
                TabuleiroInicial();
                break;
            case EnumEstadoPartida.ESPERANDOJOGADOR:
                break;
            case EnumEstadoPartida.FAZENDOJOGADA:
                this.JogadaIA();
                break;
            case EnumEstadoPartida.FINALJOGO:
                break;
        };

    }

    public void TabuleiroInicial()
    {
        estadoPartida = EnumEstadoPartida.ESPERANDOJOGADOR;
        tabuleiroAtual = new TOEstado();
        //Proximo a jogar eh o Min
        tabuleiroAtual.Estado = EnumEstado.MAX;
        tabuleiroAtual.Tabuleiro = new Int32[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        MatrixParaTabuleiro(tabuleiroAtual.Tabuleiro);
    }

    public void JogadorMinEfetuouJogada(BotaoPeca UltimaJogada)
    {
        int[,] tab = this.tabuleiroAtual.Tabuleiro;
        tab[UltimaJogada.coord.x, UltimaJogada.coord.y] = UltimaJogada.Valor;
        this.tabuleiroAtual.Tabuleiro = tab;
        this.tabuleiroAtual.Estado = EnumEstado.MIN;
        if (this.tabuleiroAtual.EhEstadoFinal())
        {
            estadoPartida = EnumEstadoPartida.FINALJOGO;
            return;
        }
        estadoPartida = EnumEstadoPartida.FAZENDOJOGADA;

    }

    public void JogadaIA()
    {
        TOEstado novoEstado = algo.MinmaxAvaliacao(this.tabuleiroAtual);
        this.tabuleiroAtual = novoEstado;
        MatrixParaTabuleiro(novoEstado.Tabuleiro);
        if (this.tabuleiroAtual.EhEstadoFinal())
        {
            estadoPartida = EnumEstadoPartida.FINALJOGO;

        }
        else
        {
            estadoPartida = EnumEstadoPartida.ESPERANDOJOGADOR;
        }

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

public enum EnumEstadoPartida
{
    INICIO = 10,
    ESPERANDOJOGADOR = 20,
    FAZENDOJOGADA = 30,
    FINALJOGO = 40
}
