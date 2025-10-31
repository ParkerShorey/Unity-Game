/* using UnityEngine;
using UnityEngine.SceneManagement;
public class DoubleJump : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private bool dj;
    [SerializeField] public JumpController jump;
    [SerializeField] public PlayerController PlayerController;

    
    void Start(){
        player = GetComponent<GameObject>();
        jump = GetComponent<JumpController>();
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 3){
            allowDoubleJump();
        }
    }
    public void allowDoubleJump(){
        dj = true;
    }
    public void disableDoubleJump(){
        dj = false;
    }
    public bool canDoubleJump(){
        return dj;
    }
}
*/