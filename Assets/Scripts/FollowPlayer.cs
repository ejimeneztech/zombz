using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private UnityEngine.AI.NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(player == null)
        {
            Debug.Log("Missing Player Reference");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }

    }
}
