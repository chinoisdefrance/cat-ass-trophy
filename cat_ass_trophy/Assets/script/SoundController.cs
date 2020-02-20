using UnityEngine;
using UnityEngine.Events;

public class SoundController : MonoBehaviour
{
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip = null)
    {
        if (clip)
        {
            audio.PlayOneShot(clip);
        }       
    }
   
}
