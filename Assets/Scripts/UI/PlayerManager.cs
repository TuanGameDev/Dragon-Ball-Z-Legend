using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum HeroName
{
    Picolo,
    Gohan,
    Vegeta
}
public class PlayerManager : MonoBehaviour
{
    [Header("Info")]
    HeroName _heroName = HeroName.Picolo;
    public static PlayerManager instance;

    [HideInInspector] public int coins;
    [HideInInspector] public Transform respawnPoint;
    [HideInInspector] public GameObject currentPlayer;
    //[HideInInspector] public int choosenSkinId;
    public InGame_UI inGameUI;
    public Quanly ingameUI;

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject playerPrefab;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void SetHeroName(int id)
    {
        _heroName = (HeroName)id;
    }
    public int GetHeroName()
    {
        return (int)_heroName ;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            PlayerRespawn();
    }
    private bool HaveEnoughFruits()
    {
        if (coins > 0)
        {
            coins--;

            if (coins < 0)
                coins = 0;

            DropFruit();
            return true;
        }
        return false;
    }

    private void DropFruit()
    {
        int CoinIndex = UnityEngine.Random.Range(10, Enum.GetNames(typeof(FruitType)).Length);

        GameObject newCoins = Instantiate(coinPrefab, currentPlayer.transform.position, transform.rotation);
        Destroy(newCoins, 20);
    }
    public void OnTakingDamage()
    {

        if (!HaveEnoughFruits())
        {
            if (GameManager.instance.difficulty < 3)
                Invoke("RespawnPlayer", 1);
            else
                inGameUI.OnDeath();
        }
    }
    public void PlayerRespawn()
    {
        if (currentPlayer == null)
        {
            AudioManager.instance.PlaySFX(12);
            currentPlayer = Instantiate(playerPrefab, respawnPoint.position, transform.rotation);
            inGameUI.AssingPlayerControlls(currentPlayer.GetComponent<Player>());
            currentPlayer.name = "Player";

        }
    }
}
