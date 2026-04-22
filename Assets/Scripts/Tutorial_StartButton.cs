using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial_StartButton : MonoBehaviour
{
    public void OnStartClick(){
        SceneManager.LoadScene("Tutorial_WallJump");
    
    }
}
