using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class email_order : MonoBehaviour
{
    public TMP_Text[] emailText;
    public TMP_Text ScamSignText;
    public TMP_Text LegitSignText;
    private int currentIndex = 0;
    public Button replyButton;
    public Button trashButton;
    public TMP_Text Answer_Text;
    public Image backdrop;
    public Button X;
    public GameObject ANSWER;
    private string answer;


    void Start()
    {

        Button button = GetComponent<Button>();

        if(replyButton != null)
        {
            replyButton.onClick.AddListener(OnReplyButtonClicked); //onreply vs replybuttonclicked
        }

        if (trashButton != null)
        {
            trashButton.onClick.AddListener(OnTrashButtonClicked);
        }

        ShowCurrentEmailText();

        Answer_Text.gameObject.SetActive(false);
        backdrop.gameObject.SetActive(false);
        X.gameObject.SetActive(false);
        ANSWER.gameObject.SetActive(false);




    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(5);
    }



        void OnReplyButtonClicked()
    {

        string tag = emailText[currentIndex].tag; //checks string

        if (tag == "Legit")
        {
            ReplyButtonClicked(); //filter system
        }
        else
        {
            IncorrectActionClicked();
        }
    }

    void ReplyButtonClicked()
    {
        Debug.Log("Reply button clicked!"); //player gets a reward of some sort??
        answer = "Correct!";
        Answer_Text.SetText(answer.ToString());
        MoveToNextText();

        Answer_Text.gameObject.SetActive(true);
        backdrop.gameObject.SetActive(true);
        backdrop.GetComponent<Image>().color = new Color32(232, 244, 234, 250);
        X.gameObject.SetActive(true);
        ANSWER.gameObject.SetActive(true);
    }

    void OnTrashButtonClicked()
    {
        string tag = emailText[currentIndex].tag; //filter system

        if (tag == "Scam")
        {
            TrashButtonClicked();
        }
        else
        {
            IncorrectActionClicked();
        }
    }

    void TrashButtonClicked()
    {
        Debug.Log("Trash button clicked!"); //player gets rewarded!!
        answer = "Correct!";
        Answer_Text.SetText(answer.ToString());
        MoveToNextText();

        Answer_Text.gameObject.SetActive(true);
        backdrop.gameObject.SetActive(true);
        backdrop.GetComponent<Image>().color = new Color32(232, 244, 234, 250);
        X.gameObject.SetActive(true);
        ANSWER.gameObject.SetActive(true);
    }

    void IncorrectActionClicked()
    {

        Debug.Log("Incorrect action clicked!"); //initiate bugs if scam
        

        if (tag == "Scam")
        {
            answer = "Incorrect!";
            Answer_Text.SetText(answer.ToString());
            //ReleaseTheBug();
        }
        else
        {
            answer = "Incorrect!";
            Answer_Text.SetText(answer.ToString());
        }


        MoveToNextText();

        Answer_Text.gameObject.SetActive(true);
        backdrop.gameObject.SetActive(true);
        backdrop.GetComponent<Image>().color = new Color32(255, 222, 222, 250);
        X.gameObject.SetActive(true);
        ANSWER.gameObject.SetActive(true);
    }

    void MoveToNextText()
    {
        //cycles through text options
        emailText[currentIndex].gameObject.SetActive(false); 


        currentIndex = (currentIndex + 1) % emailText.Length;


        ShowCurrentEmailText();
    }


    void ShowCurrentEmailText()
    {
        //shows current when toggled
        emailText[currentIndex].gameObject.SetActive(true);
    }

    void ToggleSignVisibility()
    {
        string emailTextName = emailText[currentIndex].name;

        if (emailTextName.Contains("Scam"))
        {
            ScamSignText.gameObject.SetActive(true);
        }
        if (emailTextName.Contains("Legit"))
        {
            LegitSignText.gameObject.SetActive(true);
        }
    }

    /*void ReleaseTheBug()
    {
        string emailTextName = emailText[currentIndex].name; 
        
        if (emailText.name == "EMAIL TEXT - SCAM 1")
        {
            Debug.Log("Credit Card Scam");
        }
        if (emailText.name == "EMAIL TEXT - SCAM 2")
        {
            Debug.Log("Invoice Scam");
        }
        if (emailText.name == "EMAIL TEXT - SCAM 3")
        {

            Debug.Log("Package Scam");
        }
        if (emailText.name == "EMAIL TEXT - SCAM 4")
        {

            Debug.Log("Confidential Leak");
        }
        if (emailText.name == "EMAIL TEXT - SCAM 5")
        {

            Debug.Log("Password Leak");
        }
    } */
}

