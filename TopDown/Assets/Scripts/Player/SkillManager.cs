using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject GoldThunder;
    public GameObject BlueThunder;
    public GameObject SkillThree;

    private void Start()
    {
       
    }
    private void Update()
    {
        AttackGoldThunder();
        AttackBlueThunder();
    }

    public void AttackGoldThunder()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {

            StartCoroutine(InsGoldThunder());

        }
    }
    public void AttackBlueThunder()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(InsBlueThunder());

        }
    }

    IEnumerator InsGoldThunder()
    {
        Vector3 Pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
         //GameObject GoldThunder = Instantiate(SkillOne,new Vector3( Pos.x - 1,Pos.y-1,0), Quaternion.identity);
        for(int i =0; i<=4; i++)
        {
            GameObject Gold = Instantiate(GoldThunder, new Vector3(Pos.x - Random.Range(-1.5f,1.5f), Pos.y - Random.Range(-1.5f, 1.5f), 0), Quaternion.identity);
            Destroy(Gold,0.5f);
        }
        
        yield return new WaitForSeconds(0f);
        
    }
    IEnumerator InsBlueThunder()
    {
        Vector3 Pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //GameObject GoldThunder = Instantiate(SkillOne,new Vector3( Pos.x - 1,Pos.y-1,0), Quaternion.identity);
        for (int i = 0; i <= 4; i++)
        {
            GameObject Blue = Instantiate(BlueThunder, new Vector3(Pos.x - Random.Range(-1.5f, 1.5f), Pos.y - Random.Range(-1.5f, 1.5f), 0), Quaternion.identity);
            Destroy(Blue, 0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        //Destroy(GoldThunder);
    }
}
