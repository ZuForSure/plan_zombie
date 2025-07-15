using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : ZuMonoBehaviour
{
    public virtual void OnClick()
    {
        WaveManager.Instance.isStartWave = true;
        transform.gameObject.SetActive(false);
    }
}
