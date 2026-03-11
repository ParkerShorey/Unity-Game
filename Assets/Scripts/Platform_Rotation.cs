using UnityEngine;

public class Platform_Rotation : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed;
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.rotation += rotationSpeed;
    }
}
