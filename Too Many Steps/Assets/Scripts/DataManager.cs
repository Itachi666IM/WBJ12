using UnityEngine;

public class DataManager : MonoBehaviour
{
    [HideInInspector] public const string COIN_SPAWNRATE = "Coin_Spawnrate";
    [HideInInspector] public const string COIN_DECAYTIME = "Coin_Decaytime";
    [HideInInspector] public const string OXYGEN_DEPLETIONRATE = "Oxygen_Depletionrate";
    [HideInInspector] public const string YELLOW_COINS = "Yellow_Coins";
    [HideInInspector] public const string RED_COINS = "Red_Coins";
    [HideInInspector] public const string BLUE_COINS = "Blue_Coins";
    [HideInInspector] public const string GREEN_COINS = "Green_Coins";
    [HideInInspector] public const string GAME_STATE = "Game_State";

    public static DataManager Instance;
    public float coinSpawnrate;
    public float coinDecayTime;
    public float oxygenDepletionRate;
    public int yellowCoins;
    public int redCoins;
    public int blueCoins;
    public int greenCoins;
    public bool hasPlayedBefore = false;

    private float _coinSpawnRate = 1.2f;
    private float _coinDecayTime = 1.5f;
    private float _oxygenDepletionRate = 5f;
    private int _yellowCoins = 0;
    private int _redCoins = 0;
    private int _blueCoins = 0;
    private int _greenCoins = 0;

    public void ResetAllData()
    {
        coinSpawnrate = _coinSpawnRate;
        coinDecayTime = _coinDecayTime;
        oxygenDepletionRate = _oxygenDepletionRate;
        yellowCoins = _yellowCoins;
        redCoins = _redCoins;
        blueCoins = _blueCoins;
        greenCoins = _greenCoins;
        hasPlayedBefore = false;
        PlayerPrefs.SetFloat(COIN_SPAWNRATE, coinSpawnrate);
        PlayerPrefs.SetFloat(COIN_DECAYTIME, coinDecayTime);
        PlayerPrefs.SetFloat(OXYGEN_DEPLETIONRATE, oxygenDepletionRate);
        PlayerPrefs.SetInt(YELLOW_COINS, yellowCoins);
        PlayerPrefs.SetInt (RED_COINS, redCoins);
        PlayerPrefs.SetInt(BLUE_COINS, blueCoins);
        PlayerPrefs.SetInt(GREEN_COINS, greenCoins);
        PlayerPrefs.SetInt(GAME_STATE, 0);
    }

    public void UpdateCoins(int yc, int rc, int bc, int gc)
    {
        hasPlayedBefore = true;
        PlayerPrefs.SetInt(GAME_STATE, 1);
        PlayerPrefs.SetInt(YELLOW_COINS, yc);
        PlayerPrefs.SetInt(RED_COINS, rc);
        PlayerPrefs.SetInt(BLUE_COINS, bc);
        PlayerPrefs.SetInt(GREEN_COINS, gc);
    }
    private void Awake()
    {
        Instance = this;
        ManageSingleton();
        if(PlayerPrefs.GetInt(GAME_STATE)==1)
        {
            hasPlayedBefore= true;
            yellowCoins = PlayerPrefs.GetInt(YELLOW_COINS);
            redCoins = PlayerPrefs.GetInt(RED_COINS);
            blueCoins = PlayerPrefs.GetInt(BLUE_COINS);
            greenCoins = PlayerPrefs.GetInt(GREEN_COINS);
        }
    }

    private void ManageSingleton()
    {
        int instance = FindObjectsByType<DataManager>(FindObjectsSortMode.None).Length;
        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
