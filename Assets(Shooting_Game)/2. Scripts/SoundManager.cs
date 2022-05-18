using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip sndExplosion;
    public AudioSource myAudio;

    void Awake()
    {
        if(SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        myAudio.PlayOneShot(sndExplosion);
    }
}
