using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AgentState
{
    Devriye,
    Takip,
    Saldiri,
    KuleyeGit
}
//public interface IDevriyeGezebilir
//{
//    void Devriye();
//}
//public interface ITakipEdebilir
//{
//    void Takip();
//}
//public interface ISaldirabilir
//{
//    void Saldir();
//}
//public interface IKuleyeGidebilir
//{
//    void KuleyeGit();
//}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AgentState currentState;
    public bool isPlayerCatched;
    public Transform bridge;

    void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }
    private void Start()
    {
        currentState = AgentState.Devriye;//baþlangýç state
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerCatched)
        {
            for (int i = 0; i < bridge.childCount; i++)
            {
                bridge.GetChild(i).gameObject.SetActive(true);//var olan bütün köprüleri göster
            }
            currentState = AgentState.KuleyeGit;//tanklar kuleye gitmesi için statei kuleye git yap
        }
    }
}
