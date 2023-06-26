using UnityEngine;


public class CoinManager : MonoBehaviour
{
    [SerializeField] private Transform[] coinPosition;
    [SerializeField] private GameObject coinPrefab;
    void Start()
    {
        coinPosition = GetComponentsInChildren<Transform>();

        for (int i = 1; i < coinPosition.Length; i++)
        {
            GameObject newCoin = Instantiate(coinPrefab, coinPosition[i]);
            

            int levelNumber = GameManager.instance.levelNumber;
            int totaAmountOfCoins = PlayerPrefs.GetInt("Level" + levelNumber + " TotalCoins");
            if (totaAmountOfCoins != coinPosition.Length - 1)
                PlayerPrefs.SetInt("Level" + levelNumber + " TotalCoins", coinPosition.Length - 1);
        }
    }
}

