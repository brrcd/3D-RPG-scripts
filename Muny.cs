using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Muny : MonoBehaviour
{
    public int currentMuny;

    [SerializeField] TextMeshProUGUI munyText;

    public static Muny instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentMuny = 0;
    }

    private void Update()
    {
        munyText.text = currentMuny.ToString();
    }
}
