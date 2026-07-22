using UnityEngine;

public class UpgradeLoader : MonoBehaviour
{
    private void Start()
    {
        UpgradeManager.Instance.CheckForUpgrades();
    }
}
