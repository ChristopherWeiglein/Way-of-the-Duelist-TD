using MemoryPack;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDataTypes
{
    public static List<MonsterTags> extraDeckTags = new List<MonsterTags>() { MonsterTags.Fusion, MonsterTags.Synchro, MonsterTags.Xyz, MonsterTags.Link };
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

    public enum SpellType
    {
        Normal,
        QuickPlay,
        Equip,
        Field,
        Continous,
        Ritual
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
        Tuner
    }

    public enum CardTags
    {
        UsedAsTribute,
        ActivatedSpellCard,
        UsedAsFusionMaterial,
        SentFromField,
        SentFromDeck,
        SentFromHand,
        DestroyedByBattle,
        DestroyedByCardEffect,
        SentAsCost
    }

    [Serializable]
    public partial struct MonsterInfo
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
    public partial struct CardInfo
    {
        public string cardName;
        [TextArea(1,100)]public string cardText;
        public Sprite sprite;
        public CardType cardType;
    }
}
