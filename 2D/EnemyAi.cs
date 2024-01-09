using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float speed;
    
    public float chasePointRange;
    public float walkPointRange;

    public PlayerController controller;
    private Transform target;

    bool walkPointSet;
    private Vector3 walkPoint;

    public float health;

    private void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < chasePointRange)
        {
            Chase();
        }
        else if (Vector2.Distance(transform.position, target.position) > chasePointRange)
        {
            Petrol();
        }
    }
    //petrolling
    private void Petrol()
    {
        if (!walkPointSet) 
            SearchWalkPoint();

        if (walkPointSet)
        {
            transform.position = Vector2.MoveTowards(transform.position, walkPoint, speed * Time.deltaTime);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpointReached
        if (distanceToWalkPoint.magnitude <= 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randy = Random.Range(-walkPointRange, walkPointRange);
        float randx = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randx, transform.position.y + randy);
        walkPointSet = true;
    }


    void Chase() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }



    //health and damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(this.gameObject);
    }


    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasePointRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }


}