using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameManager manager;
    private PlayerControl pControl;

    public BulletType bulletType;
    public float speed = 1;
    public int damage = 1;
    public float timeDeath = 0;
    private float deathTime = 0;

    [Space]
    public SpriteRenderer[] sprites;

    private const string _PlayerDeadZone = "PlayerDeadZone";
    private const string _PlayerWall = "PlayerWall";

    private void Awake()
    {
        sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();

        manager = GameManager.Instance;
        pControl = PlayerControl.Instance;
    }

    private void OnEnable()
    {
        ResetDeathTime();
    }

    private void Update()
    {
        if (manager.InGame)
        {
            transform.Translate(0, 0, Time.deltaTime * speed);

            DeathTime();
        }
    }

    public void ResetDeathTime()
    {
        deathTime = timeDeath;
    }

    private void DeathTime()
    {
        deathTime -= Time.deltaTime;
        if (deathTime <= 0)
        {
            Deactivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_PlayerDeadZone))
        {
            pControl.inBullets.Add(this);

            ///Color debug
            //for (int i = 0; i < sprites.Length; i++)
            //{
            //    sprites[i].color = Color.red;
            //}
        }

        if (collision.CompareTag(_PlayerWall))
        {
            pControl.ChangeHealth(-damage);
            Deactivate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_PlayerDeadZone))
        {
            pControl.inBullets.Remove(this);

            ///Color debug
            //for (int i = 0; i < sprites.Length; i++)
            //{
            //    sprites[i].color = Color.blue;
            //}
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}