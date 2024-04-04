using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class computer_screen_scene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("this is a key press");
            SceneManager.LoadScene("2");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

}
