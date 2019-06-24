using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public InGameManager manager;
    [Space]
    public float velocidad;
    [Space]
    public Transform jugador;
    [Space]
    public GameObject balaInstancia;
    public Transform posicion;
    public Transform padre;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject bala;
            bala = Instantiate(balaInstancia, posicion.position, Quaternion.identity, padre);
            bala.GetComponent<Bala>().manager = manager;
            bala.transform.rotation = transform.rotation;
        }

        transform.LookAt(jugador, Vector3.forward);

        transform.Translate(0, 0, Time.unscaledDeltaTime * velocidad);
    }

    public void Explotar()
    {
        Destroy(gameObject);
        manager.CambiarPuncuacion(2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("EnemigoBala"))
        {
            manager.CambiarPuncuacion(1);
            Destroy(collision.transform.parent.gameObject);
            Destroy(gameObject);
        }

        if (collision.CompareTag("JugadorPuntoMuerte"))
        {
            manager.CambiarVida(-4);
            Destroy(gameObject);
        }
    }
}