using System.Collections;
using UnityEngine;


/// <summary>
/// Butonlarda olan script event yoladýðým yer
/// </summary>
public class ButtonController : MonoBehaviour
{
    public EnumButtonType enumButtonType;
    public static float clickDelay = 1.5f;
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
