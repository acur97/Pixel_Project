using UnityEngine;

public class PoolBalas : MonoBehaviour
{
    public static PoolBalas Instance { get; private set; }

    [SerializeField] private BulletParams parameters;
    [SerializeField] private int count = 100;

    private Transform root;
    private GameObject[] ob;
    private SpriteRenderer[] obColors;
    private Bala bl;
    private bool found = false;

    private const string rootName = "Balas";
    private const string mas = "Mas pool";

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
                ob[i].transform.SetPositionAndRotation(Position, Rotation);

                obColors = ob[i].GetComponentsInChildren<SpriteRenderer>();
                for (int j = 0; j < obColors.Length; j++)
                {
                    obColors[j].color = parameters.startColor;
                }

                ob[i].layer = 12;

                bl = ob[i].GetComponent<Bala>();
                bl.speed = speed;
                bl.timeDead = parameters.deathTime;

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