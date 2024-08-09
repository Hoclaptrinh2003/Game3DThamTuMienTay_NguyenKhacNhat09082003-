using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab của đạn
    public int poolSize = 10; // Kích thước của pool
    private Queue<GameObject> bulletPool; // Queue để lưu trữ các đạn trong pool

    void Start()
    {
        bulletPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false); // Không kích hoạt các đạn khi khởi tạo
            bulletPool.Enqueue(bullet); // Thêm đạn vào pool
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            // Nếu không còn đạn trong pool, tạo mới (tuỳ chọn)
            GameObject bullet = Instantiate(bulletPrefab);
            return bullet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
