using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //NavMeshAgent agent;
    float speed;

    void Start()
    {
        speed = 5;
        //playerýn týklanýlan yere gitmesini istiyorsak
        //agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        gameObject.transform.Translate(new Vector3(h, 0, v)*Time.deltaTime*speed);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;

        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        //    {
        //        agent.destination = hit.point;
        //    }
        //}
    }
}