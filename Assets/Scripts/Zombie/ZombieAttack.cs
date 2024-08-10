using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Transform player;
    public float speed = 3.0f; 

    private bool isChasing = false; 

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isChasing && player != null)
        {
          
            Vector3 direction = (player.position - transform.position).normalized;

   
            transform.position += direction * speed * Time.deltaTime;

       
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            animator.SetBool("isMove", true);
            isChasing = true; 
        }
    }

   
}
