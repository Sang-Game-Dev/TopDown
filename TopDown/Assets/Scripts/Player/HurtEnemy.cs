using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    private Enemyhealth enemyhealth;
    public int Damage;
    HealthManager player;
    [SerializeField] AudioClip ZombieSound;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemyhealth>().HurtEnemy(Damage);
            if(other.gameObject.GetComponent<Enemyhealth>().CurrentHealth <= 0)
            {
                SoundEffect.instance.PlaySound(ZombieSound);
                player.Scull++;
            }
        }
    }
}
