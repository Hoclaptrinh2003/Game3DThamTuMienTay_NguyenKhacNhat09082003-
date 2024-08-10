using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 5f;
    public Vector3 offset;  
    public Vector3 rotationOffset; 

    private void LateUpdate()
    {
    
        Vector3 desiredPosition = target.position + offset;
      
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

 
        Quaternion desiredRotation = Quaternion.Euler(target.eulerAngles + rotationOffset);
   
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed);

        transform.rotation = smoothedRotation;
    }
}
