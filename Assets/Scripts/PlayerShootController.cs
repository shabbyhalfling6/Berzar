using UnityEngine;
using System.Collections;

public class PlayerShootController : MonoBehaviour {

    public GameObject bulletPrefab;

    private float playerFireRate = 0.4f;
    private float timer = 0.8f;

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
            bulletInstance.GetComponent<BulletController>().RotateBullet();

            audio.Play();

            timer = playerFireRate;
        }
    }
}
