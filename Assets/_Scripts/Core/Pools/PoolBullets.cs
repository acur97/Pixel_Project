using System.Collections.Generic;
using UnityEngine;

public class PoolBullets : MonoBehaviour
{
    public static PoolBullets Instance { get; private set; }

    [SerializeField] private BulletParams parameters;
    [SerializeField] private int count = 100;

    private Transform root;
    private GameObject[] ob;
    private Bullet[] bl;
    private readonly Dictionary<int, Bullet> bulletsDic = new();
    private bool found = false;

    private const string rootName = "_Bullets";
    private const string debug_more = "Mas pool";

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
        bl = new Bullet[count];
        for (int i = 0; i < count; i++)
        {
            ob[i] = Instantiate(parameters.prefab.gameObject, Vector3.zero, Quaternion.identity, root);
            ob[i].name = parameters.name + i;
            bl[i] = ob[i].GetComponent<Bullet>();
            ob[i].SetActive(false);
            bulletsDic.Add(ob[i].GetInstanceID() - 2, bl[i]);
        }

        System.GC.Collect();
    }

    public void SetBullet(Vector3 _position, Quaternion _rotation, float _speed, BulletType _bulletType)
    {
        found = false;
        for (int i = 0; i < count; i++)
        {
            if (!ob[i].activeSelf)
            {
                ob[i].transform.SetPositionAndRotation(_position, _rotation);
                bl[i].bulletType = _bulletType;
                bl[i].speed = _speed;
                bl[i].damage = parameters.damage;
                bl[i].timeDeath = parameters.deathTime;
                for (int j = 0; j < bl[i].sprites.Length; j++)
                {
                    bl[i].sprites[j].color = parameters.startColor;
                }
                ob[i].SetActive(true);

                found = true;
                break;
            }
        }

        if (!found)
        {
            Debug.LogError(debug_more);
        }
    }

    public Bullet GetBulletComponent(int id)
    {
        return bulletsDic[id];
    }
}