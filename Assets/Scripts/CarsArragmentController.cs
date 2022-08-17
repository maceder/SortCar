using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarsArragmentController : MonoBehaviour
{
    public bool CheckListIsHaveCar(List<TeamCars> TeamCars, EnumButtonType enumButtonType)
    {
        if (EnumButtonType.Left == enumButtonType)
            return TeamCars[0].NumberOfCars.Count > 0;
        else
            return TeamCars[1].NumberOfCars.Count > 0;
    }
    public void SortCarQueue(int childValue, List<TeamCars> _TeamLeft, Transform _TeamRightPosition)
    {
        _TeamLeft[childValue].NumberOfCars.RemoveAt(0);
        for (int i = 0; i < _TeamLeft[childValue].NumberOfCars.Count; i++)
        {
            _TeamLeft[childValue].NumberOfCars[i].transform.DOMove(_TeamRightPosition.position - ((_TeamLeft[childValue].NumberOfCars[i].transform.GetChild(0).GetComponent<Renderer>().bounds.size.z + 5) * i * Vector3.forward), .4f);
        }
    }

}







