using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
	
	public GameObject m_playerHitPrefab;

	
	public AudioClip m_jumpClip;

	
	public AudioClip m_hitClip;

	// bỏ qua nhảy
	public bool IsSkipJumpSe;

	
	public void Dead()
	{
		// ẩn
		// Destroy 
		// OnRetry 
		// SetActive  Ẩn chức năng
		gameObject.SetActive( false );

		
		var cameraShake = FindObjectOfType<CameraShaker>();

		//
		cameraShake.Shake();

		// Thử lại sau 2 giây
		Invoke( "OnRetry", 2 );

		// Tạo đối tượng  đánh bại của người chơi
		Instantiate
		(
			m_playerHitPrefab,
			transform.position,
			Quaternion.identity
		);

		
		var audioSource = FindObjectOfType<AudioSource>();
		audioSource.PlayOneShot( m_hitClip );
	}

	// 
	private void OnRetry()
	{
		//Tải lại cảnh hiện tại và thử lại
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
	}

	// 
	private void Awake()
	{
		
		var motor = GetComponent<PlatformerMotor2D>();

		// gọi hàm khi nhảy
		motor.onJump += OnJump;
	}

	
	private void OnJump()
	{
		// bỏ qua nhay
		if ( IsSkipJumpSe )
		{
			// false
			IsSkipJumpSe = false;
		}
		
		else
		{
			// 
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot( m_jumpClip );
		}
	}
}