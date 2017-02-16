using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float bulletMoveSpeed = 6.0f;

	void Update ()
    {
        transform.Translate(transform.forward * Time.deltaTime * bulletMoveSpeed);
	}
}
