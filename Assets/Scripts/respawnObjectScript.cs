using UnityEngine;
using UnityEngine.Tilemaps;

public class respawnObjectScript : MonoBehaviour
{
    public TilemapCollider2D kill2D;
    void Start()
    {
        kill2D = GetComponent<TilemapCollider2D>();
    }

    void Update()
    {
        
    }
}
