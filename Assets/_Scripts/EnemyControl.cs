using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public InGameManager manager;
    [Space]
    public float segundosDisparos = 1;
    public float velocidad = 0.5f;
    public int vida = 5;
    private int vidaV;
    private float porcentajeVidas;
    [Space]
    public Transform jugador;
    public SpriteRenderer sprt;
    private Color32 colSprt;
    private float colV = 255;
    [Space]
    public GameObject balaInstancia;
    public Transform posicion;
    public Transform padre;

    [Space]
    public float tiempoFrenaz = 0.5f;
    public float divididoPausa = 4;
    private bool frenazo = false;
    public bool frenazoMitad = true;
    private Coroutine coru;

    private void Awake()
    {
        colSprt = sprt.color;
        porcentajeVidas = 255 / vida;
        vidaV = vida;
    }

    private void Start()
    {
        StartCoroutine(Disparando());
        coru = StartCoroutine(Pausas(tiempoFrenaz));
    }

    private void Update()
    {
        if (manager.InGame)
        {
            transform.LookAt(jugador, Vector3.forward);
            if (frenazo)
            {
                transform.Translate(0, 0, Time.unscaledDeltaTime * velocidad);
            }
        }
    }

    IEnumerator Pausas(float tim)
    {
        yield return new WaitForSecondsRealtime(tim);
        if (frenazo == true)
        {
            frenazo = false;
            if (frenazoMitad)
            {
                StopCoroutine(coru);
                coru = StartCoroutine(Pausas(tiempoFrenaz / divididoPausa));
            }
            else
            {
                StopCoroutine(coru);
                coru = StartCoroutine(Pausas(tiempoFrenaz));
            }
        }
        else
        {
            frenazo = true;
            StopCoroutine(coru);
            coru = StartCoroutine(Pausas(tiempoFrenaz));
        }
    }

    IEnumerator Disparando()
    {
        GameObject bala;
        bala = Instantiate(balaInstancia, posicion.position, Quaternion.identity, padre);
        bala.GetComponent<Bala>().manager = manager;
        bala.transform.rotation = transform.rotation;
        yield return new WaitForSecondsRealtime(segundosDisparos);
        StartCoroutine(Disparando());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("JugadorBala"))
        {
            vidaV -= 1;
            colV -= porcentajeVidas;
            colSprt = new Color32(255, (byte)colV, (byte)colV, 255);
            sprt.color = colSprt;

            if (vidaV == 0)
            {
                manager.CambiarPuncuacion(1);
                Destroy(collision.transform.parent.gameObject);
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("JugadorPuntoMuerte"))
        {
            manager.CambiarVida(-4);
        }
    }
}