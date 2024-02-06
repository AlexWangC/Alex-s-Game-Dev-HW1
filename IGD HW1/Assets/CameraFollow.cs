using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float soomthSpeed = 0.125f;
    public float offsetX = 0f;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offsetX, transform.position.y, transform.position.z);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, soomthSpeed);
        transform.position = smoothPosition;
    }
}
