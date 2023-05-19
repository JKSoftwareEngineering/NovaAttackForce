using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShoot : MonoBehaviour
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player.GetComponent<Movement>().f_timerCheck > 0)
        {
            player.GetComponent<Movement>().f_timerCheck -= .2f;
            player.GetComponent<Movement>().shoot = true;
        }
    }
}
