using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private float enemyMoveSpeed = 1.5f;
    private float smoothFactor = 1.0f;
    private float timer = 0.0f;
    private float enemyFireRate = 1.0f;

    protected Vector2 move;

    public GameObject bulletPrefab;
    private GameObject player;

    enemyState currentState;

    enum enemyState
    {
        eesPatrol = 0,
        eesShootPlayer,
        eesShootNothing,
        eesShootFriendlies
    }

    void Start()
    {
        timer = enemyFireRate;
    }

	void Update ()
    {


        switch (currentState)
        {
            case enemyState.eesPatrol:
             
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    move.x = Random.Range(-1, 1);
                    move.y = Random.Range(-1, 1);

                    timer = 2.0f;
                }
        
                break;
            case enemyState.eesShootPlayer:
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    GameObject bulletInstance = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

                    // Get Angle to mouse position in Radians
                    float AngleRad = Mathf.Atan2(player.transform.position.y - this.transform.position.y, player.transform.position.x - this.transform.position.x);
                    // Convert angle to Degrees
                    float AngleDeg = (90 / Mathf.PI) * AngleRad;
                    // Rotate towards mouse 
                    bulletInstance.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
                    bulletInstance.tag = "PlayerObstacle";
                    timer = enemyFireRate;
                }
                break;
            case enemyState.eesShootNothing:
                break;
            case enemyState.eesShootFriendlies:
                break;
        }

       this.transform.position = Vector2.Lerp(this.transform.position, move * enemyMoveSpeed, Time.deltaTime * smoothFactor);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            currentState = enemyState.eesShootPlayer;
            player = collider.gameObject;
        }
    }
}
