using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToNext : MonoBehaviour
{
   void Start()
   {
     
   }
   
  
   private void OnTriggerEnter2D(Collider2D collision)
   {
        if(collision.CompareTag("Player")){
            Debug.Log("I'm colliding it right now!");
            SceneManagement.instance.NextLevel();
        }
   }
   
}
