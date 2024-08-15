using TMPro;
using UnityEngine;

public class bulletCount : MonoBehaviour
{
    public int quantityBullet;
    [SerializeField] private TextMeshProUGUI textQuantityBullet;
    private float timeSinceLastShot;

    private void Update()
    {
        textQuantityBullet.SetText(quantityBullet.ToString());

        if (Input.GetMouseButtonDown(0) && quantityBullet>0)
        {
            
            quantityBullet--;

        }
        if (Input.GetMouseButton(0) && quantityBullet > 0)
        {
            timeSinceLastShot += Time.deltaTime;

            if (timeSinceLastShot >= 0.5f)
            {
                quantityBullet--;
                timeSinceLastShot = 0f;
            }
        }
        else
        {
            timeSinceLastShot = 0f;
        }

        if(quantityBullet > 0 && Input.GetMouseButtonUp(0))
        {
            AudioManager.Instance.PlayBulletSound();

        }
    }
}
