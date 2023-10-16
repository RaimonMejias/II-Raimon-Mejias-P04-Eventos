using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SphereScore : MonoBehaviour
{
    AudioSource source;
    CubeNotificator cubeNotificator;
    int sphereScore;

    // Start is called before the first frame update
    void Start()
    {
        cubeNotificator = GameObject.FindWithTag("green_cube").GetComponent<CubeNotificator>();
        cubeNotificator.OnAddScoreGroup1 += addScore;
        cubeNotificator.OnAddScoreGroup2 += addScore;
        sphereScore = 0;
        GetComponentInChildren<TMP_Text>().text = $"{sphereScore}";
    }

    void Update() {
        GetComponentInChildren<TMP_Text>().text = $"{sphereScore}";
    }

    void addScore(int score, GameObject sphere) { 
        sphereScore += score;
        source = sphere.GetComponent<AudioSource>();
        if (source != null) { source.Play(); }
        sphere.GetComponent<Renderer>().enabled = false; 
        sphere.GetComponent<Rigidbody>().detectCollisions = false; 
        Destroy(sphere, (source != null)? source.clip.length : 0);
    }

}
