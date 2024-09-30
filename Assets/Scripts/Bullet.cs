using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 80.0f; //variabel som håller info om hur snabbt kulan färdas.
    public int damage = -5;


    // Update is called once per frame
    void Update()
    {
        MoveBullet(); //Funktionen flyttar kulan framåt
        StartCoroutine(BulletLifetime());
    }

    private void OnCollisionEnter(Collision collision)
    //en premade funktion i Unity: när objektet gör en collision, så händer något.
    {
        if (collision.gameObject.CompareTag("Enemy"))
        //om taggen på gameObjectet vi krockar med är ”Enemy”...
        {
            Enemy hurtEnemy = collision.gameObject.GetComponent<Enemy>(); //Hämtar in koppling till vad som träffade kulan
            hurtEnemy.AdjustCarHealth(damage); //kopplingen till skriptet på det vi träffade möjliggör att vi kan minska hälsan på det som träffades genom dess AdjustCarHealth-method..

            Destroy(gameObject);
                    }

        // if (collision.gameObject.CompareTag("Enemy"))
        //om taggen på gameObjectet vi krockar med är ”Enemy”...
        //{
        //    Destroy(collision.gameObject); //Förstör gameObjektet med taggen Enemy
        //    Destroy(gameObject);
        //}

    }

    void MoveBullet() //en funktion som körs i update, som får spelaren att röra sig
    {
            transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward); //rör spelaren framåt
    }

    IEnumerator BulletLifetime()//Funktionen väntar ett antal sekunder innan den stänger av Speedboosten
    {
        yield return new WaitForSeconds(1); //Vänta 1 sekund
        Destroy(gameObject);//Förstör kulan
    }
}


