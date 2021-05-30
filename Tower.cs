using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Towers")]
public class Tower : ScriptableObject
{
    new public string name = "New Tower";
    public Sprite icon = null;
    public GameObject tower;
}
