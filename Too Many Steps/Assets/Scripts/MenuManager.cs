using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });

        optionsButton.onClick.AddListener(() => 
        {
            Debug.Log("Options...");
        });

        exitButton.onClick.AddListener(() =>
        {
            Debug.Log("Quitting...");
            Application.Quit();
        });
    }
}
