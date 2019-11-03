using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip winClip;
    public AudioClip paintClip;

    public static AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playWin()
    {
        source.clip = GameObject.Find("AudioHandler").GetComponent<AudioScript>().winClip;
        source.Play();
    }
    public static void playPaint()
    {
        source.clip = GameObject.Find("AudioHandler").GetComponent<AudioScript>().paintClip;
        source.Play();
    }

}
