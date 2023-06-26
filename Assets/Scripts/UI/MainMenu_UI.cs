using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public GameObject Menu_UI;
    public GameObject Hero_UI;
    [SerializeField] private VolumeController_UI[] volumeController;

    // Start is called before the first frame update
   private void Start()
    {
       
        for (int i=0; i < volumeController.Length; i++)
        {
            volumeController[i].GetComponent<VolumeController_UI>().SetupVolumeSlider();
        }
        AudioManager.instance.PlayBGM(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwitchUI(GameObject uiMenu)
    {
        Menu_UI.SetActive(false);
        Hero_UI.SetActive(false);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        AudioManager.instance.PlaySFX(5);
        uiMenu.SetActive(true);
    }
   public void Exit()
    {
        Application.Quit();
        AudioManager.instance.PlaySFX(19);

    }
    public void SceneCreen(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void SetGameDifficulty(int i) => GameManager.instance.difficulty = i;
    public void LoadNextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}

