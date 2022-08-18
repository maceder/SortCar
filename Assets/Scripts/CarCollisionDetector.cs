using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Arabalar çarpışırsa navmeshlerini durdurup gameover yapıyorum
/// </summary>


public class CarCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            other.gameObject.GetComponent<CarMovementController>().StopNavMeshAgent();
            transform.GetComponent<CarMovementController>().StopNavMeshAgent();
            GameManager.instance.GameOver();
        }
    }
}
