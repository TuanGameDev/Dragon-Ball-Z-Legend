using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quanly : MonoBehaviour
{
    public GameObject NPCVuavegeta;
    [SerializeField] private GameObject endLevelUI;
    [Header("TextComponents")]
    //[SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI currentFruitAmount;

   // [SerializeField] private TextMeshProUGUI endTimerText;
    //[SerializeField] private TextMeshProUGUI endBestTimeText;
    [SerializeField] private TextMeshProUGUI endCoinsText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.instance.ingameUI = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInGameInfo();
    }
    public void OnLevelFinished()
    {
        endCoinsText.text = "X" + PlayerManager.instance.coins;
        //endTimerText.text = "Your time:" + GameManager.instance.timer.ToString("00") + "s";
       // endBestTimeText.text = "Best time:" + PlayerPrefs.GetFloat("Level" + GameManager.instance.levelNumber + " BestTime", 10).ToString("00") + "s";
        SwitchUI(endLevelUI);
    }
    public void SwitchUI(GameObject uiMenu)
    {
        NPCVuavegeta.SetActive(true);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        uiMenu.SetActive(true);
        {
        }
    }
    private void UpdateInGameInfo()
    {
        //timerText.text = "Time:" + GameManager.instance.timer.ToString("00") + "s";
        currentFruitAmount.text = PlayerManager.instance.coins.ToString();
    }
}
