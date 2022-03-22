using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance { get; private set; }

    public bool InGame = true;

    [Space]
    public GameObject Jugador;

    [Header("UI Canvas")]
    public GameObject canvas_game;
    public GameObject canvas_Pausa;

    [Header("Estadisticas")]
    public Text UI_puntos;
    public Text UI_vida;

    [Space]
    public int Puntuacion;

    [Space]
    public GameObject ob;

    private const string _Cancel = "Cancel";

    private void Awake()
    {
        Instance = this;

        UI_puntos.text = Puntuacion.ToString();

        canvas_game.SetActive(true);
        canvas_Pausa.SetActive(false);
    }

    private void Start()
    {
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

        InGame = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown(_Cancel))
        {
            Pausa();
        }
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

    public void CambiarVidaUI(int vida)
    {
        UI_vida.text = vida.ToString();
    }

    public void Morir()
    {
        //canvas_game.SetActive(false);
        InGame = false;
    }
}