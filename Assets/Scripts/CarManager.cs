using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public CarsArragmentController carsArragmentController;
    public CarInstantieController carInstantieController;


    private Transform carGoingThisTransform;
    private CarMovementController activeCarMovementController;
    public void Awake()
    {
        carInstantieController.CreateCar();
    }
    private void OnEnable()
    {
        Message.AddListener<Transform>(EventName.CarGoingPosition, GetGoGridPos);
        Message.AddListener<EnumButtonType>(EventName.ButtonType, GenerateCarsArragment);
    }

    private void OnDisable()
    {
        Message.RemoveListener<Transform>(EventName.CarGoingPosition, GetGoGridPos);
        Message.RemoveListener<EnumButtonType>(EventName.ButtonType, GenerateCarsArragment);
    }

    private void GetGoGridPos(Transform activeGridPos)
    {
        carGoingThisTransform = activeGridPos;
    }

    void GenerateCarsArragment(EnumButtonType enumButtonType)
    {
        switch (enumButtonType)
        {
            case EnumButtonType.Left:

                if (carsArragmentController.CheckCarTeamListIn(carInstantieController.NumberOfTeam, EnumButtonType.Left))
                {
                    activeCarMovementController = carInstantieController.NumberOfTeam[0].NumberOfCars[0].GetComponent<CarMovementController>();
                    activeCarMovementController.startCarMovement = true;
                    activeCarMovementController.GetGridPosition(carGoingThisTransform);
                    carsArragmentController.SortByLeftCar(carInstantieController.NumberOfTeam, carInstantieController.purpleCreatePosition);
                }
                else
                    print("12");


                break;
            case EnumButtonType.Right:
                if (carsArragmentController.CheckCarTeamListIn(carInstantieController.NumberOfTeam, EnumButtonType.Right))
                {
                    activeCarMovementController = carInstantieController.NumberOfTeam[1].NumberOfCars[0].GetComponent<CarMovementController>();
                    activeCarMovementController.startCarMovement = true;
                    activeCarMovementController.GetGridPosition(carGoingThisTransform);
                    carsArragmentController.SortByRightCar(carInstantieController.NumberOfTeam, carInstantieController.yellowCreatePosition);
                }
                else
                    print("12");

                
                break;
        }
    }
}
