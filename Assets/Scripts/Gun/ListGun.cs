using System.Collections.Generic;
using UnityEngine;

public class ListGun : MonoBehaviour
{
    public List<GameObject> guns;
    private int currentGunIndex = 0;
    private float scrollInput;
    private float lastScrollTime = 0f;
    public float scrollDelay = 0.2f;
    public PlayerShooter playerShooter;
    public List<bulletCount> bulletCounts; 

    private void Start()
    {
        UpdateGunVisibility();
        UpdateBulletCountDisplay();

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
                UpdateBulletCountDisplay();

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

    private void UpdateBulletCountDisplay()
    {
        for (int i = 0; i < bulletCounts.Count; i++)
        {
            if (i == currentGunIndex)
            {
                bulletCounts[i].gameObject.SetActive(true);
                bulletCounts[i].quantityBullet = GetBulletCountForGun(i); 
            }
            else
            {
                bulletCounts[i].gameObject.SetActive(false);
            }
        }
    }

    private int GetBulletCountForGun(int gunIndex)
    {
       
        return 0;
    }
}
