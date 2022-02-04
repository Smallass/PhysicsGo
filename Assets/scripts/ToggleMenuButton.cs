using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenuButton : MonoBehaviour
{
    public GameObject MenuButton;
    private void Start()
    {
        //Скрыть кнопку
    }
    public void ShowButton()
    {
        if(MenuButton)
        {
            MenuButton.SetActive(true);
        }
    }
    public void HideButton()
    {
        if (MenuButton)
        {
            MenuButton.SetActive(false);
        }
    }
}
