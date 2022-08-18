using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Bütün Car scriplerinin control edildiði yer
/// </summary>
public class CarManager : MonoBehaviour
{
    public CarsArragmentController carsArragmentController;
    public CarInstantieController carInstantieController;
    public GenerateCarGoingPosition generateCarGoingPos;


    private CarController activeCarController;
    private int levelWinConditionCount = 0;
    private List<GameObject> AllCars;
    public void Awake()
    {
        AllCars = new List<GameObject>();
        carInstantieController.CreateCar();
    }
    private void OnEnable()
    {
        //ButtonController'dan gelen event
        Message.AddListener<EnumButtonType>(EventName.ButtonType, CheckCarDestitaion);
        //CarController'dan gelen event
        Message.AddListener<GameObject>(EventName.CarInGridBox, LevelWinControl);
    }

    private void OnDisable()
    {
        //ButtonController'dan gelen event
        Message.RemoveListener<EnumButtonType>(EventName.ButtonType, CheckCarDestitaion);
        //CarController'dan gelen event
        Message.RemoveListener<GameObject>(EventName.CarInGridBox, LevelWinControl);
    }


    //Bütün Park alanlarý doldumu kontrol ettiðim yer
    private void LevelWinControl(GameObject obj)
    {
        levelWinConditionCount++;
        AllCars.Add(obj);
        if (levelWinConditionCount == generateCarGoingPos.boxModels.Count())
        {
            GameManager.instance.LevelDone();
            foreach (var item in AllCars)
            {
                item.GetComponent<CarController>().CarScaleAnimation();
            }
        }
    }

    

    //Týklanýlan buton'daki bölümde araba varsa o bölümün özelliklerini SetCarDestination'a yolla

    //O bölümdeki arabalarý hizalamasý için controllera emir ver
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
    //CheckCarDestitaion gelen bilgilerle arabayý yolla ve doðru renge gidip gitmediðini söyle
    private void SetCarDestination(int _childValue, BoxModel selectedBox, EnumObjectColor enumObjectColor)
    {
        activeCarController = carInstantieController.NumberOfTeam[_childValue].NumberOfCars[0].GetComponent<CarController>();
        activeCarController.startCarMovement = true;

        activeCarController.SetGridPosition(selectedBox.gridBox.transform, selectedBox.gridBoxColor == enumObjectColor);

    }
}
