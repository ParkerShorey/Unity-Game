using UnityEngine;
using System.Collections;

public class Teleport_Orb : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] public Transform Teleport_Point;
    public bool isTeleporting = false;
    //[SerializeField] private BoxCollider2D collider
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isTeleporting = true;
            player.position = Teleport_Point.position;
        }       
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isTeleporting = false;
        }
    }
    
    
}
