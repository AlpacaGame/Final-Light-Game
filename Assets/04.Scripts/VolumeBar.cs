using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void 操控音效(float Volume)
    {
        SoundManager.Sound = Volume;
    }

    public void 操控音樂(float Volume)
    {
        SoundManager.Music = Volume;
    }

    public void 靜音音效()
    {
        SoundManager.MuteSound = !SoundManager.MuteSound;
    }
    public void 靜音音樂()
    {
        SoundManager.MuteMusic = !SoundManager.MuteMusic;
    }

}
