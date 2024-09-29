using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PlayerController playerControllerScript; //Vi skapar en variabel fr�n ett utomst�ende script vid namn PlayerController, som Unity hittar i samma scen
    public int enemyCount; //variabel som kommer h�lla r�kningen p� hur m�nga fiender som finns i spelet f.n.
    public int waveNumber = 1; //variabel som kommer �ka f�r varje v�g
    private float spawnCivilianTimer = 10; //en variabel som h�ller numret f�r tiden mellan jumps
    public GameObject enemyPrefab; //public variabel som kopplar GameObjektet i Unity till detta script
    public GameObject civilianPrefab; //public variabel som kopplar GameObjektet i Unity till detta script

    public float spawnRange = 100.0f;
    private bool countingDown = false;
    private bool civilianCountingDown = false;


    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab = GameObject.Find("Enemy"); //Variabeln h�ller info om Gameobjektet Enemy
        civilianPrefab = GameObject.Find("Civilian"); //Variabeln h�ller info om Gameobjektet Civilian
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //Variabeln h�mtar info fr�n ett script vid namn �PlayerController� (Som vi hittar genom att s�ka efter gameobjektet med namnet Player)

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //var enemyCount r�knar object som har scripts med namnet �Enemy�. V�rdet blir en array som grund, d�rf�r l�gger vi till .Length s� det blir l�ngden p� arrayen (dvs en int, som v�r variabel vill vara)

        if (countingDown == false) //Om boolen countingDown �r false...
        {
            countingDown = true;
            StartCoroutine(SpawnCountdownRoutine());
        }

        if (civilianCountingDown == false) //Om boolen countingDown �r false...
        {
            civilianCountingDown = true;
            StartCoroutine(CivilianCountdownRoutine());
        }
    }


    IEnumerator SpawnCountdownRoutine()//IEnumerator metoder hj�lper oss med att g�ra saker utanf�r Update-loopen
    {
        yield return new WaitForSeconds(15);//V�nta 15 sekunder, d�refter...
        waveNumber++; //�kar v�rdet i var med 1, dvs l�gger till en fiende till n�sta g�ng
        SpawnEnemyWave(waveNumber);//K�r funktionen (med int waveNumber som v�rde, se ovan f�r exempel p� funktion m. int prereq)
        SpawnCivilian(); //Spawna 1 civilian p� motorv�gen
        countingDown = false;
    }

    IEnumerator CivilianCountdownRoutine()//IEnumerator metoder hj�lper oss med att g�ra saker utanf�r Update-loopen
    {
        yield return new WaitForSeconds(3);//V�nta 3 sekunder, d�refter...
        SpawnCivilian(); //Spawna 1 civilian p� motorv�gen
        countingDown = false;
    }
    void SpawnEnemyWave(int enemiesToSpawn) //en custom funktion som t.ex. kallas i Start(). En funktion kan ha flera variabler i parentesen om man vill, det kr�vs d� att de specificeras n�r funktionen kallas: i detta fallet ett nummer.
    {
        if (playerControllerScript.gameOver != true) //s� l�nge gameOver-variabeln fr�n PlayerController inte �r true...
        {
            for (int i = 0; i < enemiesToSpawn; i++)  //En for-loop beh�ver tre parametrar: Startv�rdet, n�r den ska sluta, matten f�r att n� dit (i++ betyder l�gg till ett varje g�ng)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

            }  //skapar Enemy prefab, p� en random position, med rotationen som enemyPrefab har
        }
    }

    void SpawnCivilian() //en custom funktion som t.ex. kallas i Start(). En funktion kan ha flera variabler i parentesen om man vill, det kr�vs d� att de specificeras n�r funktionen kallas: i detta fallet ett nummer.
    {
        if (playerControllerScript.gameOver != true) //s� l�nge gameOver-variabeln fr�n PlayerController inte �r true...
        {
    
            Instantiate(civilianPrefab, GenerateCivilianPosition(), civilianPrefab.transform.rotation); //skapar Civilian prefab, p� en random x-position, med rotationen som enemyPrefab har
            Instantiate(civilianPrefab, new Vector3(-190, 0.5f, 295), Quaternion.identity); //skapar Civilian prefab, p� en random x-position, med rotationen som enemyPrefab har

        }
    }
    private Vector3 GenerateSpawnPosition() //En custom �Return�-function ger oss ett v�rde att referera till. I detta fallet en Vector3-position fr�n var randomPos 
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        //variabel som i detta fallet ger en random x-range mellan -100 och 100
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        //variabel som i detta fallet ger en random yp�-range mellan -100 och 100
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosY);
        //en Vector3-variabel som g�r en vector3 av de olika randomnumren fr�n spawnPosX och Z 
        return randomPos; //denna raden g�r att funktionen blir summan av utr�kningen inuti.  }

}

    private Vector3 GenerateCivilianPosition() //En custom �Return�-function ger oss ett v�rde att referera till. I detta fallet en Vector3-position fr�n var randomPos 
    {
        float spawnPosX = Random.Range(-197.0f, -183.0f);
        //variabel som i detta fallet ger en random x-range mellan -100 och 100
        Vector3 randomPos = new Vector3(spawnPosX, 0.5f, -295);
        //en Vector3-variabel som g�r en vector3 av de olika randomnumren fr�n spawnPosX och Z 
        return randomPos; //denna raden g�r att funktionen blir summan av utr�kningen inuti.  }

    }

}
