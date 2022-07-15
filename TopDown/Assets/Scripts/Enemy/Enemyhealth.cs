using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    private int currentHealth;
    [SerializeField] int maxHealth;

    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;

    private bool flashActive;

    public HealthBar healthBar;

    public GameObject[] SpawnItems;
    bool isDrop ;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }




    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        enemySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }

            else if (flashCounter > flashLength * .82f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }
    public void HurtEnemy(int damage)
    {
        flashActive = true;
        flashCounter = flashLength;

        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);


        if (CurrentHealth <= 0)
        {
            //GameObject emty =  Instantiate(SpawnItems[Random.Range(0, SpawnItems.Length)], this.transform);
            Dead();
            Instantiate(SpawnItems[Random.Range(0, SpawnItems.Length)], gameObject.transform.position, Quaternion.identity);
            //Destroy(gameObject);
            //isDrop = true;
            //Dead();

        }
    }
    void Dead()
    {
        Destroy(gameObject);
        //if (isDrop)
        //{
        //    Instantiate(SpawnItems[Random.Range(0, SpawnItems.Length)], this.transform);
        //}
    }


}
