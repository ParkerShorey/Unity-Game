using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithPlayer : MonoBehaviour
{ 
    public Transform player;

    public void Awake()
    {

    }
    public void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 2, transform.position.z);
    } 
}