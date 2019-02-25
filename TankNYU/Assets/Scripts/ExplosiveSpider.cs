using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveSpider : MonoBehaviour
{
    public enum FSMState
    {
        Wander,
        Chase,
        Explode,
    }

    public float ExplosiveTime = 5;
    public GameObject ExplodeEffect;
    public bool ifEx = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(ExplosiveTime<=0&&!ifEx)
        {
            Explode();
            Destroy(gameObject, 0.1f);
            ifEx = true;
        }else
        {
            ExplosiveTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        
    
    }

    public void Explode()
    {
        Instantiate(ExplodeEffect, transform.position, transform.rotation);
    }


}
