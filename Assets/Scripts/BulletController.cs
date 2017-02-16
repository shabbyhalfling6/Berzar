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

    public void RotateBullet()
    {
        // Get Angle to mouse position in Radians
        float AngleRad = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x);
        // Convert angle to Degrees
        float AngleDeg = (90 / Mathf.PI) * AngleRad;
        // Rotate towards mouse 
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
