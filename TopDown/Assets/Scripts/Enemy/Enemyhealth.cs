using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip deathSound;
    private int currentHealth;
    [SerializeField] int maxHealth;

    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;
    [SerializeField] GameObject popupDame;

    private bool flashActive;
    private Transform PositionObject;

    public HealthBar healthBar;

    public GameObject[] SpawnItems;
    bool isDrop ;
    private float scull = 0;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float Scull { get => scull; set => scull = value; }




    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        enemySprite = GetComponent<SpriteRenderer>();
        PositionObject = GetComponent<Transform>();
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
        Popup(popupDame, "-", damage, " HP");
        SoundEffect.instance.PlaySound(hurtSound);
        if (CurrentHealth <= 0)
        {
            SoundEffect.instance.PlaySound(deathSound);
            Destroy(gameObject);
            Instantiate(SpawnItems[Random.Range(0, SpawnItems.Length)], gameObject.transform.position, Quaternion.identity);
        }
    }

    void Popup(GameObject PopUp, string text1, float HP, string text2)
    {
        GameObject TakeopUp = Instantiate(PopUp, new Vector3(PositionObject.transform.position.x - 0.5f, PositionObject.transform.position.y + 1f, 0), Quaternion.identity);
        TakeopUp.GetComponentInChildren<TextMesh>().text = text1 + HP.ToString() + text2;
    }


}
