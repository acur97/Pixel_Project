using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 1;
    public InGameManager manager;
    public float tiempoMuerte = 2;

    private void Start()
    {
        StartCoroutine(TMuerte());
    }

    private void Update()
    {
        if (manager.InGame)
        {
            transform.Translate(0, 0, Time.unscaledDeltaTime * velocidad);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("JugadorPuntoMuerte"))
        {
            manager.CambiarVida(-2);
            Destroy(gameObject);
        }
    }

    IEnumerator TMuerte()
    {
        yield return new WaitForSecondsRealtime(tiempoMuerte);
        Destroy(gameObject);
    }
}