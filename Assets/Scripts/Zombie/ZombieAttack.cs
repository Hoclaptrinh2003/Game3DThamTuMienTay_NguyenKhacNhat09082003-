using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Transform player;
    public float speed = 3.5f;
    public float stoppingDistance = 1.5f;

    private Rigidbody rb;
    private bool isChasing = false; // Thay đổi trạng thái

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
        if (isChasing && player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > stoppingDistance)
            {
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hi");
            isChasing = true; // Kích hoạt trạng thái đuổi theo Player
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hi");
            isChasing = true; // Kích hoạt trạng thái đuổi theo Player
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false; // Dừng đuổi theo khi không còn va chạm
        }
    }
}
