using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public static int pointCount;
    void Start()
    {
        pointCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "X " + pointCount.ToString();
    }
}
