using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseHoverBehaviour : MonoBehaviour
{
    private string buttonName = "ButtonNotWorking";

    void Start()
    {
        buttonName = this.GetComponent<Text>().text;
    }

    public void HoverIconActive(bool active)
    {
        if (active)
            GetComponent<Text>().text = "~ " + buttonName + " ~";
        else if (!active)
            GetComponent<Text>().text = buttonName;
    }

}
