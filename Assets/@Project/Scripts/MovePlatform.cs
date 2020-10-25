using UnityEngine;


public class MovePlatform : MonoBehaviour
{
	// Khoảng cách di chuyển 
	public Vector3 m_distance = new Vector3( 5, 0, 0 );


	public float m_speed = 0.5f;

	// Vị trí bắt đầu
	private Vector3 m_startPosition;

	// Vị trí kết thúc
	private Vector3 m_endPosition;

	
	private void Awake()
	{
		//  vị trí hiện tại là vị trí bắt đầu
		m_startPosition = transform.localPosition;

		// Đặt vị trí kết thúc từ vị trí bắt đầu và khoảng cách di chuyển
		m_endPosition = m_startPosition + m_distance;
	}

	
	private void Update()
	{
		// Tính vị trí hiện tại
		var t           = Mathf.PingPong( Time.time * m_speed, 1 );
		var newPosition = Vector3.Lerp( m_startPosition, m_endPosition, t );

		// tạo vịt trí hiẹn ttai
		transform.localPosition = newPosition;
	}
}