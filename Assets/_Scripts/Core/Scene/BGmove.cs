using UnityEngine;

public class BGmove : MonoBehaviour
{
    private Transform player;

    [SerializeField] private Material material;
    [SerializeField] private Vector2 speed = new(0.154321f, 0.2777778f);

    private readonly int _Offset = Shader.PropertyToID("_Offset");

    private void Awake()
    {
        player = PlayerControl.Instance.transform;
    }

    private void Update()
    {
        transform.position = player.position;
        material.SetVector(_Offset, new Vector2(player.position.x * speed.x, player.position.y * speed.y));
    }
}