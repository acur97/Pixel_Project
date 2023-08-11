using UnityEngine;

[CreateAssetMenu(fileName = "Player Parameters", menuName = "Scriptable Objects/Parameters/Player", order = 0)]
public class PlayerParams : ScriptableObject
{
    public bool test;

    [Header("Movement")]
    public float speed = 1;

    [Header("Actions")]
    public float returnShootSpeed = 1.5f;
    public int returnDamage = 1;
    public Color returnColor = new Color32(0, 255, 0, 255);

    [Header("Health")]
    public int life = 10;
}