using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Parameters", menuName = "Scriptable Objects/Parameters/Bullet", order = 2)]
public class BulletParams : ScriptableObject
{
    public Bullet prefab;
    public new string name;

    [Header("Visual")]
    public Color startColor = Color.white;

    [Header("Data")]
    public BulletType type;
    public int damage = 1;

    [Space]
    public float deathTime = 5;
}