using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public GameObject ob;
    public EventSystem eSystem;
    [Header("UI Canvas")]
    public GameObject canvas_game;
    public GameObject canvas_Pausa;
    public Button Pausa_firstSelect;

    private void Awake()
    {
        UI_puntos.text = Puntuacion.ToString();
        UI_vida.text = Vida.ToString();

        canvas_game.SetActive(true);
        canvas_Pausa.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(DelayStart());

        ob = FindObjectOfType<GameObject>();
        //ob = FindObjectsOfType<GameObject>();

        if (ob.name == "[Debug Updater]")
        {
            ob.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No es el primero");
        }
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        InGame = true;
    }

    public void Pausa()
    {
        if (InGame)
        {
            InGame = false;
            Debug.Log("Pausado");

            canvas_game.SetActive(false);
            canvas_Pausa.SetActive(true);
            eSystem.SetSelectedGameObject(null);
            Pausa_firstSelect.Select();
        }
        else
        {
            InGame = true;
            Debug.Log("Reanudar");

            canvas_game.SetActive(true);
            canvas_Pausa.SetActive(false);
        }
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