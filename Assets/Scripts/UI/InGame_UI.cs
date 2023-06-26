using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGame_UI : MonoBehaviour
{
    private bool gamePaused;
    public GameObject gameWin;
    public GameObject gameLose;

    [Header("Menu gameobjects")]
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject pauseUI;
    [Header("Controlls")]
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Button attacckButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button KameButton;
    [SerializeField] private Button ManaButton;
    [SerializeField] private Button SkillButon1;
    [SerializeField] private Button SkillButon2;
    [SerializeField] private HealthBar health;
    [SerializeField] private InGame_UI gameLose1;

    private void Awake()
    {
        PlayerManager.instance.inGameUI = this;
    }
    private void Start()
    {
        GameManager.instance.levelNumber = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SwitchUI(inGameUI);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CheckIfNotPaused();
    }

    public void AssingPlayerControlls(Player player)
    {
        player.gameWin = gameLose1;
        player.healthBar = health;
        player.joystick = joystick;
        attacckButton.onClick.AddListener(player.Attack);
        fireButton.onClick.AddListener(player.Skill1);
        ManaButton.onClick.AddListener(player.Skill3);
        KameButton.onClick.AddListener(player.ActiveSkill);
    }


    public void SwitchUI(GameObject uiMenu)
    {
        AudioManager.instance.PlaySFX(5);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        uiMenu.SetActive(true);
        {
            joystick.gameObject.SetActive(true);
            fireButton.gameObject.SetActive(true);
            ManaButton.gameObject.SetActive(true);
            attacckButton.gameObject.SetActive(true);
            KameButton.gameObject.SetActive(true);
            SkillButon1.gameObject.SetActive(true);
            SkillButon2.gameObject.SetActive(true);

        }
    }
    public void PauseButton() => CheckIfNotPaused();
    private bool CheckIfNotPaused()
    {
        AudioManager.instance.PlaySFX(20);
        if (!gamePaused)
        {
            gamePaused = true;
            Time.timeScale = 0;
            SwitchUI(pauseUI);
            return true;
        }
        else
        {
            gamePaused = false;
            Time.timeScale = 1;
            SwitchUI(inGameUI);
            return false;
        }
    }
    public void OnDeath() => SwitchUI(pauseUI);
    public void mainMenu(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
    public void GamePlayWin()
    {
        Time.timeScale = 1;
        gameWin.SetActive(true);
    }
    public void GamePlayLose()
    {
        gameLose.SetActive(true);
    }
    public void ResumGame()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void RedloadCurrentLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void LoadNextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
