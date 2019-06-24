using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float velocidad;
    public Transform cubeTest;
    public Transform pointerTest;
    public Camera cam;
    [Space]
    public List<GameObject> balas;
    public List<GameObject> enemigos;

    private Vector3 Mpos;
    private bool balaPasando;

    private void Awake()
    {
        pointerTest.GetComponentsInChildren<Transform>()[1].localEulerAngles = new Vector3(-90, 90, 90);
    }

    private void Update()
    {
        transform.position += new Vector3(Time.unscaledDeltaTime * (Input.GetAxis("Horizontal") * velocidad), Time.unscaledDeltaTime * (Input.GetAxis("Vertical") * velocidad));

        Mpos = cam.ScreenToWorldPoint(Input.mousePosition);
        cubeTest.position = new Vector3(Mpos.x, Mpos.y);
        Mpos.z = 0;
        pointerTest.LookAt(Mpos, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < balas.Count; i++)
            {
                balas[i].transform.rotation = pointerTest.rotation;
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