using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject asteroidSplitter;
    private float spawnTime = 0.0f;
    public float period = 0.5f;
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
            float xLean = (Random.Range(-2.0f, 2.0f));
            Vector2 vec = new Vector2(xLean, -1.0f);
            vec = vec.normalized;
            float xPos = (Random.Range(-5.0f, 5.0f));
            spawnAsteroid(vec, xPos);
        }

    }

    public void spawnAsteroid(Vector2 direction, float xPos)
    {
        Vector3 position = transform.position;
        position.x = xPos;

        if (Random.Range(0.0f, 1.0f) <= splitterChance)
        {
            GameObject bo = Instantiate(asteroidSplitter, position, Quaternion.identity);
            AsteroidSplitter bob = bo.GetComponent<AsteroidSplitter>();
            bob.direction = direction;
        }
        else
        {
            GameObject bo = Instantiate(asteroid, position, Quaternion.identity);
            Asteroid bob = bo.GetComponent<Asteroid>();
            bob.direction = direction;
        }
    }

    public void restartTime()
    {
        spawnTime = Time.time;
    }
}
