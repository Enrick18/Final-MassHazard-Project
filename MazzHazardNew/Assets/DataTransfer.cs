using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DataTransfer : MonoBehaviour
{
    public TMP_InputField inputField;
    public MapData mapName;

    public void LoadCustomMap()
    {
        if (inputField.text.Equals("")) 
        {
            return;
        }
        else
        {
            mapName.mapName = inputField.text;
            SceneManager.LoadSceneAsync("CustomLevel");
        }
       
    }
}
