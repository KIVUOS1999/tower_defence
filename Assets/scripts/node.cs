using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    public Color hovercolor;
    private Renderer rend;
    private Color startcolor;
    private GameObject turret;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if(turret!=null)
        {
            Debug.Log("Cannnot build here");
            return;
        }

        GameObject turrettobuild = game_manager.instance.GetTurrttobuild();
        turret = Instantiate(turrettobuild, new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z), transform.rotation);
    }
    void OnMouseEnter()
    {
        rend.material.color = hovercolor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
