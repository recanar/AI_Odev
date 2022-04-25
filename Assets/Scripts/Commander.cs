using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Commander : Enemy,IDevriyeGezebilir,ISaldirabilir,ITakipEdebilir
{
    private float timeCount;

    private Transform player;

    void Start()
    {
        timeCount = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Toplan
        //if (currentState == AgentState.Toplan)
        //{
        //    agent.SetDestination(toplanmaNoktasi.position);

        //    // bu iþ bittikten sonra
        //    currentState = AgentState.Devriye;
        //}
        if (GameManager.Instance.currentState == AgentState.Devriye)
            Devriye();
        else if (GameManager.Instance.currentState == AgentState.Takip)
            Takip();
        else if (GameManager.Instance.currentState == AgentState.Saldiri)
            Saldir();

    }
    public void Takip()
    {
        agent.SetDestination(player.position);
        if (Vector3.Distance(transform.position, player.position) < 5f)
        {
            GameManager.Instance.currentState = AgentState.Saldiri;
        }
        if (Vector3.Distance(transform.position, player.position) > 12f)
        {
            GameManager.Instance.currentState = AgentState.Devriye;
        }
    }
    public void Saldir()
    {
        timeCount += 1 * Time.deltaTime;
        Debug.Log("Saldýrýyorum...");
        if (Vector3.Distance(transform.position, player.position) > 3f)
        {
            GameManager.Instance.currentState = AgentState.Takip;
            timeCount = 0;
        }
        agent.SetDestination(player.position);

        if (timeCount >= 2f)
        {
            GameManager.Instance.isPlayerCatched = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Gördüm...");
            GameManager.Instance.currentState = AgentState.Takip;
        }
    }
}
