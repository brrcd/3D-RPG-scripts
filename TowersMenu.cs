using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersMenu : MonoBehaviour
{
    public static TowersMenu instance;
    public GameObject selectedBuildModeGridCell;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of Towers menu found!");
            return;
        }

        instance = this;
    }

    public void SelectGridCell(GameObject newGridCell)
    {
        selectedBuildModeGridCell = newGridCell;
    }
}
