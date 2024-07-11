using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public float camSpeed;

    public Vector2 camCenter, camSize;
    float widthHalf, heightHalf;

    // Start is called before the first frame update
    void Start()
    {
        heightHalf = Camera.main.orthographicSize;
        widthHalf = (float)Screen.width / (float)Screen.height * heightHalf;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(camCenter, camSize);
    }



    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerTarget = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerTarget, Time.deltaTime * camSpeed);

        float limitX = camSize.x * 0.5f - widthHalf;
        float limitY = camSize.y * 0.5f - heightHalf;

        float clampX = Mathf.Clamp(transform.position.x, camCenter.x - limitX, camCenter.x + limitX);
        float clampY = Mathf.Clamp(transform.position.y, camCenter.y - limitY, camCenter.y + limitY);

        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }
}
