using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D body;
    Vector2 startPosition;
    private float maxSpeed = 10;
    private float accel = 0.01f;
    [SerializeField] private float maxFallSpeed;
    //private float velocityX = body.linearVelocity.x;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        //DontDestroyOnLoad(this.gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "ChangeScene"){
            body.position = startPosition;
        }
        if(collision.gameObject.layer == 7){
            transform.position = startPosition;
        }
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
} 