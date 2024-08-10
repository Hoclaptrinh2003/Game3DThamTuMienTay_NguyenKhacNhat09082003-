using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light flashlight;

    private bool isOn = false;

    void Start()
    {
        if (flashlight == null)
        {
            flashlight = GetComponent<Light>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;


            flashlight.enabled = isOn;
        }
    }
}
