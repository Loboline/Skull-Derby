using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;// S� vi kan dra in referens till Player-gameobject till skriptet p� kameran
    private Vector3 cameraOffset = new Vector3(0, 100, 0); //en offset (s� inte kameran hamnar mitt i playern
    public Vector3 playerLoc; //en var som h�ller spelarens riktiga location, s� vi kan rikta kameran mot den


    // Update is called once per frame
    void LateUpdate() //k�r detta efter Update (s� att det blir en smooth camerafollow). Annars r�r playern och cameran lite kaotiskt i turordning vilket kan se hackigt ut.
    {
        playerLoc = player.transform.position;
        //transform.LookAt(playerLoc); //Det som har det h�r skriptet f�r samma rotation som player-Objektet + en offset (d�r vi vill ha kameran dvs)
        //transform.position = player.transform.position + cameraOffset; //Det som har det h�r skriptet f�r samma position som player-Objektet + en offset (d�r vi vill ha kameran dvs)
    }
}
