using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public int health = 10; // Máu của đối tượng

    // Update is called once per frame
    void Update()
    {
        // Có thể thêm logic khác liên quan đến máu ở đây
    }

    // Hàm xử lý va chạm
    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra nếu đối tượng va chạm có tag là "Bullet"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1); // Giảm 1 máu khi va chạm với viên đạn
        }
    }

    // Hàm xử lý giảm máu
    private void TakeDamage(int damage)
    {
        health -= damage; // Giảm máu
        Debug.Log("Current Health: " + health); // Hiển thị máu còn lại trong Console

        if (health <= 0)
        {
            Die(); // Gọi hàm chết khi máu <= 0
        }
    }

    // Hàm xử lý khi đối tượng chết
    private void Die()
    {
        Debug.Log(gameObject.name + " has died."); // Hiển thị thông báo trong Console
        Destroy(gameObject); // Xóa đối tượng
    }
}
