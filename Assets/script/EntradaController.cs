using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EntradaController : MonoBehaviour
{

    public Dropdown dificuldade;
    public Dropdown jogadorHumano;
    public Toggle primeiroJogadorIA;

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

        config.IaInicia = primeiroJogadorIA.isOn;
        config.NivelDificuldade = (EnumDificuldade)this.dificuldade.value;
        if (jogadorHumano.value == 0)
        {
            config.JogadorHumano = EnumEstado.MIN;
        }
        else
        {
            config.JogadorHumano = EnumEstado.MAX;
        }
             

       // DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Jogo");
    }

    public void FecharJogo()
    {
        Debug.Log("Fechar Jogo");
        Application.Quit();

    }
}
