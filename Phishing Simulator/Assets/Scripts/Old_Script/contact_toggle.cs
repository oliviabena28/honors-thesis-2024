using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class contact_toggle : MonoBehaviour
{
    Camera cam;
    toggle Toggle;
    Vector2 origin = Vector2.zero;
    Vector2 dir = Vector2.zero;
    
    // Start is called before the first frame update
    void Awake()
    {
       GameObject contactsObject = GameObject.Find("contacts_popup");

        if (contactsObject != null)
        {
            Toggle = contactsObject.GetComponent<toggle>();

            if (Toggle == null)
            {
                Debug.LogError("toggle component not found on 'contacts_popup' GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameObject with name 'contacts_popup' not found.");
        }
       

    }

    void Start()
    {
        cam = Camera.main;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Toggle.onScreen + "YO");

        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }



    }

    void HandleClick()
    {
        Debug.Log("HANDLE INITIATED");

        // Cast a ray from the screen point to the world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        origin = ray.origin;
        dir = ray.direction;

        // Perform a raycast and get the hit information
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            Debug.Log("YOU DID IT");
            if (hit.collider.CompareTag("Contacts"))
            {
                Debug.Log("CONTACT INITIATED");
                if (Toggle.onScreen == 1)
                {
                    Debug.Log(Toggle.onScreen + " - HIDE!");
                    gameObject.transform.localScale = new Vector3(0, 0, 0);
                    //contactsObject.onScreen = 0; // Assuming you want to update the Toggle.onScreen value
                }
                else if (Toggle.onScreen == 0)
                {
                    Debug.Log(Toggle.onScreen + " - SHOW!");
                    gameObject.transform.localScale = new Vector3(1, 1, 1);
                    //contactsObject.onScreen = 1; // Assuming you want to update the Toggle.onScreen value
                }
            }

        }


        /*if (hit.collider != null)
        {
            Debug.Log("YOU DID IT");
            if (hit.collider.CompareTag("Contacts"))
            {
                Debug.Log("CONTACT INITIATED");
                if (Toggle.onScreen == 1)
                {
                    Debug.Log(Toggle.onScreen + "me!");
                    contactsObject.transform.localScale = new Vector3(1, 1, 1);
                }
                if (Toggle.onScreen == 0)
                {
                    Debug.Log(Toggle.onScreen + "me!");
                    contactsObject.transform.localScale = new Vector3(0, 0, 0);
                }
            }*/
        
        
    
    }
}


