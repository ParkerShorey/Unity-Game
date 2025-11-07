using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] Rigidbody2D player;
    [SerializeField] private float jumpForce;
    //public float jumpBy = 5;
    public int jumpsLeft;
    [SerializeField] public bool canDoubleJump; 
    //public int jumpsLeft;
    
    void start(){
        player = GetComponent<Rigidbody2D>();
    }
    void Update(){
        if(isGrounded == false){
            //player.
        }
        
        if(Input.GetButtonDown("Jump")){
        Jump();
        Debug.Log("Jumps Left" + jumpsLeft);
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 6){
            isGrounded = true;
            if(canDoubleJump){
                jumpsLeft = 2;
            }
            else{
                jumpsLeft = 1;
            }
        }
   }
   void Jump(){
        if(jumpsLeft > 0){
            player.linearVelocity = new Vector2(player.linearVelocity.x,jumpForce);
            isGrounded = false;
            jumpsLeft--;
        }
   }
}
