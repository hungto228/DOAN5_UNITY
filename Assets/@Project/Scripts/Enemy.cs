using PC2D;
using UnityEngine;


public class Enemy : MonoBehaviour
{
	
	public GameObject m_hitPrefab;

	
	public AudioClip m_hitClip;

	
	private PlatformerMotor2D m_motor;

	
	private SpriteRenderer m_renderer;

	
	private BoxCollider2D m_collider;

	private void Awake()
	{
		
		m_motor = GetComponent<PlatformerMotor2D>();

		// di chuyển sang trái
		m_motor.normalizedXMovement = -1;

		
		m_renderer = GetComponent<SpriteRenderer>();

		// ban đầu di quay sang trái
		m_renderer.flipX = false;

		
		m_collider = GetComponent<BoxCollider2D>();
	}


	private void Update()
	{
		//Nhận hướng đi hiện tại
		var dir = 0 < m_motor.normalizedXMovement
			? Vector3.right
			: Vector3.left;

		// check xem có bản đồ ô theo hướng di chuyển 
		var offset = m_collider.size.y * 0.5f;
		var hit = Physics2D.Raycast
		(
			transform.position - new Vector3( 0, offset, 0 ),
			dir,
			m_collider.size.x * 0.55f,
			Globals.ENV_MASK
		);

		// 
		if ( hit.collider != null )
		{
			//Đảo ngược hướng chuyển động
			m_motor.normalizedXMovement = -m_motor.normalizedXMovement;

			// Đảo ngược hướng của hình ảnh
			m_renderer.flipX = !m_renderer.flipX;
		}
	}

	
	private void OnTriggerEnter2D( Collider2D other )
	{
		if ( other.name.Contains( "Player" ) )
		{
			// 
			var motor = other.GetComponent<PlatformerMotor2D>();

			// người chơi bị ngã
			if ( motor.IsFalling() )
			{
				// Xóa kẻ thù
				Destroy( gameObject );

				// Làm cho người chơi nhảy
				motor.ForceJump();

				// ảnh rung
				var cameraShake = FindObjectOfType<CameraShaker>();

				// rung ảnh
				cameraShake.Shake();

				//  đối tượng  bị đập vỡ
				Instantiate( m_hitPrefab, transform.position, Quaternion.identity );

				//	Ckhi bị giết
				var audioSource = FindObjectOfType<AudioSource>();
				audioSource.PlayOneShot( m_hitClip );

				
				//  phát khi người chơi nhảy

				var player = other.GetComponent<Player>();
				player.IsSkipJumpSe = true;
			}
			//  người chơi không ngã
			else
			{
				
				var player = other.GetComponent<Player>();

				//  gọi khi người chơi bị giết
				player.Dead();
			}
		}
	}
}