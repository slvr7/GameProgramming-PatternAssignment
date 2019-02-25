using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDelete : MonoBehaviour
{
    // Start is called before the first frame update
    public float AutoDeleteTime;
    void Start()
    {
        Destroy(gameObject, AutoDeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
