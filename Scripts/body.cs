using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class body : MonoBehaviour
{
    public float mass;
    public manager manager;
    public GameObject target;
    public float forward_force;

    private body target_body;

    private float orbitalVelocity;
    private Vector2 velocity;

    public bool isMoon = false;

    private void Start()
    {
        target_body = target.GetComponent<body>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = target.transform.position - transform.position;
        Vector2 force = manager.f * direction;

        Vector2 acceleration = force / mass;
        transform.position += (Vector3)acceleration * Time.fixedDeltaTime;

        orbitalVelocity = Mathf.Sqrt(manager.g * target_body.mass / manager.r);

        // Get direction from target body to current object
        Vector2 _direction = (transform.position - target_body.transform.position).normalized;

        // Compute perpendicular direction for proper orbital motion
        Vector2 tangentialDirection = new Vector2(-_direction.y, _direction.x); // Rotates 90 degrees

        // Apply velocity along tangential direction
        if (!isMoon)
        {
            velocity = tangentialDirection * orbitalVelocity * Time.fixedDeltaTime * forward_force;
        }
        else
        {
            velocity = (tangentialDirection * orbitalVelocity * Time.fixedDeltaTime * forward_force) + target.GetComponent<body>().velocity;
        }
            transform.position += (Vector3)velocity;

    }
}
