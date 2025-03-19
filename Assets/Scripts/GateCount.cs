using UnityEngine;
using TMPro;

public class GateCount : MonoBehaviour
{
    public int randMin;
    public int randMax;
    public int finalCount = 0;
    TextMeshProUGUI tmp;
    int randCount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Awake()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        randCount = Random.Range(randMin, randMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (randCount != finalCount)
        {   finalCount = randCount;
            string textCount = finalCount.ToString();
            tmp.text = textCount;
        }
    }
}
