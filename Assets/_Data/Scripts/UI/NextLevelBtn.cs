using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelBtn : ZuMonoBehaviour
{
    public virtual void OnClick()
    {
        Time.timeScale = 1.0f;
    }
}
