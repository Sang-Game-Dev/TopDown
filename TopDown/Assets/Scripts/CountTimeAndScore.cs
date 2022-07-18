using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimeAndScore : MonoBehaviour
{
    [SerializeField] Text countDownTime;
    [SerializeField] Text countScull;
    [SerializeField] float timer;

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
        CountScore(12);
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


    void CountScore(float Scull)
    {
        countScull.text = ": " + Scull.ToString("0");
    }
}
