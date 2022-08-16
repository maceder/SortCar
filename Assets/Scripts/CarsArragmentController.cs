using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarsArragmentController : MonoBehaviour
{
    public Transform purpleCreatePosition, yellowCreatePosition;
    public List<TeamCars> NumberOfTeam;
    public float carPadding = 5;
    private void Awake()
    {
        for (int i = 0; i < NumberOfTeam.Count; i++)
        {
            for (int j = 0; j < NumberOfTeam[i].CarCount; j++)
            {

                GameObject obj = null;
                int randomValue = Random.Range(1, 5);
                Debug.Log(randomValue);
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
    private void OnEnable()
    {
        Message.AddListener<EnumButtonType>(EventName.ButtonType, GenerateCarsArragment);
    }

    private void OnDisable()
    {
        Message.RemoveListener<EnumButtonType>(EventName.ButtonType, GenerateCarsArragment);
    }

    public void GenerateCarsArragment(EnumButtonType enumButtonType)
    {
        switch (enumButtonType)
        {
            case EnumButtonType.Left:
                if (NumberOfTeam[0].NumberOfCars.Count > 0)
                {
                    NumberOfTeam[0].NumberOfCars[0].GetComponent<CarMovementController>().startCarMovement = true;
                    NumberOfTeam[0].NumberOfCars.RemoveAt(0);

                    for (int i = 0; i < NumberOfTeam[0].NumberOfCars.Count; i++)
                    {
                        NumberOfTeam[0].NumberOfCars[i].transform.DOMove(purpleCreatePosition.position - ((NumberOfTeam[0].NumberOfCars[i].transform.GetChild(0).GetComponent<Renderer>().bounds.size.z + carPadding) * i * Vector3.forward), .4f);
                    }
                }
                break;
            case EnumButtonType.Right:
                if (NumberOfTeam[1].NumberOfCars.Count > 0)
                {
                    NumberOfTeam[1].NumberOfCars[0].GetComponent<CarMovementController>().startCarMovement = true;
                    NumberOfTeam[1].NumberOfCars.RemoveAt(0);

                    for (int i = 0; i < NumberOfTeam[1].NumberOfCars.Count; i++)
                    {
                        NumberOfTeam[1].NumberOfCars[i].transform.DOMove(yellowCreatePosition.position - ((NumberOfTeam[1].NumberOfCars[i].transform.GetChild(0).GetComponent<Renderer>().bounds.size.z + carPadding) * i * Vector3.forward), .4f);
                    }
                }
                break;
        }
    }


}

[System.Serializable]
public class TeamCars
{
    public List<GameObject> NumberOfCars;
    public int CarCount;
}


