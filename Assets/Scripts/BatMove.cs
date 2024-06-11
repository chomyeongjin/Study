using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    public float speed;
    public float distance;

    Vector2 originPos;

    int direction = 1;
    
    void Start()
    {
        originPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = originPos + new Vector2(0, distance * direction);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, targetPos) < 0.01f)
        {
            direction *= -1;
        }
    }
}
