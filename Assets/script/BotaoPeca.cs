﻿using MinimaxSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BotaoPeca : MonoBehaviour
{
    public int Valor { get => valor; }
    public EnumEstado Jogador;
    public Vector2Int coord;
    public TicTacToeController tab;

    private Image imagem;
    private int valor;
    private Sprite X;
    private Sprite O;



    // Start is called before the first frame update
    void Start()
    {
        imagem = GetComponent<Image>();
        valor = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetarPecas()
    {
        if (TryGetComponent<Image>(out imagem))
        {
            Destroy(imagem);
        }
        valor = 0;

    }

    public void PosicionarPeca(EnumEstado estado)
    {

        this.valor = (int)estado;
        Sprite spr = null;

        if (estado == EnumEstado.Empate)
        {
            if (TryGetComponent<Image>(out imagem))
            {
                Destroy(imagem);
            }
            return;
        }

        if (estado == EnumEstado.MAX)
        {
            spr = Resources.Load<Sprite>("img/xizinho");
        }
        else if (estado == EnumEstado.MIN)
        {
            spr = Resources.Load<Sprite>("img/bolinha");
        }

        if (TryGetComponent<Image>(out imagem))
        {
            imagem.sprite = spr;

        }
        else
        {

            imagem = gameObject.AddComponent<Image>() as Image;
            imagem.sprite = spr;
        }

        AudioSource audio;

        if (TryGetComponent<AudioSource>(out audio))
        {
            audio.Play();
        }

    }

    void OnMouseDown()
    {
        if (this.valor != (int)EnumEstado.Empate)
        {
            return;
        }
        if (tab.estadoPartida == EnumEstadoPartida.JOGADOR01)
        {
            PosicionarPeca(EnumEstado.MIN);
            tab.JogadorMinEfetuouJogada(this);
        }

    }

}
