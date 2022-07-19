using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthMan;
    private bool isTouching = true;

    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();

    }

    // Update is called once per frame
    void Update()
    {



    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isTouching == true)
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(Damage);
            isTouching = false;
            StartCoroutine(HurtCoolDown());
        }
    }


    IEnumerator HurtCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        isTouching = true;
    }
}
