using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public float bulletPower;
    int dir;

    GameObject[] bulletPool = new GameObject[5];

    PlayerMove playerMove;


    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();

        for(int i = 0; i < bulletPool.Length; i++)
        {
            GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;

            bulletPool[i] = bullet;
            bulletPool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            for(int i = 0; i < bulletPool.Length; i++)
            {
                GameObject bullet = bulletPool[i];

                if(!bullet.activeSelf)
                {
                    bullet.SetActive(true);

                    if(playerMove.sr.flipX)
                    {
                        dir = -1;
                    }
                    else
                    {
                        dir = 1;
                    }

                    bullet.transform.position = transform.position + new Vector3(dir * 0.5f, -0.3f, 0);
                    bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * dir * bulletPower, ForceMode2D.Impulse);

                    StartCoroutine(ResetBullet(bullet));

                    break;
                }
            }
        }
    }


    IEnumerator ResetBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(1f);

        bullet.SetActive(false);
    }
}
