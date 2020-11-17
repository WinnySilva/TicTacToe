using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigsPers : MonoBehaviour
{

    public EnumDificuldade NivelDificuldade;
    public EnumEstado JogadorHumano;
    public bool IaInicia;


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("config");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}
