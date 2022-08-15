using System;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float XBasedCM;
    [SerializeField] private float XPosLimit;
    [SerializeField] private float swerveSensitivity;
    [SerializeField] private bool inEditor;

    private float lastX;
    private bool buttonState;


    private void Update()
    {
        SwerveMovement();
        InputDetection();

#if UNITY_EDITOR
        InputEditor();
#endif
    }
    void InputDetection()
    {
        if (Input.touchCount > 0)
        {
            XBasedCM = (Input.GetTouch(0).deltaPosition.x / Screen.dpi) * 2.54f;
        }
        else
            if (!inEditor)
            XBasedCM = 0;
    }

    void SwerveMovement()
    {
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -XPosLimit, XPosLimit), transform.localPosition.y, transform.localPosition.z);
        if (XPosLimit - Math.Abs(transform.localPosition.x) != 0)
        {
            Move();
        }
        else if (transform.localPosition.x >= 0 && XBasedCM < 0)
        {
            Move();
        }
        else if (transform.localPosition.x <= 0 && XBasedCM > 0)
        {
            Move();
        }

    }

    void Move()
    {
        if (XBasedCM < 100 || XBasedCM > -100)
            transform.Translate(XBasedCM * swerveSensitivity, 0, 0);
    }

    void InputEditor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastX = Input.mousePosition.x;
            buttonState = true;
        }
        if (Input.GetMouseButton(0) && buttonState)
        {
            XBasedCM = ((Input.mousePosition.x - lastX) / Screen.dpi) * 2.54f;
            lastX = Input.mousePosition.x;
        }
        else
        {
            buttonState = false;
            if (inEditor)
                XBasedCM = 0;
        }
    }
}
