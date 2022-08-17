using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarsArragmentController : MonoBehaviour
{
    public bool CheckCarTeamListIn(List<TeamCars> TeamCars, EnumButtonType enumButtonType)
    {
        switch (enumButtonType)
        {
            case EnumButtonType.Left:
                if (TeamCars[0].NumberOfCars.Count > 0)
                    return true;
                break;
            case EnumButtonType.Right:
                if (TeamCars[1].NumberOfCars.Count > 0)
                    return true;
                break;
        }
        return false;

    }
    public void SortByLeftCar(List<TeamCars> _TeamLeft, Transform _TeamRightPosition)
    {
            _TeamLeft[0].NumberOfCars.RemoveAt(0);
            for (int i = 0; i < _TeamLeft[0].NumberOfCars.Count; i++)
            {
                _TeamLeft[0].NumberOfCars[i].transform.DOMove(_TeamRightPosition.position - ((_TeamLeft[0].NumberOfCars[i].transform.GetChild(0).GetComponent<Renderer>().bounds.size.z + 5) * i * Vector3.forward), .4f);
            }
    }
    public void SortByRightCar(List<TeamCars> TeamRight, Transform TeamRightPosition)
    {

        TeamRight[1].NumberOfCars.RemoveAt(0);
        for (int i = 0; i < TeamRight[1].NumberOfCars.Count; i++)
        {
            TeamRight[1].NumberOfCars[i].transform.DOMove(TeamRightPosition.position - ((TeamRight[1].NumberOfCars[i].transform.GetChild(0).GetComponent<Renderer>().bounds.size.z + 5) * i * Vector3.forward), .4f);
        }
    }
    
}







