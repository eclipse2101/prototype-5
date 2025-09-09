using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBox : MonoBehaviour
{
    private AudioSource gameAudio;
    private Slider musicVol; 
    private float volume = 1;
    bool foundJukeBox = false;
    // Start is called before the first frame update
    void Start()
    { 
        gameAudio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        FindJukeBox();

        //Debug.Log(volume);
        gameAudio.volume = volume;  
    }

    void FindJukeBox()
    {
        
            musicVol = GameObject.Find("music changer").GetComponent<Slider>();
       
            volume = musicVol.value;
            foundJukeBox = true; 
    }
}
