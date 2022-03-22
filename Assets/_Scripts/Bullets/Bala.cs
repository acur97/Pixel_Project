using UnityEngine;

public class Bala : MonoBehaviour
{
    private InGameManager manager;
    private PlayerControl pControl;

    public float speed = 1;
    public int damage = 1;
    public float timeDead = 0;

    [Space]
    public Transform[] transforms;
    public SpriteRenderer[] sprites;

    private const string _JugadorPuntoMuerte = "JugadorPuntoMuerte";

    private void Awake()
    {
        manager = InGameManager.Instance;
        pControl = PlayerControl.Instance;

        transforms = gameObject.GetComponentsInChildren<Transform>();
        sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
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
            pControl.CambiarVida(-damage);
            Morir();
        }
    }

    private void Morir()
    {
        gameObject.SetActive(false);
    }
}