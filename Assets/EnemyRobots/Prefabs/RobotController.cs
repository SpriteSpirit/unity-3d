using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    private Transform player;
    private float range = 8;
    public List<Transform> points;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(points[Random.Range(0, points.Count)].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        GameObject allPoints = GameObject.FindGameObjectWithTag("Points");

        foreach (Transform point in allPoints.transform)
        {
            points.Add(point);
        }

        Transform newPoint = points[Random.Range(0, points.Count)];
        agent.SetDestination(newPoint.position);
        agent.transform.LookAt(newPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Transform newPoint = points[Random.Range(0, points.Count)];
            agent.SetDestination(newPoint.position);
            agent.transform.LookAt(newPoint);
        } 


        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= range)
        {
            agent.SetDestination(player.position);
            agent.transform.LookAt(player);
        }
    }
}
