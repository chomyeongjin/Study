using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    Rigidbody2D rig;
    int dir;

    bool isChange;

    Vector3 rayPos;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        RandomDir();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(dir, rig.velocity.y);

        if (rig.velocity.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }


        Debug.DrawRay(transform.position + rayPos, Vector2.down * 1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayPos, Vector2.down, 1);

        if(!hit)
        {
            ChangeDir();
        }
        else
        {
            if(hit.collider.gameObject.tag != "Floor")
            {
                ChangeDir();
            } else
            {
                isChange = false;
            }
            
        }

        switch(dir)
        {
            case 0:
                anim.SetBool("isWalk", false);
                break;
            case -1:
                anim.SetBool("isWalk", true);
                rayPos = new Vector3(-0.7f, 0, 0);
                break;
            case 1:
                anim.SetBool("isWalk", true);
                rayPos = new Vector3(0.7f, 0, 0);
                break;
        }
    }

    void ChangeDir()
    {
        if (!isChange)
        {
            dir *= -1;
            isChange = true;

            CancelInvoke();

            Invoke("RandomDir", Random.Range(2f, 3f));
        }

    }

    void RandomDir()
    {
        dir = Random.Range(-1, 2);
        Invoke("RandomDir", Random.Range(2f, 3f));
    }


}
