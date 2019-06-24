using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
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
