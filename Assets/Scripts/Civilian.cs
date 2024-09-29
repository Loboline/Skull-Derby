using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{
    public PlayerController playerControllerScript; //Vi skapar en variabel från ett utomstående script vid namn PlayerController, som Unity hittar i samma scen
    public float civilianSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //Variabeln hämtar info från ett script vid namn ”PlayerController” (Som vi hittar genom att söka efter gameobjektet med namnet Player)
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


    void MoveCivilian() //en funktion som körs i update, som får spelaren att röra sig
    {
            transform.Translate(Vector3.forward * Time.deltaTime * civilianSpeed); //rör spelaren framåt
    }
}
