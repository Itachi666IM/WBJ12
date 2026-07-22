using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUpgrade : MonoBehaviour
{
    private Button myButton;

    private void Awake()
    {
        
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            SceneManager.LoadScene("Win");
        });
    }

    private void Start()
    {
        UpgradeManager.Instance.ResetAllUpgrades();
    }
}
