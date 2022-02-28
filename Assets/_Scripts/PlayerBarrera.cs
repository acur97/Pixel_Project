using UnityEngine;

public class PlayerBarrera : MonoBehaviour
{
    [SerializeField] private PlayerControl pControl;

    private const string _EnemigoBala = "EnemigoBala";

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
