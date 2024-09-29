using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{
    public PlayerController playerControllerScript; //Vi skapar en variabel fr�n ett utomst�ende script vid namn PlayerController, som Unity hittar i samma scen
    public float civilianSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //Variabeln h�mtar info fr�n ett script vid namn �PlayerController� (Som vi hittar genom att s�ka efter gameobjektet med namnet Player)
        civilianSpeed = Random.Range(20, 30);
    }

    // Update is called once per frame
    void Update()
    {

            MoveCivilian();

        if (transform.position.z > 295.0f)
        {
            Destroy(gameObject);
        }

    }


    void MoveCivilian() //en funktion som k�rs i update, som f�r spelaren att r�ra sig
    {
            transform.Translate(Vector3.forward * Time.deltaTime * civilianSpeed); //r�r spelaren fram�t
    }
}
