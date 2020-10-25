using UnityEngine;
using UnityEngine.SceneManagement;

// 
public class Goal : MonoBehaviour
{
	// 
	public GameObject m_transition;

	public AudioClip m_goalClip;


	// 
	private bool m_isGoal;


    private void OnTriggerEnter2D( Collider2D other )
	{
		// chưa đạt được mục tiêu
		if ( !m_isGoal )
		{
			
			if ( other.name.Contains( "Player" ))
			{
				//
				var cameraShake = FindObjectOfType<CameraShaker>();

				
				cameraShake.Shake();

				// đã đạt mục tiêu
				m_isGoal = true;

				
				var animator = GetComponent<Animator>();

				// load khi dạt mục tiêu
				animator.Play( "Pressed" );
				
				Debug.Log("gold");
				var audioSource = FindObjectOfType<AudioSource>();
				audioSource.PlayOneShot( m_goalClip );

				m_transition.SetActive(true);

			
				
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


			}
		}
	}
}