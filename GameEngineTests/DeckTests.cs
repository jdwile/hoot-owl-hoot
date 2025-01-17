﻿using System.Collections.Generic;
using System.Linq;
using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngineTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void ShouldDrawFromBeginningOfDeck()
        {
            var deck = new Deck(2);
            var expectedCards = deck.Cards.GetRange(0, 2);

            var actualCards = deck.Draw(2);

            CollectionAssert.AreEqual(expectedCards, actualCards);
        }

        [TestMethod]
        public void ShouldRemoveDrawnCardsFromTheDeck()
        {
            var deck = new Deck(2);
            var deckSizeBefore = deck.Cards.Count;

            deck.Draw(3);

            var deckSizeAfter = deck.Cards.Count;
            Assert.AreEqual(deckSizeBefore - 3, deckSizeAfter);
        }

        [TestMethod]
        public void ShouldDrawFewerWhenDrawingTooMany()
        {
            var deck = new Deck(2);
            deck.Draw(deck.Cards.Count - 1);
            var theRestOfTheDeck = new List<CardType>(deck.Cards);

            var actualCardsDrawn = deck.Draw(1000);

            CollectionAssert.AreEqual(theRestOfTheDeck, actualCardsDrawn);
        }

        [TestMethod]
        public void ShouldDefaultTo28PercentSunCards()
        {
            var cards = new Deck(1).Cards;
            Assert.AreEqual(8, cards.Count);
            Assert.AreEqual(2, cards.Count(card => card == CardType.Sun));

            cards = new Deck(6).Cards;
            Assert.AreEqual(50, cards.Count);
            Assert.AreEqual(14, cards.Count(card => card == CardType.Sun));

            cards = new Deck(300).Cards;
            Assert.AreEqual(2500, cards.Count);
            Assert.AreEqual(700, cards.Count(card => card == CardType.Sun));
        }

        [TestMethod]
        public void ShouldAcceptExplicitNumberOfSunCards()
        {
            var cards = new Deck(1, 0).Cards;
            Assert.AreEqual(6, cards.Count);
            CollectionAssert.DoesNotContain(cards, CardType.Sun);

            cards = new Deck(6, 1).Cards;
            Assert.AreEqual(37, cards.Count);
            Assert.AreEqual(1, cards.Count(card => card == CardType.Sun));

            cards = new Deck(300, 800).Cards;
            Assert.AreEqual(2600, cards.Count);
            Assert.AreEqual(800, cards.Count(card => card == CardType.Sun));
        }
    }
}
