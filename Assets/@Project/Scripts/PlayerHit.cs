using UnityEngine;


public class PlayerHit : MonoBehaviour
{
	// Tốc độ di chuyển mới
	public Vector3 m_velocity = new Vector3( 0, 15, 0 );

	// trọng lực áp dụng cho chuyển động 
	public float m_gravity = 30;

	
	private void Update()
	{
		
		transform.localPosition += m_velocity * Time.deltaTime;

		//  trọng lực làm cho rơi dần
		m_velocity.y -= m_gravity * Time.deltaTime;
	}
}