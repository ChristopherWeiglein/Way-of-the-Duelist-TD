using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChainLinkVisualisation : MonoBehaviour
{
    [SerializeField] private GameObject chainLinkPrefab;
    public List<GameObject> chain = new();

    public void AddChainLink(CardData cardData)
    {
        GameObject chainLink =  Instantiate(chainLinkPrefab, transform.position, Quaternion.identity, gameObject.transform);
        chain.Add(chainLink);
        chainLink.GetComponentInChildren<Image>().sprite = cardData.GetCardInfo().sprite;
        chainLink.GetComponentInChildren<TMP_Text>().text = cardData.GetCardInfo().cardName;
    }

    public void RemoveChainLink(int position)
    {
        Destroy(chain[position]);
        chain.RemoveAt(position);
    }
}
