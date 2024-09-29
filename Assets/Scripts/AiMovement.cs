using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Behövs för att hitta i Navmesh

public class AiMovement : MonoBehaviour
{
    private GameObject target; //Variabeln kommer hålla info om var objektet som vi har kopplat till detta script i inspectorn befinner sig
    private NavMeshAgent agent;//variabeln håller info från NavMeshAgent-componenten
    private PlayerController playerControllerScript; //Vi skapar en variabel från ett utomstående script vid namn PlayerController, som Unity hittar i samma scen
    public bool gameOver = false;// håller koll på om gameOver är true, hämtar den infon senare från PlayerController-scriptet


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //hämtar NavMeshAgent som sitter på Gameobjektet till scriptet och lagrar det i var agent
        target = GameObject.Find("Player");
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //Variabeln hämtar info från ett script vid namn ”PlayerController” (Som vi hittar genom att söka efter gameobjektet med namnet Player)
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy() //en funktion som körs i update, som får spelaren att röra sig
    {
        agent.destination = target.transform.position; //sätter detta objekts destination på en navmesh till ett target position

        gameOver = playerControllerScript.gameOver;
        if (gameOver) //När gameOver är true
        {
            GetComponent<NavMeshAgent>().speed = 10;
        }
    }

}
