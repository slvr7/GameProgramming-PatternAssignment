using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank1 : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            enemys.Add(obj.gameObject);
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "Player")
        {
            enemys.Remove(obj.gameObject);
        }
    }

    void UpdateEnemys()
    {
        //enemys.RemoveAll(null);
        List<int> emptyIndex = new List<int>();
        for (int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                emptyIndex.Add(index);
            }
        }

        for (int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i] - i);
        }
    }

    public Rigidbody bullet;
    public float shootFrequency = 2;
    private float shootTimer = 0;
    public GameObject bulletLaunchEffect;
    public GameObject Turret;
    public GameObject turretEnd;
    public AudioClip shootingAudio;
    public float FireMinForce=1800;
    public float FireMaxForce=2100;

    enum FSMState
    {
        Wander,
        Attack,
        Dead,
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemys.Count > 0)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            Turret.transform.LookAt(targetPosition);
        }

        shootTimer += Time.deltaTime;
        if (enemys.Count > 0 && shootTimer >= shootFrequency)
        {
            shootTimer = 0;
            shoot();
        }

    }

    void shoot()
    {
        if (enemys[0] == null)
        {
            UpdateEnemys();
        }

        if (enemys.Count > 0)
        {
            //   AudioSource.PlayClipAtPoint(shootingAudio, ShootPosition.transform.position);
            GameObject bulletEffectInstance = Instantiate(bulletLaunchEffect, turretEnd.transform.position, turretEnd.transform.rotation);
            bulletEffectInstance.transform.parent = turretEnd.transform;
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(bullet, turretEnd.transform.position, Turret.transform.rotation) as Rigidbody;
            bulletInstance.AddForce(turretEnd.transform.right * Random.Range(FireMinForce, FireMaxForce));
        }
        else
        {
            shootTimer = shootFrequency;
        }
    }

}
