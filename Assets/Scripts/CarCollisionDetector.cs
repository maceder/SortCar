using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Arabalar �arp���rsa navmeshlerini durdurup gameover yap�yorum
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
