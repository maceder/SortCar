using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public CarsArragmentController carsArragmentController;
    public CarInstantieController carInstantieController;
    public GenerateCarGoingPosition generateCarGoingPos;
    private CarMovementController activeCarMovementController;

    public void Awake()
    {
        carInstantieController.CreateCar();
    }
    private void OnEnable()
    {
        //ButtonController'dan gelen event
        Message.AddListener<EnumButtonType>(EventName.ButtonType, GenerateCarsArragment);
    }

    private void OnDisable()
    {
        //ButtonController'dan gelen event
        Message.RemoveListener<EnumButtonType>(EventName.ButtonType, GenerateCarsArragment);
    }

    void GenerateCarsArragment(EnumButtonType enumButtonType)
    {
        switch (enumButtonType)
        {
            case EnumButtonType.Left:

                if (carsArragmentController.CheckListIsHaveCar(carInstantieController.NumberOfTeam, EnumButtonType.Left))
                {
                    var boxModel = generateCarGoingPos.GetNextPosition(EnumButtonType.Left);
      
                    CheckCarInCorrectGrid(0, boxModel, EnumObjectColor.Purple);

                    carsArragmentController.SortByLeftCar(carInstantieController.NumberOfTeam, carInstantieController.purpleCreatePosition);

                }
                break;
            case EnumButtonType.Right:
                if (carsArragmentController.CheckListIsHaveCar(carInstantieController.NumberOfTeam, EnumButtonType.Right))
                {
                    var boxModel = generateCarGoingPos.GetNextPosition(EnumButtonType.Right);
                
                    CheckCarInCorrectGrid(1, boxModel, EnumObjectColor.Yellow);

                    carsArragmentController.SortByRightCar(carInstantieController.NumberOfTeam, carInstantieController.yellowCreatePosition);

                }
                break;
        }
    }





    private void CheckCarInCorrectGrid(int childValue, BoxModel selectedBox, EnumObjectColor enumObjectColor)
    {
        activeCarMovementController = carInstantieController.NumberOfTeam[childValue].NumberOfCars[0].GetComponent<CarMovementController>();
        activeCarMovementController.startCarMovement = true;

        activeCarMovementController.SetGridPosition(selectedBox.gridBox.transform, selectedBox.gridBoxColor==enumObjectColor);

    }
}
