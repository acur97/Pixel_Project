using UnityEngine;

public class PoolBalas : MonoBehaviour
{
    public static PoolBalas Instance { get; private set; }

    [SerializeField] private BulletParams parameters;
    [SerializeField] private int count = 100;

    private Transform root;
    private GameObject[] ob;
    private Bala bl;
    private bool found = false;

    private const string rootName = "Balas";
    private const string mas = "Mas pool";
    private const string _EnemigoBala = "EnemigoBala";

    private void Awake()
    {
        Instance = this;

        root = new GameObject(rootName).transform;
        root.SetParent(transform);

        SetPool();
    }

    private void SetPool()
    {
        ob = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            ob[i] = Instantiate(parameters.prefab, Vector3.zero, Quaternion.identity, root);
            ob[i].name = parameters.name + i;
            ob[i].SetActive(false);
        }

        System.GC.Collect();
    }

    public void GetBala(Vector3 Position, Quaternion Rotation, float speed)
    {
        found = false;
        for (int i = 0; i < count; i++)
        {
            if (!ob[i].activeSelf)
            {
                ob[i].tag = _EnemigoBala;
                ob[i].transform.SetPositionAndRotation(Position, Rotation);
                bl = ob[i].GetComponent<Bala>();
                for (int x = 0; x < bl.transforms.Length; x++)
                {
                    bl.transforms[x].gameObject.layer = 12;
                }
                for (int j = 0; j < bl.sprites.Length; j++)
                {
                    bl.sprites[j].color = parameters.startColor;
                }
                bl.speed = speed;
                bl.timeDead = parameters.deathTime;
                bl.damage = parameters.damage;
                ob[i].SetActive(true);

                found = true;
                break;
            }
        }

        if (!found)
        {
            Debug.LogError(mas);
        }
    }
}