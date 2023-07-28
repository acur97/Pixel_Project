using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Parameters", menuName = "Scriptable Objects/Enemy Parameters", order = 1)]
public class EnemyParams : ScriptableObject
{
    [Header("Movement")]
    public float speed = 1;
    public AnimationCurve steps;
    public float stepsSpeed = 2;

    [Header("Actions")]
    public BulletParams bulletParams;
    public float shootInterval = 1;
    public float shootSpeed = 1;
    public int collisionDamage = 4;

    [Header("Health")]
    public int life = 5;
}