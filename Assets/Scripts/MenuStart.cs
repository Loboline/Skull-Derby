using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //L�gg till denna rad bland de �versta i scriptet


public class MenuStart : MonoBehaviour
{


    public void StartGame() // En custom funktion
    { SceneManager.LoadScene(1); } //Startar om scenen med nummer 1
}
