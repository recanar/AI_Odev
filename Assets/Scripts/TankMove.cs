using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMove : Enemy//,IDevriyeGezebilir,IKuleyeGidebilir,ITakipEdebilir
{
    OffMeshLink offMeshLinkTank;
    [SerializeField]
    private Transform tower;
    [SerializeField]
    private Transform toplanmaNoktasi;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        offMeshLinkTank = GetComponent<OffMeshLink>();
    }
    private void Update()
    {
        if (GameManager.Instance.currentState == AgentState.Devriye)
            Devriye();
        else if (GameManager.Instance.currentState == AgentState.Takip)
            Takip();
        else if (GameManager.Instance.currentState == AgentState.KuleyeGit)
            KuleyeGit();
    }
    public void Takip()
    {
        agent.SetDestination(toplanmaNoktasi.position);
    }
    public void KuleyeGit()
    {
        offMeshLinkTank.activated = true;
        agent.SetDestination(tower.position);
    }
}
