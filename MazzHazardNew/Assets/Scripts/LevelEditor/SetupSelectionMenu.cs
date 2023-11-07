using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SetupSelectionMenu : MonoBehaviour
{
    [SerializeField] private GameObject selectionMenu;
    private ObjectClickHandler clickHandler;
    private SelectionMenu menu;

   
    private void Start()
    {
        clickHandler = GetComponent<ObjectClickHandler>();
        menu = selectionMenu.GetComponent<SelectionMenu>();
    }

    private void Update()
    {
        if (clickHandler.SelectedTile != null)
        {
            menu.EnableButtons();
           
        }
        else
        {
            menu.DisableButtons();
        }

        if (clickHandler.SelectedChildTile != null)
        {
            menu.EnableRemoveButton();

        }
        else
        {
            menu.DisableRemoveButton();
        }
        menu.selectedCube = clickHandler.SelectedTile;
        menu.selectedChildCube = clickHandler.SelectedChildTile;
    }
}
