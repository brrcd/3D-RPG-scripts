using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : MonoBehaviour
{
    public static MainBuilding instance;

    private void Awake()
    {
        instance = this;
    }
}
