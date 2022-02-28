using System.Collections;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private InGameManager manager;

    public float velocidad = 1;
    [SerializeField] private float tiempoMuerte = 2;

    private WaitForSeconds wait;

    private const string _JugadorPuntoMuerte = "JugadorPuntoMuerte";

    private void Awake()
    {
        manager = InGameManager.instance;
        wait = new WaitForSeconds(tiempoMuerte);
    }

    private void Start()
    {
        StartCoroutine(TMuerte());
    }

    private void Update()
    {
        if (manager.InGame)
        {
            transform.Translate(0, 0, Time.deltaTime * velocidad);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_JugadorPuntoMuerte))
        {
            manager.CambiarVida(-2);
            Destroy(gameObject);
        }
    }

    IEnumerator TMuerte()
    {
        yield return wait;
        Destroy(gameObject);
    }
}