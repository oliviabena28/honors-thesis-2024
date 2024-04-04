using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeMaterial : MonoBehaviour
{
    public Texture2D[] image;
    private int counter = 0;

    public Button legit;
    public Button scam;

    private int points;
    public string[] imageTags;
    private int[] randomIndexes;
    private int imgnum = 0;

    public Button legitButton;
    public Button scamButton;
    public TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeIndexes();
        getMaterial();
        legit.onClick.AddListener(OnButtonLegitClick);
        scam.onClick.AddListener(OnButtonScamClick);


        Button btn = legitButton.GetComponent<Button>();
        Button btn2 = scamButton.GetComponent<Button>();
        btn.onClick.AddListener(mouseClick);
        btn2.onClick.AddListener(mouseClick2);
        points = 0;
        SetPointText();


    }

    void Update()
    {

    }

    void OnButtonLegitClick()
    {
        counter++;
        getMaterial();
    }

    void OnButtonScamClick()
    {
        counter++;
        getMaterial();
    }



    void RandomizeIndexes()
    {
        randomIndexes = new int[imageTags.Length];

        for (int i = 0; i < imageTags.Length; i++)
        {
            randomIndexes[i] = i;
        }

        for (int i = 0; i < imageTags.Length - 1; i++)
        {
            int randomIndex = Random.Range(i, imageTags.Length);
            int temp = randomIndexes[i];
            randomIndexes[i] = randomIndexes[randomIndex];
            randomIndexes[randomIndex] = temp;
        }
    }

    void getMaterial()
    {
        Material material = new Material(Shader.Find("Universal Render Pipeline/Lit"));

        if (counter >= 0 && counter < randomIndexes.Length)
        {
            int imageIndex = randomIndexes[counter];
            material.mainTexture = image[imageIndex];
        }
        else
        {
            Debug.LogError("Counter is out of range for randomIndexes.");
            return;
        }


        Renderer renderer = GetComponent<Renderer>();
        renderer.material = material;
    }

    void mouseClick()
    {
        Debug.Log("You have clicked the legit button!");
        Debug.Log(imgnum);
        if (imageTags[randomIndexes[imgnum]] == "legit")
        {
            points += 1;
            SetPointText();
        }
        else
        {
            points -= 1;
            SetPointText();
        }
        imgnum++;

        if (imgnum >= randomIndexes.Length)
        {
            imgnum = 0;
        }


    }

    void mouseClick2()
    {
        Debug.Log("You have clicked the scam button!");
        Debug.Log(imgnum);
        if (imageTags[randomIndexes[imgnum]] == "scam")
        {
            points += 1;
            SetPointText();
        }
        else
        {
            points -= 1;
            SetPointText();
        }
        imgnum++;

        if (imgnum >= randomIndexes.Length)
        {
            imgnum = 0;
        }

    }



    void SetPointText()
    {
        pointsText.text = "Score: " + points.ToString();
    }



    //TEST

    public string name;

    public void Function1(string name)
    {
        Debug.Log(Function2(name));
    }

    private string Function2(string name)
    {
        return name;

    }





}
