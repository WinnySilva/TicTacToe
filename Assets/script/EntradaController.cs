using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EntradaController : MonoBehaviour
{

    public Dropdown Dificuldade;
    public Dropdown JogadorHumano;
    public Toggle PrimeiroJogadorIA;
    public Toggle VersusIA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarCenaJogo()
    {
        GameObject conf = GameObject.FindGameObjectWithTag("config");

        ConfigsPers config = conf.GetComponent<ConfigsPers>();

        config.IaInicia = PrimeiroJogadorIA.isOn;
        config.versusIA = VersusIA.isOn;
        config.NivelDificuldade = (EnumDificuldade)this.Dificuldade.value;
        if (JogadorHumano.value == 0)
        {
            config.JogadorHumano = EnumEstado.MIN;
        }
        else
        {
            config.JogadorHumano = EnumEstado.MAX;
        }

        SceneManager.LoadScene("Jogo");
    }

    public void FecharJogo()
    {
        Debug.Log("Fechar Jogo");
        Application.Quit();

    }
}
