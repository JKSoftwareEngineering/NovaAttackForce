using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject shield;
    public GameObject wepon;
    public GameObject point;
    public GameObject bomb;
    private float spawnTime = 0.0f;
    public float period = 10.0f;
    public float splitterChance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        restartTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            spawnTime += period;
            Vector2 vec = new Vector2(0, -1.0f);
            vec = vec.normalized;
            float xPos = (Random.Range(-5.0f, 5.0f));
            spawnPowerup(vec, xPos);
        }

    }

    public void spawnPowerup(Vector2 direction, float xPos)
    {
        Vector3 position = transform.position;
        position.x = xPos;
        position.y = 6;

        int i_whatPowerup = 3;

        i_whatPowerup = (int)Random.Range(0.0f, 4.0f);

        switch(i_whatPowerup)
        {
            case 0:
                {
                    GameObject bo = Instantiate(shield, position, Quaternion.identity);
                    PowerupShield bob = bo.GetComponent<PowerupShield>();
                    bob.direction = direction;
                }
                break;
            case 1:
                {
                    GameObject bo = Instantiate(bomb, position, Quaternion.identity);
                    PowerupBomb bob = bo.GetComponent<PowerupBomb>();
                    bob.direction = direction;
                }
                break;
            case 2:
                {
                    GameObject bo = Instantiate(point, position, Quaternion.identity);
                    PowerupScore bob = bo.GetComponent<PowerupScore>();
                    bob.direction = direction;
                }
                break;
            default:
                {
                    GameObject bo = Instantiate(wepon, position, Quaternion.identity);
                    PowerupShoot bob = bo.GetComponent<PowerupShoot>();
                    bob.direction = direction;
                }
                break;
        }

        // GameObject bo = Instantiate(shield, position, Quaternion.identity);
        // PowerupShield bob = bo.GetComponent<PowerupShield>();
        // bob.direction = direction;

        //float rand = Random.Range(0.0f, 1.0f)

        //if (<= splitterChance)
        //{
        //    GameObject bo = Instantiate(asteroidSplitter, position, Quaternion.identity);
        //    AsteroidSplitter bob = bo.GetComponent<AsteroidSplitter>();
        //    bob.direction = direction;
        //}
        //else
        //{
        //    GameObject bo = Instantiate(asteroid, position, Quaternion.identity);
        //    Asteroid bob = bo.GetComponent<Asteroid>();
        //    bob.direction = direction;
        //}
        //else
        //{
        //    GameObject bo = Instantiate(asteroid, position, Quaternion.identity);
        //    Asteroid bob = bo.GetComponent<Asteroid>();
        //    bob.direction = direction;
        //}
        //else
        //{
        //    GameObject bo = Instantiate(asteroid, position, Quaternion.identity);
        //    Asteroid bob = bo.GetComponent<Asteroid>();
        //    bob.direction = direction;
        //}
    }

    public void restartTime()
    {
        spawnTime = Time.time;
    }
}
