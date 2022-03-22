using UnityEngine;

public class BGmove : MonoBehaviour
{
    public Transform player;
    public Material mat1;
    public float speed = 0.154321f;

    private void Update()
    {
        transform.position = player.position;
        mat1.mainTextureOffset = new Vector2(player.position.x * speed, player.position.y * speed);
    }
}