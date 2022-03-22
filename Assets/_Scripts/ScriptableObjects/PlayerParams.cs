using UnityEngine;

[CreateAssetMenu(fileName = "Player Parameters", menuName = "Scriptable Objects/Player Parameters", order = 0)]
public class PlayerParams : ScriptableObject
{
    public bool test = false;

    [Header("Movimiento")]
    public float speed = 1;

    [Header("Accion")]
    public float returnShootSpeed = 1.5f;
    public Color returnColor = new Color32(0, 255, 0, 255);
    public int returnDamageMulti = 1;

    [Header("Vida")]
    public int life = 10;
}