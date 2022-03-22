using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Parameters", menuName = "Scriptable Objects/Bullet Parameters", order = 0)]
public class BulletParams : ScriptableObject
{
    public bool test = false;

    [Space]
    public GameObject prefab;

    [Header("Visual")]
    public Color startColor = Color.white;

    [Header("Valores")]
    public float deathTime = 5;
    public int damage = 1;
}