using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    private float bulletMoveSpeed = 0.1f;
    private float bulletLifeTime = 5.0f;

    public Vector2 shootDirection;

	void FixedUpdate ()
    {
        transform.Translate(transform.right * bulletMoveSpeed);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (this.tag == "PlayerBullet" && collider.gameObject.tag == "PlayerObstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
