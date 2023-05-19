using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] powerups = GameObject.FindGameObjectsWithTag("Powerup");

        GameObject[] shots = GameObject.FindGameObjectsWithTag("Bullet");

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject shield = GameObject.FindGameObjectWithTag("Shield");

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < shots.Length; i++)
        {

            for (int j = 0; j < enemies.Length; j++)
            {

                if (AABBCollision(shots[i], enemies[j]))
                {

                    Destroy(shots[i]);

                    Destroy(enemies[j]);
                }

            }


        }

        for (int j = 0; j < enemies.Length; j++)
        {
            if (shield != null)
            {
                if (AABBCollision(shield, enemies[j]))
                {
                    Destroy(shield);
                    Destroy(enemies[j]);
                }

            }


            if (AABBCollision(player, enemies[j]))
            {

                Destroy(player);

                Destroy(enemies[j]);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }


        for (int j = 0; j < powerups.Length; j++)
        {

            if (AABBCollision(player, powerups[j]))
            {
                GameObject bo = powerups[j];
                if (bo.GetComponent<PowerupShield>())
                {
                    PowerupShield bob = bo.GetComponent<PowerupShield>();
                    bob.Activate();
                    Destroy(powerups[j]);
                }
                else if (bo.GetComponent<PowerupBomb>())
                {
                    PowerupBomb bob = bo.GetComponent<PowerupBomb>();
                    bob.Activate();
                    Destroy(powerups[j]);
                }
                else if (bo.GetComponent<PowerupScore>())
                {
                    PowerupScore bob = bo.GetComponent<PowerupScore>();
                    bob.Activate();
                    Destroy(powerups[j]);
                }
                else if (bo.GetComponent<PowerupShoot>())
                {
                    PowerupShoot bob = bo.GetComponent<PowerupShoot>();
                    bob.Activate();
                    Destroy(powerups[j]);
                }
            }

        }


        for (int i = 0; i < shots.Length; i++)
        {

            for (int j = 0; j < enemies.Length; j++)
            {

                if (AABBCollision(shots[i], enemies[j]))
                {

                    Destroy(shots[i]);

                    Destroy(enemies[j]);
                }

            }


        }



    }

    public bool AABBCollision(GameObject A, GameObject B)
    {

        Vector3 aMin = A.GetComponent<SpriteRenderer>().bounds.min;
        Vector3 aMax = A.GetComponent<SpriteRenderer>().bounds.max;

        Vector3 bMin = B.GetComponent<SpriteRenderer>().bounds.min;
        Vector3 bMax = B.GetComponent<SpriteRenderer>().bounds.max;

        if (bMin.x < aMax.x && bMax.x > aMin.x && bMin.y < aMax.y && bMax.y > aMin.y)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


}
