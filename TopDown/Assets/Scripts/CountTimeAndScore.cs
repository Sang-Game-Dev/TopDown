using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimeAndScore : MonoBehaviour
{
    [SerializeField] Text countDownTime;
    [SerializeField] Text countScull;
    [SerializeField] Text countScore;
    [SerializeField] float timer;

    [SerializeField] HealthManager player;
    private float currentTime;
    private float remainingTime;

    public float CurrentTime { get => currentTime; set => currentTime = value; }
    public float RemainingTime { get => remainingTime; set => remainingTime = value; }



    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        CountDownTime();
        CountScull(player.Scull);
        CountScore(player.Score);
    }

    void CountDownTime()
    {
        CurrentTime -= 1 * Time.deltaTime; 
        if(CurrentTime<=0)
        {
            CurrentTime = 0;
        }
        RemainingTime = timer - CurrentTime;
        countDownTime.text = ": " + CurrentTime.ToString("0") +"s";
       
    }


    void CountScull(float Scull)
    {
        countScull.text = ": " + Scull.ToString("0");
    }

    void CountScore(float Score)
    {
        countScore.text = ": " + Score.ToString("0");
    }
}
