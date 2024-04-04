using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit : MonoBehaviour
{

    public GameObject objectToHide;

    // Start is called before the first frame update
    void Start()
    {
        Button exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    void OnExitButtonClicked()
    {
        if (objectToHide != null)
        {
            objectToHide.SetActive(false);
        }

    }
}
