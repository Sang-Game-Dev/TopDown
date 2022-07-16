using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SettingsMenu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {

    }

    public void Settings()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
}
