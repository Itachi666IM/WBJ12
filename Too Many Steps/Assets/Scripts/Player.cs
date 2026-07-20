using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator myAnim;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.Instance.OnOxygenLow += GameManager_OnOxygenLow;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnOxygenLow -= GameManager_OnOxygenLow;
    }
    private void GameManager_OnOxygenLow(object sender, System.EventArgs e)
    {
        myAnim.SetTrigger("stopped");
    }
}
