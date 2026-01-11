using System.Collections.Generic;
using UnityEngine;

public class SpellGraveyardCardInfo : InfoRoot, IGraveyardCard, ISpellCard
{
    public List<CardDataTypes.CardTags> cardTags { get; set; }
}
