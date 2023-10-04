using UnityEngine;

public class BounceBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private float minForce = 2f; // Minimum force to apply
    private float maxForce = 5f; // Maximum force to apply
    private float constantSpeed = 10f; // Constant speed to maintain

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Generate a random force in a random direction
        Vector3 randomForce = Random.onUnitSphere * Random.Range(minForce, maxForce);

        // Apply the random force to the object
        rb.AddForce(randomForce, ForceMode.Impulse);

        // Set the velocity to move at constant speed
        rb.velocity = rb.velocity.normalized * constantSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Reflect the velocity when the object collides with something
        Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
        rb.velocity = reflectedVelocity.normalized * constantSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        // Reflect the velocity when the object enters a trigger zone
        Vector3 triggerNormal = other.transform.up;
        Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, triggerNormal);
        rb.velocity = reflectedVelocity.normalized * constantSpeed;
    }
}
