using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreen : MonoBehaviour
{
    private GameObject activeObject;

    [SerializeField] private Button closeButton;

    public void Init()
    {
        gameObject.SetActive(false);

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseScreen);
        }
    }

    public GameObject GetActiveObject()
    {
        return activeObject;
    }

    public void ShowObjectOnScreen(GameObject objectPrefab)
    {
        if (activeObject != null)
        {
            return; 
        }

        activeObject = Instantiate(objectPrefab, transform);

        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }

    public void RemoveObjectFromScreen(GameObject objectToRemove)
    {
        if (activeObject == objectToRemove)
        {
            Destroy(activeObject);
            activeObject = null;
            UIManager.Instance.FreeSlotOnScreen(); 

            if (activeObject == null)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void CloseScreen()
    {
        if (activeObject != null)
        {
            RemoveObjectFromScreen(activeObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
