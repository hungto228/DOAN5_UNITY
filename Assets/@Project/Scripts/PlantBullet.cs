using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    public float m_speed = 2;
    public float m_lifetime = 2;
    public bool left;
    private void Start()
    {
        Destroy(gameObject, m_lifetime);
    }
    private void Update()
    {
        if(left)
        {
            transform.Translate(Vector2.left * m_speed * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.right * m_speed * Time.deltaTime);
        }
    }
}
