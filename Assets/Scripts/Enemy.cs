using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    protected NavMeshAgent agent;
    [SerializeField]
    protected Transform[] targets; // devriye noktalar�
    protected int targetIndex;

    public void Devriye()//devriye olay� b�t�n d��manlarda ayn�d�r (belirli noktalar aras�nda)
    {
        if (agent.remainingDistance < 1f)  // vard�
        {
            targetIndex++; // yeni hedef indeksi
            targetIndex = targetIndex % targets.Length;  // round robin
            agent.SetDestination(targets[targetIndex].position);
        }
    }
}
