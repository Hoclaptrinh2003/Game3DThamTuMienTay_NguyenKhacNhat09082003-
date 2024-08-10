using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 800f; 
    private Vector3 direction; 
    private BulletPool bulletPool; 
    private bool hasCollided = false; 


    public void Initialize(Vector3 bulletDirection, BulletPool pool)
    {
        direction = bulletDirection;
        bulletPool = pool;
    
        gameObject.SetActive(true);
        hasCollided = false;
        StartCoroutine(ReturnToPoolAfterTime(4f)); 
    }

    void Update()
    {
        if (!hasCollided)
        {
            MoveBullet();
        }
    }

    private void MoveBullet()
    {
      
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided)
        {
            hasCollided = true;
            StopCoroutine(ReturnToPoolAfterTime(6f)); 
         
            if (bulletPool != null)
            {
                bulletPool.ReturnBullet(gameObject);
            }
        }
    }

    private IEnumerator ReturnToPoolAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (!hasCollided)
        {
            
            if (bulletPool != null)
            {
                bulletPool.ReturnBullet(gameObject);
            }
        }
    }
}
