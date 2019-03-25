using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaskSpace;

public class TaskProcessorTest : MonoBehaviour
{
    // Start is called before the first frame update
    public ShootTask shoottask1 = new ShootTask();
    public ShootTask shoottask2 = new ShootTask();
    public MoveTask movetask1 = new MoveTask();
    public ExplodeTask explodetask = new ExplodeTask();
    public taskProcessor tp = new taskProcessor();

    public GameObject player;
    public Rigidbody bullet;
    public GameObject bulletLaunchEffect;
    public GameObject Turret;
    public GameObject LturretEnd;
    public GameObject RturretEnd;
    public AudioClip shootingAudio;
    public GameObject boss;
    public GameObject explodeEffect;
    

    void Start()
    {
        shoottask1.bullet = bullet;
        shoottask1.bulletLaunchEffect = bulletLaunchEffect;
        shoottask1.Turret = Turret;
        shoottask1.turretEnd = LturretEnd;
        shoottask1.player = player;

        shoottask2.bullet = bullet;
        shoottask2.bulletLaunchEffect = bulletLaunchEffect;
        shoottask2.Turret = Turret;
        shoottask2.turretEnd = RturretEnd;
        shoottask2.player = player;

        movetask1.target = boss;
        movetask1.ani = GetComponent<Animator>();

        explodetask.Target = boss;
        explodetask.explodeEffect = explodeEffect;

        tp.shoottask1 = shoottask1;
        tp.shoottask2 = shoottask2;
        tp.movetask = movetask1;
        tp.explosiontask = explodetask;
        tp.t = boss.GetComponent<TankHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        tp.Update();
    }
}
