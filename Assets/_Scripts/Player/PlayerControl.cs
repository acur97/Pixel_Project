using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance { get; private set; }

    private GameManager manager;

    [SerializeField] private PlayerParams parameters;

    private int life;

    [Header("Test")]
    [SerializeField] private Transform cubeTest;
    [SerializeField] private Transform cubeTestEnemy;
    [SerializeField] private GameObject colliderTest;

    [Space]
    [SerializeField] private Transform pointer;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sRender;

    [Space]
    public List<Bullet> inBullets;
    private Bullet bl;

    private Vector3 Mpos = Vector3.zero;
    private Vector2 moves = Vector2.zero;
    private Vector2 offset = Vector2.zero;

    private const string _mov_side = "mov_side";
    private const string _mov_up = "mov_up";
    private const string _mov_down = "mov_down";

    private void Awake()
    {
        Instance = this;

        life = parameters.life;

        if (parameters.test)
        {
            cubeTest.gameObject.SetActive(true);
            cubeTestEnemy.gameObject.SetActive(true);
            colliderTest.SetActive(true);
        }
        else
        {
            cubeTest.gameObject.SetActive(false);
            cubeTestEnemy.gameObject.SetActive(false);
            colliderTest.SetActive(false);
        }
    }

    private void Start()
    {
        manager = GameManager.Instance;
        manager.ChangeHealthUI(life);
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("FIRE !!!");
            //Debug.LogWarning(context.action.name);

            //Debug.LogWarning(context.action.activeControl.name);
            //Debug.LogWarning(context.action.activeControl.displayName);
        }
    }

    private void Update()
    {
        if (manager.InGame)
        {
            Aim();
            //Move(new Vector2(Input.GetAxis(_Horizontal), Input.GetAxis(_Vertical)));
            //if (Input.GetButtonDown(_Fire1))
            //{
            //    Action();
            //}

            transform.Translate(Time.deltaTime * (moves.x * parameters.speed), Time.deltaTime * (moves.y * parameters.speed), 0);
        }

        //pInput.camera.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }

    public void Aim()
    {
        //Mpos = pInput.camera.ScreenToWorldPoint(Input.mousePosition);
        cubeTest.position = new Vector2(Mpos.x, Mpos.y);
        pointer.LookAt(cubeTest.position, Vector3.forward);

        // invertido rojo
        offset = new Vector2(-cubeTest.localPosition.x, -cubeTest.localPosition.y);
        if (cubeTest.localPosition.x > 0)
        {

            offset.x -= 2;
            offset.x = Mathf.Clamp(offset.x, -3, 2);
        }
        else
        {
            offset.x += 2;
            offset.x = Mathf.Clamp(offset.x, 2, 3);
        }
        if (cubeTest.localPosition.y > 0)
        {

            offset.y -= 2;
            offset.y = Mathf.Clamp(offset.y, -3, 2);
        }
        else
        {
            offset.y += 2;
            offset.y = Mathf.Clamp(offset.y, 2, 3);
        }
        //if (offset.x < 2 && offset.x > -2 || offset.y < 2 && offset.y > -2)
        //if (parameters.test)
        {
            cubeTestEnemy.localPosition = new Vector2(offset.x, offset.y);
        }
        Mpos.z = 0;
        pointer.LookAt(Mpos, Vector3.forward);
    }

    public void Move(Vector2 _moves)
    {
        moves = _moves;

        if (moves.x > 0)
        {
            anim.SetBool(_mov_side, true);
            sRender.flipX = false;
            anim.SetBool(_mov_up, false);
            anim.SetBool(_mov_down, false);
        }
        else if (moves.x < 0)
        {
            anim.SetBool(_mov_side, true);
            sRender.flipX = true;
            anim.SetBool(_mov_up, false);
            anim.SetBool(_mov_down, false);
        }
        else
        {
            if (moves.y > 0)
            {
                anim.SetBool(_mov_side, false);
                anim.SetBool(_mov_up, true);
                anim.SetBool(_mov_down, false);
            }
            else
            {
                anim.SetBool(_mov_side, false);
                anim.SetBool(_mov_up, false);
                anim.SetBool(_mov_down, true);
            }
        }
        if (moves.x == 0 && moves.y == 0)
        {
            anim.SetBool(_mov_side, false);
            anim.SetBool(_mov_up, false);
            anim.SetBool(_mov_down, false);
        }
    }

    public void Action()
    {
        for (int i = 0; i < inBullets.Count; i++)
        {
            if (inBullets[i] == null)
            {
                inBullets.RemoveAt(i);
            }
            else
            {
                inBullets[i].bulletType = BulletType.PlayerBullet;
                bl = inBullets[i];
                for (int j = 0; j < bl.sprites.Length; j++)
                {
                    bl.sprites[j].color = parameters.returnColor;
                }
                inBullets[i].transform.rotation = pointer.rotation;
                bl.speed = parameters.returnShootSpeed;
                bl.damage = parameters.returnDamage;
                bl.ResetDeathTime();
            }
        }
        inBullets.Clear();
    }

    public void ChangeHealth(int health)
    {
        life += health;

        manager.ChangeHealthUI(life);

        if (life <= 0)
        {
            Debug.LogWarning("Muerto");
            if (!parameters.test)
            {
                manager.ChangeHealthUI(0);
                manager.Death();
            }
        }
    }
}