﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionBehaviour : MonoBehaviour {
    
    void OnCollisionEnter2D (Collision2D collider)
    {
            Destroy(collider.gameObject);
    }
}
