using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject titleScreen;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            //Play SFX
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
}
