using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
