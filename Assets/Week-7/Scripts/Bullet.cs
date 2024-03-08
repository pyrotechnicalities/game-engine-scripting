using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float m_Speed;

    private void Awake()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * m_Speed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
