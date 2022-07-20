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

    [Header("Cooldown Skill")]
    [SerializeField] float coolDownBlueThunder;
    [SerializeField] float coolDownGoldThunder;
    [SerializeField] float coolDownSkillThree;

    [Header("Sound SKill")]
    [SerializeField] AudioClip blueThunderSound;
    [SerializeField] AudioClip goldThunderSound;
    [SerializeField] AudioClip tornadoSound;


    private bool isCoolDownBlueThunder = true;
    private bool isCoolDownGoldThunder = true;
    private bool isCoolDownSkillThree = true;
    private float timerBlueThunder;
    private float timerGoldThunder;
    private float timerSkillThree;

    public bool IsCoolDownBlueThunder { get => isCoolDownBlueThunder; set => isCoolDownBlueThunder = value; }
    public bool IsCoolDownGoldThunder { get => isCoolDownGoldThunder; set => isCoolDownGoldThunder = value; }
    public bool IsCoolDownSkillThree { get => isCoolDownSkillThree; set => isCoolDownSkillThree = value; }
    public float TimerBlueThunder { get => timerBlueThunder; set => timerBlueThunder = value; }
    public float TimerGoldThunder { get => timerGoldThunder; set => timerGoldThunder = value; }
    public float TimerSkillThree { get => timerSkillThree; set => timerSkillThree = value; }
    public float CoolDownBlueThunder { get => coolDownBlueThunder; set => coolDownBlueThunder = value; }
    public float CoolDownGoldThunder { get => coolDownGoldThunder; set => coolDownGoldThunder = value; }
    public float CoolDownSkillThree { get => coolDownSkillThree; set => coolDownSkillThree = value; }

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

        if (SimpleInput.GetKeyDown(KeyCode.K) && MP.CurrentMana >= goldThunderMp && IsCoolDownGoldThunder)
        {
            SoundEffect.instance.PlaySound(goldThunderSound);
            MP.DecreasingMp(goldThunderMp);
            IsCoolDownGoldThunder = false;
            StartCoroutine(InsGoldThunder());
            StartCoroutine(CoolDownGold());
        }
    }
    public void AttackBlueThunder()
    {

        if (SimpleInput.GetKeyDown(KeyCode.L)&& MP.CurrentMana >= blueThunderMp && IsCoolDownBlueThunder)
        {
            MP.DecreasingMp(blueThunderMp);
            IsCoolDownBlueThunder = false;
            StartCoroutine(InsBlueThunder());
            StartCoroutine(CoolDownBlue());
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

    IEnumerator CoolDownBlue()
    {
        TimerBlueThunder = CoolDownBlueThunder;
        yield return new WaitForSeconds(CoolDownBlueThunder);        
        IsCoolDownBlueThunder = true;
    }

    IEnumerator CoolDownGold()
    {
        TimerGoldThunder = CoolDownGoldThunder;
        yield return new WaitForSeconds(CoolDownGoldThunder);
        IsCoolDownGoldThunder = true;
    }



    IEnumerator InsTornado()
    {
        yield return new WaitForSeconds(1f);

    }  
}
