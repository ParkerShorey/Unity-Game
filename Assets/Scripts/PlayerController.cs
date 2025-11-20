using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    [SerializeField] public float jumpForce;
    [SerializeField] public Vector3 startPosition;
    

    private float acceleration;
    private float maximumSpeed;
    private float startingSpeed;
    //public float currentSpeed = rb.velocity.x;
    
    private bool isGrounded;
    [SerializeField] public Transform circlePos;
    [SerializeField] public float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping; 
    public int jumpsLeft = 1;


    void start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        /*while(moveInput != 0)
        {
            if(curentSpeed < maximumSpeed){
                speed = speed * moveInput * Time.deltaTime;
            }
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }*/
        
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(circlePos.position, checkRadius, whatIsGround);
        if(isGrounded && Input.GetButtonDown("Jump")){
            Debug.Log("Pressed");
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            
        }

        if(Input.GetButton("Jump") && isJumping == true){
            if(jumpTimeCounter > 0){
                 rb.velocity = Vector2.up * jumpForce;
                 jumpTimeCounter -= Time.deltaTime;
            } else{
                isJumping = false;
            }
        }
        if(Input.GetButtonUp("Jump"))
            {
                Debug.Log("Released");
                isJumping = false;
            }
           
        
        if(moveInput > 0.01f){
            transform.localScale = new Vector3(5,5,1);
        }
        else if(moveInput < -0.01f){
            transform.localScale = new Vector3(-5,5,1);
        } 
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "ChangeScene"){
            rb.position = startPosition;
        }
        if(collision.gameObject.layer == 7){
            Debug.Log("I died!");      
             transform.position = startPosition;
        }
    }
    
    
    /*[SerializeField] private float speed;
    public Rigidbody2D body;
    Vector2 startPosition;
    private float maxSpeed = 10;
    private float accel = 0.01f;
    [SerializeField] private float maxFallSpeed;
    //private float velocityX = body.linearVelocity.x;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        //DontDestroyOnLoad(this.gameObject);
    }
    
    
    private void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        if(horizontalInput > 0.01f){
            transform.localScale = new Vector3(5,5,1);
        }
        else if(horizontalInput < -0.01f){
            transform.localScale = new Vector3(-5,5,1);
        } 

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = startPosition;
        }
    }
} */
}