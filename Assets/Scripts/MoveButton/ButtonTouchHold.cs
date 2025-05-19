using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTouchHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayerController playerController;

    public enum ButtonType { Left, Right }
    public ButtonType buttonType;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonType == ButtonType.Right)
        {
            playerController.isPressedButtonRight = true;
        }
        else if (buttonType == ButtonType.Left)
        {
            playerController.isPressedButtonLeft = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonType == ButtonType.Right)
        {
            playerController.isPressedButtonRight = false;
        }
        else if (buttonType == ButtonType.Left)
        {
            playerController.isPressedButtonLeft = false;
        }
    }
}
