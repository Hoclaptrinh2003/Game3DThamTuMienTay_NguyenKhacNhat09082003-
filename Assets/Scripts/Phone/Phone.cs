using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Singleton<Phone>
{
    [SerializeField] private GameObject ActionTextKey_Phone;
    [SerializeField] private GameObject ActionTextOpen_Phone;
    [SerializeField] private GameObject ArrowPhone;
    [SerializeField] private GameObject TextPhone;
    public float timePhone = 0f;
    private const float maxTimePhone = 32f;
    private bool isLaserTargetingPhone;
    private bool hasOpened = false;
    private bool hasNotify = false;
    private bool isTiming = false;
    private Coroutine phoneSoundCoroutine;

    private void Start()
    {
        StartCoroutine(PlayPhoneSoundAfterDelay(3f));
    }

    private void Update()
    {
        isLaserTargetingPhone = PlayerLaser.Instance.targetDistance < 5 && PlayerLaser.Instance.hit.collider != null && PlayerLaser.Instance.hit.collider.CompareTag("Phone");

        if (Input.GetKeyDown(KeyCode.E) && isLaserTargetingPhone)
        {
            
            if (!hasOpened)
            {
                ArrowPhone.SetActive(false);
                TextPhone.SetActive(false); 
                PlayerController.Instance.canMove = false;
                AudioManager.Instance.OpenDoorPhoneSound(); 
                hasOpened = true;
                isTiming = true;

                if (phoneSoundCoroutine != null)
                {
                    StopCoroutine(phoneSoundCoroutine);
                    phoneSoundCoroutine = null;
                }

               
            }
        }

        if (isTiming==true)
        {
            timePhone += Time.deltaTime;
            if (timePhone >= maxTimePhone)
            {
                timePhone = maxTimePhone;
                PlayerController.Instance.canMove = true;
                isTiming = false;
            }
        }

        if (isLaserTargetingPhone)
        {
            OpenTextDoor();
        }
        else
        {
            ActionTextKey_Phone.SetActive(false);
            ActionTextOpen_Phone.SetActive(false);
        }

        if (timePhone == maxTimePhone && hasNotify == false)
        {
            NotifyMission.Instance.TriggerNotification();
            hasNotify = true;
        }
    }

    private IEnumerator PlayPhoneSoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ArrowPhone.SetActive(true);
        TextPhone.SetActive(true);
        // Bắt đầu phát âm thanh chuông liên tục
        phoneSoundCoroutine = StartCoroutine(PlayPhoneSoundLoop());
    }

    private IEnumerator PlayPhoneSoundLoop()
    {
        while (true)
        {
            AudioManager.Instance.PhoneSound(); // Phát âm thanh chuông
            yield return new WaitForSeconds(AudioManager.Instance.soundEffectsClips[5].length); // Đợi thời gian âm thanh kết thúc
        }
    }

    private void OpenTextDoor()
    {
        if (hasOpened)
        {
            ActionTextKey_Phone.SetActive(false);
            ActionTextOpen_Phone.SetActive(false);
            return;
        }
        ActionTextKey_Phone.SetActive(true);
        ActionTextOpen_Phone.SetActive(true);
    }
}
