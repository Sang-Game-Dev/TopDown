using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownSkilll : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] RougeController player;
    [SerializeField] SkillManager player;
    [SerializeField] GameObject textBlue;
    [SerializeField] GameObject textGold;
    [SerializeField] GameObject textSkill3;
    [SerializeField] GameObject SkillBlue;
    [SerializeField] GameObject SkillGold;
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
        CoolDownSkillBlueThunder();
        CoolDownSkillGoldThunder();

    }
    //void SkillUI()
    //{
    //    CoolDown(player.IsCoolDownBlueThunder,player.TimerBlueThunder,player.CoolDownBlueThunder, textSkill1,Skill1);
    //}

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

    void CoolDownSkillBlueThunder()
    {
        if (player.IsCoolDownBlueThunder == false)
        {
            textBlue.SetActive(true);
            SkillBlue.SetActive(true);
            player.TimerBlueThunder -= 1 * Time.deltaTime;
            textBlue.GetComponent<Text>().text = player.TimerBlueThunder.ToString("0.0");
            SkillBlue.GetComponent<Image>().fillAmount = player.TimerBlueThunder / player.CoolDownBlueThunder;
            if (player.TimerBlueThunder <= 0)
            {
                textBlue.SetActive(false);
                SkillBlue.SetActive(false);
            }
        }
    }

    void CoolDownSkillGoldThunder()
    {
        if (player.IsCoolDownGoldThunder == false)
        {
            textGold.SetActive(true);
            SkillGold.SetActive(true);
            player.TimerGoldThunder -= 1 * Time.deltaTime;
            textGold.GetComponent<Text>().text = player.TimerGoldThunder.ToString("0.0");
            SkillGold.GetComponent<Image>().fillAmount = player.TimerGoldThunder / player.CoolDownGoldThunder;
            if (player.TimerGoldThunder <= 0)
            {
                textGold.SetActive(false);
                SkillGold.SetActive(false);
            }
        }
    }

}
