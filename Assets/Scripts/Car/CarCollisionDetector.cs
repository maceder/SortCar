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
            other.gameObject.GetComponent<CarController>().StopNavMeshAgent();
            transform.GetComponent<CarController>().StopNavMeshAgent();
            GameManager.instance.GameOver();
        }
    }
}
