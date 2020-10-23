using MinimaxSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BotaoPeca : MonoBehaviour
{
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

    }

    public void PosicionarPeca(EnumEstado estado)
    {
        Sprite spr = null;
        if (estado == EnumEstado.MAX)
        {
            spr = Resources.Load<Sprite>("img/xizinho");
        }
        else if(estado == EnumEstado.MIN)
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

    }

}
