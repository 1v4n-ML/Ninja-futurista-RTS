using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    //Função da câmera que converte para o Ray
    public  Camera cam;

    public NavMeshAgent agent;
    void Update ()
    {
        //Pegando a posição do mouse
        if (Input.GetMouseButtonDown(1))
        {
            //cria e defino o ray
            Ray ray = cam.ScreenPointToRay (Input.mousePosition);
            //no que  a ray colide
            RaycastHit hit;

            //disparando o Ray
            if (Physics.Raycast(ray, out hit))
            {
                //move our agent
                agent.SetDestination(hit.point);
            }
        }
    }
}