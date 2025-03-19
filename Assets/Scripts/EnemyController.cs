using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float baseSpeed;
    public float maxSpeed;
    public float timeToMaxSpeed = 300;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.Clamp01(Time.time / timeToMaxSpeed);
        float curSpeed = Mathf.Lerp(baseSpeed, maxSpeed, t);

        transform.Translate(Vector3.back * curSpeed * Time.deltaTime);
    }
}
