using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideDANO : MonoBehaviour
{
    public GameObject DanoPanel;
    public GameObject ImageTarget;

    public void HidePanel()
    {
        if (DanoPanel)
        {
            DanoPanel.SetActive(false);
        }
    }

    public void ShowPanel()
    {
        if (ImageTarget)
        {
            DanoPanel.SetActive(true);
        }
    }

}

