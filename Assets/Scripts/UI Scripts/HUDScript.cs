using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDScript : MonoBehaviour
{
    int topScore;
    public Text topScoreText;
    public Text pointText;
    public Text healthText;
    public Text powerText;

    // Use this for initialization
    void Start()
    {
        topScore = PlayerPrefs.GetInt("TOP_SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
