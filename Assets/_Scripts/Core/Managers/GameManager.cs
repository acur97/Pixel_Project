using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool InGame = true;

    [Space]
    [SerializeField] private GameObject player;

    [Header("UI Canvas")]
    [SerializeField] private GameObject canvas_Game;
    [SerializeField] private GameObject canvas_Pausa;

    [Header("Estadisticas")]
    [SerializeField] private Text UI_score;
    [SerializeField] private Text UI_health;

    [Space]
    [SerializeField] private int score;

    //private const string _Cancel = "Cancel";

    private void Awake()
    {
        Instance = this;

        UI_score.text = score.ToString();

        canvas_Pausa.SetActive(false);
        canvas_Game.SetActive(true);
    }

    private void Start()
    {
        InGame = true;
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (InGame)
            {
                InGame = false;
                ///Pausado

                canvas_Game.SetActive(false);
                canvas_Pausa.SetActive(true);

                InputSystemManager.Instance.pInput.SwitchCurrentActionMap("UI");

                Time.timeScale = 0;
            }
            else
            {
                InGame = true;
                ///Reanudar

                canvas_Game.SetActive(true);
                canvas_Pausa.SetActive(false);

                InputSystemManager.Instance.pInput.SwitchCurrentActionMap("Player");

                Time.timeScale = 1;
            }
        }
    }

    public void ChangePoints(int points)
    {
        score += points;
        UI_score.text = score.ToString();
    }

    public void ChangeHealthUI(int health)
    {
        UI_health.text = health.ToString();
    }

    public void Death()
    {
        //canvas_game.SetActive(false);
        InGame = false;
    }
}