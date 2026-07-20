using UnityEngine;

public class Coin : MonoBehaviour
{
    private float decayTime;
    private void Start()
    {
        decayTime = DataManager.Instance.coinDecayTime;
        Destroy(gameObject, decayTime);
    }
}
