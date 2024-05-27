using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScript : MonoBehaviour
{
    public Slider slider;

    void start()
    {
        slider.minValue = 0f;
    }

    public void SetJumpMin(float jump)
    {
        slider.minValue = 0f;
        slider.value = jump;
       
        
    }
    public void SetJump(float jump)
    {
        Debug.Log(jump);
        slider.SetValueWithoutNotify(jump);

    }
}