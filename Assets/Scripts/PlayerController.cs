using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Controls how fast the player moves
    private Rigidbody2D rb;            // Reference to the player's Rigidbody2D component
    private Vector2 moveInput;         // Stores the player's movement input (x, y)

    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Read raw input from the keyboard (arrow keys or WASD)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Combine input into a single vector and normalize it so diagonal movement isn't faster
        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody using velocity
        rb.linearVelocity = moveInput * moveSpeed;
    }
}

/*using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public Rigidbody2D player;
    public Vector2 startPosition;
    
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        //DontDestroyOnLoad(this.gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 7){
            transform.position = startPosition;
            player.linearVelocity = new Vector2(0, 0);
            Debug.Log("Player is touching an object on layer 7 (trigger interaction).");
        }
        if(collision.gameObject.tag == "ChangeScene"){
            player.position = startPosition;
        }
    }
    
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        player.linearVelocity = new Vector2(horizontalInput * speed, player.linearVelocity.y);
        if(horizontalInput > 0.01f){
            transform.localScale = new Vector3(3,3,1);
        }
        else if(horizontalInput < -0.01f){
            transform.localScale = new Vector3(-3,3,1);
        } 

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = startPosition;
        }
    }
} 
*/