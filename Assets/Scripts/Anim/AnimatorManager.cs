using UnityEngine;

/// <summary>
/// ButtonControl'den gelen eventi yakalayýp gelen evente göre animasyon oynattýðým yer
/// </summary>
public class AnimatorManager : MonoBehaviour
{
    public Animator leftButtonAnimator, leftBarrierAnimator;
    [Header("")]
    public Animator rightButtonAnimator;
    public Animator rightBarrierAnimator;

    private void OnEnable()
    {
        Message.AddListener<EnumButtonType>(EventName.ButtonType, SetButtonAndBarrierAnim);
    }

    private void OnDisable()
    {
        Message.RemoveListener<EnumButtonType>(EventName.ButtonType, SetButtonAndBarrierAnim);
    }

    private void SetButtonAndBarrierAnim(EnumButtonType enumButtonType)
    {
        switch (enumButtonType)
        {
            case EnumButtonType.Left:
                leftBarrierAnimator.SetTrigger("leftBarrierTrigger");
                leftButtonAnimator.SetTrigger("leftButtonTrigger");
                break;
            case EnumButtonType.Right:
                rightBarrierAnimator.SetTrigger("rightBarrierTrigger");
                rightButtonAnimator.SetTrigger("rightButtonTrigger");
                break;
        }
    }
}
