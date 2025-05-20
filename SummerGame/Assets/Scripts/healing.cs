using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class healing : MonoBehaviour
{
    [SerializeField] GameObject speechbubble;
    [SerializeField] GameObject player;

    public Animation popIn;


    void Start()
    {
        player = GameObject.Find("/Player");
        speechbubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SpeechAnim();
    }

    void SpeechAnim()
    {
        if (Vector2.Distance(player.transform.position, gameObject.transform.position) < 5.0f)
        {
            speechbubble.SetActive(true);
        }
        else
        {
            speechbubble.SetActive(false);
        }
    }
    IEnumerator Popout()
    {
        yield return new WaitForSeconds(0.6f);
        speechbubble.SetActive(false);
    }
}
