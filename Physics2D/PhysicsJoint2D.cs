using System.Collections.Generic;
using UnityEngine;

public class PhysicsJoint2D : MonoBehaviour
{
    public List<Transform> connectedBody;
    private List<Vector2> positions;
    private Rigidbody2D rb;
    public float mod = 1;
    public bool autoConnect;
    public float autoConnectRadius;
    private void Start()
    {
        if (autoConnect)
        {
            Collider2D[] near = Physics2D.OverlapCircleAll(transform.position, autoConnectRadius);
            foreach (Collider2D col in near)
            {
                if (col.gameObject != gameObject)
                {
                    connectedBody.Add(col.transform);
                }
            }
        }

        rb = GetComponent<Rigidbody2D>();
        positions = new List<Vector2>();
        foreach (var body in connectedBody)
        {
            positions.Add(body.position - transform.position);
        }
    }
    private void Update()
    {
        
        Vector2 direction = GetDirection();
        rb.linearVelocity += direction*mod;
    }
    public Vector2 GetDirection()
    {
        Vector2 resultDirection = Vector2.zero;
        for(int i = 0; i < connectedBody.Count; i++)
        {
            Vector2 direction = connectedBody[i].position-transform.position;
            direction -= positions[i];
            resultDirection += direction;
        }
        return resultDirection;
    }
}
