using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTruck : Enemy //INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void CheckForDestruction() //POLYMORPHISM
    {
        if (carHealth <= 5)
        {
            Destroy(gameObject);
        }
    }
}
