using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject titleScreen;

    private void Awake()
    {
        continueButton.onClick.AddListener(() =>
        {
            //Play SFX
            SceneManager.LoadScene("Game");
        });

        newGameButton.onClick.AddListener(() =>
        {
            DataManager.Instance.ResetAllData();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });

        optionsButton.onClick.AddListener(() => 
        {
            optionsPanel.SetActive(true);
            titleScreen.SetActive(false);
            //Play SFX
        });

        exitButton.onClick.AddListener(() =>
        {
            //Play SFX
            Debug.Log("Quitting...");
            Application.Quit();
        });

        backButton.onClick.AddListener(() =>
        {
            titleScreen.SetActive(true);
            optionsPanel.SetActive(false);
            //Play SFX
        });
    }

    private void Start()
    {
        if(DataManager.Instance.hasPlayedBefore==false)
        {
            continueButton.enabled = false;
        }
    }
}
