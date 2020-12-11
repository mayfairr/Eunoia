using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    /* NavBar */
    [Header("NavBar Elements")]
    public GameObject nav_simulation;
    public GameObject nav_database;
    public GameObject nav_settings;

    /* Main Sub Panels */
    [Header("Main Sub Panel Elements")]
    public GameObject crossfade;
    public GameObject start;


    int[] panels;
    public void Start()
    {
        //There are 3 Pannels
        panels = new int[3];
    }
    public void SelectDatabase()
    {
        //Since Database is the second element in the sequenetial array;
        panels[0] = 0;
        panels[1] = 1;
        panels[2] = 0;

        //play animation; stop all other animations
        nav_simulation.GetComponent<Animator>().SetBool("hasClicked", false);
        nav_database.GetComponent<Animator>().SetBool("hasClicked", true);
        nav_settings.GetComponent<Animator>().SetBool("hasClicked", false);

        //Stop Hovering
        nav_simulation.GetComponent<Animator>().SetBool("isHovering", false);
        nav_database.GetComponent<Animator>().SetBool("isHovering", false);
        nav_settings.GetComponent<Animator>().SetBool("isHovering", false);
        //show dataase pannel;

    }
    public void SelectSimulation()
    {
        //Since Database is the second element in the sequenetial array;
        panels[0] = 1;
        panels[1] = 0;
        panels[2] = 0;

        //play animation; stop all other animations
        nav_simulation.GetComponent<Animator>().SetBool("hasClicked", true);
        nav_database.GetComponent<Animator>().SetBool("hasClicked", false);
        nav_settings.GetComponent<Animator>().SetBool("hasClicked", false);

        //Stop Hovering
        nav_simulation.GetComponent<Animator>().SetBool("isHovering", false);
        nav_database.GetComponent<Animator>().SetBool("isHovering", false);
        nav_settings.GetComponent<Animator>().SetBool("isHovering", false);
        //show dataase pannel;

    }
    public void SelectSettings()
    {
        //Since Database is the second element in the sequenetial array;
        panels[0] = 0;
        panels[1] = 0;
        panels[2] = 1;

        //play animation; stop all other animations
        nav_simulation.GetComponent<Animator>().SetBool("hasClicked", false);
        nav_database.GetComponent<Animator>().SetBool("hasClicked", false);
        nav_settings.GetComponent<Animator>().SetBool("hasClicked", true);

        //Stop Hovering
        nav_simulation.GetComponent<Animator>().SetBool("isHovering", false);
        nav_database.GetComponent<Animator>().SetBool("isHovering", false);
        nav_settings.GetComponent<Animator>().SetBool("isHovering", false);
        //show dataase pannel;

    }

    public void HoverSimulation()
    {
        nav_simulation.GetComponent<Animator>().SetBool("isHovering", false);
        nav_database.GetComponent<Animator>().SetBool("isHovering", false);
        nav_settings.GetComponent<Animator>().SetBool("isHovering", false);
        if (panels[0] != 1) { nav_simulation.GetComponent<Animator>().SetBool("isHovering", true); }
    }
    public void UnHoverSimulation()
    {
        nav_simulation.GetComponent<Animator>().SetBool("isHovering", false);
        nav_database.GetComponent<Animator>().SetBool("isHovering", false);
        nav_settings.GetComponent<Animator>().SetBool("isHovering", false);
    }

    public void HoverDatabase()
    {
        nav_simulation.GetComponent<Animator>().SetBool("isHovering", false);
        nav_database.GetComponent<Animator>().SetBool("isHovering", false);
        nav_settings.GetComponent<Animator>().SetBool("isHovering", false);
        if (panels[1] != 1) { nav_database.GetComponent<Animator>().SetBool("isHovering", true); }
    }
    public void UnHoverDatabase()
    {
        nav_simulation.GetComponent<Animator>().SetBool("isHovering", false);
        nav_database.GetComponent<Animator>().SetBool("isHovering", false);
        nav_settings.GetComponent<Animator>().SetBool("isHovering", false);
    }

    public void HoverSettings()
    {
        nav_simulation.GetComponent<Animator>().SetBool("isHovering", false);
        nav_database.GetComponent<Animator>().SetBool("isHovering", false);
        nav_settings.GetComponent<Animator>().SetBool("isHovering", false);
        if (panels[2] != 1) { nav_settings.GetComponent<Animator>().SetBool("isHovering", true); }
    }
    public void UnHoverSettings()
    {
        nav_simulation.GetComponent<Animator>().SetBool("isHovering", false);
        nav_database.GetComponent<Animator>().SetBool("isHovering", false);
        nav_settings.GetComponent<Animator>().SetBool("isHovering", false);
    }

    /* Main Panel */
    public void SelectStart()
    {
        print("123");
        StartCoroutine(loadMain());
    }

    IEnumerator loadMain()
    {
        print("Hello");
        crossfade.GetComponent<Animator>().SetBool("Crossfade", true);
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
