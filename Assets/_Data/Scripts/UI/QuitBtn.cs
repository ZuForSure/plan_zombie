using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn : MonoBehaviour
{
    public virtual void OnClick()
    {
        Application.Quit();
    }
}
