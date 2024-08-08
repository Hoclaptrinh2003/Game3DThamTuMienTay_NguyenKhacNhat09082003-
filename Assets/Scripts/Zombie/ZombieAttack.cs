using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public Transform player;      
    public float speed = 3.5f;    
    public float stoppingDistance = 1.5f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on this GameObject");
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > stoppingDistance)
            {
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            }
        }
    }
}