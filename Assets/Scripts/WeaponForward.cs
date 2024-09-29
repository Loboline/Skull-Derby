using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponForward : MonoBehaviour
{
    private float reloadTimer = 0.0f; //Handling speed between shots
    public GameObject bulletPrefab; //Skapar koppling mellan Gameobjekt och detta skript


    // Update is called once per frame
    void Update()
    {
        AutocannonFire(); //funktionen som kallas kollar om någon trycker på Uparrow-knappen för ett skott framåt
    }

    private void AutocannonFire() //funktionen som kallas kollar om någon trycker på Uparrow-knappen för ett skott framåt
    {

        reloadTimer -= Time.deltaTime;
        if (reloadTimer < 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // On uparrow trycks in, skjut ett skott
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                reloadTimer = 0.5f; //sätter tillbaka reloadTimer till 1
            }
        }
    }
}
