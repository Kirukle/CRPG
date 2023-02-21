using System;
using System.Linq;

namespace CRPG
{
    // Ty Good YYYY
    class Program
    {

        private static Player _player = new Player("Fred the Fearless", 10, 10, 20, 0, 0, "None");
        public static int playerLevel;

        static void Main(string[] args)
            {
                GameEngine.Intiatize();
            _player.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            InventoryItem sword = new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1);
            InventoryItem club = new InventoryItem(World.ItemByID(World.ITEM_ID_CLUB), 1);
            _player.Inventory.Add(sword);
            //_player.Inventory.Add(club);
            InventoryItem aPass = new InventoryItem(World.ItemByID(World.ITEM_ID_ADVENTURER_PASS), 1);
            //_player.Inventory.Add(aPass);
            //Console.WriteLine(RandomNumberGenerator.NumberBetween(4, 10));

            

            while (true)
            {
                playerLevel = _player.Level;
                //Console.WriteLine("Player Level: {0}", playerLevel);
                Console.Write("> ");
                string userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    continue;
                }
                string cleanedInput = userInput.ToLower();

                if(cleanedInput == "exit")
                {
                    break;
                }
                ParseInput(cleanedInput);
            } //while


            //Location tmpLocation = World.LocationByID(2);
            //Console.WriteLine(tmpLocation.Name);

                Console.ReadLine();
        } //Main

        public static void ParseInput(string input)
        {
            if(input.Contains("laugh") && playerLevel < 1)
            {
                _player.Level = 1;
                _player.Purpose = "To Laugh";
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\tA bright light consumes the abyss as you awake.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input.Contains("fight") && playerLevel < 1)
            {
                _player.Level = 1;
                _player.Purpose = "To Fight";
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\tA bright light consumes the abyss as you awake.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input.Contains("love") && playerLevel < 1)
            {
                _player.Level = 1;
                _player.Purpose = "To Love";
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\tA bright light consumes the abyss as you awake.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input.Contains("sing") && playerLevel < 1)
            {
                _player.Level = 1;
                _player.Purpose = "To Sing";
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\tA bright light consumes the abyss as you awake.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input.Contains("live") && playerLevel < 1)
            {
                _player.Level = 1;
                _player.Purpose = "To Live";
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\tA bright light consumes the abyss as you awake.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input.Contains("die") && playerLevel < 1)
            {
                _player.Level = 1;

                _player.Purpose = "To Die";
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("A bright light consumes the abyss as you awake.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (input.Contains("help") && playerLevel > 0)
            {
                Console.Write("Help is coming later... stay tuned.");
            }
            else if (input.Contains("look") && playerLevel > 0)
            {
                DisplayCurrentLocation();
            }
            else if ((input.Contains("north") || input == "n") && playerLevel > 0 )
            {
                _player.MoveNorth();
            }
            else if ((input.Contains("east") || input == "e") && playerLevel > 0 )
            {
                _player.MoveEast();
            }
            else if ((input.Contains("south") || input == "s") && playerLevel > 0 )
            {
                _player.MoveSouth();
            }
            else if ((input.Contains("west") || input == "w") && playerLevel > 0)
            {
                _player.MoveWest();
            } else if (input.Contains("debug"))
            {
                GameEngine.DebugInfo();
            } else if ((input == "inventory" || input == "i") && playerLevel > 0 )
            {
                Console.WriteLine("\nCurrent Inventory:");
                foreach (InventoryItem invItem in _player.Inventory)
                {
                    Console.WriteLine("\t{0} : {1}", invItem.Details.Name, invItem.Quantity);
                }
            } else if((input == "stats") && playerLevel > 0 )
            {
                Console.WriteLine("\nStats for {0}", _player.Name);
                Console.WriteLine("\t Current HP: \t{0}", _player.CurrentHitPoints);
                Console.WriteLine("\tMaximum HP: \t{0}", _player.maximumHitPoints);
                Console.WriteLine("\tXP:\t\t{0}", _player.ExperiencePoints);
                Console.WriteLine("\tLevel:\t\t{0}", _player.Level);
                Console.WriteLine("\tGold:\t\t{0}", _player.Gold);
            } else if (input == "quests")
            {
                if((_player.Quests.Count == 0) && playerLevel > 0 )
                {
                    Console.WriteLine("You do not have any quests.");
                } else
                {
                    foreach (PlayerQuest playerQuest in _player.Quests)
                    {
                        Console.WriteLine("{0}: {1}", playerQuest.Details.Name,
                            playerQuest.IsCompleted ? "Completed" : "Incomplete");
                    }
                }
            } else if ((input.Contains("attack") || input == "a" ) && playerLevel > 0 )
            {
                if(_player.CurrentLocation.MonsterLivingHere == null)
                {
                    Console.WriteLine("There is nothing here to attack.");
                }
                else
                {
                    if(_player.CurrentWeapon == null)
                    {
                        Console.WriteLine("You are not equipped with a weapon.");
                    }else
                    {
                        _player.UseWeapon(_player.CurrentWeapon);
                    }
                }
            } else if ((input.StartsWith("equip ")) && playerLevel > 0 )
            {
                _player.UpdateWeapons();
                string inputWeaponName = input.Substring(6).Trim();
                if(string.IsNullOrEmpty(inputWeaponName))
                {
                    Console.WriteLine("You must enter the name of the weapon to equip.");
                }
                else
                {
                    Weapon weaponToEquip = _player.Weapons.SingleOrDefault(x => x.Name.ToLower() == inputWeaponName
                   || x.NamePlural.ToLower() == inputWeaponName);

                    if(weaponToEquip == null)
                    {
                        Console.WriteLine("You do not have the weapon {0}", inputWeaponName);
                    }
                    else
                    {
                        _player.CurrentWeapon = weaponToEquip;
                        Console.WriteLine("You equip your {0}", _player.CurrentWeapon.Name);
                    }
                }
            }else if ((input == "weapons") && playerLevel > 0)
            {
                _player.UpdateWeapons();
                Console.WriteLine("List of Weapons:");
                foreach (Weapon w in _player.Weapons)
                {
                    Console.WriteLine("\t{0}", w.Name);
                }
            }

            else if (playerLevel > 0)
            {
                Console.WriteLine("I don't understand. Sorry!");
            }

            else if (playerLevel == 0)
            {
                Console.WriteLine("Choose...");
            }
        }//ParseInput

        public static void DisplayCurrentLocation()
        {
            Console.WriteLine("\nYou are at: {0}", _player.CurrentLocation.Name);
            if(_player.CurrentLocation.Description != "")
            {
                Console.WriteLine("\t{0}\n", _player.CurrentLocation.Description);
            }
        }
    }
}
