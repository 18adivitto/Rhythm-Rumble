using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuTransitions : MonoBehaviour
{

    public static int MenuType;

    public static bool subMenuActive = false;


    public Image[] subMenus;

    // Start is called before the first frame update
    void Start()
    {
        MenuType = 999;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return) && !subMenuActive)
        {
            MenuType = OptionScroller.selectedOption;
            subMenuActive = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuType = 999;
            subMenuActive = false;
        }

        SubMenuTransition();
        SubMenuOptionsDisplay(MenuType);

        if (Input.GetKeyDown(KeyCode.Return) && subMenuActive)
        {
            SubMenuInputs(MenuType);
        }
    }

    void SubMenuInputs(int SubMenu)
    {
        if (SubMenu == 0)
        {
            SceneManager.LoadScene("PlayerTesting");
        }
    }

    void SubMenuTransition()
    {
        if (subMenuActive)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,90,0), Time.deltaTime * 25);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 25);
        }
    }

    void SubMenuOptionsDisplay(int SubMenu)
    {
        if (SubMenu == 999)
        {
            subMenuActive = false;
            foreach (Image menu in subMenus)
            {
                menu.transform.localPosition = Vector3.Lerp(menu.transform.localPosition, new Vector3(-600, 0, 0), Time.deltaTime * 10);
            }
        }
        else if (SubMenu == 0)
        {
            subMenus[0].transform.localPosition = Vector3.Lerp(subMenus[0].transform.localPosition, new Vector3(-150, 0, 0), Time.deltaTime * 10);
        }
        else if (SubMenu == 1)
        {

        }
        else if (SubMenu == 2)
        {

        }
        else if (SubMenu == 3)
        {

        }
        else
        {
            foreach (Image menu in subMenus)
            {
                menu.transform.localPosition = Vector3.Lerp(menu.transform.localPosition, new Vector3(-600,0,0), Time.deltaTime * 10);
            }
        }
    }
}
