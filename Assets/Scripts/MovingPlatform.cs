using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{
    //Code made using tutorial https://www.youtube.com/watch?v=oftgVDuxn8k&list=PLaaFfzxy_80EWnrTHyUkkIy6mJrhwGYN0&index=22
    //2nd Rendition made using https://www.youtube.com/watch?v=-NLuiTV0-ns
    [SerializeField] public Transform[] points;
    [SerializeField] public  float moveSpeed;
    private int pointIndex;
    void Start()
    {
        transform.position = points[pointIndex].transform.position;
    }
    
    void Update()
    {
       if(pointIndex <= points.Length - 1)
       {
            transform.position = Vector2.MoveTowards(transform.position, points[pointIndex].transform.position, moveSpeed * Time.deltaTime);
            if(transform.position == points[pointIndex].transform.position)
            {
                pointIndex++;
            }

            if(pointIndex == points.Length)
            {
                pointIndex = 0;
            }
       }

    
            
    }
}

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }*/

