using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero_UI : MonoBehaviour
{
    [Serializable]
    public class HeroInfo : IEquatable<HeroInfo>
    {
        public string _heroName;
        public Sprite _sprite;
        public int _price;
        public bool _skinpurchased;

        public bool Equals(HeroInfo other)
        {
            throw new NotImplementedException();
        }
    }
    //[SerializeField] private int[] priceForSkin;
    [SerializeField] private List<HeroInfo> _heroList;

    [Header("Info")]
    private int skind_Id;
    [SerializeField] private GameObject _skinDisplay;
    private Image _currentSkinSprite;

    [Header("Componoents")]
    [SerializeField] private TextMeshProUGUI bankText;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject selectButton;
   // [SerializeField] private Animator anim;
    //[SerializeField] private List<Sprite> _playerImages;

    private List<HeroInfo> HeroList { get => _heroList; set => _heroList = value; }

    private void Start()
    {
        //_currentSkinSprite = _skinDisplay.GetComponent<SpriteRenderer>();
        _currentSkinSprite.sprite = _heroList[0]._sprite;
    }
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
    }
    private void SetupSkinInfo()
    {
        _heroList[0]._skinpurchased = true;

        for (int i = 1; i < _heroList.Count; i++)

        {
            bool skinUnlocked = PlayerPrefs.GetInt("SkinPurchased" + i) == 1;

            if (skinUnlocked)
                _heroList[i]._skinpurchased = true;
        }
        bankText.text = PlayerPrefs.GetInt("TotalCoinsCollected").ToString();


        selectButton.SetActive(_heroList[skind_Id]._skinpurchased);
        buyButton.SetActive(!_heroList[skind_Id]._skinpurchased);

        if (!_heroList[skind_Id]._skinpurchased)
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "X" + _heroList[skind_Id]._price;

        //anim.SetInteger("skinId", skind_Id);
        _currentSkinSprite.sprite = _heroList[skind_Id]._sprite;
    }

    public bool EnoughMoney()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoinsCollected");

        if (totalCoins > _heroList[skind_Id]._price)
        {
            totalCoins = totalCoins - _heroList[skind_Id]._price;

            PlayerPrefs.SetInt("TotalCoinsCollected", totalCoins);

            AudioManager.instance.PlaySFX(6);
            return true;
        }

            AudioManager.instance.PlaySFX(7);
        return false;
    }

    public void NextSkin()
    {
        AudioManager.instance.PlaySFX(6);
        skind_Id++;
        if (skind_Id > 9)
            skind_Id = 0;

        SetupSkinInfo();
    }
    public void PreviousSkin()
    {
        AudioManager.instance.PlaySFX(5);
        skind_Id--;

        if (skind_Id < 0)
            skind_Id = 9;

        SetupSkinInfo();
    }

    public void Buy()

    {
        if (EnoughMoney())
        {
            PlayerPrefs.SetInt("SkinPurchased" + skind_Id, 1);
            SetupSkinInfo();
        }
        else
            Debug.Log("NotEnoughMoney");

    }
    public void Select()
    {
        AudioManager.instance.PlaySFX(19);
       // PlayerManager.instance.choosenSkinId = skind_Id;
        PlayerManager.instance.SetHeroName(skind_Id);


    }
    public void SwitchSelectButton(GameObject newButton)
    {
        selectButton = newButton;
    }

    private void OnEnable()
    {
        _currentSkinSprite = _skinDisplay.GetComponent<Image>();
        SetupSkinInfo();
    }
    private void OnDisable()
    {
        selectButton.SetActive(false);
    }
}


