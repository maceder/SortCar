using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public EnumButtonType enumButtonType;
    public static int clickDelay = 1;
    private bool isClick;

    public void ButtonClick()
    {
        if (!isClick)
        {
            Message.Send<EnumButtonType>(EventName.ButtonType, enumButtonType);
            isClick = true;
            StartCoroutine(DelayTimer());
        }
    }

    IEnumerator DelayTimer()
    {
        yield return new WaitForSeconds(clickDelay);
        isClick = false;
    }
}
