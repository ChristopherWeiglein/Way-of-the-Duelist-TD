using UnityEngine;
using UnityEngine.EventSystems;

public class UnlockDeckSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int slotIndex;
    [SerializeField] private int starChipsRequired;
    [SerializeField] private int cardsRequired;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameObject.Find("Deckboxes").GetComponent<DeckEditorUnlockHandler>().TryUnlockSlot(slotIndex, starChipsRequired, cardsRequired))
            gameObject.SetActive(false);
    }
}
