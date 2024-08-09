using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Tốc độ của viên đạn
    private Vector3 direction; // Hướng di chuyển của viên đạn
    private BulletPool bulletPool; // Reference đến BulletPool

    // Hàm khởi tạo hướng di chuyển của viên đạn
    public void Initialize(Vector3 bulletDirection, BulletPool pool)
    {
        direction = bulletDirection;
        bulletPool = pool;
        // Reset viên đạn tại vị trí khởi tạo
        gameObject.SetActive(true);
    }

    void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        // Cập nhật vị trí của viên đạn theo hướng
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Xử lý va chạm tại đây và trả viên đạn về pool
        if (bulletPool != null)
        {
            bulletPool.ReturnBullet(gameObject);
        }
    }
}
