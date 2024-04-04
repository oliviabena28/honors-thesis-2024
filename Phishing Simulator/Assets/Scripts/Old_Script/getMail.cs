using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class getMail : MonoBehaviour
{
    public Button mail;

    private changeMaterial change;
 
        
    // Start is called before the first frame update
    void Start()
    {
        //make an array of buttons and stick the script
        //on the canvas object not the button itself
        Button btn = mail.GetComponent<Button>();
        btn.onClick.AddListener(mouseClick);

        //change = FindObjectOfType<changeMaterial>();

        //change.Function1(name);

        
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void mouseClick()
    {
        Debug.Log("You have clicked the mail!");
  

    }
}
