using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] private List<RectTransform> Slots;

    public void PlaceNewCard(Transform card)
    {

        var slot = GetFurthestSlot();

        if (slot == null)
        {
            Destroy(card.gameObject);
            return;
        }

        card.SetParent(slot);
        card.GetComponent<Card>().MoveToPosition(slot.position);
    }

    public RectTransform? GetFurthestSlot()
    {
        for (int i = Slots.Count - 1; i >= 0; i--)
        {
            if (Slots[i].childCount == 0)
            {
                return Slots[i];
            }
        }

        return null;
    }

    public void ToggleCards(bool isEnabled)
    {
        foreach (var slot in Slots)
        {
            if (slot.childCount > 0)
            {
                slot.GetChild(0).GetComponent<Button>().interactable = isEnabled;
            }
        }
    }

    public void RemoveAllCards()
    {
        foreach (var slot in Slots)
        {
            if (slot.childCount > 0)
            {
                slot.GetChild(0).GetComponent<Animator>().SetBool("Remove", true);
            }
        }
    }
}
