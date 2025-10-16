using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D body;
    Vector2 startPosition;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
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
/*    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7){
            transform.position = startPosition;
            body.linearVelocity = new Vector2(0, 0);
            Debug.Log("Player is touching an object on layer 7 (trigger interaction).");
        }
   } */
} 