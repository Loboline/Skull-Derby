using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //viktig n�r man jobbar med UI att ha med denna, annars funkar det inte
using TMPro; //�verst: beh�ver vara med f�r anv�ndning av TextMeshPro i skripts



public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 20.0f; //var for the speed the player currently has
    private float startSpeed = 20.0f; //var holding the number for the speed the player has from start
    public bool gameOver = false; //var h�ller info om spelet �r slut eller inte
    public GameObject RestartButton; //deklarerar knappen som ett gameobject s� vi kan koppla den och interagera med den
    public GameObject menuButton; //deklarerar knappen som ett gameobject s� vi kan koppla den och interagera med den
    public GameObject GameOverText; //deklarerar GamOvertexten som ett gameobject s� vi kan koppla den och interagera med den
    public float horizontalInput; // h�ller ett v�rde som vi anv�nder till att multiplicera styrningen med
    public float turnSpeed = 50.0f; //var f�r hastigheten som vi kan rotera
    private bool hasSpeedBoost = false; //h�ller info om vi har tryckt p� Space-knappen
    private bool hasSpeedbooster = false; //h�ller koll p� om vi har charges kvar i speedboosterAmount-variabeln
    private int speedboosterAmount = 0; //variabeln lagrar hur m�nga charges spelaren har kvar att boosta farten 
    public TMP_Text speedboosterText; //Beh�ver ha using UnityEngine.UI �verst f�r att Text Mesh Pro-text ska funka. Variabeln anv�nds f�r att f�r�ndra kopplade texten


    // Start is called before the first frame update
    void Start()
    {
        RestartButton.SetActive(false); //s�tter knapp att vara icke aktiv fr�n b�rjan (d� playern inte �r d�d �n)
        menuButton.SetActive(false); //s�tter knapp att vara icke aktiv fr�n b�rjan (d� playern inte �r d�d �n)
        GameOverText.SetActive(false); //s�tter texten att vara icke aktiv fr�n b�rjan (d� playern inte �r d�d �n)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer(); //ABSTRACTION. Funktionen som kallas sk�ter den konstanta hastigheten som playern har. 
        NitroActivation(); //ABSTRACTION. Funktionen som kallas kollar om n�gon trycker p� Space-knappen f�r speedboost, och om charges finns kvar: �ka farten
    }


    void MovePlayer () //en funktion som k�rs i update, som f�r spelaren att r�ra sig
    {
            if (!gameOver) //s� l�nge gameOver inte �r true
            {
                horizontalInput = Input.GetAxis("Horizontal"); //H�mtar tal mellan (-1 och 1) + knappar fr�n en premade Unity (project settings/Input manager) som hanterar styrning horisontellt
                transform.Translate(playerSpeed * Time.deltaTime * Vector3.forward); //r�r spelaren fram�t
                transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput); //roterar objektet som multipliceras �ver tid, med var turnSpeed och med tal mellan -1 och 1 (fr�n horizontalInput)
            }
        }



    private void OnCollisionEnter(Collision collision)
    //en premade funktion i Unity: n�r objektet g�r en collision, s� h�nder n�got.
    {
        if (collision.gameObject.CompareTag("Ground"))
        //om taggen p� gameObjectet vi krockar med �r �Ground�...
        {
            //spelarn �r p� marken  (och kan styra igen)
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        //om taggen p� gameObjectet vi krockar med �r �Obstacle�...
        {
            gameOver = true; //bool-variabeln gameOver blir True (och kan initiera GameOver av olika slag)
            RestartButton.SetActive(true); //G�r starta-om-knappen synlig
            GameOverText.SetActive(true);//G�r Game Over-texten synlig
            menuButton.SetActive(true);

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        //om taggen p� gameObjectet vi krockar med �r �Enemy�...
        {
            gameOver = true; //bool-variabeln gameOver blir True (och kan initiera GameOver av olika slag)
            RestartButton.SetActive(true); //G�r starta-om-knappen synlig
            GameOverText.SetActive(true); //G�r Game Over-texten synlig
            menuButton.SetActive(true);
            Destroy(collision.gameObject); //F�rst�r gameObjektet med taggen Enemy

        }
        else if (collision.gameObject.CompareTag("Speedbooster"))
        //om taggen p� gameObjectet vi krockar med �r �Speedbooster�...
        {
            speedboosterAmount += 4; //Vi l�gger till 4 till speedboosterAmount
            Destroy(collision.gameObject); //F�rst�r gameObjektet med taggen Speedbooster
            speedboosterText.text = "Speedboosters: " + speedboosterAmount.ToString(); //�ndra kopplade texten till nya antalet
        }
    }
    private void NitroActivation() //En funktion som kollar om det finns Speedbooster-charges, och i s� fall ger extra fart i antal sekunder specificerat av SpeedBoostDuration()
    {
        if (speedboosterAmount > 0) //Om antalet �r st�rre �n 0...
        {
            hasSpeedbooster = true; //S�tt boolen till true
            if (Input.GetKeyDown(KeyCode.UpArrow) && hasSpeedbooster) //Om space trycks ner OCH om boolen �r true
            {
                hasSpeedBoost = true;
                speedboosterAmount = --speedboosterAmount; //S�tt antalet i int-variabeln till ett mindre
                speedboosterText.text = "Speedboosters: " + speedboosterAmount.ToString(); //uppdatera texten till nya antalet

                StartCoroutine(SpeedBoostDuration());//K�r ig�ng funktion (utanf�r update-loopen) som sk�ter en duration f�r hur l�nge som boosten ska vara ig�ng
            }

            if (hasSpeedBoost == true) //Om variabeln �r true
            {
                playerSpeed = 80.0f; //S�tt spelarens hastighet till numret
            }
            else
            {
                playerSpeed = 20.0f; //annars s�tt den till detta numret
            }
        }

    }
    IEnumerator SpeedBoostDuration()//Funktionen v�ntar ett antal sekunder innan den st�nger av Speedboosten
    {
        yield return new WaitForSeconds(1); //V�nta 1 sekund
        hasSpeedBoost = false;//s�tt hasSpeedBoost till false
        playerSpeed = startSpeed; //s�tt playerSpeed till originalv�rdet igen
    }


}
