using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event EventHandler OnOxygenLow;
    [SerializeField] private Slider oxygenBar;
    [SerializeField] private float depletionRate;
    [SerializeField] private GameObject gameEndPanel;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button upgradesButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        Instance = this;
        replayButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        upgradesButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Upgrades");
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void Start()
    {
        oxygenBar.value = oxygenBar.maxValue;
    }

    private void Update()
    {
        oxygenBar.value -= depletionRate * Time.deltaTime;
        if(oxygenBar.value <= 0)
        {
            OnOxygenLow?.Invoke(this, EventArgs.Empty);
            gameEndPanel.SetActive(true);
        }
    }
}
