using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private GameManager manager;
    private PlayerControl pControl;
    private PoolBullets pBullets;

    [SerializeField] private EnemyParams parameters;

    [Space]
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Transform root;

    private float shotTime = 0;
    private float stepTime = 0;
    private float speedVal = 0;

    private Transform player;
    private int health;
    private float healthColor;
    private Color32 spriteColor;
    private float colorValue = 255;

    private Transform collisionT;
    private Bullet bullet;

    private const string _Bullet = "Bullet";
    private const string _PlayerWall = "PlayerWall";

    private void Awake()
    {
        manager = GameManager.Instance;
        pControl = PlayerControl.Instance;
        player = pControl.transform;
        pBullets = PoolBullets.Instance;

        spriteColor = sprite.color;
        healthColor = 255 / parameters.life;
        health = parameters.life;
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

            transform.LookAt(player, Vector3.forward);
            transform.Translate(0, 0, Time.deltaTime * speedVal);

            shotTime += Time.deltaTime * parameters.shootInterval;
            if (shotTime > 1)
            {
                shotTime = 0;
                pBullets.SetBullet(root.position, transform.rotation, parameters.shootSpeed, parameters.bulletParams.type);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionT = collision.transform.parent;

        if (collisionT.CompareTag(_Bullet))
        {
            bullet = PoolBullets.Instance.GetBulletComponent(collisionT.GetInstanceID());

            if (bullet.bulletType == BulletType.PlayerBullet)
            {
                health -= bullet.damage;
                colorValue -= healthColor * bullet.damage;
                spriteColor = new Color32(255, (byte)colorValue, (byte)colorValue, 255);
                sprite.color = spriteColor;

                if (health <= 0)
                {
                    manager.ChangePoints(1);
                    collisionT.gameObject.SetActive(false);
                    Destroy(gameObject);
                }
            }
        }
        else if (collisionT.CompareTag(_PlayerWall))
        {
            pControl.ChangeHealth(-parameters.collisionDamage);
        }

        bullet = null;
        collisionT = null;
    }
}