﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawn : MonoBehaviour
{
    public InGameManager manager;
    public Transform Pcontrol;
    public Transform BasuraBalas;
    public Transform PadreEnemigos;
    public GameObject Prefab;
    [Space]
    public Transform bordes1_1;
    public Transform bordes1_2;
    [Space]
    public Transform bordes2_1;
    public Transform bordes2_2;
    [Space]
    public Transform bordes3_1;
    public Transform bordes3_2;
    [Space]
    public Transform bordes4_1;
    public Transform bordes4_2;
    [Space]
    public Transform borde_invertido;
    [Space]
    public List<GameObject> enemigos;
    public int ronda = 1;

    private Vector3 zero = new Vector3(-90, 0, 0);

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            InstanciarOleadaBordes();
        }
    }

    public void Start()
    {
        //InstanciarOleadaBordes();
    }

    public void InstanciarOleadaBordes()
    {
        for (int i = 0; i < ronda; i++)
        {
            Vector3 areaPos1 = new Vector3(Random.Range(bordes1_1.position.x, bordes1_2.position.x), Random.Range(bordes1_1.position.y, bordes1_2.position.y));
            GameObject ob1 = Instantiate(Prefab, areaPos1, Quaternion.Euler(zero), PadreEnemigos);
            EnemyControl ob1C = ob1.GetComponent<EnemyControl>();
            ob1C.manager = manager;
            ob1C.jugador = Pcontrol;
            ob1C.padre = BasuraBalas;
            enemigos.Add(ob1);

            Vector3 areaPos2 = new Vector3(Random.Range(bordes2_1.position.x, bordes2_2.position.x), Random.Range(bordes2_1.position.y, bordes2_2.position.y));
            GameObject ob2 = Instantiate(Prefab, areaPos2, Quaternion.Euler(zero), PadreEnemigos);
            EnemyControl ob2C = ob2.GetComponent<EnemyControl>();
            ob2C.manager = manager;
            ob2C.jugador = Pcontrol;
            ob2C.padre = BasuraBalas;
            enemigos.Add(ob2);

            Vector3 areaPos3 = new Vector3(Random.Range(bordes3_1.position.x, bordes3_2.position.x), Random.Range(bordes3_1.position.y, bordes3_2.position.y));
            GameObject ob3 = Instantiate(Prefab, areaPos3, Quaternion.Euler(zero), PadreEnemigos);
            EnemyControl ob3C = ob3.GetComponent<EnemyControl>();
            ob3C.manager = manager;
            ob3C.jugador = Pcontrol;
            ob3C.padre = BasuraBalas;
            enemigos.Add(ob3);

            Vector3 areaPos4 = new Vector3(Random.Range(bordes4_1.position.x, bordes4_2.position.x), Random.Range(bordes4_1.position.y, bordes4_2.position.y));
            GameObject ob4 = Instantiate(Prefab, areaPos4, Quaternion.Euler(zero), PadreEnemigos);
            EnemyControl ob4C = ob4.GetComponent<EnemyControl>();
            ob4C.manager = manager;
            ob4C.jugador = Pcontrol;
            ob4C.padre = BasuraBalas;
            enemigos.Add(ob4);

            Vector3 areaPos5 = borde_invertido.position;
            GameObject ob5 = Instantiate(Prefab, areaPos5, Quaternion.Euler(zero), PadreEnemigos);
            EnemyControl ob5C = ob5.GetComponent<EnemyControl>();
            ob5C.manager = manager;
            ob5C.jugador = Pcontrol;
            ob5C.padre = BasuraBalas;
            enemigos.Add(ob5);
        }
    }
}