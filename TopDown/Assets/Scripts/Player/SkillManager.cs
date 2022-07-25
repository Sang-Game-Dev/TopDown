using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("Skills")]

    public GameObject GoldThunder;
    public GameObject BlueThunder;
    public GameObject Tornado;

    public GameObject Pos;

    [Header("Mp from skills")]

    [SerializeField] float blueThunderMp;
    [SerializeField] float goldThunderMp;
    [SerializeField] float tornadoThunderMp;

    ManaManager MP;

    [Header("Cooldown Skill")]
    [SerializeField] float coolDownBlueThunder;
    [SerializeField] float coolDownGoldThunder;
    [SerializeField] float coolDownTornado;

    [Header("Sound SKill")]
    [SerializeField] AudioClip blueThunderSound;
    [SerializeField] AudioClip goldThunderSound;
    [SerializeField] AudioClip tornadoSound;


    private bool isCoolDownBlueThunder = true;
    private bool isCoolDownGoldThunder = true;
    private bool isCoolDownTornado = true;
    private float timerBlueThunder;
    private float timerGoldThunder;
    private float timerTornado;

    public bool IsCoolDownBlueThunder { get => isCoolDownBlueThunder; set => isCoolDownBlueThunder = value; }
    public bool IsCoolDownGoldThunder { get => isCoolDownGoldThunder; set => isCoolDownGoldThunder = value; }
    public bool IsCoolDownTornado { get => isCoolDownTornado; set => isCoolDownTornado = value; }
    public float TimerBlueThunder { get => timerBlueThunder; set => timerBlueThunder = value; }
    public float TimerGoldThunder { get => timerGoldThunder; set => timerGoldThunder = value; }
    public float TimerSkillThree { get => timerTornado; set => timerTornado = value; }
    public float CoolDownBlueThunder { get => coolDownBlueThunder; set => coolDownBlueThunder = value; }
    public float CoolDownGoldThunder { get => coolDownGoldThunder; set => coolDownGoldThunder = value; }
    public float CoolDownSkillThree { get => coolDownTornado; set => coolDownTornado = value; }

    private void Start()
    {
        MP = GetComponent<ManaManager>();
        
    }
    private void Update()
    {
        AttackGoldThunder();
        AttackBlueThunder();
        AttackTornado();
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
            SoundEffect.instance.PlaySound(blueThunderSound);
            MP.DecreasingMp(blueThunderMp);
            IsCoolDownBlueThunder = false;
            StartCoroutine(InsBlueThunder());
            StartCoroutine(CoolDownBlue());
        }
    }
     public void AttackTornado()
     {
        if(SimpleInput.GetKeyDown(KeyCode.O) && MP.CurrentMana >= tornadoThunderMp && IsCoolDownTornado)
        {
            SoundEffect.instance.PlaySound(tornadoSound);
            MP.DecreasingMp(tornadoThunderMp);
            IsCoolDownTornado = false;
            StartCoroutine(InsTornado());
            StartCoroutine(CoolDownTornado());

        }
     }
    
    IEnumerator InsTornado()
    {
        GameObject tor = Instantiate(Tornado, Pos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(tor);
    }


    IEnumerator InsBlueThunder()
    {
        GameObject Blue = Instantiate(BlueThunder, Pos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(Blue);
    }
   

    IEnumerator InsGoldThunder()
    {
        GameObject Gold = Instantiate(GoldThunder,Pos.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(Gold);
    }
    
 

    IEnumerator CoolDownTornado()
    {
        timerTornado = coolDownTornado;
        yield return new WaitForSeconds(coolDownTornado);
        IsCoolDownTornado = true;
    }

    IEnumerator CoolDownBlue()
    {
        TimerBlueThunder = CoolDownBlueThunder;
        yield return new WaitForSeconds(CoolDownBlueThunder);        
        IsCoolDownBlueThunder = true;
    }

    IEnumerator CoolDownGold()
    {
        timerGoldThunder = CoolDownGoldThunder;
        yield return new WaitForSeconds(CoolDownGoldThunder);
        IsCoolDownGoldThunder = true;
    }




}
