using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateCarGoingPosition : MonoBehaviour
{
    [SerializeField]
    public List<BoxModel> boxModels;

    public BoxModel GetNextPosition(EnumButtonType enumButtonType)
    {
        var filter = boxModels;
        if (enumButtonType == EnumButtonType.Left)
            filter = filter.OrderBy(t => t.leftQueue).Where(t => t.leftQueue > 0).ToList();
        else
            filter = filter.OrderBy(t => t.rightQueue).Where(t => t.rightQueue > 0).ToList();

        var nextBox = filter.FirstOrDefault(t => !t.isHaveCar);
        foreach (var item in boxModels.Where(t => t.gridBox == nextBox.gridBox))
        {
            item.isHaveCar = true;
        }
        return nextBox;
    }
}
