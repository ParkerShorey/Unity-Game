using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    [SerializeField] public float jumpForce;
    [SerializeField] public Vector3 startPosition;
    [SerializeField] public Transform circlePos;
    [SerializeField] public float checkRadius;
    [SerializeField] LayerMask whatIsGround;
    //[SerializeField] public Transform wallCheck;
    //[SerializeField] LayerMask wallLayer;
    //private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping; 
    public int maximimumjumps = 2;
    public float maximumSpeed = 7;
    public float numDashes = 1;
    private bool canDash = true;
    private bool isDashing = false;
    private float dashingPower = 24f;
    private float dashingTime = .2f;
    [SerializeField] private float dashCooldown;


    //[Header("For Wallsliding")]
    //[SerializeField] public Transform wallCheck;
    
    //[SerializeField] private bool isWallSliding;

    // try to make the bool always true when holding against a wall and then make a function so that when that is happening, the player will have a constant negative velocity
    [Header("For WallJumping")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] LayerMask wallLayer;
    private float wallJumpCooldown;

    void Awake()
    {
        startPosition = rb.position;
    }

    void start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        //startPosition = rb.position;
    }
    
    void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        //Vector2 moveVector = (moveInput * speed, 0f);
        // try to add a force more with a timer so that it will accelerate the player for a certain amount of time and reset when the player stops moving horizontally or changes direction
        
        //testCases();
        /*if(rb.velocity.x > maximumSpeed)
        {
            // this will not work, add force instead
        }
        /*while(moveInput != 0)
        {
            if(curentSpeed < maximumSpeed){
                speed = speed * moveInput * Time.deltaTime;
            }
            rb.velocity = new Vector2(speed, rb.velocity.y); While the player is inputting movement, if the movement was less than their maximum speed, it was supposed to increase their speed
        Need to watch video on how to implement this correctly
        
        }*/
        
    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }
        if(moveInput > 0.01f){
            transform.localScale = new Vector3(1,1,1);
        }
        else if(moveInput < -0.01f){
            transform.localScale = new Vector3(-1,1,1);
        }
         // Uses a circle object on the player to decide when they are touching the ground
        //CheckCol(); 
        //WallSlide();
        Jump();
        TouchingWall();
        if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
        //Debug.Log(TouchingWall());
        if(TouchingWall() && !IsGrounded() && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Should Wall Jump");
            WallJump();
            //wallJumpCooldown = 0;
        }
            
            
            if (Input.GetKey(KeyCode.LeftArrow) && TouchingWall()){
                Debug.Log("left");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x - 10 , rb.linearVelocity.y);
            } else if (Input.GetKey(KeyCode.RightArrow) && TouchingWall()) {
                Debug.Log("right");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x + 10 , rb.linearVelocity.y);
            }
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "ChangeScene"){
            rb.position = startPosition;
            Debug.Log("scene change!!!!");
        }
        if(collision.gameObject.layer == 7){
            Debug.Log("I died!");      
            transform.position = startPosition;
            Debug.Log(startPosition);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(circlePos.position, checkRadius, whatIsGround);
    }
    void Jump()
    {
        if(IsGrounded() && Input.GetButtonDown("Jump")){ // this will run when the button is pressed initially
            Debug.Log("Pressed");
            isJumping = true;
            jumpTimeCounter = jumpTime; 
            rb.linearVelocity = Vector2.up * jumpForce; // adds the jumpforce to the players vertical velocity, I might want to make this into a force rather than velocity
            Debug.Log(isJumping);
        }

        if(Input.GetButton("Jump") && isJumping == true){ // this will run when the jump button is held
            Debug.Log("Holding");
            if(jumpTimeCounter > 0){ // will add this force as long as the time is still going
                 rb.linearVelocity = Vector2.up * jumpForce;
                 jumpTimeCounter -= Time.deltaTime;
            } else{
                isJumping = false;
            }
        }
        if(Input.GetButtonUp("Jump")) // this will run when the player releases the jump button
            {
                Debug.Log("Released");
                isJumping = false;
                Debug.Log(isJumping);
            }   
    }


    private bool TouchingWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
        Debug.Log("Touching wall");
    }

    void WallJump(){
        if(TouchingWall() && !IsGrounded() && Input.GetButtonDown("Jump")){ // this will run when the button is pressed initially
            Debug.Log("Pressed");
            isJumping = true;
            jumpTimeCounter = jumpTime; 
            rb.linearVelocity = Vector2.up * jumpForce; // adds the jumpforce to the players vertical velocity, I might want to make this into a force rather than velocity
            Debug.Log(isJumping);
        }

        if(Input.GetButton("Jump") && isJumping == true){ // this will run when the jump button is held
            Debug.Log("Holding");
            if(jumpTimeCounter > 0){ // will add this force as long as the time is still going
                 rb.linearVelocity = Vector2.up * jumpForce;
                 jumpTimeCounter -= Time.deltaTime;
            } else{
                isJumping = false;
            }
        }
        if(Input.GetButtonUp("Jump")) // this will run when the player releases the jump button
            {
                Debug.Log("Released");
                isJumping = false;
                Debug.Log(isJumping);
            }   
    }


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float ogGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = ogGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    /*void testCases()
    {
        speed = 9;
    }*/


    
    
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
