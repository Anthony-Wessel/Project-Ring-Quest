using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class ProbabilityTable
    {
        Random rng;
        float combatChance, choiceChance, loreChance;
        List<CombatEvent> combatEvents;
        List<ChoiceEvent> choiceEvents;
        List<LoreEvent> loreEvents;

        // TODO: parameter for filename? to load seperate probability tables
        public ProbabilityTable()
        {
            rng = new Random();
            combatChance = 0.15f;
            choiceChance = 0.12f;
            loreChance = 0.05f;

            combatEvents = new List<CombatEvent>
            {
                new CombatEvent(new List<AICharacter> { new AICharacter("Lizardman", ImageDB.C_Lizard, 10) }),
                new CombatEvent(new List<AICharacter> { new AICharacter("Cyclops", ImageDB.C_Cyclops, 15) }),
                new CombatEvent(new List<AICharacter> { new AICharacter("Ninja", ImageDB.C_Ninja, 7), new AICharacter("Ninja", ImageDB.C_Ninja, 7) })
            };

            choiceEvents = new List<ChoiceEvent>
            {
                new ChoiceEvent("Old Begger", "You come across an old man sitting next to the path. His clothes are barely more than rags, and his hair is long and disheveled. He looks up when he hears your footsteps. 'Please kind sir, could you spare some of your supplies? I don't need much, just enough to help me reach the next town'.",
                new Dictionary<string, Action>
                {
                    {"Give him supplies", () => Debug.WriteLine("You lost some supplies. The begger is very thankful.") },
                    {"Ignore him", () => Debug.WriteLine("The begger is sad, but gives up on his plea.") },
                    {"Spit on him", () => Debug.WriteLine("The begger recoils in fear. He cowers behind a nearby tree while you walk away.") }
                }),

                new ChoiceEvent("Wolf pup", "As you continue down the path, you hear some noises from the nearby bushes. Upon investigating, you realize it is a lone wolf pup. It is tiny, probably the runt of the pack, and seems to have been separated from its family. It doesn't appear to have eaten in days, and is barely strong enough to look up at you.",
                new Dictionary<string, Action>
                {
                    {"Take it with you", () => Debug.WriteLine("This pup couldn't survive on its own, perhaps you can help it.") },
                    {"Give it some food", () => Debug.WriteLine("The pup begins nibbling on the food. Hopefully this will help it regain enough strength to survive on its own.") },
                    {"Kill it", () => Debug.WriteLine("This pup was abandoned because it is too weak to survive in this area. Rather than letting it die slowly and painfully, you end its misery in an instant. Perhaps it is in a better place now.") }
                })
            };

            loreEvents = new List<LoreEvent>
            {
                new LoreEvent("A Book!", "You found a book containing useful information. It talks about the history of this region.", "I love books!"),
                new LoreEvent("A Wanted Poster!", "You found a wanted poster for a cyclops called 'The King of Eyes'. Defeating him will net you a large bounty.", "Challenge Accepted!"),
                new LoreEvent("A Cave Painting", "You found a cave painting depicting several humanoid figures performing some sort of dark ritual. Perhaps one of the local tribes practices occult magic.", "Scary!")
            };
        }

        public TileEvent GetRandomEvent()
        {
            float r = rng.NextSingle();
            if (r < combatChance)
            {
                return new CombatEvent(combatEvents[rng.Next(combatEvents.Count)]);
            }
            else if (r < combatChance + choiceChance)
            {
                return new ChoiceEvent(choiceEvents[rng.Next(choiceEvents.Count)]);
            }
            else if (r < combatChance + choiceChance + loreChance)
            {
                return new LoreEvent(loreEvents[rng.Next(loreEvents.Count)]);
            }

            return null;
        }
    }
}
