using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float baseSpeed;
    public float maxSpeed;
    public float timeToMaxSpeed = 300;
    private Transform target;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        float t = Mathf.Clamp01(Time.time / timeToMaxSpeed);
        float curSpeed = Mathf.Lerp(baseSpeed, maxSpeed, t);

        transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);

    }
}
