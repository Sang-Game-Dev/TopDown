using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    [Header("Slider Mana")]
    
    [SerializeField] int maxMana;
    public ManaBar MP;
    private float currentMana;
    private float Upstamina;

    


    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
        MP.SetMaxMP(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        IncreasingMp();
        
    }

    

    public void IncreasingMp()
    {
        if(currentMana < maxMana)
        {
            currentMana += Upstamina * Time.deltaTime;
        }
        else
        {
            currentMana = maxMana;
        }
    }

    public void DecreasingMp(float MinusStamina)
    {
        currentMana -= MinusStamina;
    }
}
