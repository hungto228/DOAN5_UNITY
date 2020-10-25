using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Player"))
        {

            var player = other.GetComponent<Player>();

            player.Dead();
        }
        if (other.name.Contains("Tilemap"))
        {
            Destroy(gameObject);
        }

    }
}
