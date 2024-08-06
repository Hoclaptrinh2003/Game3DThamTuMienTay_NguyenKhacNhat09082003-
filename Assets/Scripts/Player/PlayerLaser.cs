using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : Singleton<PlayerLaser>
{
    public static float DistanceFromTarget;
    public float targetDistance;
    public RaycastHit hit;

    void Update()
    {
        CheckByLaser();

        if (hit.collider != null && hit.collider.CompareTag("Door412"))
        {
            Debug.Log("412!");
        }

        if (hit.collider != null && hit.collider.CompareTag("Door413"))
        {
            Debug.Log("413!");
        }
    }

    private void CheckByLaser()
    {
        if (Camera.main != null) 
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            if (Physics.Raycast(ray, out hit))
            {
                targetDistance = hit.distance;
                DistanceFromTarget = targetDistance;
            }
        }
    }
}
