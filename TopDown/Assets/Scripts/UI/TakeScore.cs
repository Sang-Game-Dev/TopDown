using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScore : MonoBehaviour
{
    [SerializeField] float score;
    
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
            collision.GetComponent<HealthManager>().TakeScore(score);
            Destroy(gameObject);
        }
    }
}
