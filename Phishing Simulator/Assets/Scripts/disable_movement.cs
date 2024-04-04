using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable_movement : MonoBehaviour
{
    PlayerController playerController;
    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
        
    }

    void OnMouseDown()
    {
        Debug.Log("ya ha ha! you found me!");
        playerController.enabled = false;
    }
}
