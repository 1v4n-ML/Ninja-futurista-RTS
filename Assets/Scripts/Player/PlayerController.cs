using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public Interactable focus;

    public LayerMask movementMask;  //filter out everything not walkable

    Camera cam;                     //reference to our camera
    PlayerMotor motor;              //reference to our motor


    //Get references
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if the ray hits
            if(Physics.Raycast(ray, out hit, 100 ))
            {
                //Check if we hit an interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //if we did set it our focus
                if(interactable != null)
                {
                    SetFocus(interactable);

                }else if( Physics.Raycast(ray, out hit, 100, movementMask )) {

                    motor.MoveToPoint(hit.point);
                    RemoveFocus();
                }

            }
            
        }           
    }

    void SetFocus (Interactable newFocus) 
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus; 
            motor.FollowTarget(newFocus.gameObject, 1f);
        }
    }

    void RemoveFocus ()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    } 
}
