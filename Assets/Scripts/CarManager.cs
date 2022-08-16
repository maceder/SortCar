using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public CarsArragmentController carsArragmentController;
    public CarInstantieController carInstantieController;


    private void OnEnable()
    {
        Message.AddListener<EnumButtonType>(EventName.ButtonType, GenerateCarsArragment);
    }

    private void OnDisable()
    {
        Message.RemoveListener<EnumButtonType>(EventName.ButtonType, GenerateCarsArragment);
    }

    public void Awake()
    {
        carInstantieController.CreateCar();
    }

    void GenerateCarsArragment(EnumButtonType enumButtonType)
    {
        switch (enumButtonType)
        {
            case EnumButtonType.Left:
                carInstantieController.NumberOfTeam[0].NumberOfCars[0].GetComponent<CarMovementController>().startCarMovement = true;
                carsArragmentController.SortByLeftCar(carInstantieController.NumberOfTeam, carInstantieController.purpleCreatePosition);
                break;
            case EnumButtonType.Right:
                carInstantieController.NumberOfTeam[1].NumberOfCars[0].GetComponent<CarMovementController>().startCarMovement = true;
                carsArragmentController.SortByRightCar(carInstantieController.NumberOfTeam, carInstantieController.yellowCreatePosition);
                break;
        }
    }
}
