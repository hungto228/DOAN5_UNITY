﻿using UnityEngine;

// gai
public class Spike : MonoBehaviour
{
	// khi va vào đối tượng khác
	private void OnTriggerEnter2D( Collider2D other )
	{
		//
		if ( other.name.Contains( "Player" ) )
		{
			
			var player = other.GetComponent<Player>();

			
			player.Dead();
		}
	}
}