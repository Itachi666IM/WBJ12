using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpecialUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text yellowCoinsRequired;
    [SerializeField] private TMP_Text redCoinsRequired;
    [SerializeField] private TMP_Text blueCoinsRequired;
    [SerializeField] private TMP_Text greenCoinsRequired;
    [SerializeField] private int ycr;
    [SerializeField] private int rcr;
    [SerializeField] private int bcr;
    [SerializeField] private int gcr;
    [SerializeField] private GameObject finalUpgrade;
    private Button upgradeButton;

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
        if(DataManager.Instance.coinMultiplier!=1)
        {
            upgradeButton.enabled = false;
            finalUpgrade.SetActive(true);
        }
    }

    private bool CanBuyUpgrade()
    {
        yc = DataManager.Instance.yellowCoins;
        rc = DataManager.Instance.redCoins;
        bc = DataManager.Instance.blueCoins;
        gc = DataManager.Instance.greenCoins;
        if (yc >= ycr && rc >= rcr && bc >= bcr && gc >= gcr)
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
        if (!CanBuyUpgrade())
        {
            upgradeButton.enabled = false;
        }
    }

    private void Update()
    {
        if(!CanBuyUpgrade())
        {
            upgradeButton.enabled = false;
        }
    }

    public void SpecialUpgradeFunction()
    {
        SFX.Instance.PlayClickSound();
        UpdateCashInDataManagerOnClick();
        DataManager.Instance.CoinMultiplier();
        finalUpgrade.SetActive(true);
        upgradeButton.enabled = false;
    }
}
