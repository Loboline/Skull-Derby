using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int baseHealth = 10; // ENCAPSULATION Making this number hard to corrupt by using this as a backing field, while 
    public int eHealth; //temporary health
    public int carHealth
        {
        get {return baseHealth; } // ENCAPSULATION
        set {baseHealth = value;}        
}
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AdjustCarHealth(int adj)
    {
        carHealth += adj;
        CheckForDestruction();
    }

    public virtual void CheckForDestruction() // INHERITANCE
    {
        if (carHealth <= 0)
        {
            Destroy(gameObject);
        }
    } 

}
