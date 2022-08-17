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

    
    public void GetGridPosition(Transform gridPosition)
    {
        if (startCarMovement)
        {
            goGridTransform = gridPosition;
            startCarMovement = false;
            navMeshAgent.SetDestination(goGridTransform.position);
        }
    }
}
