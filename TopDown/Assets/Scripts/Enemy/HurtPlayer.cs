using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthMan;
    private float waitToHurt = 1f;
    private bool isTouching = false;

    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();

    }

    // Update is called once per frame
    void Update()
    {


        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;

            if(waitToHurt <= 0)
            {
                healthMan.HurtPlayer(Damage);
                waitToHurt = 1f;
                
            }
        
        }



    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(Damage);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
            isTouching = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
