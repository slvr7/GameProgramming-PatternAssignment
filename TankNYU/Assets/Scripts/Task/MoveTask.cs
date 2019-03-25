using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaskSpace;

public class MoveTask : task
{
    // Start is called before the first frame update
    public GameObject target;
    public Animator ani;

    // Update is called once per frame
    internal override void Update()
    {
        Rotate(-6);
        moveForward(1);
    }

    public void moveForward(float a)
    {
        ani.SetFloat("Speed", 3);
        a *= 0.02f;
        target.transform.Translate(Vector3.forward * a);
    }
    public void RandomRotate()
    {
        float value = Random.Range(-3, 3);
        ani.SetFloat("RotateSpeed", value);
    }
    public void Rotate(float a)
    {
        ani.SetFloat("RotateSpeed", a);
    }
}
