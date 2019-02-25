using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyType1;
    public GameObject EnemyType2;
    public GameObject EnemyType3;

    public Transform[] positionlist;

    private int currentEnemyNum=0;
    public int maxEnemyNum = 5;
    public float SpawnTime = 10;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentEnemyNum = 0;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawner();
    }

    public void EnemySpawner()
    {
        if (currentTime >= SpawnTime)
        {
            if (currentEnemyNum < maxEnemyNum)
            {
                int enemy = Random.Range(1, 3);
                int position = Random.Range(0, 5);
                switch (enemy)
                {
                    case 1:
                        Instantiate(EnemyType1, positionlist[position].position, positionlist[position].rotation);
                        break;
                    case 2:
                        Instantiate(EnemyType2, positionlist[position].position, positionlist[position].rotation);
                        break;
                    case 3:
                        Instantiate(EnemyType3, positionlist[position].position, positionlist[position].rotation);
                        break;
                    default:
                        Instantiate(EnemyType1, positionlist[position].position, positionlist[position].rotation);
                        break;
                }
                currentEnemyNum++;
                currentTime = 0;
            }

        }else
        {
            currentTime += Time.deltaTime;
        }
    }
}
