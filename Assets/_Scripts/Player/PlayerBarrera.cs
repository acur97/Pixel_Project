using UnityEngine;

public class PlayerBarrera : MonoBehaviour
{
    private PlayerControl pControl;

    private const string _EnemigoBala = "EnemigoBala";

    private void Start()
    {
        pControl = PlayerControl.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag(_EnemigoBala))
        {
            pControl.balas.Add(collision.transform.parent.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag(_EnemigoBala))
        {
            pControl.balas.Remove(collision.transform.parent.gameObject);
        }
    }
}
