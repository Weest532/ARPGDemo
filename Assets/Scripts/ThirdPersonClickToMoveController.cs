using UnityEngine;
using UnityEngine.AI;

public class ThirdPersonClickToMoveController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;
    }

    private void Update()
    {
        HandleClick();
    }

    // Handles mouse click input to set destination
    private void HandleClick()
    {
        if (Input.GetMouseButton(0)) // Left-click to move
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                navMeshAgent.SetDestination(hit.point); // Set the clicked point as the destination
            }
        }
    }
}
