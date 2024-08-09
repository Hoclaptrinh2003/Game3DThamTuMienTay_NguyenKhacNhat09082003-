using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Tốc độ của viên đạn
    private Vector3 direction; // Hướng di chuyển của viên đạn

    // Hàm khởi tạo hướng di chuyển của viên đạn
    public void Initialize(Vector3 bulletDirection)
    {
        direction = bulletDirection;
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
        // Xử lý va chạm tại đây
        Destroy(gameObject,4); // Xóa viên đạn khi va chạm
    }
}
