using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Nhân vật 3D mà camera sẽ theo dõi
    public float smoothSpeed = 5f; // Tốc độ mượt mà của camera
    public Vector3 offset;  // Khoảng cách giữa camera và nhân vật
    public Vector3 rotationOffset; // Góc xoay của camera so với nhân vật

    private void LateUpdate()
    {
        // Tính toán vị trí mục tiêu của camera
        Vector3 desiredPosition = target.position + offset;
        // Tạo một vị trí mượt mà cho camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Đặt vị trí của camera
        transform.position = smoothedPosition;

        // Tính toán góc xoay mục tiêu của camera
        Quaternion desiredRotation = Quaternion.Euler(target.eulerAngles + rotationOffset);
        // Tạo một góc xoay mượt mà cho camera
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed);
        // Đặt góc xoay của camera
        transform.rotation = smoothedRotation;
    }
}
