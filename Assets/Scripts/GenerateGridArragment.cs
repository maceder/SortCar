using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class BoxModel
{
    public GameObject gridBox;
    public int leftQueue;
    public int rightQueue;
    public bool isHaveCar;
}
public class GenerateGridArragment : MonoBehaviour
{
    [SerializeField]
    public List<BoxModel> boxModels;

    private void OnEnable()
    {
        Message.AddListener<EnumButtonType>(EventName.ButtonType, GetNextPosition);
    }

    private void OnDisable()
    {
        Message.RemoveListener<EnumButtonType>(EventName.ButtonType, GetNextPosition);
    }

    public void GetNextPosition(EnumButtonType enumButtonType)
    {
        var filter = boxModels;
        if (enumButtonType == EnumButtonType.Left)
            filter = filter.OrderBy(t => t.leftQueue).Where(t => t.leftQueue > 0).ToList();
        else
            filter = filter.OrderBy(t => t.rightQueue).Where(t => t.rightQueue > 0).ToList();

        var nextPosition = filter.FirstOrDefault(t => !t.isHaveCar);
        foreach (var item in boxModels.Where(t => t.gridBox == nextPosition.gridBox))
        {
            item.isHaveCar = true;
        }
        Message.Send<Transform>(EventName.CarGoingPosition, nextPosition.gridBox.transform);
    }
}
