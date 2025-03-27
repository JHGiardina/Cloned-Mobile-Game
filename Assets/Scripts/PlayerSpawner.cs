using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject charPrefab;
    public Transform charSpawnLoc;

    public TextMeshProUGUI currentCountTMP;
    public int curPlayerCount;
    int newPlayers;
    private GateCount count;
    private float radRandMin = .5f;
    private float radRandMax = 4f;
    private float timeToMaxRad = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curPlayerCount = charSpawnLoc.childCount - 1;
        currentCountTMP.text = curPlayerCount.ToString();
        if (charSpawnLoc.childCount <= 1)
        {
            SceneManager.LoadScene("Respawn");
        }
    }

    private void OnTriggerEnter(Collider other) 
    {


        //int newPlayers;
        GateCount count = other.GetComponent<GateCount>();

        if (count != null)
        {
            //Debug.Log("oth " + other);
            newPlayers = count.finalCount;
            //Debug.Log("New player: " + newPlayers);
            //Debug.Log("Collission! w/ " + count.finalCount);



            if (newPlayers > 0 )
            {
                PosSpawnPlayers(newPlayers);
                //Debug.Log(newPlayers);
            }else
            {
                NegSpawnPlayers(newPlayers);
            }

        } else
        {
            return;
        }


    }
 
    private void PosSpawnPlayers(int count)
    {
        if (count <= 0) return;

        float t = Mathf.Clamp01(Time.time / timeToMaxRad);
        float curRad = Mathf.Lerp(radRandMin, radRandMax, t);

        for (int i = 0; i < count; i++)
        {
            float angle = i * (360f / count);
            float radians = angle * Mathf.Deg2Rad;
            Vector3 spawnPos = charSpawnLoc.position + new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians)) * curRad;

            Vector3 offset = new Vector3(0, 1, 0);
            GameObject newObject = Instantiate(charPrefab, spawnPos, charSpawnLoc.rotation);
            
            newObject.transform.SetParent(charSpawnLoc);
        }
    }
    private void NegSpawnPlayers(int count)
    {
        
        int toDestroy = Mathf.Abs(count);
        int destroyed = 0;
        // Assuming you want to remove from the same parent as PosSpawnPlayers
        for (int i = charSpawnLoc.childCount - 1; i >= 0 && destroyed < toDestroy; i--)
        {
            Destroy(charSpawnLoc.GetChild(i).gameObject);
            destroyed++;
        }


        // int destroyed = 0;
        // for (int i = transform.childCount - 1; i >= 0; i--)
        // {
        //     if (destroyed <= count) break;
        //     Destroy(transform.GetChild(i).gameObject);
        //     destroyed--;
        // }
    }
}
