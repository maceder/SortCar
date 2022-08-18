using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;



/// <summary>
/// Arabalar� kontrol etti�im yer
/// </summary>
public class CarController : MonoBehaviour
{
    public float navMeshAgentMovementSpeed = 75;
    [HideInInspector]
    public bool startCarMovement;
    private NavMeshAgent navMeshAgent;
    private Transform goGridTransform;
    private bool isCorrectGrid;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = navMeshAgentMovementSpeed;
    }



    //CarManager'dan ald���m gidilicek park yeri bilgisiyle haraketin ba�lad��� yer
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
    //Son k�sma gelince gridin rotationunu al�yor ve 
    private void Update()
    {
        if (goGridTransform != null)
        {
            if (Vector3.Distance(transform.position, goGridTransform.position) < 0.5f)
            {
                navMeshAgent.isStopped = true;
                if (isCorrectGrid)
                {
                    TickAnimation();
                    navMeshAgent.enabled = false;
                    transform.gameObject.AddComponent<NavMeshObstacle>().size = new Vector3(20, 8, 17);

                    transform.GetComponent<NavMeshObstacle>().carving = true;
                    goGridTransform = null;
                }
                else
                    GameManager.instance.GameOver();

            }
        }
    }

    //Ayn� renk park alan� animation
    private void TickAnimation()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        Message.Send<GameObject>(EventName.CarInGridBox, this.gameObject);
        transform.DOLocalRotate(new Vector3(0, goGridTransform.parent.localEulerAngles.y, 0), .18f);
    }

    //Finish Scale Animation
    public void CarScaleAnimation()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(transform.localScale.x + 0.25f, 0.3f)).Append(transform.DOScale(transform.localScale.x, 0.3f));
    }

    public void StopNavMeshAgent()
    {
        navMeshAgent.isStopped = true;
    }
}