using UnityEngine;


public class FallPlatform : MonoBehaviour
{
	// rơi
	public float m_speed = 0.3f;

	//  người chơi đứng đầu
	private bool m_isHit;

	
	private void Awake()
	{
		
		var motor = GetComponent<MovingPlatformMotor2D>();

		// trong trường hợp được gọi khi người chơi truy cập,đăng ký
		motor.onPlatformerMotorContact += OnContact;
	}

	
	private void OnContact( PlatformerMotor2D player )
	{
		// người chơi bị ngã
		if ( player.IsFalling() )
		{
			//
			m_isHit = true;
		}
	}


	private void Update()
	{
		
		if ( m_isHit )
		{
			
			var motor = GetComponent<MovingPlatformMotor2D>();

			//tốc độ rơi
			motor.velocity = Physics2D.gravity * m_speed;
		}
	}
}