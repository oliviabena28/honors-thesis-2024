using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class contact_button_toggle : MonoBehaviour
{
    public TMP_Text[] textObjects;
    private int currentIndex = 0;
    public Button backButton;
    public Button nextButton;

    void Start()
    {
        
        Button button = GetComponent<Button>();

        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(OnNextButtonClicked);
        }

        ShowCurrentText();
    }

    void ShowCurrentText()
    {
        
        foreach (TMP_Text textObject in textObjects)
        {
            textObject.gameObject.SetActive(false);
        }

        
        textObjects[currentIndex].gameObject.SetActive(true);
    }

    public void OnNextButtonClicked()
    {
        currentIndex = (currentIndex + 1) % textObjects.Length;
        ShowCurrentText();
    }

    public void OnBackButtonClicked()
    {
        currentIndex = (currentIndex - 1 + textObjects.Length) % textObjects.Length;
        ShowCurrentText();
    }
}