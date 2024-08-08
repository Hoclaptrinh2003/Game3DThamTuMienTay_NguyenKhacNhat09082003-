using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Animation animationGun;
 

    private void Awake()
    {
        animationGun = GetComponent<Animation>();
    }
    private void Update()
    {
        
        if(Input.GetMouseButton(0)) 
        {

            animationGun.Play(); 
        }
    }
}
