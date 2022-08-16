using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CarMovementController : MonoBehaviour
{
    public bool startCarMovement;
    private NavMeshAgent navMeshAgent;
    public Transform goGridTransform;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        Message.AddListener<Transform>(EventName.CarGoingPosition, GetGridPosition);
    }

    private void OnDisable()
    {
        Message.RemoveListener<Transform>(EventName.CarGoingPosition, GetGridPosition);
    }
    void GetGridPosition(Transform gridPosition)
    {
        if (startCarMovement)
        {
            Debug.Log(gridPosition);
            goGridTransform = gridPosition;
            navMeshAgent.SetDestination(goGridTransform.position);
            startCarMovement = false;
            navMeshAgent.velocity = Vector3.zero;
        }
    }
}
