using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event EventHandler OnOxygenLow;
    [SerializeField] private Slider oxygenBar;
    [SerializeField] private GameObject gameEndPanel;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button upgradesButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_Text yellowCoinText;
    [SerializeField] private TMP_Text redCoinText;
    [SerializeField] private TMP_Text blueCoinText;
    [SerializeField] private TMP_Text greenCoinText;

    private float depletionRate;
    private int yellowCoins;
    private int redCoins;
    private int blueCoins;
    private int greenCoins;

    private void Awake()
    {
        Instance = this;
        replayButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        upgradesButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            SceneManager.LoadScene("Upgrades");
        });

        quitButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            Application.Quit();
        });
    }

    private void Start()
    {
        depletionRate = DataManager.Instance.oxygenDepletionRate;
        UpdateUI();
        oxygenBar.value = oxygenBar.maxValue;
    }

    public void UpdateUI()
    {
        yellowCoins = DataManager.Instance.yellowCoins;
        redCoins = DataManager.Instance.redCoins;
        blueCoins = DataManager.Instance.blueCoins;
        greenCoins = DataManager.Instance.greenCoins;
        yellowCoinText.text = yellowCoins.ToString();
        redCoinText.text = redCoins.ToString();
        blueCoinText.text = blueCoins.ToString();
        greenCoinText.text = greenCoins.ToString();
    }

    private void Update()
    {
        oxygenBar.value -= depletionRate * Time.deltaTime;
        if(oxygenBar.value <= 0)
        {
            OnOxygenLow?.Invoke(this, EventArgs.Empty);
            gameEndPanel.SetActive(true);
            DataManager.Instance.UpdateCoins(yellowCoins, redCoins, blueCoins, greenCoins);
        }
    }
}
