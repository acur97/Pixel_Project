using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private InGameManager manager;
    private PoolBalas Pbalas;

    [SerializeField] private EnemyParams parameters;

    [Space]
    [SerializeField] private Transform root;
    [SerializeField] private SpriteRenderer sprt;

    private float shotTime = 0;
    private float stepTime = 0;
    private float speedVal = 0;

    private Transform jugador;
    private int vidaV;
    private float porcentajeVidas;
    private Color32 colSprt;
    private float colV = 255;

    private const string _JugadorBala = "JugadorBala";
    private const string _JugadorPuntoMuerte = "JugadorPuntoMuerte";

    private void Awake()
    {
        manager = InGameManager.Instance;
        jugador = PlayerControl.Instance.transform;
        Pbalas = PoolBalas.Instance;

        colSprt = sprt.color;
        porcentajeVidas = 255 / parameters.life;
        vidaV = parameters.life;
    }

    private void Update()
    {
        if (manager.InGame)
        {
            stepTime += Time.deltaTime * parameters.stepsSpeed;
            if (stepTime > 1)
            {
                stepTime = 0;
            }

            speedVal = parameters.steps.Evaluate(stepTime) * parameters.speed;

            transform.LookAt(jugador, Vector3.forward);
            transform.Translate(0, 0, Time.deltaTime * speedVal);

            shotTime += Time.deltaTime * parameters.shootInterval;
            if (shotTime > 1)
            {
                shotTime = 0;
                Pbalas.GetBala(root.position, transform.rotation, parameters.shootSpeed);
            }
        }
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
                collision.transform.parent.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag(_JugadorPuntoMuerte))
        {
            manager.CambiarVida(-4);
        }
    }
}