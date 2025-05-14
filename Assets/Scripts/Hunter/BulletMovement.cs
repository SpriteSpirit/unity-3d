using Assets.Scripts.Hunter;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BulletMovement: MonoBehaviour
{
    public float speed;
    //private GameManager3 gameManager;
    private GameManagerTest gameManager;
    private TargetList list;
    private Transform bulletSpawnerPos;
    private Rigidbody rb;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerTest>();
        list = GameObject.Find("Main Camera").GetComponent<TargetList>();
        // ��������� ����������� �� ������� ������� ���� � bulletSpawner
        bulletSpawnerPos = GameObject.Find("BulletSpawner").transform;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // ������ �������� ���� � ���� �����������
        rb.linearVelocity = bulletSpawnerPos.forward * speed;
       // Invoke("FreeMovement", 2f);
        //transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.x >= -90)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            gameManager.score++;
            list.animals.Remove(other.gameObject);
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
        }
    }

    private void FreeMovement()
    {
        rb.linearVelocity = Vector3.zero;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
