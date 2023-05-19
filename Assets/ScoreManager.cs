using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    // private float startTime = 0.0f;
    // private float scoreTime = 0.0f;

    [SerializeField] private GameObject g_ship;

    public float scoreScale = 1;

    private Transform t_ship;
    float f_scoreOut = 0.0f;
    float f_timer = 0;
    // position in the world being checked against
    float f_localGoal = 5;
    float f_localPosition;
    // Start is called before the first frame update
    void Start()
    {
        t_ship = g_ship.GetComponent<Transform>();
        // wherever the ship is at the start of the mission is the baseline
        if(t_ship.position.y < 0)
        {
            f_localPosition = t_ship.position.y * -1;
        }
        else
        {
            f_localPosition = t_ship.position.y;
        }
        
        // startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // hardcode position of y5 to offset 0 in the center of the scene
        float f_shipPositionY = t_ship.transform.position.y + f_localGoal;
        float f_scoreScale = (f_shipPositionY / 10.0f) * 100.0f;
        f_timer += (Time.deltaTime * f_scoreScale * scoreScale);

        // between step preserved in the event of later changes
        f_scoreOut = (int)f_timer;

        scoreText.text = "Score: " + f_scoreOut;

        // scoreTime = Mathf.Round((Time.time - startTime) * 100.0f);
        // scoreText.text = "Score: " + scoreTime;


    }
}
