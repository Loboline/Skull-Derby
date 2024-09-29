using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;// Så vi kan dra in referens till Player-gameobject till skriptet på kameran
    private Vector3 cameraOffset = new Vector3(0, 100, 0); //en offset (så inte kameran hamnar mitt i playern
    public Vector3 playerLoc; //en var som håller spelarens riktiga location, så vi kan rikta kameran mot den


    // Update is called once per frame
    void LateUpdate() //kör detta efter Update (så att det blir en smooth camerafollow). Annars rör playern och cameran lite kaotiskt i turordning vilket kan se hackigt ut.
    {
        playerLoc = player.transform.position;
        //transform.LookAt(playerLoc); //Det som har det här skriptet får samma rotation som player-Objektet + en offset (där vi vill ha kameran dvs)
        //transform.position = player.transform.position + cameraOffset; //Det som har det här skriptet får samma position som player-Objektet + en offset (där vi vill ha kameran dvs)
    }
}
