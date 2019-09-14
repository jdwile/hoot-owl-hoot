﻿using System.Collections.Generic;

namespace GameEngine.Players
{
    public abstract class Player : IPlayer
    {
        public List<CardType> Hand { get; private set; }

        public Player()
        {
            Hand = new List<CardType>();
        }

        public void AddCardsToHand(List<CardType> cards)
        {
            Hand.AddRange(cards);
        }

        public void Discard(CardType card)
        {
            Hand.Remove(card);
        }

        public abstract CardType SelectCardToPlay(GameBoard board);

        public bool HandContainsSun()
        {
            return Hand.Contains(CardType.Sun);
        }
    }
}
