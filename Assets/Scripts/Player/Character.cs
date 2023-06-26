using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    //Skill Cooldown
    public Text textTombol;
    public Button tombolPukul;
    public int waktuCD;
    private int waktucCDUpdate;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ButtonPukul()
    {
        tombolPukul.interactable = false;
        waktucCDUpdate = waktuCD;
        StartCoroutine(CheckCooldown());

    }
    IEnumerator CheckCooldown()
    {
        textTombol.text = waktucCDUpdate.ToString();
        waktucCDUpdate--;

        yield return new WaitForSeconds(1);

        if (waktucCDUpdate <= 0)
        {
            tombolPukul.interactable = true;
            textTombol.text = "";
        }
        else
        {
            StartCoroutine(CheckCooldown());
        }
    }
    
}
