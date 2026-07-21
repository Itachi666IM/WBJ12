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
    private float maxSpawnRate = 0.1f;

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
    }

    private bool CanBuyUpgrade()
    {
        if(yc>=ycr && rc>=rcr && bc>=bcr && gc>=gcr)
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
        UpdateCashInDataManagerOnClick();
        float spawnRate = DataManager.Instance.coinSpawnrate;
        spawnRate -= 0.1f;
        if(spawnRate<=maxSpawnRate)
        {
            spawnRate = maxSpawnRate;
            upgradeButton.enabled = false;
        }
        DataManager.Instance.CoinSpawnRate(spawnRate);

    }

    private void Update()
    {
        if(!CanBuyUpgrade())
        {
            upgradeButton.enabled = false;
        }
    }

}
