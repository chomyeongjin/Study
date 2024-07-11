using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed = 5; // 플레이어 움직임 속도

    public float jumpForce;
    public bool isJump;

    [HideInInspector]
    public Rigidbody2D rig;
    Animator anim;

    [HideInInspector]
    public SpriteRenderer sr;

   
    public bool isLadder; //사다리 변수
    public int upSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌우 이동코드
        float Xinput = Input.GetAxisRaw("Horizontal");
        rig.AddForce(Vector2.right * Xinput, ForceMode2D.Impulse);  // 방향 * 힘 // 힘의 종류 -> impulse: 불연속 (짧은 순간 힘)

        if(rig.velocity.x > speed) // 움직이고 있다
        {
            // 제한속도
            rig.velocity = new Vector2(speed, rig.velocity.y);
        } else if(rig.velocity.x < -speed)
        {
            rig.velocity = new Vector2(-speed, rig.velocity.y);
        }

        // jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJump && !isLadder)
            {
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("isJump", true);
                isJump = true;
            }
        }

        

        // 미끄러짐 방지
        if (Input.GetButtonUp("Horizontal"))
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
            anim.SetBool("isWalk", false);
        }

        // 방향 반대
        if(Xinput != 0)
        {
            sr.flipX = Input.GetAxisRaw("Horizontal") == -1;
            anim.SetBool("isWalk", true);
        }
    }

    private void FixedUpdate()
    {
        if(isLadder)
        {
            // 위아래 키보드
            float ver = Input.GetAxisRaw("Vertical");
            rig.velocity = new Vector2(rig.velocity.x, ver * upSpeed);

            rig.gravityScale = 0;

            if(ver != 0)
            {
                anim.SetBool("isClimb", true);
            }
        } else
        {
            rig.gravityScale = 1;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;

            anim.SetBool("isClimb", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }

        if(collision.gameObject.CompareTag("Enemies"))
        {
            anim.SetBool("isHurt", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            anim.SetBool("isHurt", false);
        }
    }
}


