using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillOne;
    public GameObject SkillTwo;
    public GameObject SkillThree;

    public Transform OnePos;
    public Transform TwoPos;
    public Transform ThreePos;

    private void Update()
    {
        AttackSkillOne();
    }

    public void AttackSkillOne()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject skillOne = Instantiate(SkillOne, OnePos);
            Destroy(skillOne, 2f);
            
        }
        //StartCoroutine(One());
    }

    IEnumerator One()
    {
        
        yield return new WaitForSeconds(1f);
        Instantiate(SkillOne, OnePos);
    }
}
