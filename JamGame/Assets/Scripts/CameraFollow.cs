using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private CinemachineVirtualCamera cam;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        cam.Follow = player.transform;
    }
}
