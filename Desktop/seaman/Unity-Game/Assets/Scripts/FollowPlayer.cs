using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z),
            //ref velocity, speed * Time.deltaTime);
    }
}

    /*void MoveToNewRoom(Transform _newRoom){
        currentPosX = _newRoom.position.x;
    }*/
