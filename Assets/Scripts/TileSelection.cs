using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class TileSelection : MonoBehaviour
{
    private Color org_color;
    [SerializeField] Color highlight_color;
    [SerializeField] TextMeshProUGUI txt,panel_txt;
    [SerializeField] GameObject panel;
    Vector3 desiredScale = Vector3.zero;
    [SerializeField] float transSpeed;
    GameObject player;
    
    

    private void Start()
    {
        org_color = GetComponent<Renderer>().material.color;
        //txt = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        panel.SetActive(false);
        
    }
    
   
    private void OnMouseEnter()
    {
            GetComponent<Renderer>().material.color = highlight_color;
            txt.text = gameObject.name;
   

    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = org_color;
        txt.text = "";
    }
    private void OnMouseDown()
    {
        bool x = IsMouseOverUI();
        Debug.Log("isnotUI : " +!x);
        if (!x)
        {

            if (panel.activeInHierarchy)
            {
                panel.SetActive(false);

            }
            else
            {
                Debug.Log("Entered");

                allPanelDisable();
                panel.SetActive(true);
                panel_txt.text = "(" + gameObject.name + ")";

            }
        }
    }


    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    void allPanelDisable()
    {
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        foreach (GameObject go in panels)
        {
            go.SetActive(false);
        }
    }

    public void OnJump()
    {

            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = gameObject.transform.position;
            panel.SetActive(false);

    }
    
}
