using UnityEngine;
using UnityEngine.SceneManagement;

public class T_End_Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
       {
            SceneManager.LoadScene("Main_Menu");
       } 
    }
}
