using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArrowNavigation : MonoBehaviour
{
    public Button button1;
    public Button button2;
    private int selectedIndex = 0;
    private Button[] buttons;
    private RectTransform arrow;

    void Start()
    {
        buttons = new Button[] { button1, button2 };
        arrow = GetComponent<RectTransform>();
        UpdateArrowPosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            selectedIndex = (selectedIndex == 0) ? 1 : 0;
            UpdateArrowPosition();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            selectedIndex = (selectedIndex == 1) ? 0 : 1;
            UpdateArrowPosition();
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            buttons[selectedIndex].onClick.Invoke();
        }
    }

    void UpdateArrowPosition()
    {
        if (arrow != null && buttons[selectedIndex] != null)
        {
            Vector3 buttonPosition = buttons[selectedIndex].GetComponent<RectTransform>().anchoredPosition;
            arrow.anchoredPosition = new Vector3(buttonPosition.x - 125, buttonPosition.y, 0);
        }
    }
}