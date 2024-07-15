using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastController : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 5.0f;

    [SerializeField]
    //The layer that will determine what the raycast will hit
    LayerMask layerMask, door, desk;
    //The UI text component that will display the name of the interactable hit
    public TextMeshProUGUI interactionInfo;

     private bool isDoorOpen = false;

     private bool isDeskOpen = false;

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance, layerMask))
        {
            // do something that hits
            interactionInfo.text = hit.transform.GetComponent<Item>().id;

            //destroy when get
            if(Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.GetComponent<Item>().Interact();
                Debug.Log("Destroyed");
            }
        }
        else
        {
             interactionInfo.text = "";

        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance, door))
        {
            interactionInfo.text = hit.transform.GetComponent<Item>().id;
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.GetComponent<Item>().id == "Door")
            {
                Animator doorAnimator = hit.transform.GetComponent<Animator>();
                if (doorAnimator!= null)
                {
                    if (!isDoorOpen)
                    {
                        doorAnimator.SetBool("character_nearby", true);
                        Debug.Log("Door interaction - Open");
                        isDoorOpen = true;
                    }
                    else
                    {
                        doorAnimator.SetBool("character_nearby", false);
                        Debug.Log("Door interaction - Close");
                        isDoorOpen = false;
                    }
                }
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance, desk))
        {
            interactionInfo.text = hit.transform.GetComponent<Item>().id;
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.GetComponent<Item>().id == "Desk")
            {
                Animator deskAnimator = hit.transform.GetComponent<Animator>();
                if (deskAnimator!= null)
                {
                    if (!isDeskOpen)
                    {
                        deskAnimator.SetBool("isInteractedWith", true);
                        Debug.Log("Desk interaction - Open");
                        isDeskOpen = true;
                    }
                    else
                    {
                        deskAnimator.SetBool("isInteractedWith", false);
                        Debug.Log("Desk interaction - Close");
                        isDeskOpen = false;
                    }
                }
            }
        }
        //TODO: Raycast
        //1. Perform a raycast originating from the gameobject's position towards its forward direction.
        //   Make sure that the raycast will only hit the layer specified in the layermask
        //2. Check if the object hits any Interactable. If it does, show the interactionInfo and set its text
        //   to the id of the Interactable hit. If it doesn't hit any Interactable, simply disable the text
        //3. Make sure to interact with the Interactable only when the mouse button is pressed.
        
    }
}