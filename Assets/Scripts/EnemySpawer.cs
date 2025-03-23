using UnityEngine;

public class EnemySpawer : MonoBehaviour
{
    public GameObject charPrefab;

    public Transform charSpawnLoc;

    public int minCount;
    public int maxCount;
    public float timeToMax = 300;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float t = Mathf.Clamp01(Time.time / timeToMax);
        int curCount = Mathf.RoundToInt(Mathf.Lerp(minCount, maxCount, t));
        PosSpawnPlayers(curCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PosSpawnPlayers(int count)
    {
        if (count <= 0) return;

        for (int i = 0; i < count; i++)
        {
            float angle = i * (360f / count);
            float radians = angle * Mathf.Deg2Rad;
            Vector3 spawnPos = charSpawnLoc.position + new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians)) * 4;

            Vector3 offset = new Vector3(0, 1, 0);
            GameObject newObject = Instantiate(charPrefab, spawnPos, charSpawnLoc.rotation);
            
            newObject.transform.SetParent(charSpawnLoc);
        }
    }
}
