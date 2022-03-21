using UnityEngine;

public class Bala : MonoBehaviour
{
    private InGameManager manager;

    public float speed = 1;
    public float timeDead = 0;

    private const string _JugadorPuntoMuerte = "JugadorPuntoMuerte";

    private void Awake()
    {
        manager = InGameManager.Instance;
    }

    private void Update()
    {
        if (manager.InGame)
        {
            Tmuerte();

            transform.Translate(0, 0, Time.deltaTime * speed);
        }
    }

    private void Tmuerte()
    {
        timeDead -= Time.deltaTime;
        if (timeDead < 0)
        {
            Morir();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_JugadorPuntoMuerte))
        {
            manager.CambiarVida(-2);
            Morir();
        }
    }

    private void Morir()
    {
        gameObject.SetActive(false);
    }
}