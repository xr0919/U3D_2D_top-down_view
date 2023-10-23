using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC2 : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public AudioSource musicSource;
    public Transform mask;

    public float maxDistance = 3.08f;
    public float minBPM = 60f;
    public float maxBPM = 120f;
    public float minMaskScale = 1f;
    public float maxMaskScale = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && target != null && musicSource != null)
        {
            float distance = Vector3.Distance(player.position, target.position);
            //Debug.Log(distance);
            float t = 1 - Mathf.Clamp01(distance / maxDistance);
            float bpm = Mathf.Lerp(minBPM, maxBPM, t);
            musicSource.pitch = bpm / minBPM;

            // Adjust mask scale
            float maskScale = Mathf.Lerp(minMaskScale, maxMaskScale, t);
            mask.localScale = new Vector3(maskScale, maskScale, 1);
        }
    }
}
