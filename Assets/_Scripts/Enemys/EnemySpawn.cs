using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Transform pControl;
    private Transform root;
    [SerializeField] private GameObject prefab;

    [Space]
    [SerializeField] private Transform bordes1_1;
    [SerializeField] private Transform bordes1_2;
    [Space]
    [SerializeField] private Transform bordes2_1;
    [SerializeField] private Transform bordes2_2;
    [Space]
    [SerializeField] private Transform bordes3_1;
    [SerializeField] private Transform bordes3_2;
    [Space]
    [SerializeField] private Transform bordes4_1;
    [SerializeField] private Transform bordes4_2;
    [Space]
    [SerializeField] private Transform borde_invertido;

    [Space]
    [SerializeField] private List<GameObject> enemigos;

    [SerializeField] private int ronda = 1;

    private Vector3 areaPos1 = Vector3.zero;
    private GameObject ob1;
    private Vector3 areaPos2 = Vector3.zero;
    private GameObject ob2;
    private Vector3 areaPos3 = Vector3.zero;
    private GameObject ob3;
    private Vector3 areaPos4 = Vector3.zero;
    private GameObject ob4;
    private Vector3 areaPos5 = Vector3.zero;
    private GameObject ob5;

    private Vector3 zero = new(-90, 0, 0);

    private const string rootName = "_Enemys";

    private void Awake()
    {
        root = new GameObject(rootName).transform;
        root.SetParent(transform);
    }

    private void Start()
    {
        pControl = PlayerControl.Instance.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstanciarOleadaBordes();
        }
    }

    public void InstanciarOleadaBordes()
    {
        transform.position = pControl.position;
        for (int i = 0; i < ronda; i++)
        {
            areaPos1 = new Vector3(Random.Range(bordes1_1.position.x, bordes1_2.position.x), Random.Range(bordes1_1.position.y, bordes1_2.position.y));
            ob1 = Instantiate(prefab, areaPos1, Quaternion.Euler(zero), root);
            enemigos.Add(ob1);

            areaPos2 = new Vector3(Random.Range(bordes2_1.position.x, bordes2_2.position.x), Random.Range(bordes2_1.position.y, bordes2_2.position.y));
            ob2 = Instantiate(prefab, areaPos2, Quaternion.Euler(zero), root);
            enemigos.Add(ob2);

            areaPos3 = new Vector3(Random.Range(bordes3_1.position.x, bordes3_2.position.x), Random.Range(bordes3_1.position.y, bordes3_2.position.y));
            ob3 = Instantiate(prefab, areaPos3, Quaternion.Euler(zero), root);
            enemigos.Add(ob3);

            areaPos4 = new Vector3(Random.Range(bordes4_1.position.x, bordes4_2.position.x), Random.Range(bordes4_1.position.y, bordes4_2.position.y));
            ob4 = Instantiate(prefab, areaPos4, Quaternion.Euler(zero), root);
            enemigos.Add(ob4);

            areaPos5 = borde_invertido.position;
            ob5 = Instantiate(prefab, areaPos5, Quaternion.Euler(zero), root);
            enemigos.Add(ob5);
        }
    }
}