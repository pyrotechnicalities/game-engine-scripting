using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public UnityEvent GameOverEvent;
    // if making a static UnityEvent you have to initialize it like so: private UnityEvent event = new UnityEvent
    // making an event broadcast data: UnityEvent<(data type)>
    private void Awake()
    {
        instance = this;
    }

    [ContextMenu("Test GameOverEvent")]
    void GameOver()
    {
        GameOverEvent.Invoke();
    }

    public static void AddGameOverEventListener(UnityAction action)
    {
        instance.GameOverEvent.AddListener(action);
    }
}
