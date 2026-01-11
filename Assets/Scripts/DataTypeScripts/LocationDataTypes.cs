using UnityEngine;

public class LocationDataTypes
{
    public enum CardLocation
    {
        Banishment,
        Deck,
        ExtraDeck,
        Field,
        Graveyard,
        Hand
    }

    public struct CardLocationData
    {
        public GameObject gameObject;
        public CardData cardData;
        public CardLocation cardLocation;
    }
}
