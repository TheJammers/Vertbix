using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    private NavMeshAgent agent;

    private bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Move", 1);
        agent = GetComponent<NavMeshAgent>();
    }

    void Move()
    {
        Debug.Log("Start");
        agent.destination = agent.transform.position + Vector3.forward * 100;
        NavMeshPath a = new NavMeshPath();
        agent.CalculatePath(agent.transform.position + Vector3.forward * 100, a);
        Debug.Log(string.Join(",", a.corners));
        moving = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            
        }
    }
}
