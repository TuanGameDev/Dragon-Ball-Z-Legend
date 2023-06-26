using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    //public Image manaBar;
    public Text manaText;

    public float myMana;

    private float currentMana;
    private float calculateMana;
    // Start is called before the first frame update
    void Start()
    {
        currentMana = myMana;
    }

    // Update is called once per frame
    void Update()
    {
        calculateMana = currentMana / myMana;
        //manaBar.fillAmount = Mathf.MoveTowards(manaBar.fillAmount, calculateMana, Time.deltaTime);
        manaText.text = "%" + (int)currentMana;
    }
    public void Manatru(float mana)
    {
        currentMana -= mana;
        if (currentMana <= 0)
        {
            currentMana = 0;
        }
    }
    public void ManaCong(float mana)
    {
        currentMana += mana;
        {
            currentMana = 100;
        }

    }
}

