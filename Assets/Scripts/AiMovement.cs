using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Beh�vs f�r att hitta i Navmesh

public class AiMovement : MonoBehaviour
{
    private GameObject target; //Variabeln kommer h�lla info om var objektet som vi har kopplat till detta script i inspectorn befinner sig
    private NavMeshAgent agent;//variabeln h�ller info fr�n NavMeshAgent-componenten
    private PlayerController playerControllerScript; //Vi skapar en variabel fr�n ett utomst�ende script vid namn PlayerController, som Unity hittar i samma scen
    public bool gameOver = false;// h�ller koll p� om gameOver �r true, h�mtar den infon senare fr�n PlayerController-scriptet


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //h�mtar NavMeshAgent som sitter p� Gameobjektet till scriptet och lagrar det i var agent
        target = GameObject.Find("Player");
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //Variabeln h�mtar info fr�n ett script vid namn �PlayerController� (Som vi hittar genom att s�ka efter gameobjektet med namnet Player)
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy() //en funktion som k�rs i update, som f�r spelaren att r�ra sig
    {
        agent.destination = target.transform.position; //s�tter detta objekts destination p� en navmesh till ett target position

        gameOver = playerControllerScript.gameOver;
        if (gameOver) //N�r gameOver �r true
        {
            GetComponent<NavMeshAgent>().speed = 10;
        }
    }

}
