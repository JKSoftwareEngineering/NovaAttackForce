using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBomb : MonoBehaviour
{
    public Vector2 direction = new Vector2(0, 1);
    public float speed = 3;
    public Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.deltaTime;

        transform.position = pos;
    }

    public void Activate()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < asteroids.Length; i++)
        {
            Destroy(asteroids[i]);
        }
    }
}
