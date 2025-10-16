using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] Rigidbody2D player;
    [SerializeField] private float jumpForce;
    public float jumpBy = 5;
    //public int jumpsLeft;
    
    void start(){
        player = GetComponent<Rigidbody2D>();
    }
    void Update(){
        if(Input.GetButtonDown("Jump")){
            jumpBy += player.linearVelocity.y + 5;
            player.linearVelocity = new Vector2(player.linearVelocity.x, jumpBy /*player.linearVelocity.y*/);
            isGrounded = false;
        } else {
            jumpBy = 5;
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 6){
            isGrounded = true;
        }
   }
}
