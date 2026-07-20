using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject staticBackground;
    private float nextTimeToSpawn;
    private bool hasStopped = false;

    private void Start()
    {
        GameManager.Instance.OnOxygenLow += GameManager_OnOxygenLow;
    }

    private void GameManager_OnOxygenLow(object sender, System.EventArgs e)
    {
        hasStopped = true;
    }

    private void Update()
    {
        if(!hasStopped)
        {
            if(Time.time>=nextTimeToSpawn)
            {
                Instantiate(backgroundPrefab,spawnPos.position, Quaternion.identity);
                nextTimeToSpawn = Time.time + timeBetweenSpawns;
            }    
        }
        else
        {
            staticBackground.SetActive(true);
            Background[] remainingBackgrounds = FindObjectsByType<Background>(FindObjectsSortMode.None);
            foreach(Background background in remainingBackgrounds)
            {
                Destroy(background.gameObject);
            }
        }
    }
}
