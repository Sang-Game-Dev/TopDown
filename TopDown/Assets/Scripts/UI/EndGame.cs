using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{
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
        //End(false);
    }

    void TheEnd(GameObject End,float totalScull)
    {
        endGame.SetActive(true);
        End.SetActive(true);
        time.text = ": " + scUIPlayGame.RemainingTime.ToString("0") + "s";
        scull.text = ": " + totalScull.ToString();
        score.text = ": " + (totalScull * x).ToString("0");
    }

    void End(bool Win)
    {
        if (scUIPlayGame.CurrentTime <= 0 || !Win)
        {
            UIPlayGame.SetActive(false);
            Time.timeScale = 0;
            TheEnd(defeat, 12);
        }
        else if(scUIPlayGame.CurrentTime >= 0 || Win)
        {
            UIPlayGame.SetActive(false);
            Time.timeScale = 0;
            TheEnd(victory, 15);
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
}
