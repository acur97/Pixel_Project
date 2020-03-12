using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public InGameManager manager;
    [Space]
    public float velocidad = 1;
    public float XdevolverBala = 1.5f;
    public Transform cubeTest;
    public Transform cubeTestEnemy;
    public Transform pointerTest;
    public Camera cam;
    [Space]
    public List<GameObject> balas;

    private Vector3 Mpos;
    private Vector2 moves;
    private bool balaPasando;
    private Animator anim;
    private SpriteRenderer Srender;
    private PlayerInput Pinput;

    private void Awake()
    {
        Pinput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        Srender = GetComponent<SpriteRenderer>();
        pointerTest.GetComponentsInChildren<Transform>()[1].localEulerAngles = new Vector3(-90, 90, 90);
    }

    public void OnDeviceLost(PlayerInput device)
    {
        Debug.Log("No hay control, reconecte o active otro control");
    }

    public void OnDeviceRegained(PlayerInput device)
    {
        Debug.Log("Control reconectado");
    }

    public void OnControlsChanged(PlayerInput change)
    {
        Debug.Log(change.currentControlScheme);
    }

    public void OnMover(InputValue value)
    {
        if (manager.InGame)
        {
            moves = value.Get<Vector2>();

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
        }
    }

    public void OnApuntar(InputValue value)
    {
        if (manager.InGame)
        {
            if (Pinput.currentControlScheme == "TecladoMouse")
            {
                Mpos = cam.ScreenToWorldPoint(value.Get<Vector2>());
                cubeTest.position = new Vector3(Mpos.x, Mpos.y);
            }
            else
            {
                Mpos = value.Get<Vector2>();
                cubeTest.localPosition = new Vector3(Mpos.x, Mpos.y);
            }
            pointerTest.LookAt(cubeTest.position, Vector3.forward);

            // invertido rojo
            Vector2 offset = new Vector2(-cubeTest.localPosition.x, -cubeTest.localPosition.y);
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
                cubeTestEnemy.localPosition = new Vector3(offset.x, offset.y);
            }
            Mpos.z = 0;
            pointerTest.LookAt(Mpos, Vector3.forward);
        }
    }

    public void OnAccion()
    {
        if (manager.InGame)
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
                    balas[i].tag = "JugadorBala";
                    Transform[] balasL = balas[i].GetComponentsInChildren<Transform>();
                    for (int x = 0; x < balasL.Length; x++)
                    {
                        balasL[x].gameObject.layer = 11;
                    }
                    //balas[i].layer = 11;
                    SpriteRenderer[] balaColors = balas[i].GetComponentsInChildren<SpriteRenderer>();
                    for (int j = 0; j < balaColors.Length; j++)
                    {
                        balaColors[j].color = new Color32(0, 255, 0, 255);
                    }
                    balas[i].transform.rotation = pointerTest.rotation;
                    float vel = balas[i].GetComponent<Bala>().velocidad;
                    balas[i].GetComponent<Bala>().velocidad = vel * XdevolverBala;
                }
            }
            balas.Clear();
        }
    }

    public void OnPausa()
    {
        manager.Pausa();
    }

    private void Update()
    {
        if (manager.InGame)
        {
            transform.position += new Vector3(Time.unscaledDeltaTime * (moves.x * velocidad), Time.unscaledDeltaTime * (moves.y * velocidad));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("EnemigoBala"))
        {
            balas.Remove(collision.gameObject);
        }
    }
}