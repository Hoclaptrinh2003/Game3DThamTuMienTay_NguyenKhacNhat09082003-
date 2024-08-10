using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject ActionTextKey_Door;
    [SerializeField] private GameObject ActionTextOpen_Door;
    [SerializeField] private string ID_Door;
    [SerializeField] private string ID_DoorMission;

    private Animation animationDoor;
    private bool hasOpened = false;
    private bool isLaserTargetingDoor;

    private void Awake()
    {
        animationDoor = GetComponent<Animation>();
    }

    private void Update()
    {
        if (PlayerLaser.Instance != null)
        {

            isLaserTargetingDoor = PlayerLaser.Instance.targetDistance < 5 && PlayerLaser.Instance.hit.collider != null && PlayerLaser.Instance.hit.collider.CompareTag("Door"+ID_Door);
     
            if (Input.GetKey(KeyCode.E) && isLaserTargetingDoor == true)
            {
                if (hasOpened==false)
                {
                    OnOpenDoor();
                    if(PlayerLaser.Instance.hit.collider.CompareTag("Door" + ID_DoorMission) == PlayerLaser.Instance.hit.collider.CompareTag("Door" + ID_Door))
                    {
                        NotifyMission.Instance.TriggerNotification();
                    }
                }
            }

            if (isLaserTargetingDoor==true)
            {
                OpenTextDoor();
            }
            else
            {
                // Ko hiện text nếu tia laser ko bắn đến cánh cửa
                ActionTextKey_Door.SetActive(false);
                ActionTextOpen_Door.SetActive(false);
            }
        }
        else
        {
            // Ko hiện text nếu PlayerLaser.Instance là null
            ActionTextKey_Door.SetActive(false);
            ActionTextOpen_Door.SetActive(false);
        }
    }

    public void OnOpenDoor()
    {
        SubJect.Notify("OnOpenDoor"+ID_Door);
        AudioManager.Instance.OpenDoorSound();
        animationDoor.Play();
        hasOpened = true;
    }

    private void OpenTextDoor()
    {
        // Vô hiệu hóa text khi cánh cửa đã mở
        if (hasOpened==true)
        {
            ActionTextKey_Door.SetActive(false);
            ActionTextOpen_Door.SetActive(false);
            return;
        }
        ActionTextKey_Door.SetActive(true);
        ActionTextOpen_Door.SetActive(true);
    }

 
}