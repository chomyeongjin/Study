using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    Rigidbody2D rig;
    int dir;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        RandomDir();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(dir, rig.velocity.y);

        if(rig.velocity.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void RandomDir()
    {
        dir = Random.Range(-1, 2);

        Invoke("RandomDir", Random.Range(2f, 3f));
    }
}
