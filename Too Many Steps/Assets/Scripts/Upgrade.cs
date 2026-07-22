using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text yellowCoinsRequired;
    [SerializeField] private TMP_Text redCoinsRequired;
    [SerializeField] private TMP_Text blueCoinsRequired;
    [SerializeField] private TMP_Text greenCoinsRequired;
    [SerializeField] private int ycr;
    [SerializeField] private int rcr;
    [SerializeField] private int bcr;
    [SerializeField] private int gcr;
    private Button upgradeButton;
    readonly float maxSpawnRate = 0.1f;
    readonly float maxDecayTime = 2f;
    readonly float maxLungCapacity = 4f;
    readonly float maxRadius = 0.69f;

    private int yc;
    private int rc;
    private int bc;
    private int gc;

    private void Awake()
    {
        upgradeButton = GetComponent<Button>();
        yellowCoinsRequired.text = ycr.ToString();
        redCoinsRequired.text = rcr.ToString();
        blueCoinsRequired.text = bcr.ToString();
        greenCoinsRequired.text = gcr.ToString();
    }

    private void Start()
    {
        yc = DataManager.Instance.yellowCoins;
        rc = DataManager.Instance.redCoins;
        bc = DataManager.Instance.blueCoins;
        gc = DataManager.Instance.greenCoins;
        UpgradeManager.Instance.UpdateCoins();
    }


    private bool CanBuyUpgrade()
    {
        yc = DataManager.Instance.yellowCoins;
        rc = DataManager.Instance.redCoins;
        bc = DataManager.Instance.blueCoins;
        gc = DataManager.Instance.greenCoins;
        if (yc>=ycr && rc>=rcr && bc>=bcr && gc>=gcr)
        {
            return true;
        }
        return false;
    }
    private void UpdateCashInDataManagerOnClick()
    {
        yc -= ycr;
        rc -= rcr;
        bc -= bcr;
        gc -= gcr;
        DataManager.Instance.UpdateCoins(yc, rc, bc, gc);
        UpgradeManager.Instance.UpdateCoins();
    }
    public void IncreaseSpawnRate()
    {
        SFX.Instance.PlayClickSound();
        UpdateCashInDataManagerOnClick();
        float spawnRate = DataManager.Instance.coinSpawnrate;
        spawnRate -= 0.1f;
        if(spawnRate<=maxSpawnRate)
        {
            spawnRate = maxSpawnRate;
            upgradeButton.enabled = false;
            UpgradeManager.Instance.Upgrade1();
        }
        DataManager.Instance.CoinSpawnRate(spawnRate);

    }

    public void IncreaseDecayTime()
    {
        SFX.Instance.PlayClickSound();
        UpdateCashInDataManagerOnClick();
        float decayTime = DataManager.Instance.coinDecayTime;
        decayTime += 0.1f;
        if(decayTime>=maxDecayTime)
        {
            decayTime = maxDecayTime;
            upgradeButton.enabled=false;
            UpgradeManager.Instance.Upgrade2();
        }
        DataManager.Instance.CoinDecayTime(decayTime);
    }

    public void IncreaseLungCapacity()
    {
        SFX.Instance.PlayClickSound();
        UpdateCashInDataManagerOnClick();
        float lungCapacity = DataManager.Instance.oxygenDepletionRate;
        lungCapacity -= 0.1f;
        if(lungCapacity<=maxLungCapacity)
        {
            lungCapacity = maxLungCapacity;
            upgradeButton.enabled = false;
            UpgradeManager.Instance.Upgrade3();
        }
        DataManager.Instance.OxygenDepletionRate(lungCapacity);
    }

    public void IncreaseCoilRadius()
    {
        SFX.Instance.PlayClickSound();
        UpdateCashInDataManagerOnClick();
        float coilRadius = DataManager.Instance.coilRadius;
        coilRadius += 0.03f;
        if(coilRadius>=maxRadius)
        {
            coilRadius = maxRadius;
            upgradeButton.enabled = false;
            UpgradeManager.Instance.Upgrade4();
        }
        DataManager.Instance.CoilRadius(coilRadius);
    }

    private void Update()
    {
        if(!CanBuyUpgrade())
        {
            upgradeButton.enabled = false;
        }
    }

}
