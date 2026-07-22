using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [HideInInspector] public const string COIN_SPAWNRATE = "Coin_Spawnrate";
    [HideInInspector] public const string COIN_DECAYTIME = "Coin_Decaytime";
    [HideInInspector] public const string OXYGEN_DEPLETIONRATE = "Oxygen_Depletionrate";
    [HideInInspector] public const string COIL_RADIUS = "Coil_Radius";
    [HideInInspector] public const string YELLOW_COINS = "Yellow_Coins";
    [HideInInspector] public const string RED_COINS = "Red_Coins";
    [HideInInspector] public const string BLUE_COINS = "Blue_Coins";
    [HideInInspector] public const string GREEN_COINS = "Green_Coins";
    [HideInInspector] public const string GAME_STATE = "Game_State";
    [HideInInspector] public const string COIN_MULTIPLIER = "Coin_Multiplier";
    [HideInInspector] public const string FINAL_UPGRADE = "Final_Upgrade";

    public static DataManager Instance;
    public float coinSpawnrate;
    public float coinDecayTime;
    public float oxygenDepletionRate;
    public float coilRadius;
    public int yellowCoins;
    public int redCoins;
    public int blueCoins;
    public int greenCoins;
    public int coinMultiplier;
    public bool hasPlayedBefore = false;
    public bool hasFoundFinalUpgrade = false;

    readonly float _coinSpawnRate = 1.2f;
    readonly float _coinDecayTime = 1.5f;
    readonly float _oxygenDepletionRate = 5f;
    readonly float _coilRadius = 0.33f;
    readonly int _yellowCoins = 0;
    readonly int _redCoins = 0;
    readonly int _blueCoins = 0;
    readonly int _greenCoins = 0;
    readonly int _coinMultiplier = 1;

    public void ResetAllData()
    {
        coinSpawnrate = _coinSpawnRate;
        coinDecayTime = _coinDecayTime;
        oxygenDepletionRate = _oxygenDepletionRate;
        coilRadius = _coilRadius;
        yellowCoins = _yellowCoins;
        redCoins = _redCoins;
        blueCoins = _blueCoins;
        greenCoins = _greenCoins;
        coinMultiplier = _coinMultiplier;
        hasPlayedBefore = false;
        hasFoundFinalUpgrade = false;
        PlayerPrefs.SetFloat(COIN_SPAWNRATE, coinSpawnrate);
        PlayerPrefs.SetFloat(COIN_DECAYTIME, coinDecayTime);
        PlayerPrefs.SetFloat(OXYGEN_DEPLETIONRATE, oxygenDepletionRate);
        PlayerPrefs.SetFloat(COIL_RADIUS, coilRadius);
        PlayerPrefs.SetInt(YELLOW_COINS, yellowCoins);
        PlayerPrefs.SetInt (RED_COINS, redCoins);
        PlayerPrefs.SetInt(BLUE_COINS, blueCoins);
        PlayerPrefs.SetInt(GREEN_COINS, greenCoins);
        PlayerPrefs.SetInt(GAME_STATE, 0);
        PlayerPrefs.SetInt(COIN_MULTIPLIER, coinMultiplier);
        PlayerPrefs.SetInt(FINAL_UPGRADE, 0);
    }

    public void UpdateCoins(int yc, int rc, int bc, int gc)
    {
        yellowCoins = yc;
        redCoins = rc;
        blueCoins = bc;
        greenCoins = gc;
        hasPlayedBefore = true;
        PlayerPrefs.SetInt(GAME_STATE, 1);
        PlayerPrefs.SetInt(YELLOW_COINS, yellowCoins);
        PlayerPrefs.SetInt(RED_COINS, redCoins);
        PlayerPrefs.SetInt(BLUE_COINS, blueCoins);
        PlayerPrefs.SetInt(GREEN_COINS, greenCoins);
        
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
            coinSpawnrate = PlayerPrefs.GetFloat(COIN_SPAWNRATE);
            coinDecayTime = PlayerPrefs.GetFloat(COIN_DECAYTIME);
            oxygenDepletionRate = PlayerPrefs.GetFloat(OXYGEN_DEPLETIONRATE);
            coilRadius = PlayerPrefs.GetFloat(COIL_RADIUS);
            coinMultiplier = PlayerPrefs.GetInt(COIN_MULTIPLIER);
            if (PlayerPrefs.GetInt(FINAL_UPGRADE) == 1)
            {
                hasFoundFinalUpgrade = true;
            }
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

    public void CoinSpawnRate(float _updatedSpawnRate)
    {
        coinSpawnrate = _updatedSpawnRate;
        PlayerPrefs.SetFloat(COIN_SPAWNRATE,_updatedSpawnRate);
    }

    public void CoinDecayTime(float _updatedDecayTime)
    {
        coinDecayTime = _updatedDecayTime;
        PlayerPrefs.SetFloat(COIN_DECAYTIME,_updatedDecayTime);
    }

    public void OxygenDepletionRate(float _updatedDepletionRate)
    {
        oxygenDepletionRate= _updatedDepletionRate;
        PlayerPrefs.SetFloat(OXYGEN_DEPLETIONRATE,_updatedDepletionRate);
    }

    public void CoilRadius(float _updatedCoilRadius)
    {
        coilRadius= _updatedCoilRadius;
        PlayerPrefs.SetFloat(COIL_RADIUS,_updatedCoilRadius);
    }
    public void CoinMultiplier()
    {
        coinMultiplier = 3;
        PlayerPrefs.SetInt(COIN_MULTIPLIER, coinMultiplier);
    }

    public void FinalUpgrade()
    {
        hasFoundFinalUpgrade = true;
        PlayerPrefs.SetInt(FINAL_UPGRADE, 1);
    }
}
