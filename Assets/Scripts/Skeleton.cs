using System.Threading;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private float speed;
    private Animator animator;
    private float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            speed = 8f;
            animator.SetBool("isRun", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            timer = 0;
        }
        else
        {
            animator.SetBool("isRun", false);
            speed = 0f;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
