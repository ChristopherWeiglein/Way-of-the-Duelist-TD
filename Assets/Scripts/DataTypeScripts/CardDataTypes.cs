using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDataTypes
{
    public enum CardType
    {
        Monster,
        Spell,
        Trap
    }
    public enum MonsterType
    {
        Aqua,
        Beast,
        BeastWarrior,
        Cyberse,
        Dinosaur,
        DivineBeast,
        Dragon,
        Fairy,
        Fiend,
        Fish,
        Insect,
        Illusion,
        Machine,
        Plant,
        Psychic,
        Pyro,
        Reptile,
        Rock,
        SeaSerpent,
        Spellcaster,
        Thunder,
        Warrior,
        WingedBeast,
        Wyrm,
        Zombie,
        None
    }

    public enum MonsterAttribute
    {
        Dark,
        Divine,
        Earth,
        Fire,
        Light,
        Water,
        Wind,
        None
    }

    public enum MonsterTags
    {
        Normal,
        Effect,
        Fusion,
        Synchro,
        Xyz,
        Pendulum,
        Link,
        Tuner,
        RedEyes,
        BlueEyes,
        Archfiend
    }

    public enum CardTags
    {
        UsedAsTribute,
        ActivatedSpellCard,
        UsedAsFusionMaterial,
        SentFromField
    }

    [Serializable]
    public struct MonsterInfo
    {
        public MonsterAttribute attribute;
        public MonsterType type;
        public int attack;
        public int defense;
        public int level;
        public int tributeCost;
        public List<MonsterTags> monsterTags;
    }

    [Serializable]
    public struct CardInfo
    {
        public string cardName;
        public string cardText;
        public Sprite sprite;
        public CardDataTypes.CardType cardType;
    }
}
