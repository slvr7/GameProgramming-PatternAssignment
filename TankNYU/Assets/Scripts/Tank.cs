using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    // Start is called before the first frame update
    public float TranslateSpeed = 5;
    public float RotateSpeed = 3;
    public GameObject moveEffect;
    public GameObject moveSound;

//    public Rigidbody bullet1;
//    public GameObject bulletLaunchEffect1;
//    public Rigidbody bullet2;
//    public GameObject bulletLaunchEffect2;
//    public Rigidbody bullet3;
//    public GameObject bulletLaunchEffect3;
//    public float Fire1MinForce = 2800;
//    public float Fire1MaxForce = 3000;
//    public float Fire2MinForce = 2800;
//    public float Fire2MaxForce = 3000;
//    public float Fire3MinForce = 800;
//    public float Fire3MaxForce = 850;

    [System.Serializable]
    public class weapon
    {
        public string name;
        public int num;
        public Rigidbody bullet;
        public GameObject bulletLaunchEffect;
        public float FireMinForce;
        public float FireMaxForce;
        public bool IfBulletShake;
        public bool IfShotGun;
        public int shotgunNum;
    }
    public weapon[] weaponlist;

    public float TurretRotateSpeed = 10;

    public GameObject tank;
    public GameObject turret;
    public GameObject turretEnd;
    public GameObject[] ShotGunEnd;

    public float ChargeProgress;
    public bool isCharging;
    public float ChargeSpeed = 1;
    public bool Fired;
    public float FireChargeFlag = 0.5f;
    public float MaxCharge = 1.0f;

    public int bulletShake = 0;

    public Slider ChargeSlider;


    void Start()
    {
        ChargeProgress = 0;
        isCharging = false;
        // ShootTimeCount = 0.2f;

        ChargeSlider.minValue = 0;
        ChargeSlider.maxValue = MaxCharge;
        ChargeSlider.value = ChargeProgress;
    }

    // Update is called once per frame
    void Update()
    {
        TurretRotate();

        Charge();
        ChargeSlider.value = ChargeProgress;
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float t = TranslateSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(0, 0, t);

        float r = RotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Rotate(0, r, 0);
    }

    public void TurretRotate()
    {
        if (Input.GetMouseButton(1))
        {
            float r = TurretRotateSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
            turret.transform.Rotate(0, r, 0);
        }
    }

    public void Charge()
    {
        if (ChargeProgress >= MaxCharge && !Fired)
        {
            ChargeProgress = MaxCharge;
            Fire(weaponlist[2]);
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            Fired = false;
            ChargeProgress = 0;
        }
        else if (Input.GetButton("Fire1") && !Fired)
        {
            ChargeProgress += ChargeSpeed * Time.deltaTime;
        }
        else if (Input.GetButtonUp("Fire1") && !Fired)
        {
            if (ChargeProgress > 0 && ChargeProgress < FireChargeFlag)
            {
                Fire(weaponlist[0]);
            }
            else if (ChargeProgress >= FireChargeFlag && ChargeProgress < MaxCharge)
            {
                Fire(weaponlist[1]);
            }
        }
    }

    public void Fire(weapon a)
    {
        Fired = true;
        GameObject bulletEffectInstance= Instantiate(a.bulletLaunchEffect, turretEnd.transform.position, turretEnd.transform.rotation);
        bulletEffectInstance.transform.parent = turretEnd.transform;
        Rigidbody bulletInstance;
        bulletInstance = Instantiate(a.bullet, turretEnd.transform.position, turret.transform.rotation) as Rigidbody;
        bulletInstance.AddForce(turretEnd.transform.right * Random.Range(a.FireMinForce, a.FireMaxForce));
        ChargeProgress = 0;
        if (a.IfBulletShake)
        {
            BulletShake();
        }

        if(a.IfShotGun)
        {
            for(int i=0;i<a.shotgunNum;i++)
            {
                Rigidbody ShotgunInstance;
                ShotgunInstance = Instantiate(a.bullet, ShotGunEnd[i].transform.position, ShotGunEnd[i].transform.rotation)as Rigidbody;
                ShotgunInstance.AddForce(ShotGunEnd[i].transform.forward * Random.Range(a.FireMinForce, a.FireMaxForce));
            }
        }
    }

    public void BulletShake()
    {
        if (bulletShake == 0)
        {
            bulletShake++;
            turretEnd.transform.Rotate(0, 0.2f, 0);
        }
        else if (bulletShake == 1)
        {
            bulletShake++;
            turretEnd.transform.Rotate(0.2f, 0.2f, 0);
        }
        else if (bulletShake == 2)
        {
            bulletShake++;
            turretEnd.transform.Rotate(0.2f, -0.6f, 0);
        }
        else if (bulletShake == 3)
        {
            bulletShake++;
            turretEnd.transform.Rotate(-0.4F, 0.2f, 0);
        }
        else if (bulletShake == 4)
        {
            bulletShake++;
            turretEnd.transform.Rotate(0.2f, 0.2f, 0.2f);
        }
        else if (bulletShake == 5)
        {
            bulletShake = 0;
            turretEnd.transform.Rotate(-0.2f, -0.2f, -0.2f);
        }
    }

    public void TurretShake()
    {

    }
}
