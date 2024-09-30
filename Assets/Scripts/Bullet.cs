using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 80.0f; //variabel som h�ller info om hur snabbt kulan f�rdas.
    public int damage = -5;


    // Update is called once per frame
    void Update()
    {
        MoveBullet(); //Funktionen flyttar kulan fram�t
        StartCoroutine(BulletLifetime());
    }

    private void OnCollisionEnter(Collision collision)
    //en premade funktion i Unity: n�r objektet g�r en collision, s� h�nder n�got.
    {
        if (collision.gameObject.CompareTag("Enemy"))
        //om taggen p� gameObjectet vi krockar med �r �Enemy�...
        {
            Enemy hurtEnemy = collision.gameObject.GetComponent<Enemy>(); //H�mtar in koppling till vad som tr�ffade kulan
            hurtEnemy.AdjustCarHealth(damage); //kopplingen till skriptet p� det vi tr�ffade m�jligg�r att vi kan minska h�lsan p� det som tr�ffades genom dess AdjustCarHealth-method..

            Destroy(gameObject);
                    }

        // if (collision.gameObject.CompareTag("Enemy"))
        //om taggen p� gameObjectet vi krockar med �r �Enemy�...
        //{
        //    Destroy(collision.gameObject); //F�rst�r gameObjektet med taggen Enemy
        //    Destroy(gameObject);
        //}

    }

    void MoveBullet() //en funktion som k�rs i update, som f�r spelaren att r�ra sig
    {
            transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward); //r�r spelaren fram�t
    }

    IEnumerator BulletLifetime()//Funktionen v�ntar ett antal sekunder innan den st�nger av Speedboosten
    {
        yield return new WaitForSeconds(1); //V�nta 1 sekund
        Destroy(gameObject);//F�rst�r kulan
    }
}


