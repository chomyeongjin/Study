using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformIgnore : MonoBehaviour
{
    public Collider2D platform;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // true일때 콜라이더 무시
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), platform, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // true일때 콜라이더 무시
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), platform, false);
        }
    }
}
