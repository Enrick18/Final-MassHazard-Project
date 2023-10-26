using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickHandler : MonoBehaviour
{
    public Material highlightMaterial;
    public Material originalMaterial;
    public GameObject SelectedTile { get { return _selectedTile; } }
    public GameObject SelectedChildTile { get { return _selectedChildTile; } }
    private Renderer objectRenderer;
    private List<Renderer> cubeRenderers = new List<Renderer>();
    private GameObject _selectedTile;
    private GameObject _selectedChildTile;

    void Start()
    {
        int childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            cubeRenderers.Add(child.GetComponent<Renderer>());
        }
    }

    void GetRenderer(GameObject go)
    {
        // Get the Renderer component of the object
        objectRenderer = go.GetComponent<Renderer>();
        
    }

    private void Update()
    {

        if (Input.GetMouseButtonUp(0)) 
        {
            ResetObject();

            GameObject clickedObject = null;
            GameObject clickedChildObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Perform the raycast to detect the clicked object
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the collider hit belongs to a clickable object
                
                if(hit.collider.gameObject.tag == "Cube")
                {
                    clickedObject = hit.collider.gameObject;
                }

                if(hit.collider.gameObject.tag == "ChildCube")
                {
                    clickedChildObject = hit.collider.gameObject;
                }
            }

            if (clickedObject != null)
            {
                GetRenderer(clickedObject);
                
                HighlightObject();

                _selectedTile = clickedObject;
            }

            if(clickedChildObject != null)
            {
                _selectedChildTile = clickedChildObject;
            }
        }
    }

    void HighlightObject()
    {
        
        // Check if a highlight material is assigned
        if (highlightMaterial != null)
        {
            // Apply the highlight material to the object
            objectRenderer.material = highlightMaterial;
        }
        
    }

    void ResetObject()
    {
        foreach(Renderer renderer in cubeRenderers)
        {
            renderer.material = originalMaterial;

        }
        _selectedTile = null;
        _selectedChildTile = null;
    }
    
}
