using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // Reference to the player

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0, 3, -10); // Offset from the player
    public float followSpeed = 10f; // Speed of following the player

    private Vector3 fixedRotation; // Variable to store initial rotation

    private void Start()
    {
        // Store the initial rotation of the camera to keep it locked
        fixedRotation = transform.eulerAngles;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // Move the camera to maintain a fixed offset from the target
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Keep the camera's rotation locked to the initial rotation
        transform.eulerAngles = fixedRotation;

        Ray ray = new Ray(target.position, -transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, offset.magnitude))
        {
            transform.position = hit.point + transform.forward * 0.5f; // Adjust position to just before the obstacle
        }

        else
        {
            transform.position = target.position + offset;
        }

    }
}



