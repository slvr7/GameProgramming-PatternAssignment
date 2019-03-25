using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaskSpace;

public class ExplodeTask : task
{
    public GameObject explodeEffect;
    public GameObject Target;

    public void Explode()
    {
        Object.Destroy(Target);
        Object.Instantiate(explodeEffect, Target.transform.position, Target.transform.rotation);
    }
}
