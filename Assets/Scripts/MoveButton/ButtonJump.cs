using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonJump : MonoBehaviour, IPointerDownHandler
{
    private PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.HandleMoveJump();
    }
}
