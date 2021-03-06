﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//shares namespace with program.cs
//designing this class to also be used with other card games even

namespace Casino
{
    public struct Card               //make struct public to use in other parts of the program *IMPORTANT* *Can't be null or inherited(struct)
    {

        public Suit Suit { get; set; }   //we made an class called "Suit" that you can get or set as spades, hearts, clubs, diamonds
        public Face Face { get; set; }   //set sets a variable to it such as king, queen, jack, 2, 10, etc.
                                         //**Not an object. set creates an object from the class
        public override string ToString()
        {
            return string.Format("{0} of {1}", Face, Suit);
        }
    }

    public enum Suit
    {
        Clubs, Diamonds,   //Clubs underLyingValue = 0, spades = 3 unless designated like Clubs=100;  Suit is a set of enums
        Hearts, Spades
    }
    public enum Face
    {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
        Jack, Queen, King, Ace
    }
}
