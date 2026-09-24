using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class W3_UIManager : MonoBehaviour
{
    public GameObject winPanel;

    public void WinGame()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }
}
