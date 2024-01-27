using System.Collections.Generic;
using UnityEngine;

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

    public void ManageSlots()
    {
        for (int i = Slots.Count - 1; i > 0; i--)
        {
            if (Slots[i].childCount == 0)
            {
                for (int j = 0; j < i; j++)
                {

                    //Slots[j].transform.Add = Slots[j + 1].GetChild(0);
                }
            }
        }
    }
}
