using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSoft : MonoBehaviour
{
    public Transform lookAt;
    public Vector2 max;
    public Vector2 min;
    public float speed;
    private Vector3 targetPosition;

    private void Update()
    {
        targetPosition = transform.position;
        if(transform.position.x > lookAt.position.x + max.x)
        {
            targetPosition.x = lookAt.position.x + max.x;
        }
        if(transform.position.x < lookAt.position.x - min.x)
        {
            targetPosition.x = lookAt.position.x - min.x;
        }
        if(transform.position.y > lookAt.position.y + max.y)
        {
            targetPosition.y = lookAt.position.y + max.y;
        }
        if (transform.position.y < lookAt.position.y - min.y)
        {
            targetPosition.y = lookAt.position.y - min.y;
        }
        transform.position = targetPosition;
    }
}