using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public GameObject m_hitPrefab;


    public AudioClip m_hitClip;


   
    [SerializeField]
    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());

    }

 
    //ham ban
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Player"))
        {
            var motor = other.GetComponent<PlatformerMotor2D>();

            // người chơi bị ngã
            if (motor.IsFalling())
            {
                // Xóa kẻ thù
                Destroy(gameObject);

                // Làm cho người chơi nhảy
                motor.ForceJump();

                // ảnh rung
                var cameraShake = FindObjectOfType<CameraShaker>();

                // rung ảnh
                cameraShake.Shake();

                //  đối tượng  bị đập vỡ
                Instantiate(m_hitPrefab, transform.position, Quaternion.identity);

                //	Ckhi bị giết
                var audioSource = FindObjectOfType<AudioSource>();
                audioSource.PlayOneShot(m_hitClip);


                //  phát khi người chơi nhảy

                var player = other.GetComponent<Player>();
                player.IsSkipJumpSe = true;
            }
            else
            {

                var player = other.GetComponent<Player>();


                player.Dead();
            }
        }
    }
}
