using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    public const string UPGRADE_1 = "Upgrade1";
    public const string UPGRADE_2 = "Upgrade2";
    public const string UPGRADE_3 = "Upgrade3";
    public const string UPGRADE_4 = "Upgrade4";
    [SerializeField] private TMP_Text yellowCoinsText;
    [SerializeField] private TMP_Text redCoinsText;
    [SerializeField] private TMP_Text blueCoinsText;
    [SerializeField] private TMP_Text greenCoinsText;
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private Upgrade upgrade1;
    [SerializeField] private Upgrade upgrade2;
    [SerializeField] private Upgrade upgrade3;
    [SerializeField] private Upgrade upgrade4;

    private int yc;
    private int rc;
    private int bc;
    private int gc;

    private int u1;
    private int u2;
    private int u3;
    private int u4;

    public void ResetAllUpgrades()
    {
        PlayerPrefs.SetInt(UPGRADE_1, 0);
        PlayerPrefs.SetInt(UPGRADE_2, 0);
        PlayerPrefs.SetInt(UPGRADE_3, 0);
        PlayerPrefs.SetInt(UPGRADE_4, 0);
    }

    private void Awake()
    {
        Instance = this;
        ManageSingleton();
        playButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            SceneManager.LoadScene("Game");
        });

        exitButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            Application.Quit();
        });
    }

    private void ManageSingleton()
    {
        int instance = FindObjectsByType<UpgradeManager>(FindObjectsSortMode.None).Length;
        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoins();
        CheckForUpgrades();
    }

    public void Upgrade1()
    {
        u1 = 1;
        PlayerPrefs.SetInt(UPGRADE_1, u1);
    }

    public void Upgrade2()
    {
        u2 = 1;
        PlayerPrefs.SetInt(UPGRADE_2, u2);
    }

    public void Upgrade3()
    {
        u3 = 1;
        PlayerPrefs.SetInt(UPGRADE_3, u3);
    }

    public void Upgrade4()
    {
        u4 = 1;
        PlayerPrefs.SetInt(UPGRADE_4, u4);
    }

    public void UpdateCoins()
    {
        yc = DataManager.Instance.yellowCoins;
        rc = DataManager.Instance.redCoins;
        bc = DataManager.Instance.blueCoins;
        gc = DataManager.Instance.greenCoins;
        yellowCoinsText.text = yc.ToString();
        redCoinsText.text = rc.ToString();
        blueCoinsText.text = bc.ToString();
        greenCoinsText.text = gc.ToString();
    }

    public void CheckForUpgrades()
    {
        u1 = PlayerPrefs.GetInt(UPGRADE_1);
        u2 = PlayerPrefs.GetInt(UPGRADE_2);
        u3 = PlayerPrefs.GetInt(UPGRADE_3);
        u4 = PlayerPrefs.GetInt(UPGRADE_4);
        if (u1 == 1)
        {
            upgrade1.gameObject.GetComponent<Button>().enabled = false;
        }
        if (u2 == 1)
        {
            upgrade2.gameObject.GetComponent<Button>().enabled = false;
        }
        if (u3 == 1)
        {
            upgrade3.gameObject.GetComponent<Button>().enabled = false;
        }
        if (u4 == 1)
        {
            upgrade4.gameObject.GetComponent<Button>().enabled = false;
        }
    }
}
