using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHp : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] AudioClip collectSounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //SoundEffect.instance.PlaySound(sound);
            collision.GetComponent<HealthManager>().TakeHP(hp);
            Destroy(gameObject);
            SoundEffect.instance.PlaySound(collectSounds);
        }
    }
}
