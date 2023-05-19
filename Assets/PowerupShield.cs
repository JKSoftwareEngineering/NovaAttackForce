using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShield : MonoBehaviour
{
    public Vector2 direction = new Vector2(0, 1);
    public float speed = 3;
    public Vector2 velocity;
    public GameObject shield;
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
        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;

        GameObject bo = Instantiate(shield, position, Quaternion.identity);
        //PowerupShield bob = bo.GetComponent<PowerupShield>();
    }
}

