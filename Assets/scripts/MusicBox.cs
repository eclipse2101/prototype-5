using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    private MusicVolume jukebox;
    private AudioSource gameAudio; 
    // Start is called before the first frame update
    void Start()
    {
        jukebox = GameObject.Find("Music Settings").GetComponent<MusicVolume>();
        gameAudio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        gameAudio.volume = jukebox.mainSlider.value;  
    }
}
