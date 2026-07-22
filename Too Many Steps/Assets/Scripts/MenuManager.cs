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
            SFX.Instance.PlayClickSound();
            SceneManager.LoadScene("Game");
        });

        newGameButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            DataManager.Instance.ResetAllData();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });

        optionsButton.onClick.AddListener(() => 
        {
            SFX.Instance.PlayClickSound();
            optionsPanel.SetActive(true);
            titleScreen.SetActive(false);
        });

        exitButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            Debug.Log("Quitting...");
            Application.Quit();
        });

        backButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            titleScreen.SetActive(true);
            optionsPanel.SetActive(false);
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
