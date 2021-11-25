using UnityEngine;

/// <summary>
/// Class to manage UI elements 
/// </summary>
public class UIController : MonoBehaviour
{
    //Panel to display control info
    public GameObject HelpPanel;

    private void Start()
    {
        HelpPanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            HelpPanel.SetActive(!HelpPanel.activeInHierarchy);
        }
    }
}
