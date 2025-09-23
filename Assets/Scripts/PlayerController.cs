using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D body;
    
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        
        if (Input.GetKey(KeyCode.R))
        {
            body.position = new Vector3(0,0,0);
            
            
        }
    }
} 