using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public bool canJump;
    public int groundLayer = 6;
    private void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        if (Input.GetKey(KeyCode.UpArrow) && canJump == true)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
        if (Input.GetKey(KeyCode.R))
        {
            body.position = new Vector3(0,0,0);
            canJump = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            canJump = true;
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6){
            canJump = false;
        }

    }
} 