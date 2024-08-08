using System.Collections.Generic;
using UnityEngine;

public class ListGun : MonoBehaviour
{
    public List<GameObject> guns; // Danh sách các súng
    private int currentGunIndex = 0; // Chỉ số của súng hiện tại
    private float scrollInput; // Nhận đầu vào cuộn chuột
    private float lastScrollTime = 0f; // Thời gian lần cuộn chuột gần nhất
    public float scrollDelay = 0.2f; // Thời gian cố định trước khi thay đổi súng (0.2 giây)

    private void Start()
    {
        // Ẩn tất cả súng, sau đó hiện súng đầu tiên
        UpdateGunVisibility();
    }

    private void Update()
    {
        // Nhận đầu vào cuộn chuột
        scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Nếu có đầu vào cuộn chuột
        if (scrollInput != 0f)
        {
            // Kiểm tra thời gian từ lần cuộn chuột gần nhất
            if (Time.time - lastScrollTime >= scrollDelay)
            {
                // Cập nhật thời gian lần cuộn chuột gần nhất
                lastScrollTime = Time.time;

                // Cập nhật chỉ số súng dựa trên đầu vào cuộn chuột
                if (scrollInput > 0f)
                {
                    // Cuộn chuột lên
                    currentGunIndex = (currentGunIndex + 1) % guns.Count;
                }
                else if (scrollInput < 0f)
                {
                    // Cuộn chuột xuống
                    currentGunIndex = (currentGunIndex - 1 + guns.Count) % guns.Count;
                }

                // Cập nhật tình trạng hiển thị của súng
                UpdateGunVisibility();
            }
        }
    }

    private void UpdateGunVisibility()
    {
        // Ẩn tất cả súng
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
        // Hiện súng hiện tại
        if (guns.Count > 0)
        {
            guns[currentGunIndex].SetActive(true);
        }
    }
}
