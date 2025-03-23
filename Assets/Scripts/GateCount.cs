using UnityEngine;
using TMPro;

public class GateCount : MonoBehaviour
{
    public int randMin;
    public int randMax;
    public int finalCount = 0;
    TextMeshProUGUI tmp;
    int randCount;
    private float timeToMax = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Awake()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        float t = Mathf.Clamp01(Time.time / timeToMax);
        randMin = Mathf.RoundToInt(Mathf.Lerp(0, -10, t));
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
