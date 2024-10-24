using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupScreen : MonoBehaviour
{
    private GameObject activePopup;

    [SerializeField] private Button closeButton;

    public void Init()
    {
        gameObject.SetActive(false);

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePopup);
        }
    }

    public void ShowPopup(GameObject popupPrefab)
    {
        if (activePopup != null)
        {
            return; 
        }

        activePopup = Instantiate(popupPrefab, transform);

        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }

    public void ClosePopup()
    {
        if (activePopup != null)
        {
            Destroy(activePopup);        
            activePopup = null;
            PopupsManager.Instance.PopupClosed();
        }

        if (activePopup == null)
        {
            gameObject.SetActive(false);
        }
    }
}
