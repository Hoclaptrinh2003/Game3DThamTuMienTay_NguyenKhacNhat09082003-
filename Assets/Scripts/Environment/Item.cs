using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject ActionTextKey_Item;
    [SerializeField] private GameObject ActionTextOpen_Item;
    [SerializeField] private GameObject QuitTextKey_Item;
    [SerializeField] private GameObject QuitTextOpen_Item;
    [SerializeField] private GameObject TextItem;

    [SerializeField] private string ID_Item;

    private Animation animationItem;
    private bool isLaserTargetingItem;
    private bool isActionTextItem = false;
    private bool hasPickedUp = false;

    private void Awake()
    {
        animationItem = GetComponent<Animation>();
    }

    private void Update()
    {
        if (PlayerLaser.Instance != null)
        {
            isLaserTargetingItem = PlayerLaser.Instance.targetDistance < 2 && PlayerLaser.Instance.hit.collider != null && PlayerLaser.Instance.hit.collider.CompareTag("Item" + ID_Item);

            if (isLaserTargetingItem==true)
            {
                OpenTextItem();
                if (Input.GetKey(KeyCode.E) && hasPickedUp == false)
                {
                    OnPickupItem();
                    TextItem.SetActive(true);
                    isActionTextItem = true;
                    hasPickedUp = true;
                }

            }
            else
            {
                ActionTextKey_Item.SetActive(false);
                ActionTextOpen_Item.SetActive(false);
            }

            if (isActionTextItem == true)
            {
                TurnOffItem();
            }

            if (Input.GetKey(KeyCode.Q) && isActionTextItem == true)
            {
                QuitTextKey_Item.SetActive(false);
                QuitTextOpen_Item.SetActive(false);
                TextItem.SetActive(false);
                isActionTextItem = false;
                hasPickedUp = false;
            }


        }
        else
        {
            ActionTextKey_Item.SetActive(false);
            ActionTextOpen_Item.SetActive(false);
        }
    }

    public void OnPickupItem()
    {
        animationItem.Play();

    }

    private void OpenTextItem()
    {
        if (hasPickedUp == true)
        {
            ActionTextKey_Item.SetActive(false);
            ActionTextOpen_Item.SetActive(false);
            return;
        }
        ActionTextKey_Item.SetActive(true);
        ActionTextOpen_Item.SetActive(true);
    }


    private void TurnOffItem()
    {
       
        QuitTextKey_Item.SetActive(true);
        QuitTextOpen_Item.SetActive(true);
    }
}
