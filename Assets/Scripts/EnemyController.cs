using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private float enemyMoveSpeed = 0.5f;
    private float smoothFactor = 1.0f;
    private float timer = 0.0f;
    private float enemyFireRate = 1.0f;

    protected Vector2 move;
    private Vector2 startPosition;

    public GameObject bulletPrefab;
    private GameObject player;

    public enemyState currentState;

    public enum enemyState
    {
        Patrol = 0,
        ShootPlayer,
        ShootNothing,
        ShootFriendlies,
        NumStates
    }

    void Start()
    {
        timer = enemyFireRate;
        player = GameObject.Find("Player");
        startPosition = transform.position;
    }

	void Update ()
    {
        if (player == null)
            currentState = enemyState.Patrol;
        
        switch (currentState)
        {
            case enemyState.Patrol:
             
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    move.x = Random.Range(enemyMoveSpeed * Time.deltaTime * - 1, enemyMoveSpeed * Time.deltaTime * 1);
                    move.y = Random.Range(enemyMoveSpeed * Time.deltaTime * - 1, enemyMoveSpeed * Time.deltaTime * 1);

                    timer = 2.0f;
                }

                transform.Translate(move);

                break;
            case enemyState.ShootPlayer:
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    startPosition = transform.position;
                    GameObject bulletInstance = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);

                    // Get Angle to mouse position in Radians
                    float AngleRad = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x);
                    // Convert angle to Degrees
                    float AngleDeg = (90 / Mathf.PI) * AngleRad;
                    // Rotate towards mouse 
                    bulletInstance.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
                    bulletInstance.tag = "PlayerObstacle";
                    timer = enemyFireRate;
                }
                break;
            case enemyState.ShootNothing:
                break;
            case enemyState.ShootFriendlies:
                break;
        }

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "PlayerBullet")
            Destroy(this.gameObject);
    }
}
