using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance { get; private set; }

    private InGameManager manager;

    [SerializeField] private PlayerParams parameters;

    [Header("Test")]
    [SerializeField] private Transform cubeTest;
    [SerializeField] private Transform cubeTestEnemy;

    [Space]
    [SerializeField] private Transform pointer;
    [SerializeField] private Camera cam;

    [Space]
    public List<GameObject> balas;

    private Vector3 Mpos = Vector3.zero;
    private Vector2 moves = Vector2.zero;
    private Vector2 offset = Vector2.zero;
    private Animator anim;
    private SpriteRenderer Srender;
    private Transform[] balasL = new Transform[0];
    private SpriteRenderer[] balaColors = new SpriteRenderer[0];

    private const string _Horizontal = "Horizontal";
    private const string _Vertical = "Vertical";
    private const string _Fire1 = "Fire1";
    private const string _Cancel = "Cancel";
    private const string _mov_side = "mov_side";
    private const string _mov_up = "mov_up";
    private const string _mov_down = "mov_down";
    private const string _JugadorBala = "JugadorBala";
    private const string _EnemigoBala = "EnemigoBala";

    private void Awake()
    {
        Instance = this;
        manager = InGameManager.Instance;

        anim = GetComponent<Animator>();
        Srender = GetComponent<SpriteRenderer>();
        //pointerTest.GetComponentsInChildren<Transform>()[1].localEulerAngles = new Vector3(-90, 90, 90);

        if (parameters.test)
        {
            cubeTest.gameObject.SetActive(true);
            cubeTestEnemy.gameObject.SetActive(true);
        }
        else
        {
            cubeTest.gameObject.SetActive(false);
            cubeTestEnemy.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (manager.InGame)
        {
            Apuntar();
            Mover(Input.GetAxis(_Horizontal), Input.GetAxis(_Vertical));
            if (Input.GetButtonDown(_Fire1))
            {
                Accion();
            }
            if (Input.GetButtonDown(_Cancel))
            {
                Pausa();
            }

            transform.Translate(Time.deltaTime * (moves.x * parameters.speed), Time.deltaTime * (moves.y * parameters.speed), 0);
        }
    }

    private void OnWillRenderObject()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }

    public void Apuntar()
    {
        Mpos = cam.ScreenToWorldPoint(Input.mousePosition);
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
        {
            cubeTestEnemy.localPosition = new Vector2(offset.x, offset.y);
        }
        Mpos.z = 0;
        pointer.LookAt(Mpos, Vector3.forward);
    }

    public void Mover(float _x, float _y)
    {
        moves = new Vector2(_x, _y);

        if (moves.y > 0 && moves.x == 0)
        {
            anim.SetBool(_mov_side, false);
            anim.SetBool(_mov_up, true);
            anim.SetBool(_mov_down, false);
        }
        if (moves.y < 0 && moves.x == 0)
        {
            anim.SetBool(_mov_side, false);
            anim.SetBool(_mov_up, false);
            anim.SetBool(_mov_down, true);
        }
        if (moves.x > 0)
        {
            anim.SetBool(_mov_side, true);
            Srender.flipX = false;
            anim.SetBool(_mov_up, false);
            anim.SetBool(_mov_down, false);
        }
        if (moves.x < 0)
        {
            anim.SetBool(_mov_side, true);
            Srender.flipX = true;
            anim.SetBool(_mov_up, false);
            anim.SetBool(_mov_down, false);
        }
        if (moves.x == 0 && moves.y == 0)
        {
            anim.SetBool(_mov_side, false);
            anim.SetBool(_mov_up, false);
            anim.SetBool(_mov_down, false);
        }
    }

    public void Accion()
    {
        for (int i = 0; i < balas.Count; i++)
        {
            if (balas[i] == null)
            {
                balas.RemoveAt(i);
                //return;
            }
            else
            {
                balas[i].tag = _JugadorBala;
                balasL = balas[i].GetComponentsInChildren<Transform>();
                for (int x = 0; x < balasL.Length; x++)
                {
                    balasL[x].gameObject.layer = 11;
                }
                //balas[i].layer = 11;
                balaColors = balas[i].GetComponentsInChildren<SpriteRenderer>();
                for (int j = 0; j < balaColors.Length; j++)
                {
                    balaColors[j].color = parameters.returnColor;
                }
                balas[i].transform.rotation = pointer.rotation;
                balas[i].GetComponent<Bala>().speed *= parameters.returnShoot;
            }
        }
        balas.Clear();
    }

    public void Pausa()
    {
        manager.Pausa();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(_EnemigoBala))
        {
            balas.Remove(collision.gameObject);
        }
    }
}