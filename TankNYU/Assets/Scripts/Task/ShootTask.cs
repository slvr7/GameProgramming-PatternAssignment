using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaskSpace;

public class ShootTask : task
{
    public GameObject player;
    public Rigidbody bullet;
    public float shootFrequency = 1;
    public float shootTimer = 0;
    public GameObject bulletLaunchEffect;
    public GameObject Turret;
    public GameObject turretEnd;
    public AudioClip shootingAudio;
    public float FireMinForce = 2800;
    public float FireMaxForce = 3100;


    public void shoot()
    {
        if (shootTimer >= shootFrequency)
        {
            //   AudioSource.PlayClipAtPoint(shootingAudio, ShootPosition.transform.position);
            GameObject bulletEffectInstance = Object.Instantiate(bulletLaunchEffect, turretEnd.transform.position, turretEnd.transform.rotation);
            bulletEffectInstance.transform.parent = turretEnd.transform;
            Rigidbody bulletInstance;
            bulletInstance = Object.Instantiate(bullet, turretEnd.transform.position, Turret.transform.rotation) as Rigidbody;
            bulletInstance.AddForce(turretEnd.transform.right * Random.Range(FireMinForce, FireMaxForce));
            shootTimer = 0;
        }
        else
        {
            shootTimer += Time.deltaTime;
        }
        
    }

    public Vector3 GetTargetPosition()
    {
        return player.transform.position;
    }

    internal override void Update()
    {
        Turret.transform.LookAt(GetTargetPosition());
        shoot();
    }


}
