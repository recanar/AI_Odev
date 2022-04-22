using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
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


    // Update is called once per frame
    void Update()
    {
        if (isPlayerCatched)
        {
            for (int i = 0; i < bridge.childCount; i++)
            {
                bridge.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
