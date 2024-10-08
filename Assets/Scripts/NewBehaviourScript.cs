using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.isOnNavMesh)
        {
            agent.destination = player.position;
        }
        else
        {
            Debug.LogWarning("NavMeshAgent is not on NavMesh");
        }
    }
}
