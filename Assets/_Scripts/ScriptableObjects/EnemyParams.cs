using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Parameters", menuName = "Scriptable Objects/Enemy Parameters", order = 1)]
public class EnemyParams : ScriptableObject
{
    public bool test = false;

    [Header ("Disparo")]
    public float shootInterval = 1;
    public float shootSpeed = 1;

    [Header("Movimiento")]
    public float speed = 1;
    public AnimationCurve steps;
    public float stepsSpeed = 2;

    [Header("Vida")]
    public int life = 5;
}