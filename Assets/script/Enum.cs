using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumEstadoPartida
{
    INICIO = 10,
    JOGADOR01 = 20,
    JOGADOR02 = 30,
    FINALIZANDOJOGO = 35,
    FINALJOGO = 40,

}


public enum EnumEstado
{
    MIN = -1,// O
    MAX = 1, // X
    Empate = 0
}

public enum EnumDificuldade
{
    FACIL = 0,
    MEDIO = 1,
    DIFICIL = 2
}
