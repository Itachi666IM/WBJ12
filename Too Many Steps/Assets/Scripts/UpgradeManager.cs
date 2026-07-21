using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    [SerializeField] private TMP_Text yellowCoinsText;
    [SerializeField] private TMP_Text redCoinsText;
    [SerializeField] private TMP_Text blueCoinsText;
    [SerializeField] private TMP_Text greenCoinsText;
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private int yc;
    private int rc;
    private int bc;
    private int gc;

    private void Awake()
    {
        Instance = this;
        playButton.onClick.AddListener(() =>
        {
            //Play SFX
            SceneManager.LoadScene("Game");
        });

        exitButton.onClick.AddListener(() =>
        {
            //Play SFX
            Application.Quit();
        });
    }

    private void Start()
    {
        yc = DataManager.Instance.yellowCoins;
        rc = DataManager.Instance.redCoins;
        bc = DataManager.Instance.blueCoins;
        gc = DataManager.Instance.greenCoins;

        UpdateCoins();
    }

    public void UpdateCoins()
    {
        yellowCoinsText.text = yc.ToString();
        redCoinsText.text = rc.ToString();
        blueCoinsText.text = bc.ToString();
        greenCoinsText.text = gc.ToString();
    }
}
