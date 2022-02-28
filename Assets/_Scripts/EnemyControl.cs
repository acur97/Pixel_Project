using System.Collections;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private InGameManager manager;

    [SerializeField] private float segundosDisparos = 1;
    [SerializeField] private float velocidad = 0.5f;
    [SerializeField] private int vida = 5;

    [Space]
    public Transform jugador;
    [SerializeField] private SpriteRenderer sprt;

    [Space]
    [SerializeField] private GameObject balaInstancia;
    [SerializeField] private Transform posicion;
    public Transform padre;

    [Space]
    [SerializeField] private float tiempoFrenaz = 0.5f;
    [SerializeField] private float divididoPausa = 4;
    [SerializeField] private bool frenazoMitad = true;

    private int vidaV;
    private float porcentajeVidas;
    private Color32 colSprt;
    private float colV = 255;
    private bool frenazo = false;
    private Coroutine coru;
    private Quaternion quaternionIdentity = Quaternion.identity;
    private WaitForSeconds wait;

    private const string _JugadorBala = "JugadorBala";
    private const string _JugadorPuntoMuerte = "JugadorPuntoMuerte";

    private void Awake()
    {
        manager = InGameManager.instance;

        colSprt = sprt.color;
        porcentajeVidas = 255 / vida;
        vidaV = vida;

        wait = new WaitForSeconds(segundosDisparos);
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
                transform.Translate(0, 0, Time.deltaTime * velocidad);
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
        bala = Instantiate(balaInstancia, posicion.position, quaternionIdentity, padre);
        bala.transform.rotation = transform.rotation;
        yield return wait;
        StartCoroutine(Disparando());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag(_JugadorBala))
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

        if (collision.CompareTag(_JugadorPuntoMuerte))
        {
            manager.CambiarVida(-4);
        }
    }
}