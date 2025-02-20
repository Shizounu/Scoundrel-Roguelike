using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

namespace Cards
{
    [CreateAssetMenu(fileName = "new Deck", menuName = "Cards/Deck")]
    public class Deck : ScriptableObject
    {
        public List<BaseCard> Cards;

        public List<BaseCard> GetShuffledDeck()
        {
            List<BaseCard> list = new(Cards);

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
            return list;
        }

        public void Shuffle()
        {
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                (Cards[n], Cards[k]) = (Cards[k], Cards[n]);
            }
        }

        public BaseCard DrawCard()
        {
            BaseCard temp = Cards[0];
            Cards.RemoveAt(0);
            return temp;
        }
    }
}
