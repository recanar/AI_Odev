using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum AgentState
{
    Toplan,
    Devriye,
    Takip,
    Saldiri
}
public class EnemyAIMove : MonoBehaviour
{
    public AgentState currentState; // mevcut durum

    NavMeshAgent agent;
    private Transform player;
    float timeCount;

    [SerializeField]
    private Transform[] targets; // devriye noktalarý
    private int targetIndex;

    public Transform toplanmaNoktasi;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = AgentState.Devriye;

    }

    // Update is called once per frame
    void Update()
    {
        // Devriye
        if (currentState == AgentState.Devriye)
        {
            //Debug.Log("Devriye geziyorum.....");

            if (agent.remainingDistance < 1f)  // vardý
            {
                targetIndex++; // yeni hedef indeksi
                targetIndex = targetIndex % targets.Length;  // round robin
                agent.SetDestination(targets[targetIndex].position);
            }
        }

        // Toplan
        if (currentState == AgentState.Toplan)
        {
            agent.SetDestination(toplanmaNoktasi.position);

            // bu iþ bittikten sonra
            currentState = AgentState.Devriye;
        }
        if (currentState == AgentState.Takip)
        {
            Debug.Log("Takip ediyorum...");

            agent.SetDestination(player.position);
            if (Vector3.Distance(transform.position, player.position) < 5f)
            {
                currentState = AgentState.Saldiri;
            }
        }
        // Attack - Saldýrý
        if (currentState == AgentState.Saldiri)
        {
            timeCount += 1 * Time.deltaTime;
            Debug.Log("Saldýrýyorum...");
            if (Vector3.Distance(transform.position, player.position) > 3f)
            {
                currentState = AgentState.Takip;
                timeCount = 0;
            }
            agent.SetDestination(player.position);
        }
        if (timeCount >= 3f)
        {
            GameManager.Instance.isPlayerCatched = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // 
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Gördüm...");
            currentState = AgentState.Takip;
        }
    }
}
