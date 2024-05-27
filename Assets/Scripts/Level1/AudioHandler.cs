using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private PowerButton powerButton;


    [SerializeField]private AudioSource source;
    [SerializeField]private List<AudioClip> audioClips = new List<AudioClip>();
    private int soundNum;
    private bool isPlayed;
    private bool isCollided;
    void Start()
    {
        powerButton = FindAnyObjectByType<PowerButton>();
    }

    void Update()
    {
        if (powerButton==null) 
        {
            powerButton = FindAnyObjectByType<PowerButton>();
        }
        if (powerButton != null && powerButton.isPressed)
        {
            soundNum = 2;
            PlayPowerSound(soundNum);
        }
       
        if (!isPlayed && isCollided) 
        {
            playPowerSelectSound(soundNum);
            isPlayed = true;
        }
        
    }

    public void PlayPowerSound(int sound) 
    {
        source.clip = audioClips[sound];
        source.Play();
    
    }

    public void playPowerSelectSound(int sound) 
    {
        source.clip = audioClips[sound];
        source.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Rage") 
        {
            soundNum = 1;
            isCollided = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollided=false;
    }

}
