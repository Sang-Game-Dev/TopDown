using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    [Header("Slider Mana")]
    [SerializeField] Image mana;
    [SerializeField] float maxMana;
    private float currentMana;
    [SerializeField] float Upstamina;
    private Transform PositionObject;
    [SerializeField] GameObject popUpMP;

    public float CurrentMana { get => currentMana; set => currentMana = value; }




    // Start is called before the first frame update
    void Start()
    {
        CurrentMana = maxMana;
        PositionObject = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        IncreasingMp();
        Mana();
    }

    void Mana()
    {
        mana.fillAmount = CurrentMana / maxMana;
    }

    public void IncreasingMp()
    {
        if(CurrentMana < maxMana)
        {
            CurrentMana += Upstamina * Time.deltaTime;
        }
        else
        {
            CurrentMana = maxMana;
        }
    }

    public void DecreasingMp(float MinusStamina)
    {
        CurrentMana -= MinusStamina;
    }

    public void TakeMP(int MP)
    {
        if (CurrentMana < maxMana)
        {
            CurrentMana += MP;
            Popup(popUpMP, "+", MP, " HP");

        }
        else
        {
            CurrentMana = maxMana;
            Popup(popUpMP, "+", MP, " HP");
        }
    }

    void Popup(GameObject PopUp, string text1, float HP, string text2)
    {
        GameObject TakeopUp = Instantiate(PopUp, new Vector3(PositionObject.transform.position.x - 0.5f, PositionObject.transform.position.y + 1f, 0), Quaternion.identity);
        TakeopUp.GetComponentInChildren<TextMesh>().text = text1 + HP.ToString() + text2;
    }
}
