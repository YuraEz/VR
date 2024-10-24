using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Device;

public class PopupsManager : MonoBehaviour
{
    public static PopupsManager Instance { get; private set; }

    [SerializeField] private PopupScreen popupScreen;
    [SerializeField] private GameObject[] popupPrefabs;

    private Queue<GameObject> popupQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;

        popupScreen.Init();

        StartCoroutine(SpawnPopups());
    }

    private IEnumerator SpawnPopups()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, popupPrefabs.Length);
            popupQueue.Enqueue(popupPrefabs[randomIndex]);

            ShowNextPopup();

            yield return new WaitForSeconds(5f); 
        }
    }

    public void ShowNextPopup()
    {
        if (popupQueue.Count > 0)
        {
            if (popupScreen != null)
            {
                GameObject nextPopup = popupQueue.Dequeue();
                popupScreen.ShowPopup(nextPopup);
            }
        }
    }

    public void PopupClosed()
    {
        ShowNextPopup();
    }
}
