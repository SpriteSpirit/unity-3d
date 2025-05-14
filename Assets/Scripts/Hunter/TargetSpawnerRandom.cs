using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnerRandom : MonoBehaviour
{
    public GameObject[] targets;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("Spawner", 2f, 2f);
    }

    public void Spawner()
    {
        int randomIndex = Random.Range(0, targets.Length);

        Instantiate(targets[randomIndex], new Vector3(Random.Range(-68, -30), 6.54f, Random.Range(124, 215)), targets[randomIndex].transform.rotation);
    }

}
