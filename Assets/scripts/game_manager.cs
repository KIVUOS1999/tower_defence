using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    private GameObject Turrettobuild;
    public static game_manager instance;
    public GameObject standard_turret;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Turrettobuild = standard_turret;

    }
    public GameObject GetTurrttobuild()
    {
        return Turrettobuild;
    }
}
