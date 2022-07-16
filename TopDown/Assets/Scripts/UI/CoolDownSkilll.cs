using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownSkilll : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] RougeController player;
    [SerializeField] GameObject textSkill1;
    [SerializeField] GameObject textSkill2;
    [SerializeField] GameObject textSkill3;
    [SerializeField] GameObject Skill1;
    [SerializeField] GameObject Skill2;
    [SerializeField] GameObject Skill3;
    float timerSkill1;
    float timerSkill2;
    float timerSkill3;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Test();
    }

    //void CoolDownUI()
    //{
    //    if (player.IscoolDownExtraAttack == false)
    //    {
    //        textExtra.SetActive(true);
    //        extraSkill.SetActive(true);
    //        player.TimerExtra -= 1 * Time.deltaTime;
    //        textExtra.GetComponent<Text>().text = player.TimerExtra.ToString("0.0");
    //        extraSkill.GetComponent<Image>().fillAmount = player.TimerExtra / player.CoolDownExtraAttack1;
    //        if (player.TimerExtra <= 0)
    //        {
    //            textExtra.SetActive(false);
    //            extraSkill.SetActive(false);
    //        }
    //    }
    //    if (player.IscoolDownMagicAttack == false)
    //    {
    //        magicSkill.SetActive(true);
    //        textMagic.SetActive(true);
    //        player.TimerMagic -= 1 * Time.deltaTime;
    //        textMagic.GetComponent<Text>().text = player.TimerMagic.ToString("0.0");
    //        magicSkill.GetComponent<Image>().fillAmount = player.TimerMagic / player.CoolDownMagicAttack1;
    //        if (player.TimerMagic <= 0)
    //        {
    //            textMagic.SetActive(false);
    //            magicSkill.SetActive(false);
    //        }
    //    }
    //}

    void Test()
    {
        //if(Input.GetKeyDown(KeyCode.K))
        CoolDown(false, 10f, 12f, textSkill1, Skill1);
    }

    void CoolDown(bool SkillCoolDown, float TimerSkill,float TimerCoolDownSkillPlayer,GameObject Text, GameObject Skill)
    {
        if (SkillCoolDown == false)
        {
            Text.SetActive(true);
            Skill.SetActive(true);
            TimerSkill -= 1 * Time.deltaTime;
            Text.GetComponent<Text>().text = TimerSkill.ToString("0.0");
            Skill.GetComponent<Image>().fillAmount = TimerSkill / TimerCoolDownSkillPlayer;
            if (TimerSkill <= 0)
            {
                Text.SetActive(false);
                Skill.SetActive(false);
            }
        }
    }

}
