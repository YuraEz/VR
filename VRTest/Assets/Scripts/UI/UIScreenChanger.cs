using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIScreenChanger : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            UIManager.Instance.AddObjectToScreen(objectPrefab);
        });
    }
}
