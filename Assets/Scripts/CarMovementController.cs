using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementController : MonoBehaviour
{

    public bool startCarMovement;
    public float carMoveSpeed = 15f;
    void Update()
    {
        if (startCarMovement)
        {
            CheckFront();
            transform.position += transform.forward * carMoveSpeed * Time.deltaTime * 3;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward + (Vector3.right * 2)) * 8;
        Gizmos.DrawRay(transform.position, direction);
    }
    private void CheckFront()
    {
        RaycastHit objectHit;
        // Shoot raycast
        if (Physics.Raycast(transform.position + (transform.up * 2), transform.forward, out objectHit, 16))
        {
            if (objectHit.transform.CompareTag("StopObject"))
                CheckLeft();
        }
    }

    private void CheckLeft()
    {
        RaycastHit objectHit1;
        // Shoot raycast
        Vector3 direction = transform.TransformDirection(Vector3.forward + (Vector3.left * 2)) * 8;
        if (Physics.Raycast(transform.position + (transform.up * 2), direction, out objectHit1, 18))
        {
            if (objectHit1.transform.CompareTag("StopObject"))
                CheckRight();
        }
        else
            transform.eulerAngles += new Vector3(0, -70, 0);
    }
    private void CheckRight()
    {
        RaycastHit objectHit;
        Vector3 direction = transform.TransformDirection(Vector3.forward + (Vector3.right * 2)) * 8;
        if (Physics.Raycast(transform.position + (transform.up * 2), direction, out objectHit, 18))
        {
            if (objectHit.transform.CompareTag("StopObject"))
                startCarMovement = false;
        }
        else
            transform.eulerAngles += new Vector3(0, 70, 0);
    }

}
