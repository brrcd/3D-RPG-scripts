using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    private void OnEnable()
    {
        { instance = this; }
    }

    private void OnDisable()
    {
        { instance = null; }
    }
}

