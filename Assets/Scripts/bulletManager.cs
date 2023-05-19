using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    public Bullet bullet;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = (transform.localRotation * Vector2.up);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject bo = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet bob = bo.GetComponent<Bullet>();
        bob.direction = direction;
    }
}
