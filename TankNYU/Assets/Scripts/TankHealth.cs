using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public float TankMaxHealth;
    private float TankCurentHealth;

    // Start is called before the first frame update
    void Start()
    {
        TankCurentHealth = TankMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamaged(float damage)
    {
        TankCurentHealth -= damage;
    }

    public float getCurrentHealth()
    {
        return TankCurentHealth;
    }
}
