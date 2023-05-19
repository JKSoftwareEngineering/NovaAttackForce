using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSplitter : MonoBehaviour
{

    public Vector2 direction = new Vector2(0, 1);
    public float speed = 3;
    public Vector2 velocity;
    public GameObject fragment;
    public int fragCount = 4;

    private GameObject[] fragments;
    private bool hasSplit = false;
    // Start is called before the first frame update
    void Start()
    {
        fragments = new GameObject[fragCount];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 3 && !hasSplit)
        {
            for(int i = 0; i < fragCount; i++)
            {
                fragments[i] = Instantiate(fragment, new Vector2(transform.position.x - (fragCount / 2) + i, transform.position.y), Quaternion.identity);
                fragments[i].GetComponent<AsteroidSplitterFrag>().direction = (new Vector2(Random.Range(-2.0f, 2.0f), -1.0f)).normalized;
            }
            hasSplit = true;
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
}
