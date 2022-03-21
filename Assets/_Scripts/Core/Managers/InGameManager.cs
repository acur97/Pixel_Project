using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance { get; private set; }

    public bool InGame = true;

    [Space]
    public Text UI_puntos;
    public Text UI_vida;

    [Space]
    public int Puntuacion;
    public int Vida;

    [Space]
    public GameObject Jugador;
    public GameObject ob;

    [Header("UI Canvas")]
    public GameObject canvas_game;
    public GameObject canvas_Pausa;

    private void Awake()
    {
        Instance = this;

        UI_puntos.text = Puntuacion.ToString();
        UI_vida.text = Vida.ToString();

        canvas_game.SetActive(true);
        canvas_Pausa.SetActive(false);
    }

    private void Start()
    {
        InGame = true;

#if UNITY_EDITOR
        ob = FindObjectOfType<GameObject>();

        if (ob.name == "[Debug Updater]")
        {
            ob.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No es el primero");
        }
#endif

    }

    public void Pausa()
    {
        if (InGame)
        {
            InGame = false;
            ///Pausado

            Time.timeScale = 0;

            canvas_game.SetActive(false);
            canvas_Pausa.SetActive(true);
        }
        else
        {
            InGame = true;
            ///Reanudar

            Time.timeScale = 1;

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