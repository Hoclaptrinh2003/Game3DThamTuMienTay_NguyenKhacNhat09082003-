using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public BulletPool bulletPool; 
    public Transform shootPoint;
    public float fireRate = 0.5f;
    private bool isFiring = false;
    public List<GameObject> sparkEffects;
    private int currentGunIndex = 0;
    private Coroutine sparkCoroutine;

    void Start()
    {
        UpdateSparkEffect(currentGunIndex);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
            StartCoroutine(FireBulletCoroutine());
            ToggleSparkEffect(true);
            if (sparkCoroutine != null)
            {
                StopCoroutine(sparkCoroutine);
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
            StopCoroutine(FireBulletCoroutine());
            sparkCoroutine = StartCoroutine(DelayedSparkHide());
            
        }
    }

    private IEnumerator FireBulletCoroutine()
    {
        while (isFiring)
        {
            ShootBullet();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void ShootBullet()
    {
        if (bulletPool != null)
        {
            GameObject bullet = bulletPool.GetBullet();
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = Quaternion.identity;
            Bullet bulletScript = bullet.GetComponent<Bullet>();

            if (bulletScript != null)
            {
                bulletScript.Initialize(PlayerLaser.LaserDirection, bulletPool);
            }
        }
    }

    private void ToggleSparkEffect(bool show)
    {
        if (sparkEffects != null && sparkEffects.Count > 0)
        {
            foreach (var sparkEffect in sparkEffects)
            {
                if (sparkEffect != null)
                {
                    sparkEffect.SetActive(false);
                }
            }

            if (sparkEffects.Count > currentGunIndex && sparkEffects[currentGunIndex] != null)
            {
                sparkEffects[currentGunIndex].SetActive(show);
            }
        }
    }

    private IEnumerator DelayedSparkHide()
    {
        yield return new WaitForSeconds(0.2f);
        if (!isFiring)
        {
            ToggleSparkEffect(false);
        }
    }

    public void UpdateSparkEffect(int gunIndex)
    {
        if (gunIndex >= 0 && gunIndex < sparkEffects.Count)
        {
            currentGunIndex = gunIndex;
        }
    }
}
