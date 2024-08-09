using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab của viên đạn
    public Transform shootPoint; // Điểm xuất phát của viên đạn
    public float fireRate = 0.5f; // Tốc độ bắn
    private bool isFiring = false; // Biến kiểm tra trạng thái bắn
    public List<GameObject> sparkEffects; // Danh sách các tia lửa tương ứng với các loại súng
    private int currentGunIndex = 0; // Chỉ số loại súng hiện tại
    private Coroutine sparkCoroutine; // Tham chiếu đến coroutine tia lửa

    void Start()
    {
        UpdateSparkEffect(currentGunIndex); // Khởi tạo tia lửa cho súng đầu tiên
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
            StartCoroutine(FireBulletCoroutine());
            ToggleSparkEffect(true); // Hiển thị tia lửa khi bắn
            if (sparkCoroutine != null)
            {
                StopCoroutine(sparkCoroutine); // Dừng coroutine ẩn tia lửa nếu có
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
            StopCoroutine(FireBulletCoroutine()); // Dừng coroutine khi thả chuột
            sparkCoroutine = StartCoroutine(DelayedSparkHide()); // Bắt đầu coroutine ẩn tia lửa sau 0.2 giây
        }
    }

    private IEnumerator FireBulletCoroutine()
    {
        while (isFiring)
        {
            ShootBullet();
            yield return new WaitForSeconds(fireRate); // Chờ thời gian giữa các lần bắn
        }
    }

    private void ShootBullet()
    {
        if (bulletPrefab != null)
        {
            // Tạo viên đạn tại vị trí của shootPoint
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();

            if (bulletScript != null)
            {
                // Khởi tạo viên đạn với hướng laser hiện tại
                bulletScript.Initialize(PlayerLaser.LaserDirection);
            }
        }
    }

    private void ToggleSparkEffect(bool show)
    {
        if (sparkEffects != null && sparkEffects.Count > 0)
        {
            // Ẩn tất cả các tia lửa trước
            foreach (var sparkEffect in sparkEffects)
            {
                if (sparkEffect != null)
                {
                    sparkEffect.SetActive(false);
                }
            }

            // Hiển thị tia lửa tương ứng với súng hiện tại
            if (sparkEffects.Count > currentGunIndex && sparkEffects[currentGunIndex] != null)
            {
                sparkEffects[currentGunIndex].SetActive(show);
            }
        }
    }

    private IEnumerator DelayedSparkHide()
    {
        yield return new WaitForSeconds(0.2f); // Chờ thời gian trì hoãn
        if (!isFiring) // Chỉ ẩn tia lửa nếu không còn bắn
        {
            ToggleSparkEffect(false);
        }
    }

    public void UpdateSparkEffect(int gunIndex)
    {
        if (gunIndex >= 0 && gunIndex < sparkEffects.Count)
        {
            currentGunIndex = gunIndex;
            // Không hiển thị tia lửa ngay; chỉ lưu chỉ số súng hiện tại
        }
    }
}
