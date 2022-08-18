using System.Linq;
using UnityEngine;


/// <summary>
/// B�t�n Car scriplerinin control edildi�i yer
/// </summary>
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
        Message.AddListener<EnumButtonType>(EventName.ButtonType, CheckCarDestitaion);
        //CarMovementController'dan gelen event
        Message.AddListener(EventName.CarInGridBox, LevelWinControl);
    }

    private void OnDisable()
    {
        //ButtonController'dan gelen event
        Message.RemoveListener<EnumButtonType>(EventName.ButtonType, CheckCarDestitaion);
        //CarMovementController'dan gelen event
        Message.RemoveListener(EventName.CarInGridBox, LevelWinControl);
    }


    //B�t�n Park alanlar� doldumu kontrol etti�im yer
    private void LevelWinControl()
    {
        levelWinConditionCount++;

        if (levelWinConditionCount == generateCarGoingPos.boxModels.Count())
        {
            GameManager.instance.LevelDone();
        }
    }

    

    //T�klan�lan buton'daki b�l�mde araba varsa o b�l�m�n �zelliklerini SetCarDestination'a yolla

    //O b�l�mdeki arabalar� hizalamas� i�in controllera emir ver
    void CheckCarDestitaion(EnumButtonType enumButtonType)
    {
        if (carsArragmentController.CheckListIsHaveCar(carInstantieController.NumberOfTeam, enumButtonType))
        {
            int childValue = enumButtonType == EnumButtonType.Left ? 0 : 1;
            Transform bpos = enumButtonType == EnumButtonType.Left ? carInstantieController.purpleCreatePosition : carInstantieController.yellowCreatePosition;
            EnumObjectColor enumObjectColor = enumButtonType == EnumButtonType.Left ? EnumObjectColor.Purple : EnumObjectColor.Yellow;
            var boxModel = generateCarGoingPos.GetNextPosition(enumButtonType);

            SetCarDestination(childValue, boxModel, enumObjectColor);

            carsArragmentController.SortCarQueue(childValue, carInstantieController.NumberOfTeam, bpos);
        }

    }
    //CheckCarDestitaion gelen bilgilerle arabay� yolla ve do�ru renge gidip gitmedi�ini s�yle
    private void SetCarDestination(int _childValue, BoxModel selectedBox, EnumObjectColor enumObjectColor)
    {
        activeCarMovementController = carInstantieController.NumberOfTeam[_childValue].NumberOfCars[0].GetComponent<CarMovementController>();
        activeCarMovementController.startCarMovement = true;

        activeCarMovementController.SetGridPosition(selectedBox.gridBox.transform, selectedBox.gridBoxColor == enumObjectColor);

    }
}
