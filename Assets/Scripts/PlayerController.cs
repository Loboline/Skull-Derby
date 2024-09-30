using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //viktig när man jobbar med UI att ha med denna, annars funkar det inte
using TMPro; //Överst: behöver vara med för användning av TextMeshPro i skripts



public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 20.0f; //var for the speed the player currently has
    private float startSpeed = 20.0f; //var holding the number for the speed the player has from start
    public bool gameOver = false; //var håller info om spelet är slut eller inte
    public GameObject RestartButton; //deklarerar knappen som ett gameobject så vi kan koppla den och interagera med den
    public GameObject menuButton; //deklarerar knappen som ett gameobject så vi kan koppla den och interagera med den
    public GameObject GameOverText; //deklarerar GamOvertexten som ett gameobject så vi kan koppla den och interagera med den
    public float horizontalInput; // håller ett värde som vi använder till att multiplicera styrningen med
    public float turnSpeed = 50.0f; //var för hastigheten som vi kan rotera
    private bool hasSpeedBoost = false; //håller info om vi har tryckt på Space-knappen
    private bool hasSpeedbooster = false; //håller koll på om vi har charges kvar i speedboosterAmount-variabeln
    private int speedboosterAmount = 0; //variabeln lagrar hur många charges spelaren har kvar att boosta farten 
    public TMP_Text speedboosterText; //Behöver ha using UnityEngine.UI överst för att Text Mesh Pro-text ska funka. Variabeln används för att förändra kopplade texten


    // Start is called before the first frame update
    void Start()
    {
        RestartButton.SetActive(false); //sätter knapp att vara icke aktiv från början (då playern inte är död än)
        menuButton.SetActive(false); //sätter knapp att vara icke aktiv från början (då playern inte är död än)
        GameOverText.SetActive(false); //sätter texten att vara icke aktiv från början (då playern inte är död än)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer(); //ABSTRACTION. Funktionen som kallas sköter den konstanta hastigheten som playern har. 
        NitroActivation(); //ABSTRACTION. Funktionen som kallas kollar om någon trycker på Space-knappen för speedboost, och om charges finns kvar: öka farten
    }


    void MovePlayer () //en funktion som körs i update, som får spelaren att röra sig
    {
            if (!gameOver) //så länge gameOver inte är true
            {
                horizontalInput = Input.GetAxis("Horizontal"); //Hämtar tal mellan (-1 och 1) + knappar från en premade Unity (project settings/Input manager) som hanterar styrning horisontellt
                transform.Translate(playerSpeed * Time.deltaTime * Vector3.forward); //rör spelaren framåt
                transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput); //roterar objektet som multipliceras över tid, med var turnSpeed och med tal mellan -1 och 1 (från horizontalInput)
            }
        }



    private void OnCollisionEnter(Collision collision)
    //en premade funktion i Unity: när objektet gör en collision, så händer något.
    {
        if (collision.gameObject.CompareTag("Ground"))
        //om taggen på gameObjectet vi krockar med är ”Ground”...
        {
            //spelarn är på marken  (och kan styra igen)
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        //om taggen på gameObjectet vi krockar med är ”Obstacle”...
        {
            gameOver = true; //bool-variabeln gameOver blir True (och kan initiera GameOver av olika slag)
            RestartButton.SetActive(true); //Gör starta-om-knappen synlig
            GameOverText.SetActive(true);//Gör Game Over-texten synlig
            menuButton.SetActive(true);

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        //om taggen på gameObjectet vi krockar med är ”Enemy”...
        {
            gameOver = true; //bool-variabeln gameOver blir True (och kan initiera GameOver av olika slag)
            RestartButton.SetActive(true); //Gör starta-om-knappen synlig
            GameOverText.SetActive(true); //Gör Game Over-texten synlig
            menuButton.SetActive(true);
            Destroy(collision.gameObject); //Förstör gameObjektet med taggen Enemy

        }
        else if (collision.gameObject.CompareTag("Speedbooster"))
        //om taggen på gameObjectet vi krockar med är ”Speedbooster”...
        {
            speedboosterAmount += 4; //Vi lägger till 4 till speedboosterAmount
            Destroy(collision.gameObject); //Förstör gameObjektet med taggen Speedbooster
            speedboosterText.text = "Speedboosters: " + speedboosterAmount.ToString(); //Ändra kopplade texten till nya antalet
        }
    }
    private void NitroActivation() //En funktion som kollar om det finns Speedbooster-charges, och i så fall ger extra fart i antal sekunder specificerat av SpeedBoostDuration()
    {
        if (speedboosterAmount > 0) //Om antalet är större än 0...
        {
            hasSpeedbooster = true; //Sätt boolen till true
            if (Input.GetKeyDown(KeyCode.UpArrow) && hasSpeedbooster) //Om space trycks ner OCH om boolen är true
            {
                hasSpeedBoost = true;
                speedboosterAmount = --speedboosterAmount; //Sätt antalet i int-variabeln till ett mindre
                speedboosterText.text = "Speedboosters: " + speedboosterAmount.ToString(); //uppdatera texten till nya antalet

                StartCoroutine(SpeedBoostDuration());//Kör igång funktion (utanför update-loopen) som sköter en duration för hur länge som boosten ska vara igång
            }

            if (hasSpeedBoost == true) //Om variabeln är true
            {
                playerSpeed = 80.0f; //Sätt spelarens hastighet till numret
            }
            else
            {
                playerSpeed = 20.0f; //annars sätt den till detta numret
            }
        }

    }
    IEnumerator SpeedBoostDuration()//Funktionen väntar ett antal sekunder innan den stänger av Speedboosten
    {
        yield return new WaitForSeconds(1); //Vänta 1 sekund
        hasSpeedBoost = false;//sätt hasSpeedBoost till false
        playerSpeed = startSpeed; //sätt playerSpeed till originalvärdet igen
    }


}
