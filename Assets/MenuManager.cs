using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public int frames = 0;
    public static MenuManager instance;
    public bool menuOpen = false;
    public bool statsOpen = false;
    public GameObject playerMenu;
    public GameObject statsMenu;
    public Button autoSelected;

    public Scrollbar MoralityBar;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayerMenuToggle();
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames % 30 == 0)
        {
            moralityCheck();
        }
    }

    public void PlayerMenuToggle()
    {
        if (menuOpen)
        {
            autoSelected = playerMenu.transform.GetChild(0).GetComponent<Button>();
            playerMenu.SetActive(true);
            autoSelected.Select();
        }
        else
        {
            playerMenu.SetActive(false);
            statsMenu.SetActive(false);
            statsOpen = false;
        }
    }
    public void StatsMenuToggle()
    {
        switch (statsOpen)
        {
            case false:
                statsOpen = true;
                break;
            case true:
                statsOpen = false;
                break;
        }

        if (statsOpen)
        {
            autoSelected = statsMenu.transform.GetChild(0).GetComponent<Button>();
            statsMenu.SetActive(true);
            autoSelected.Select();
        }
        else
        {
            autoSelected = playerMenu.transform.GetChild(0).GetComponent<Button>();
            autoSelected.Select();
            statsMenu.SetActive(false);
        }
    }

    public void moralityCheck()
    {
        MoralityBar.value = playerthing.instance.morality/100;
    }

}
