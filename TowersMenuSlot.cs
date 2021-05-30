using UnityEngine.UI;
using UnityEngine;

public class TowersMenuSlot : MonoBehaviour
{
    public GameObject towerGameObject; // dummy tower for test
    public Image icon;

    private GameObject gridCell;
    private TowersMenu towersMenu;

    private void Start()
    {
        towersMenu = TowersMenu.instance;
    }

    private void Update()
    {
        gridCell = towersMenu.selectedBuildModeGridCell;
    }

    public void PlaceTower()
    {
        if (towerGameObject != null && gridCell.GetComponent<BuildModeGridCell>().isFree)
        {
            Instantiate(towerGameObject,
                gridCell.transform.position,
                gridCell.transform.rotation);
            gridCell.GetComponent<BuildModeGridCell>().isFree = false;
        } else
        {
            Debug.Log("there is tower");
        }
    }
}
