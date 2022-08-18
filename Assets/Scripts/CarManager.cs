using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public CarsArragmentController carsArragmentController;
    public CarInstantieController carInstantieController;
    public GenerateCarGoingPosition generateCarGoingPos;
    private CarMovementController activeCarMovementController;

    private int levelWinConditionCount = 0;

    public void Awake()
    {
        carInstantieController.CreateCar();
    }
    private void OnEnable()
    {
        //ButtonController'dan gelen event
        Message.AddListener<EnumButtonType>(EventName.ButtonType, GenerateCarsArragment);
        Message.AddListener(EventName.CarInGridBox, LevelWinControl);
    }

    private void OnDisable()
    {
        //ButtonController'dan gelen event
        Message.RemoveListener<EnumButtonType>(EventName.ButtonType, GenerateCarsArragment);
        Message.RemoveListener(EventName.CarInGridBox, LevelWinControl);
    }

    private void LevelWinControl()
    {
        levelWinConditionCount++;

        if(levelWinConditionCount == generateCarGoingPos.boxModels.Count())
        {
            Debug.Log("You Win");
        }
    }

    void GenerateCarsArragment(EnumButtonType enumButtonType)
    {
        if (carsArragmentController.CheckListIsHaveCar(carInstantieController.NumberOfTeam, enumButtonType))
        {
            int childValue = enumButtonType == EnumButtonType.Left ? 0 : 1;
            Transform bpos = enumButtonType == EnumButtonType.Left ? carInstantieController.purpleCreatePosition : carInstantieController.yellowCreatePosition;
            EnumObjectColor enumObjectColor = enumButtonType == EnumButtonType.Left ? EnumObjectColor.Purple : EnumObjectColor.Yellow;
            var boxModel = generateCarGoingPos.GetNextPosition(enumButtonType);

            CheckCarInCorrectGrid(childValue, boxModel, enumObjectColor);

            carsArragmentController.SortCarQueue(childValue,carInstantieController.NumberOfTeam, bpos);
        }

    }
    private void CheckCarInCorrectGrid(int _childValue, BoxModel selectedBox, EnumObjectColor enumObjectColor)
    {
        activeCarMovementController = carInstantieController.NumberOfTeam[_childValue].NumberOfCars[0].GetComponent<CarMovementController>();
        activeCarMovementController.startCarMovement = true;

        activeCarMovementController.SetGridPosition(selectedBox.gridBox.transform, selectedBox.gridBoxColor == enumObjectColor);

    }
}
