using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public bool InGame = false;
    //public 
    [Space]
    public Text UI_puntos;
    public Text UI_vida;
    [Space]
    public int Puntuacion;
    public int Vida;
    [Space]
    public GameObject Jugador;

    private void Awake()
    {
        UI_puntos.text = Puntuacion.ToString();
        UI_vida.text = Vida.ToString();
    }

    private void Start()
    {
        StartCoroutine(DelayStart());
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        InGame = true;
    }

    public void CambiarPuncuacion(int puntos)
    {
        Puntuacion += puntos;
        UI_puntos.text = Puntuacion.ToString();
    }

    public void CambiarVida(int vida)
    {
        Vida += vida;
        UI_vida.text = Vida.ToString();
    }
}
