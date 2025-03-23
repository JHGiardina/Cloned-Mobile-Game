using UnityEngine;

public class Central_Enemy_Spawn : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnLoc;

    private float spawnInterval;
    private float timer;
    [Header("Spawn Interval Settings")]
    public float randMin;
    public float randMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
            //Debug.Log("Gate Spawned");
            spawnInterval = Random.Range(randMin, randMax);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(prefab, spawnLoc.position, Quaternion.Euler(0, 180, 0));

    }
}
