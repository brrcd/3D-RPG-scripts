using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeGridCell : MonoBehaviour
{
    BasicUI basicUI;

    public bool isFree = true;
    public GameObject towersMenu;

    private Camera mainCamera;

    private void Start()
    {
        basicUI = BasicUI.instance;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (basicUI.isBuildMode)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.gameObject.CompareTag("Build mode grid cell"))
                    {
                        towersMenu.SetActive(!towersMenu.activeSelf);
                        TowersMenu.instance.SelectGridCell(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
