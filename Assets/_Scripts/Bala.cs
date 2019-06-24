using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad;
    public InGameManager manager;

    private void Update()
    {
        transform.Translate(0, 0, Time.unscaledDeltaTime * velocidad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("JugadorPuntoMuerte"))
        {
            manager.CambiarVida(-2);
            Destroy(gameObject);
        }
    }
}