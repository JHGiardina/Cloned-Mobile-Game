using UnityEngine;

public class GateSpawner : MonoBehaviour
{
    public GameObject gatePrefab;
    public Transform leftGateSpawn;
    public Transform rightGateSpawn;

    public float spawnInterval;
    public float timer = 0f;

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
            SpawnGates();
            timer = 0f;
            //Debug.Log("Gate Spawned");
            spawnInterval = Random.Range(randMin, randMax);
        }
        
    }

    private void SpawnGates()
    {
        Instantiate(gatePrefab, leftGateSpawn.position, leftGateSpawn.rotation);
        Instantiate(gatePrefab, rightGateSpawn.position, rightGateSpawn.rotation);
    }
}
