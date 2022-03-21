using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform Pcontrol;

    [Space]
    [SerializeField] private Transform PadreEnemigos;
    [SerializeField] private GameObject Prefab;

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

    private Vector3 zero = new Vector3(-90, 0, 0);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstanciarOleadaBordes();
        }
    }

    private void OnWillRenderObject()
    {
        transform.position = Pcontrol.position;
    }

    //public void Start()
    //{
    //    InstanciarOleadaBordes();
    //}

    public void InstanciarOleadaBordes()
    {
        for (int i = 0; i < ronda; i++)
        {
            areaPos1 = new Vector3(Random.Range(bordes1_1.position.x, bordes1_2.position.x), Random.Range(bordes1_1.position.y, bordes1_2.position.y));
            ob1 = Instantiate(Prefab, areaPos1, Quaternion.Euler(zero), PadreEnemigos);
            enemigos.Add(ob1);

            areaPos2 = new Vector3(Random.Range(bordes2_1.position.x, bordes2_2.position.x), Random.Range(bordes2_1.position.y, bordes2_2.position.y));
            ob2 = Instantiate(Prefab, areaPos2, Quaternion.Euler(zero), PadreEnemigos);
            enemigos.Add(ob2);

            areaPos3 = new Vector3(Random.Range(bordes3_1.position.x, bordes3_2.position.x), Random.Range(bordes3_1.position.y, bordes3_2.position.y));
            ob3 = Instantiate(Prefab, areaPos3, Quaternion.Euler(zero), PadreEnemigos);
            enemigos.Add(ob3);

            areaPos4 = new Vector3(Random.Range(bordes4_1.position.x, bordes4_2.position.x), Random.Range(bordes4_1.position.y, bordes4_2.position.y));
            ob4 = Instantiate(Prefab, areaPos4, Quaternion.Euler(zero), PadreEnemigos);
            enemigos.Add(ob4);

            areaPos5 = borde_invertido.position;
            ob5 = Instantiate(Prefab, areaPos5, Quaternion.Euler(zero), PadreEnemigos);
            enemigos.Add(ob5);
        }
    }
}