using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThreadDispatcher : MonoBehaviour
{
    private static MainThreadDispatcher _instance;

    private readonly Queue<IEnumerator> _actions = new Queue<IEnumerator>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void RunOnMainThread(IEnumerator action)
    {
        if (_instance == null)
        {
            Debug.LogError("No instance of MainThreadDispatcher in the scene.");
            return;
        }

        lock (_instance._actions)
        {
            _instance._actions.Enqueue(action);
        }
    }

    private void Update()
    {
        while (_actions.Count > 0)
        {
            IEnumerator action;

            lock (_actions)
            {
                action = _actions.Dequeue();
            }

            StartCoroutine(action);
        }
    }
}
