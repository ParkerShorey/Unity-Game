using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] Rigidbody2D player;
    [SerializeField] private float jumpForce;
    //public int jumpsLeft;
    
    void start(){
        player = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            player.linearVelocity = new Vector2(player.linearVelocity.x, jumpForce);
            isGrounded = false;
            
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 6){
            isGrounded = true;
            
        }
   }
}
