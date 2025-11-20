/*using UnityEngine;
using UnityEngine.SceneManagement;
public class DoubleJump : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] public  jump;
    
    void Start()
    {
        player = GetComponent<GameObject>();
        jump = GetComponent<JumpController>();
        
    }

    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            jump.canDoubleJump = true;
            Destroy(this.gameObject);
        }
    }
    

}
*/