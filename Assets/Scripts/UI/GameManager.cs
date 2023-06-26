using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int difficulty;

    [Header("Level info")]
    public int levelNumber;

    //[Header("Timer")]
    //public float timer;
    //public bool startTime;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    private void Start()
    {
        if (difficulty == 0)
            difficulty = PlayerPrefs.GetInt("GameDifficulty");
        PlayerPrefs.GetFloat("Level" + levelNumber + "BestTime");

    }

    private void Update()
    {
    }
    public void SaveGameDifficulty()
    {
        PlayerPrefs.SetInt("GameDifficulty", difficulty);
    }
   /* public void SaveBestTime()
    {
        startTime = false;
        float lastTime = PlayerPrefs.GetFloat("Level" + levelNumber + "BestTime");
        if(timer < lastTime)
        PlayerPrefs.SetFloat("Level" + levelNumber + " BestTime", timer);
        timer = 0;
    }*/

    public void SaveCollectedFruits()
    {
        int totaCoins = PlayerPrefs.GetInt("TotalCoinsCollected");

        int newTotalCoins = totaCoins+ PlayerManager.instance.coins;

        PlayerPrefs.SetInt("TotalCoinsCollected", newTotalCoins);
        PlayerPrefs.SetInt("Level" + levelNumber + "CoinsCollected", PlayerManager.instance.coins);

        PlayerManager.instance.coins= 0;

    }

    public void SaveLevelInfo()
    {
        int nextLevelNumber = levelNumber + 1;
        PlayerPrefs.SetInt("Level" + nextLevelNumber + "Unlocked", 1);
    }

}
