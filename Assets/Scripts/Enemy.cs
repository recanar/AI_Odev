using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    protected NavMeshAgent agent;
    [SerializeField]
    protected Transform[] targets; // devriye noktalarý
    protected int targetIndex;

    public void Devriye()//devriye olayý bütün düþmanlarda aynýdýr (belirli noktalar arasýnda)
    {
        if (agent.remainingDistance < 1f)  // vardý
        {
            targetIndex++; // yeni hedef indeksi
            targetIndex = targetIndex % targets.Length;  // round robin
            agent.SetDestination(targets[targetIndex].position);
        }
    }
}
