using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    private float bulletMoveSpeed = 0.1f;
    private float bulletLifeTime = 5.0f;

    public Vector2 shootDirection;

	void FixedUpdate ()
    {
        transform.Translate(transform.right * bulletMoveSpeed);

        Destroy(this.gameObject, bulletLifeTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "PlayerObstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
