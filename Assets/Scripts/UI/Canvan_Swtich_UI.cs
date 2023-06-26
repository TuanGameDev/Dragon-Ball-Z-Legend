using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvan_Swtich_UI : MonoBehaviour
{
    public GameObject Menu_UI;
    public GameObject GameMenu_UI;
    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwitchUI(GameObject uiMenu)
    {
        Time.timeScale = 1;
        Menu_UI.SetActive(false);
        GameMenu_UI.SetActive(false);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        uiMenu.SetActive(true);
    }
}
   
