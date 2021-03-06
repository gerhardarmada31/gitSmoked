using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevel : MonoBehaviour
{
    private static FMOD.Studio.EventInstance Music;

    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Main");
        Music.start();
        Music.release();        
    }

    private void OnDestroy()
    {
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
