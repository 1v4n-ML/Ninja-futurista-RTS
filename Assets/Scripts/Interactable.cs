using UnityEngine;


public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    //bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public virtual void Interact ()
    {
        //This method is meant to be overwritten
        Debug.Log("Interacting with" + transform.name);

    }

    public void Update(){

        float distance = Vector3.Distance(player.position, interactionTransform.position);
        if (distance <= radius)
        {
            Interact();
            Debug.Log("INTERACT");
            hasInteracted = true;
        }

    }

    /* public void onFocused ( Transform playerTransform)
    {

        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused ()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    } */

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
        
    }

}
