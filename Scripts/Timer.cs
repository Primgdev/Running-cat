using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Image timerbar;
    public float maxTime = 5f;
    float timeleft;
    
    // Start is called before the first frame update
    void Start()
    {
        timerbar = GetComponent<Image>();
        timeleft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeleft > 0)
        {
            timeleft -= Time.deltaTime;
            timerbar.fillAmount = timeleft / maxTime;

        }
        else
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(3);
        }
    }
}
