using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    public float speed;
    public float distance;

    Vector2 originPos;

    int direction = 1;

    bool isDead;
    SpriteRenderer sr;
    float colorSpeed = 5f;
    
    void Start()
    {
        originPos = gameObject.transform.position;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            BatMoveControl();
        } else
        {
            sr.color = Vector4.Lerp(sr.color, new Vector4(1, 1, 1, 0), Time.deltaTime * colorSpeed);

            if(sr.color.a <= 0.5f)
            {
                Destroy(gameObject);
            }
        }
    }

    void BatMoveControl()
    {
        Vector2 targetPos = originPos + new Vector2(0, distance * direction);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.01f)
        {
            direction *= -1;
        }
    }

    public void Dead()
    {
        isDead = true;
    }
}
