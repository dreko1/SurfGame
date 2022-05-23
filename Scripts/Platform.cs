using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // start of the platform
    public Transform start;
    // end of the platform
    public Transform end;
    // all of the various obstacles that the player could encounter
    public GameObject[] obstacles; 

    public void ActivateRandomObstacle()
    {
        // first get rid of any already existing obstacles
        DeactivateAllObstacles();
        // get a random obstacle from our list of possible obstacles
        System.Random random = new System.Random();
        // activate the random obstacle
        obstacles[random.Next(0, obstacles.Length)].SetActive(true);
    }

    public void DeactivateAllObstacles()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
    }
}