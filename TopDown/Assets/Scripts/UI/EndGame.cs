using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{
    [SerializeField] HealthManager player;
    [SerializeField] CountTimeAndScore scUIPlayGame;
    [SerializeField] GameObject UIPlayGame;
    [SerializeField] GameObject endGame;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject defeat;
    [SerializeField] Text time;
    [SerializeField] Text scull;
    [SerializeField] Text score;
    [SerializeField] float x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        End();
        SaveScore();
        LoadScore();
    }

    void TheEnd(GameObject End)
    {
        endGame.SetActive(true);
        End.SetActive(true);
        time.text = ": " + scUIPlayGame.RemainingTime.ToString("0") + "s";
        scull.text = ": " + player.Scull.ToString();
        score.text = ": " + player.Score.ToString("0");
    }

    void End()
    {
        if (player.CurrentHealth <= 0)
        {
            UIPlayGame.SetActive(false);
            Time.timeScale = 0;
            TheEnd(defeat);
        }
        else if(scUIPlayGame.CurrentTime <= 0 && player.CurrentHealth > 0)
        {
            UIPlayGame.SetActive(false);
            Time.timeScale = 0;
            TheEnd(victory);
        }
    }

    public void Again(string PlayGame)
    {
        SceneManager.LoadScene(PlayGame);
    }

    public void Home(string StartGame)
    {
        SceneManager.LoadScene(StartGame);
    }

    void SaveScore()
    {
        if (player.Score > PlayerPrefs.GetFloat("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", player.Score);
        }
        if (player.Scull> PlayerPrefs.GetFloat("BestScull"))
        {
            PlayerPrefs.SetFloat("BestScull", player.Scull);
        }

    }

    void LoadScore()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Best score: " +PlayerPrefs.GetFloat("BestScore"));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Best scull: " + PlayerPrefs.GetFloat("BestScull"));
        }
    }

}
