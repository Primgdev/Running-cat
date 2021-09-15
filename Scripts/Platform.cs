using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformManager platform;


    private void OnEnable()
    {
        platform = GameObject.FindObjectOfType<PlatformManager>();
    }
    

    private void OnBecameVisible()
    {
        platform.RecyclePlatform(this.gameObject);
    }

    public void OnApplicationPause(bool pause)
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;

        else
            Time.timeScale = 1;
    }
}
