using System.Collections.Generic;
using UnityEngine;

public class ListGun : MonoBehaviour
{
    public List<GameObject> guns; // Danh sách các súng
    private int currentGunIndex = 0; // Chỉ số loại súng hiện tại
    private float scrollInput; // Nhập cuộn chuột
    private float lastScrollTime = 0f; // Thời gian của lần cuộn chuột trước đó
    public float scrollDelay = 0.2f; // Thời gian trì hoãn cuộn chuột
    public PlayerShooter playerShooter; // Tham chiếu đến PlayerShooter

    private void Start()
    {
        UpdateGunVisibility();
        // Cập nhật tia lửa cho súng đầu tiên
        if (playerShooter != null)
        {
            playerShooter.UpdateSparkEffect(currentGunIndex);
        }
    }

    private void Update()
    {
        scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f)
        {
            if (Time.time - lastScrollTime >= scrollDelay)
            {
                lastScrollTime = Time.time;

                if (scrollInput > 0f)
                {
                    currentGunIndex = (currentGunIndex + 1) % guns.Count;
                }
                else if (scrollInput < 0f)
                {
                    currentGunIndex = (currentGunIndex - 1 + guns.Count) % guns.Count;
                }

                UpdateGunVisibility();
                // Cập nhật tia lửa cho súng mới nhưng không hiển thị ngay
                if (playerShooter != null)
                {
                    playerShooter.UpdateSparkEffect(currentGunIndex);
                }
            }
        }
    }

    private void UpdateGunVisibility()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }

        if (guns.Count > 0)
        {
            guns[currentGunIndex].SetActive(true);
        }
    }
}
