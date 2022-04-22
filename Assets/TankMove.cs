using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMove : MonoBehaviour
{
    OffMeshLink offMeshLinkTank;
    NavMeshAgent agent;
    public Transform tower;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        offMeshLinkTank = GetComponent<OffMeshLink>();
    }
    private void Update()
    {
        if (GameManager.Instance.isPlayerCatched==true)
        {
            offMeshLinkTank.activated = true;
            agent.SetDestination(tower.position);
        }
    }
}
