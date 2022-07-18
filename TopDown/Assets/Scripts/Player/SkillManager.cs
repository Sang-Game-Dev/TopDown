using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("Skills")]

    public GameObject GoldThunder;
    public GameObject BlueThunder;
    public GameObject SkillThree;

    public GameObject Pos;

    [Header("Mp from skills")]

    [SerializeField] float blueThunderMp;
    [SerializeField] float goldThunderMp;
    [SerializeField] float tornadoThunderMp;

    ManaManager MP;

    
    private void Start()
    {
        MP = GetComponent<ManaManager>();
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


    public void AttackTornado()
    {
        Debug.Log("Skill 3");
    }

    IEnumerator InsGoldThunder()
    {
        GameObject Gold = Instantiate(GoldThunder,Pos.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(Gold);
    }
    IEnumerator InsBlueThunder()
    {
        GameObject Blue = Instantiate(BlueThunder, Pos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(Blue);
    }



    IEnumerator InsTornado()
    {
        yield return new WaitForSeconds(1f);

    }  
}
