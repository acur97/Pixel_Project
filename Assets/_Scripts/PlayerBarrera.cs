using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrera : MonoBehaviour
{
    public PlayerControl pControl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("EnemigoBala"))
        {
            pControl.balas.Add(collision.transform.parent.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("EnemigoBala"))
        {
            pControl.balas.Remove(collision.transform.parent.gameObject);
        }
    }
}
