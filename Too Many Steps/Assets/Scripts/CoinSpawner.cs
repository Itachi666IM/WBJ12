using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] coins;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    private float coinSpawnRate;
    private bool hasStopped = false;
    private float nextCoinSpawnTime;
    private void Start()
    {
        coinSpawnRate = DataManager.Instance.coinSpawnrate;
        GameManager.Instance.OnOxygenLow += GameManager_OnOxygenLow;
    }

    private void GameManager_OnOxygenLow(object sender, System.EventArgs e)
    {
        hasStopped = true;
    }

    private void Update()
    {
        if (!hasStopped)
        {
            if(Time.time>=nextCoinSpawnTime)
            {
                GameObject randomCoin = coins[Random.Range(0, coins.Length)];
                Vector2 randomPos = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
                Instantiate(randomCoin,randomPos,Quaternion.identity);
                nextCoinSpawnTime = Time.time + coinSpawnRate;
            }
        }
        else
        {
            Coin[] remainingCoins = FindObjectsByType<Coin>(FindObjectsSortMode.None);
            foreach (Coin coin in remainingCoins)
            {
                Destroy(coin.gameObject);
            }
        }
    }
}
