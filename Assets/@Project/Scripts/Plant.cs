using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private float m_waitedTime;
    public float m_waitimeToAttack = 3;
    public Animator anim;
    public GameObject bullet;
    public Transform launchSpawnPoint;
    private void Start()
    {
        m_waitedTime = m_waitimeToAttack;
    }
    private void Update()
    {
        if (m_waitedTime <= 0)
        {
            m_waitedTime = m_waitimeToAttack;
            anim.Play("Attack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            m_waitedTime -= Time.deltaTime;
        }
    }
    public void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bullet, launchSpawnPoint.position,launchSpawnPoint.rotation);
    }
}
