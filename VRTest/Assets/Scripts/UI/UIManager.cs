using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private UIScreen[] screens;

    private Queue<ScreenObjectData> objectQueue = new Queue<ScreenObjectData>();

    private void Awake()
    {
        Instance = this;

        foreach (UIScreen screen in screens)
        {
            screen.Init();
        }
    }

    public void AddObjectToScreen(GameObject objectPrefab)
    {
        foreach (var screen in screens)
        {
            if (screen.GetActiveObject() == null)
            {
                screen.ShowObjectOnScreen(objectPrefab); 
                return;
            }
        }

        objectQueue.Enqueue(new ScreenObjectData(objectPrefab));
    }

    public void FreeSlotOnScreen()
    {
        if (objectQueue.Count > 0)
        {
            ScreenObjectData nextObject = objectQueue.Dequeue();
            AddObjectToScreen(nextObject.objectPrefab); 
        }
    }
}


public struct ScreenObjectData
{
    public GameObject objectPrefab;

    public ScreenObjectData(GameObject objectPrefab)
    {
        this.objectPrefab = objectPrefab;
    }
}
