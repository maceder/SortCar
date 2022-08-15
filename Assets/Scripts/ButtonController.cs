using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public EnumButtonType enumButtonType;


    public void ButtonClick()
    {
        Message.Send<EnumButtonType>(EventName.ButtonType, enumButtonType);
    }
}
