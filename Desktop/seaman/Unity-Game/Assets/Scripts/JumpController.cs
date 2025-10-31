/*using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] public bool isGrounded;
    [SerializeField] public Rigidbody2D player;
    [SerializeField] private float jumpForce;
    [SerializeField] public int jumpsLeft;
    public PlayerController PlayerController;
    public DoubleJump DoubleJump;
    
    void start(){
        player = GetComponent<Rigidbody2D>();
        PlayerController = GetComponent<PlayerController>();
        DoubleJump = GetComponent<DoubleJump>();
    }
    void Update(){
        if(Input.GetButtonDown("Jump")){
            Jump();
            Debug.Log("Jumps Left" + jumpsLeft);
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        isGrounded = true;
        if(DoubleJump.canDoubleJump()){
            jumpsLeft = 2;
        } else {
            jumpsLeft = 1;
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
*/