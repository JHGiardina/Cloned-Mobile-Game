using UnityEngine;
using TMPro;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject charPrefab;
    public Transform charSpawnLoc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        //Debug.Log("Collission!");


        TextMeshProUGUI[] tmpArray = other.GetComponentsInChildren<TextMeshProUGUI>(true);
        Debug.Log(tmpArray);
        TextMeshProUGUI tmp = tmpArray[0];
        string tmpText = tmp.text.Trim();
        if (tmpText.StartsWith("+"))
        {
            tmpText = tmpText.Substring(1);
        }


        int newPlayers;
        if(int.TryParse(tmpText, out newPlayers))
        {
            if (newPlayers > 0 )
            {
                PosSpawnPlayers(newPlayers);
                //Debug.Log(newPlayers);
            }else
            {
                NegSpawnPlayers(newPlayers);
            }
        }


    }

    private void PosSpawnPlayers(int count)
    {
        if (count <= 0) return;

        for (int i = 0; i < 0; i++)
        {
            float angle = i * (360f / count);
            float radians = angle * Mathf.Deg2Rad;
            Vector3 spawnPos = charSpawnLoc.position + new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians)) * 8;

            Vector3 offset = new Vector3(0, 1, 0);
            GameObject newObject = Instantiate(charPrefab, spawnPos, charSpawnLoc.rotation);
            
            newObject.transform.SetParent(charSpawnLoc);
        }
    }
    private void NegSpawnPlayers(int count)
    {

        int destroyed = 0;
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            if (destroyed <= count) break;
            Destroy(transform.GetChild(i).gameObject);
            destroyed--;
        }
    }
}
