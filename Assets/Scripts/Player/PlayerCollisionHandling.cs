using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandling : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Debug.Log("hi");
        }
    }
}
