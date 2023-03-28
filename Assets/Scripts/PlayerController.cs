using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControls : MonoBehaviour
{

    //public Interactable focus;
    //public LayerMask movementMask;

    Camera cam;

    PlayerMotor motor;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            //cria e defino o ray
            Ray ray = cam.ScreenPointToRay (Input.mousePosition);
            //no que  a ray colide
            RaycastHit hit;

            //disparando o Ray
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    motor.FollowTarget(interactable);
                    Debug.Log("seguindo" + interactable.name);
                }else
                    motor.MoveToPoint(hit.point);
            }
        }
        /*    if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if( Physics.Raycast(ray, out hit, 100, 100))
            {
                //Check if we hit an interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                //if we did set it our
               if ( interactable != null )
               {
                    SetFocus(interactable);
               }    
            }
        } */
    }

    // Declare functions here

   /*  void SetFocus ( Interactable newFocus) 
    {
        if( newFocus != focus)
        {
            if( focus != null)
                focus.OnDeFocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        
        newFocus.onFocused(transform);     
    }

    void RemoveFocus ()
    {
        if ( focus != null)
            focus.OnDeFocused();

        focus = null;
        motor.StopFollowingTarget();
    } */
}