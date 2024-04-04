using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Toggle : MonoBehaviour
{
    public GameObject objectToToggle;

    void Start()
    {
        // Attach the button click event to the ToggleObjectVisibility method
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ToggleObjectVisibility);
    }

    void ToggleObjectVisibility()
    {
        // Toggle the visibility of the specified GameObject
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
        else
        {
            Debug.LogError("Please assign a GameObject to the 'objectToToggle' variable in the inspector.");
        }
    }
}
