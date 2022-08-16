using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInstantieController : MonoBehaviour
{

    public Transform purpleCreatePosition, yellowCreatePosition;
    public List<TeamCars> NumberOfTeam;
    public float carPadding = 5;

    public void CreateCar()
    {
        for (int i = 0; i < NumberOfTeam.Count; i++)
        {
            for (int j = 0; j < NumberOfTeam[i].CarCount; j++)
            {

                GameObject obj = null;
                int randomValue = Random.Range(1, 5);
                if (i == 0)
                    obj = Instantiate(Resources.Load<GameObject>("Purple/Car" + randomValue), purpleCreatePosition.position, Quaternion.identity);
                else if (i == 1)
                    obj = Instantiate(Resources.Load<GameObject>("Yellow/Car" + randomValue), yellowCreatePosition.position + new Vector3(), Quaternion.identity);
                else if (i == 2)
                    obj = Instantiate(Resources.Load<GameObject>("Purple/Car" + randomValue));

                obj.transform.position -= (obj.transform.GetChild(0).GetComponent<Renderer>().bounds.size.z + carPadding) * j * Vector3.forward;
                NumberOfTeam[i].NumberOfCars.Add(obj);
            }
        }
    }
}
[System.Serializable]
public class TeamCars
{
    [HideInInspector]
    public List<GameObject> NumberOfCars;
    public int CarCount;
}
