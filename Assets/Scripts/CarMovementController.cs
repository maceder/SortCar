using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class CarMovementController : MonoBehaviour
{
    [HideInInspector]
    public bool startCarMovement;
    private NavMeshAgent navMeshAgent;
    private Transform goGridTransform;
    private bool isCorrectGrid;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    public void SetGridPosition(Transform gridPosition, bool _IsCorrectGrid)
    {
        if (startCarMovement)
        {
            goGridTransform = gridPosition;
            startCarMovement = false;
            navMeshAgent.SetDestination(goGridTransform.position);
            isCorrectGrid = _IsCorrectGrid;
        }
    }


    //Son kýsma gelince gridin rotationunu alýyor ve 
    private void Update()
    {
        if (goGridTransform != null)
        {
            if (Vector3.Distance(transform.position, goGridTransform.position) < 0.5f)
            {
                navMeshAgent.isStopped = true;
                if (isCorrectGrid)
                {
                    transform.GetChild(1).gameObject.SetActive(true);
                    Message.Send(EventName.CarInGridBox);
                }
                transform.DOLocalRotate(new Vector3(0, goGridTransform.parent.localEulerAngles.y, 0), .18f);
                navMeshAgent.enabled = false;
                transform.gameObject.AddComponent<NavMeshObstacle>().size = new Vector3(20, 8, 17);
                transform.GetComponent<NavMeshObstacle>().carving = true;
                goGridTransform = null;
            }
        }

    }
}