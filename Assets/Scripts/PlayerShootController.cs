using UnityEngine;
using System.Collections;

public class PlayerShootController : MonoBehaviour {

    public GameObject bulletPrefab;

    private float playerFireRate = 1.0f;
    private float timer = 0.2f;

    private AudioSource audio;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        timer -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timer <= 0)
        {
            GameObject bulletInstance = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            bulletInstance.tag = "PlayerBullet";
            bulletInstance.layer = 10;

            // Get Angle to mouse position in Radians
            float AngleRad = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x);
            // Convert angle to Degrees
            float AngleDeg = (90 / Mathf.PI) * AngleRad;
            // Rotate towards mouse 
            bulletInstance.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

            audio.Play();

            timer = playerFireRate;
        }
    }
}
