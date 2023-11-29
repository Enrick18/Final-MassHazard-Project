using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    private Outline currentOutline;

    private void Start()
    {
        // Disable any existing outlines on start
        DisableCurrentOutline();
    }

    public void OnButtonClick(Button clickedButton)
    {
        // Disable the outline of the previous button
        DisableCurrentOutline();

        // Enable the outline for the newly clicked button
        EnableOutline(clickedButton);
    }

    private void EnableOutline(Button button)
    {
        // Get or add an Outline component to the button
        Outline outline = button.GetComponent<Outline>();
        if (outline == null)
        {
            outline = button.gameObject.AddComponent<Outline>();
        }

        // Customize the outline settings as needed
        outline.effectColor = Color.yellow;
        outline.effectDistance = new Vector2(6f, 6f);

        // Set the currentOutline to the new outline
        currentOutline = outline;
    }

    private void DisableCurrentOutline()
    {
        // Disable the outline of the previous button
        if (currentOutline != null)
        {
            Destroy(currentOutline);
            currentOutline = null;
        }
    }

}
