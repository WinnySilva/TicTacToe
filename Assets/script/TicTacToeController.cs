using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimaxSpace;
using System.Dynamic;

public class TicTacToeController : MonoBehaviour
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
        IniciarJogo();
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
            case EnumEstadoPartida.JOGADOR01:
                break;
            case EnumEstadoPartida.JOGADOR02:
                this.JogadaIA();
                break;
            case EnumEstadoPartida.FINALJOGO:
                break;
            default:
                break;
        };

    }

    public void IniciarJogo()
    {
        estadoPartida = EnumEstadoPartida.INICIO;
    }
    public void TabuleiroInicial()
    {
        estadoPartida = EnumEstadoPartida.JOGADOR01;
        tabuleiroAtual = new TOEstado();
        //Proximo a jogar eh o Min
        tabuleiroAtual.Tabuleiro = new Int32[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        MatrixParaTabuleiro(tabuleiroAtual.Tabuleiro);
    }

    public void JogadorMinEfetuouJogada(BotaoPeca UltimaJogada)
    {
        int[,] tab = this.tabuleiroAtual.Tabuleiro;
        tab[UltimaJogada.coord.x, UltimaJogada.coord.y] = UltimaJogada.Valor;
        this.tabuleiroAtual.Tabuleiro = tab;
        if (this.tabuleiroAtual.EhEstadoFinal())
        {
            estadoPartida = EnumEstadoPartida.FINALJOGO;
            return;
        }
        estadoPartida = EnumEstadoPartida.JOGADOR02;

    }

    public void JogadaIA()
    {
        TOEstado novoEstado = algo.MinMaxV2(this.tabuleiroAtual, EnumEstado.MAX, 0);
        this.tabuleiroAtual = novoEstado;
        MatrixParaTabuleiro(novoEstado.Tabuleiro);
        if (this.tabuleiroAtual.EhEstadoFinal())
        {
            estadoPartida = EnumEstadoPartida.FINALJOGO;
        }
        else
        {
            estadoPartida = EnumEstadoPartida.JOGADOR01;
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


