using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testmovement : MonoBehaviour
{
    CharacterController character;
    [SerializeField]
    GameEvent loseEvent;
    


    float gravity = -5f;
    // Awake is called just before start, as soon as the scene loads in
    private void Awake() {
        character =  GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xDir,gravity,yDir);
        character.Move(direction);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            loseEvent.Raise();
        }

    }
}
