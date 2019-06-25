using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float velocidad;
    public float XdevolverBala;
    public Transform cubeTest;
    public Transform pointerTest;
    public Camera cam;
    [Space]
    public List<GameObject> balas;
    public List<GameObject> enemigos;

    private Vector3 Mpos;
    private Vector2 moves;
    private bool balaPasando;
    private Animator anim;
    private SpriteRenderer Srender;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Srender = GetComponent<SpriteRenderer>();
        pointerTest.GetComponentsInChildren<Transform>()[1].localEulerAngles = new Vector3(-90, 90, 90);
    }

    private void Update()
    {
        moves = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += new Vector3(Time.unscaledDeltaTime * (moves.x * velocidad), Time.unscaledDeltaTime * (moves.y * velocidad));

        if (moves.y > 0 && moves.x == 0)
        {
            anim.SetBool("mov_side", false);
            anim.SetBool("mov_up", true);
            anim.SetBool("mov_down", false);
        }
        if (moves.y < 0 && moves.x == 0)
        {
            anim.SetBool("mov_side", false);
            anim.SetBool("mov_up", false);
            anim.SetBool("mov_down", true);
        }
        if (moves.x > 0)
        {
            anim.SetBool("mov_side", true);
            Srender.flipX = false;
            anim.SetBool("mov_up", false);
            anim.SetBool("mov_down", false);
        }
        if (moves.x < 0)
        {
            anim.SetBool("mov_side", true);
            Srender.flipX = true;
            anim.SetBool("mov_up", false);
            anim.SetBool("mov_down", false);
        }
        if (moves.x == 0 && moves.y == 0)
        {
            anim.SetBool("mov_side", false);
            anim.SetBool("mov_up", false);
            anim.SetBool("mov_down", false);
        }

        Mpos = cam.ScreenToWorldPoint(Input.mousePosition);
        cubeTest.position = new Vector3(Mpos.x, Mpos.y);
        Mpos.z = 0;
        pointerTest.LookAt(Mpos, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < balas.Count; i++)
            {
                balas[i].transform.rotation = pointerTest.rotation;
                float vel = balas[i].GetComponent<Bala>().velocidad;
                balas[i].GetComponent<Bala>().velocidad = vel * XdevolverBala;
            }
            for (int i = 0; i < enemigos.Count; i++)
            {
                enemigos[i].GetComponent<EnemyControl>().Explotar();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("EnemigoBala"))
        {
            balas.Add(collision.transform.parent.gameObject);
        }
        if (collision.transform.parent.CompareTag("Enemigo"))
        {
            enemigos.Add(collision.transform.parent.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("EnemigoBala"))
        {
            balas.Remove(collision.transform.parent.gameObject);
        }
        if (collision.transform.parent.CompareTag("Enemigo"))
        {
            enemigos.Remove(collision.transform.parent.gameObject);
        }
    }
}