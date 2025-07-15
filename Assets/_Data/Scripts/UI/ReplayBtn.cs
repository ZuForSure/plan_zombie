using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayBtn : ZuMonoBehaviour
{
    public virtual void OnClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("LvDemo");
    }
}
