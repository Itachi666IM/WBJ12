using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Transform spawnPos;
    private float nextTimeToSpawn;

    private void Update()
    {
        if(Time.time>=nextTimeToSpawn)
        {
            Instantiate(backgroundPrefab,spawnPos.position, Quaternion.identity);
            nextTimeToSpawn = Time.time + timeBetweenSpawns;
        }    
    }
}
