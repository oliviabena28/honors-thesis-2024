using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class toggle : MonoBehaviour
{
    public int onScreen = 0;//pop up on screen = 1, off screen = 0
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left-click.");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
               // if (hit.collider.gameObject == gameObject)
                //{
                    Debug.Log("TAP");
                    if (onScreen == 0)
                    {
                        onScreen = 1;
                        Debug.Log(onScreen);
                    }
                    else
                    {
                        onScreen = 0;
                        Debug.Log(onScreen);
                    }
                //}
            
                
            //}
            
        }
    }
}
