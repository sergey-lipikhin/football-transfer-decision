using System;
using System.Collections.Generic;

namespace TransferMarketApp.ViewModels.PagesVM.PlayerBoardVM.PlayerRatingTypes
{
    public abstract class PlayerRatingItem : ViewModelBase
    {
        public const int FEATURES_START = 4;
        public const int FEATURES_END = 32;

        public const int PRICE = 0;

        public const int INTERNATIONAL_REPUTATION = 1;
        public const int SKILL_MOVES = 2;
        public const int WEAK_FOOT = 3;

        public abstract int Value { set; get; }
        public abstract string Name { set; get; }
        public abstract string Description { set; get; }

        public abstract void Reset();


        protected Dictionary<int, (string, string)> RatingInfo = new Dictionary<int, (string, string)>()
        {
            [1] = ("International reputation", "a way to boost player's overall depending on his popularity IRL"),
            [2] = ("Skill moves", "separate decent players from great ones"),
            [3] = ("Weak foot", "specifies the shot power and ball control for the other foot of that player than his preferred"),

            [4] = ("Potential", "maximum overall rate that player can reach"),

            [5] = ("Crossing", "player's speed in walking and running"),
            [6] = ("Finishing", "the scoring ability of a player"),
            [7] = ("Heading Accuracy", "player's accuracy when using the head to pass, shoot or clear the ball"),
            [8] = ("Short Passing", "player's accuracy for the short passes"),
            [9] = ("Volleys", "player's ability for performing volleys"),

            [10] = ("Dribbling", "player's ability to carry the ball and past an opponent while being in control"),
            [11] = ("Curve", "player's ability to curve the ball"),
            [12] = ("Free Kick Accuracy", "player's accuracy for taking the Free Kicks"),
            [13] = ("Long Passing", "player's accuracy for the long and aerial passes"),
            [14] = ("Ball Control", "the ability of a player to control the ball"),

            [15] = ("Acceleration", "the increment of a player's running speed on the pitch"),
            [16] = ("Sprint Speed", "speed rate of a player's sprinting"),
            [17] = ("Agility", "the speed and the grace of a player in term of the ball control"),
            [18] = ("Reactions", "the acting speed of a player in response to the situations happening around them"),
            [19] = ("Balance", "the even distribution of enabling a player to remain upright and steady"),

            [20] = ("Shot Power", "the strength of a player's shootings"),
            [21] = ("Jumping", "player's ability and the quality for jumping from the surface for headers"),
            [22] = ("Stamina", "player's ability to sustain prolonged physical or mental effort in a match"),
            [23] = ("Strength", "the quality or state of being physically strong of a player"),
            [24] = ("Long Shots", "player's accuracy for the shots taking from long distances"),

            [25] = ("Aggression", "the aggression level of a player when they do push/pull and tackle"),
            [26] = ("Interceptions", "player's capability to catch the opposing team's passes"),
            [27] = ("Positioning", "how well a player is able to perform the positioning on the field"),
            [28] = ("Vision", "player's mental awareness about his teammates' positioning, for passing the ball to them"),
            [29] = ("Penalties", "player's accuracy for the shots taking from the penalty kicks"),
            [30] = ("Composure", "determines at what distance the player with the ball starts feeling the pressure from the opponent"),

            [31] = ("Defending", "player's ability to defend")
        };

        protected int ConvertRating(double rating)
        {
            try
            {
                return Convert.ToInt32(rating);
            }
            catch
            {
                return 100;
            }
        }
    }
}
