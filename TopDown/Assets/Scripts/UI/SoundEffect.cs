using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] Slider volumeEffectSlider;
    //[SerializeField] Text numberEffect;

    public static SoundEffect instance { get; private set; }
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("VolumeEffect"))
        {
            PlayerPrefs.SetFloat("VolumeEffect", 1);
            LoadSoundEffect();
        }
        else LoadSoundEffect();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }


    public void ChangeEffectVolume()
    {
        source.volume = volumeEffectSlider.value;
        //numberEffect.text = (source.volume * 100).ToString("0") + "%";
        if (volumeEffectSlider.value == 0)
        {
            SoundManager.instance.PlaySound(sound);
        }
        SaveSoundEffect();
    }

    private void LoadSoundEffect()
    {
        volumeEffectSlider.value = PlayerPrefs.GetFloat("VolumeEffect");

    }

    private void SaveSoundEffect()
    {
        PlayerPrefs.SetFloat("VolumeEffect", volumeEffectSlider.value);
    }

}
