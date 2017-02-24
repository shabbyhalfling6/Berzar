using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    private EnemyController enemyController;

    void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            enemyController.currentState = EnemyController.enemyState.ShootPlayer;
    }


    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            enemyController.currentState = EnemyController.enemyState.Patrol;
    }
}
