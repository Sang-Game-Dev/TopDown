using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBackround : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] Slider volumeBackroundSlider;
    //[SerializeField] Text numberBackround;
    //[SerializeField] private AudioClip Sound;



    //public static SoundManager instance { get; private set; }
    private AudioSource backround;
    // Start is called before the first frame update
    void Start()
    {
        //instance = this;
        backround = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("VolumeBackround"))
        {
            PlayerPrefs.SetFloat("VolumeBackround", 1);
            Load();
        }
        else Load();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeBackroundVolume()
    {
        backround.volume = volumeBackroundSlider.value;
        //numberBackround.text = (backround.volume * 100).ToString("0") + "%";
        if (volumeBackroundSlider.value == 0)
        {
            SoundManager.instance.PlaySound(sound);
        }
        Save();
    }

    private void Load()
    {
        volumeBackroundSlider.value = PlayerPrefs.GetFloat("VolumeBackround");

    }

    private void Save()
    {
        PlayerPrefs.SetFloat("VolumeBackround", volumeBackroundSlider.value);
    }
}
