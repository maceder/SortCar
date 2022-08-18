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
            other.gameObject.GetComponent<CarController>().StopNavMeshAgent();
            transform.GetComponent<CarController>().StopNavMeshAgent();
            GameManager.instance.GameOver();
        }
    }
}
