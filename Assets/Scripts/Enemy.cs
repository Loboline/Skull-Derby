using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int carHealth = 10;
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

    public virtual void CheckForDestruction()
    {
        if(carHealth <= 0)
        {
            Destroy(gameObject);
        }
    } 

}
