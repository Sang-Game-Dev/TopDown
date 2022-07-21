using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{   
    [Header("Set up HP")]
    private int currentHealth;
    [SerializeField] int maxHealth;

    [Header("Flash")]
    [SerializeField] 
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;

    private bool flashActive;
    private float score;
    private float scull;

    [Header("Slider bar")]

    public HealthBar HP;
    private Transform positionObject;

    [Header("PopUp")]
    [SerializeField] GameObject popupDame;
    [SerializeField] GameObject popupHp;
    [SerializeField] GameObject popupScore;

    public float Score { get => score; set => score = value; }
    public Transform PositionObject { get => positionObject; set => positionObject = value; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float Scull { get => scull; set => scull = value; }

    void Start()
    {
        CurrentHealth = maxHealth;
        HP.SetMaxHealth(maxHealth);
        PositionObject = GetComponent<Transform>();

        playerSprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive)
        {
            if(flashCounter > flashLength * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }

            else if(flashCounter > flashLength * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if(flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else 
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damage)
    {
        flashActive = true;
        flashCounter = flashLength;

        CurrentHealth -= damage;
        Popup(popupDame, "-", damage, " HP");
        HP.SetHealth(CurrentHealth);
        

        if(CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void TakeHP(int HP)
    {
        if (CurrentHealth < maxHealth)
        {
            CurrentHealth += HP;
            Popup(popupHp, "+", HP, " HP");

        }
        else
        {
            CurrentHealth = maxHealth;
            Debug.Log("HP was full");
            Popup(popupHp, "+", HP, " HP");
        }
    }

    public void TakeScore(float score)
    {
        Score += score;
        Popup(popupScore, "+", score, " $");
    }

    public void TakeScull(float scull)
    {
        Scull += scull;
    }

    void Popup(GameObject PopUp, string text1, float HP, string text2)
    {
        GameObject TakeopUp = Instantiate(PopUp, new Vector3(PositionObject.transform.position.x - 0.5f, PositionObject.transform.position.y + 1f, 0), Quaternion.identity);
        TakeopUp.GetComponentInChildren<TextMesh>().text = text1 + HP.ToString() + text2;
    }


}
