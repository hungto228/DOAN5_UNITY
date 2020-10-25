using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class SpikeHeadEnemy : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{

        if (other.name.Contains("Player"))
        {

            var player = other.GetComponent<Player>();


            player.Dead();
        }
    }
}
