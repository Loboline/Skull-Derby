using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PlayerController playerControllerScript; //Vi skapar en variabel från ett utomstående script vid namn PlayerController, som Unity hittar i samma scen
    public int enemyCount; //variabel som kommer hålla räkningen på hur många fiender som finns i spelet f.n.
    public int waveNumber = 1; //variabel som kommer öka för varje våg
    private float spawnCivilianTimer = 10; //en variabel som håller numret för tiden mellan jumps
    public GameObject enemyPrefab; //public variabel som kopplar GameObjektet i Unity till detta script
    public GameObject civilianPrefab; //public variabel som kopplar GameObjektet i Unity till detta script

    public float spawnRange = 100.0f;
    private bool countingDown = false;
    private bool civilianCountingDown = false;


    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab = GameObject.Find("Enemy"); //Variabeln håller info om Gameobjektet Enemy
        civilianPrefab = GameObject.Find("Civilian"); //Variabeln håller info om Gameobjektet Civilian
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //Variabeln hämtar info från ett script vid namn ”PlayerController” (Som vi hittar genom att söka efter gameobjektet med namnet Player)

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //var enemyCount räknar object som har scripts med namnet ”Enemy”. Värdet blir en array som grund, därför lägger vi till .Length så det blir längden på arrayen (dvs en int, som vår variabel vill vara)

        if (countingDown == false) //Om boolen countingDown är false...
        {
            countingDown = true;
            StartCoroutine(SpawnCountdownRoutine());
        }

        if (civilianCountingDown == false) //Om boolen countingDown är false...
        {
            civilianCountingDown = true;
            StartCoroutine(CivilianCountdownRoutine());
        }
    }


    IEnumerator SpawnCountdownRoutine()//IEnumerator metoder hjälper oss med att göra saker utanför Update-loopen
    {
        yield return new WaitForSeconds(15);//Vänta 15 sekunder, därefter...
        waveNumber++; //ökar värdet i var med 1, dvs lägger till en fiende till nästa gång
        SpawnEnemyWave(waveNumber);//Kör funktionen (med int waveNumber som värde, se ovan för exempel på funktion m. int prereq)
        SpawnCivilian(); //Spawna 1 civilian på motorvägen
        countingDown = false;
    }

    IEnumerator CivilianCountdownRoutine()//IEnumerator metoder hjälper oss med att göra saker utanför Update-loopen
    {
        yield return new WaitForSeconds(3);//Vänta 3 sekunder, därefter...
        SpawnCivilian(); //Spawna 1 civilian på motorvägen
        countingDown = false;
    }
    void SpawnEnemyWave(int enemiesToSpawn) //en custom funktion som t.ex. kallas i Start(). En funktion kan ha flera variabler i parentesen om man vill, det krävs då att de specificeras när funktionen kallas: i detta fallet ett nummer.
    {
        if (playerControllerScript.gameOver != true) //så länge gameOver-variabeln från PlayerController inte är true...
        {
            for (int i = 0; i < enemiesToSpawn; i++)  //En for-loop behöver tre parametrar: Startvärdet, när den ska sluta, matten för att nå dit (i++ betyder lägg till ett varje gång)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

            }  //skapar Enemy prefab, på en random position, med rotationen som enemyPrefab har
        }
    }

    void SpawnCivilian() //en custom funktion som t.ex. kallas i Start(). En funktion kan ha flera variabler i parentesen om man vill, det krävs då att de specificeras när funktionen kallas: i detta fallet ett nummer.
    {
        if (playerControllerScript.gameOver != true) //så länge gameOver-variabeln från PlayerController inte är true...
        {
    
            Instantiate(civilianPrefab, GenerateCivilianPosition(), civilianPrefab.transform.rotation); //skapar Civilian prefab, på en random x-position, med rotationen som enemyPrefab har
            Instantiate(civilianPrefab, new Vector3(-190, 0.5f, 295), Quaternion.identity); //skapar Civilian prefab, på en random x-position, med rotationen som enemyPrefab har

        }
    }
    private Vector3 GenerateSpawnPosition() //En custom ”Return”-function ger oss ett värde att referera till. I detta fallet en Vector3-position från var randomPos 
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        //variabel som i detta fallet ger en random x-range mellan -100 och 100
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        //variabel som i detta fallet ger en random ypå-range mellan -100 och 100
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosY);
        //en Vector3-variabel som gör en vector3 av de olika randomnumren från spawnPosX och Z 
        return randomPos; //denna raden gör att funktionen blir summan av uträkningen inuti.  }

}

    private Vector3 GenerateCivilianPosition() //En custom ”Return”-function ger oss ett värde att referera till. I detta fallet en Vector3-position från var randomPos 
    {
        float spawnPosX = Random.Range(-197.0f, -183.0f);
        //variabel som i detta fallet ger en random x-range mellan -100 och 100
        Vector3 randomPos = new Vector3(spawnPosX, 0.5f, -295);
        //en Vector3-variabel som gör en vector3 av de olika randomnumren från spawnPosX och Z 
        return randomPos; //denna raden gör att funktionen blir summan av uträkningen inuti.  }

    }

}
