using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class playerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    interactable currentInteractable;

    // Update is called once per frame
    void Update()
    {
        checkInteraction();
        if(Input.GetKeyDown(KeyCode.F) && currentInteractable!=null)
        {
            currentInteractable.Interact();
        }
    }
    void checkInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable")
            {
                interactable newInteractable = hit.collider.GetComponent<interactable>();
                //disable outline if switching from one interactable to another
                if(currentInteractable && newInteractable!=currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }
                if (newInteractable.enabled)
                {
                    setNewCurrentInteractable(newInteractable);
                }
                else DisableCurrentInteractable();
            }
            else DisableCurrentInteractable();
        }
        else DisableCurrentInteractable();
    }
    void setNewCurrentInteractable(interactable newInteractable)
    {
        //HUDcontroller.instance.EnableInteractionText(currentInteractable.message);
        currentInteractable=newInteractable;
        currentInteractable.EnableOutline();
    }
    void DisableCurrentInteractable()
    {
        //HUDcontroller.instance.DisableInteractionText();
        if(currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null; 
        }
    }
}
