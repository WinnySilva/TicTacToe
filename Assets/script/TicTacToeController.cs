using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimaxSpace;
using System.Dynamic;
using UnityEngine.UI;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class TicTacToeController : MonoBehaviour
{

    public UnityEngine.GameObject[] pecas;
    public EnumEstadoPartida estadoPartida;
    public Text statusJogo;
    public BotaoPeca UltimaJogada { get; set; }
    private TOEstado tabuleiroAtual;
    private MinMax algo;
    private bool isCoroutineStarted = false;
    private ConfigsPers config;
    private EnumEstado jogadorHumano;
    private EnumEstado jogadorIa;

    // Start is called before the first frame update
    void Start()
    {

        MinMax alg = new MinMax();
        IniciarJogo();
        algo = new MinMax();
        BotaoPeca.OnClicked += JogadorMinEfetuouJogada;

        config = GameObject.FindGameObjectWithTag("config").GetComponent<ConfigsPers>();
        jogadorHumano = config.JogadorHumano;
        jogadorIa = jogadorHumano == EnumEstado.MIN ? EnumEstado.MAX : EnumEstado.MIN;

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Estado: " + estadoPartida);
        switch (estadoPartida)
        {
            case EnumEstadoPartida.INICIO:
                statusJogo.text = "Iniciando Partida.";
                statusJogo.transform.localPosition = new Vector3(0f, -290f, 0f);
                TabuleiroInicial();
                break;
            case EnumEstadoPartida.JOGADOR01:
                statusJogo.text = "Jogador 1";
                break;
            case EnumEstadoPartida.JOGADOR02:
                statusJogo.text = "Jogador 2";
                if (!isCoroutineStarted)
                {
                    StartCoroutine(this.JogadaIA());
                }

                break;
            case EnumEstadoPartida.FINALJOGO:
                statusJogo.text = "Final de jogo \n " + this.tabuleiroAtual.Ganhador.ToString();
                statusJogo.transform.localPosition = new Vector3(0f, 0f, 0f);
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
        tabuleiroAtual = new TOEstado();
        //Proximo a jogar eh o Min
        tabuleiroAtual.Tabuleiro = new Int32[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        MatrixParaTabuleiro(tabuleiroAtual.Tabuleiro);
        if (config.IaInicia)
        {
            estadoPartida = EnumEstadoPartida.JOGADOR02;
        }
        else
        {
            estadoPartida = EnumEstadoPartida.JOGADOR01;
        }
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

    IEnumerator JogadaIA()
    {
        isCoroutineStarted = true;
        yield return new WaitForSeconds(3);
        TOEstado novoEstado = null;
        Random rnd = new Random();
        int rndI = 0;
        List<TOEstado> lista;
        switch (config.NivelDificuldade)
        {
            case EnumDificuldade.FACIL:
                lista = algo.GeraEstados(this.tabuleiroAtual, jogadorIa); 
                rndI = rnd.Next(0, lista.Count);
                novoEstado = lista[rndI];
                break;
            case EnumDificuldade.MEDIO:
                rndI = rnd.Next(0,100);
                if (rndI>60)
                {
                    lista = algo.GeraEstados(this.tabuleiroAtual, jogadorIa);
                    rndI = rnd.Next(0, lista.Count);
                    novoEstado = lista[rndI];
                }
                else
                {
                    novoEstado = algo.MinMaxV2(this.tabuleiroAtual, jogadorIa, 0);
                }

                break;
            case EnumDificuldade.DIFICIL:
                novoEstado = algo.MinMaxV2(this.tabuleiroAtual, jogadorIa, 0);
                break;
        }


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

        isCoroutineStarted = false;

    }

    public void RetornarTelaAnterior()
    {
        SceneManager.LoadScene("Entrada");
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


