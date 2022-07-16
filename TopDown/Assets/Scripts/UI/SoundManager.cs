using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager instance { get; private set; }
    private AudioSource number;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        number = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(AudioClip sound)
    {
        number.PlayOneShot(sound);
    }
}
