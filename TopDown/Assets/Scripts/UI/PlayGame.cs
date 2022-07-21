using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField] GameObject buttonSettings;
    [SerializeField] GameObject button;
    [SerializeField] GameObject settingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Settings()
    {
        buttonSettings.SetActive(false);
        button.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Back()
    {
        buttonSettings.SetActive(true);
        button.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void Home(string name)
    {
        SceneManager.LoadScene(name);
    }
}
