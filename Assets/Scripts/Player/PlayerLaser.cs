using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : Singleton<PlayerLaser>
{
    public static Vector3 LaserDirection; 
    public static float DistanceFromTarget;
    public float targetDistance;
    public RaycastHit hit;

    void Update()
    {
        CheckByLaser();
    }

    private void CheckByLaser()
    {
        if (Camera.main != null)
        {
       
            Vector3 mousePosition = Input.mousePosition;

       
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

    
            if (Physics.Raycast(ray, out hit))
            {
                targetDistance = hit.distance;
                DistanceFromTarget = targetDistance;

               
                LaserDirection = ray.direction;
            }
        }
    }
}
