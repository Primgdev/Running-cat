using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{

    public AudioMixer audiomixer;
    public AudioSource music;
    // Start is called before the first frame update
    public void Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();
    }

    public void StartApp()
    {
        SceneManager.LoadScene(1);
        
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        print("quit");
    }
    
 

    public void SetVolume(float volume)
    {
        print("volume");
        
        audiomixer.SetFloat("MusicVolume", volume);
        music.Play();

    }

    public void Paused()
    {

    }

}
