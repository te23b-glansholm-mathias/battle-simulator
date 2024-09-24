using System;
using System.Runtime.CompilerServices;

class Game
{
    static string realName;

    static int playerLevel = 1;
    static float xp;
    static int xpRequired = 100;
    static float enemyXpGain;

    static int defense;
    static int strength;
    static int specialStrenth;
    static int hpRando;


    static string enemyName;
    static int randomEnemy;
    static int enemyDefense;
    static int enemyStrength;
    static int enemySpecialDefense;
    static int enemySpecialHeal;
    static int enemyHpRando;
    static int healingRate = 0;

    static int missChance;

    static void Main()
    {
        Random rnd = new Random();
        int funValue = rnd.Next(0, 100);
        if (funValue == 66)
        {
            bogosort();
        }
        else
        {
            BattleSimulator();
            Console.ReadLine();
        }
    }

    static void BattleSimulator()
    {
        float difficultyMultiplier = 1f;
        Console.Clear();
        string playerName = Prompt("What is the name of your player?");

        if (playerName == "gaster")
        {
            bogosort();
        }

        realName = Prompt("What is YOUR name?");

        if (realName == "gaster")
        {
            bogosort();
        }

        difficultySelection(ref difficultyMultiplier, ref realName, ref playerName);

        static void difficultySelection(ref float difficultyMultiplier, ref string realName, ref string playerName)
        {

            shortPause();
            if (playerLevel > 1)
            {
                Console.Clear();
                Console.WriteLine($"Welcome back! you are currently level {playerLevel} with {xp} / {xpRequired} xp");
                Console.ReadLine();
                Console.WriteLine($"What do you want your difficulty to be {realName}?");
            }
            else
            {
                Console.WriteLine($"okay {realName}. What do you want your difficulty to be?");
            }
            string difficulty = Prompt("a - easy b - normal  c - hard");
            switch (difficulty)
            {
                case "b":
                    difficultyMultiplier = 1.5f;
                    battle(ref playerName, ref difficultyMultiplier);
                    break;
                case "c":
                    difficultyMultiplier = 2f;
                    battle(ref playerName, ref difficultyMultiplier);
                    break;
                case "nightmare":
                    battleNightmare(ref realName);
                    break;
                default:
                    difficultyMultiplier = 1f;
                    battle(ref playerName, ref difficultyMultiplier);
                    break;
            }
        }

        static void battle(ref string playerName, ref float difficultyMultiplier)
        {
            Random Enemy = new Random();
            randomEnemy = Enemy.Next(1, 5);
            switch (randomEnemy)
            {
                case 1:
                    gnome();
                    break;
                case 2:
                    mermaid();
                    break;
                case 3:
                    Phoenix();
                    break;
                case 4:
                    Dragon();
                    break;
            }

            static void gnome()
            {
                enemyName = "Gnome";
                enemyXpGain = 0;
                Random enemyStats = new Random();
                enemyStrength = enemyStats.Next(2, 5);
                enemyDefense = enemyStats.Next(0, 3);
                enemySpecialDefense = enemyStats.Next(12, 14);
                enemySpecialHeal = enemyStats.Next(10, 12);
                healingRate = 25;
                enemyHpRando = enemyStats.Next(-10, -5);
            }

            static void mermaid()
            {
                enemyName = "Mermaid";
                enemyXpGain = 10;
                Random enemyStats = new Random();
                enemyStrength = enemyStats.Next(4, 7);
                enemyDefense = enemyStats.Next(6, 12);
                enemySpecialDefense = enemyStats.Next(18, 22);
                enemySpecialHeal = enemyStats.Next(16, 20);
                healingRate = 10;
                enemyHpRando = enemyStats.Next(5, 10);
            }

            static void Phoenix()
            {
                enemyName = "Phoenix";
                enemyXpGain = 25;
                Random enemyStats = new Random();
                enemyStrength = enemyStats.Next(10, 14);
                enemyDefense = enemyStats.Next(8, 13);
                enemySpecialDefense = enemyStats.Next(15, 20);
                enemySpecialHeal = enemyStats.Next(12, 18);
                healingRate = 0;
                enemyHpRando = enemyStats.Next(-10, 20);
            }

            static void Dragon()
            {
                enemyXpGain = 50;
                enemyName = "Dragon";
                enemyStrength = 22;
                enemyDefense = 12;
                enemySpecialDefense = 4;
                enemySpecialHeal = 12;
                healingRate = 0;
                enemyHpRando = 50;
            }

            Random stats = new Random();
            strength = stats.Next(5, 10) + playerLevel * stats.Next(1, 5);
            specialStrenth = stats.Next(0, 15) + playerLevel * stats.Next(5, 10);
            defense = stats.Next(0, 5) + playerLevel * stats.Next(1, 5);
            hpRando = stats.Next(-15, 15) + playerLevel * stats.Next(1, 5);
            float playerHp = 100 + hpRando;

            float enemyHp = 100 * difficultyMultiplier + enemyHpRando;

            while (playerHp > 0 && enemyHp > 0)
            {
                Console.WriteLine("new round");
                Console.WriteLine($"{playerName}'s HP: {playerHp}. {enemyName}'s HP: {enemyHp}");
                Random rnd = new Random();
                int playerRng = rnd.Next(1, 101);

                Random miss = new Random();
                missChance = miss.Next(1, 101);

                Console.ReadLine();
                if (missChance <= 10)
                {
                    Console.WriteLine($"You did a attack... You missed");
                }
                else
                {
                    switch (playerRng)
                    {
                        case < 50:
                            weakAttack(ref enemyHp);
                            break;
                        case < 90:
                            strongAttack(ref enemyHp);
                            break;
                        case < 96:
                            criticalHit(ref enemyHp);
                            break;
                        case < 101:
                            crazyHit(ref enemyHp);
                            break;
                    }
                }

                static void weakAttack(ref float enemyHp)
                {
                    Random rnd = new Random();
                    int weakAttackDamage = rnd.Next(1, 10) + strength - enemyDefense;
                    if (weakAttackDamage < 0)
                    {
                        weakAttackDamage = 0;
                    }
                    Console.WriteLine($"you did a weak attack with the damage of {weakAttackDamage}");
                    enemyHp -= weakAttackDamage;
                }

                static void strongAttack(ref float enemyHp)
                {
                    Random rnd = new Random();
                    int strongAttackDamage = rnd.Next(8, 19) + strength - enemyDefense;
                    if (strongAttackDamage < 0)
                    {
                        strongAttackDamage = 0;
                    }
                    Console.WriteLine($"you did a strong attack with the damage of {strongAttackDamage}");
                    enemyHp -= strongAttackDamage;
                }

                static void criticalHit(ref float enemyHp)
                {
                    Random rnd = new Random();
                    int criticalAttackDamage = rnd.Next(22, 44) + strength - enemyDefense;
                    if (criticalAttackDamage < 0)
                    {
                        criticalAttackDamage = 0;
                    }
                    Console.WriteLine($"Critical hit! you did {criticalAttackDamage} amount of damage");
                    enemyHp -= criticalAttackDamage;
                }

                static void crazyHit(ref float enemyHp)
                {
                    Random rnd = new Random();
                    int crazyDamage = rnd.Next(80, 100) + specialStrenth - enemySpecialDefense;
                    if (crazyDamage < 0)
                    {
                        crazyDamage = 0;
                    }
                    Console.WriteLine($"Woah, what a hit! you did {crazyDamage} amount of damage");
                    enemyHp -= crazyDamage;
                }

                Console.ReadLine();

                missChance = miss.Next(1, 101);
                int enemyRng = rnd.Next(1, 101);

                if (missChance <= 10)
                {
                    Console.WriteLine("The enemy made an attack... but missed");
                }
                else
                {
                    int healingThresholdWeak = 50 - healingRate;
                    int healingThresholdStrong = 90 - healingRate;
                    int healingThresholdCritical = 96 - healingRate;

                    if (enemyRng < healingThresholdWeak)
                    {
                        enemyWeakAttack(ref playerHp, ref difficultyMultiplier);
                    }
                    else if (enemyRng < healingThresholdStrong)
                    {
                        enemyStrongAttack(ref playerHp, ref difficultyMultiplier);
                    }
                    else if (enemyRng < healingThresholdCritical)
                    {
                        enemyCriticalHit(ref playerHp, ref difficultyMultiplier);
                    }
                    else
                    {
                        enemyHeal(ref enemyHp, ref difficultyMultiplier);
                    }
                }
                static void enemyWeakAttack(ref float playerHp, ref float difficultyMultiplier)
                {
                    Random rnd = new Random();
                    int weakAttackDamage = rnd.Next(1, 4) - defense + enemyStrength;
                    if (weakAttackDamage < 0)
                    {
                        weakAttackDamage = 0;
                    }
                    Console.WriteLine($"the enemy did a weak attack with the damage of {weakAttackDamage * difficultyMultiplier}");
                    playerHp -= weakAttackDamage * difficultyMultiplier;
                }

                static void enemyStrongAttack(ref float playerHp, ref float difficultyMultiplier)
                {
                    Random rnd = new Random();
                    int strongAttackDamage = rnd.Next(2, 6) - defense + enemyStrength;
                    if (strongAttackDamage < 0)
                    {
                        strongAttackDamage = 0;
                    }
                    Console.WriteLine($"the enemy did a strong attack with the damage of {strongAttackDamage * difficultyMultiplier}");
                    playerHp -= strongAttackDamage * difficultyMultiplier;
                }

                static void enemyCriticalHit(ref float playerHp, ref float difficultyMultiplier)
                {
                    Random rnd = new Random();
                    int criticalAttackDamage = rnd.Next(10, 12) - defense + enemyStrength;
                    if (criticalAttackDamage < 0)
                    {
                        criticalAttackDamage = 0;
                    }
                    Console.WriteLine($"the enemy did a critical hit! they did {criticalAttackDamage * difficultyMultiplier} amount of damage");
                    playerHp -= criticalAttackDamage * difficultyMultiplier;
                }

                static void enemyHeal(ref float enemyHp, ref float difficultyMultiplier)
                {
                    Random rnd = new Random();
                    int healAmount = rnd.Next(20, 60) + enemySpecialHeal;
                    Console.WriteLine($"the enemy just healed! they healed {healAmount * difficultyMultiplier} amount of HP");
                    enemyHp += healAmount * difficultyMultiplier;
                }

                Console.ReadLine();
            }

            if (enemyHp <= 0 && playerHp <= 0)
            {
                Console.WriteLine("It was a tie. Restart game? press enter.");
                Console.ReadLine();
                difficultySelection(ref difficultyMultiplier, ref playerName, ref realName);
            }
            else if (enemyHp <= 0)
            {
                xp += 100 * difficultyMultiplier + enemyXpGain;
                if (xp >= xpRequired)
                {
                    xp -= xpRequired;
                    playerLevel++;
                    Console.WriteLine($"You win and leveled up! You are now level {playerLevel}. Play again?");
                    xpRequired *= 2;
                    Console.ReadLine();
                    difficultySelection(ref difficultyMultiplier, ref playerName, ref realName);
                }
                else
                {
                    Console.WriteLine($"You win! congratulation! You gained {100 * difficultyMultiplier} xp. Play again?");
                    Console.ReadLine();
                    difficultySelection(ref difficultyMultiplier, ref playerName, ref realName);
                }
            }
            else
            {
                Console.WriteLine("you lose! :( u suck lol");
                Console.ReadLine();
                difficultySelection(ref difficultyMultiplier, ref playerName, ref realName);
            }
        }

        static void battleNightmare(ref string realName)
        {
            Console.WriteLine("...");
            Console.ReadLine();

            Random stats = new Random();

            strength = stats.Next(5, 10);
            specialStrenth = stats.Next(0, 15);
            defense = stats.Next(0, 5);
            float playerHp = 250;

            enemyStrength = stats.Next(5, 10);
            enemyDefense = stats.Next(0, 5);
            enemySpecialDefense = stats.Next(0, 15);
            enemySpecialHeal = stats.Next(0, 15);
            float enemyHp = 500;

            while (playerHp > 0 && enemyHp > 0)
            {
                Console.WriteLine("round 1");
                Console.WriteLine($"{realName}'s HP: {playerHp / 10}. enemy HP: 9999999");
                Console.WriteLine($"real enemyHp: {enemyHp}");
                Random rnd = new Random();
                int playerRng = rnd.Next(1, 102);

                Console.ReadLine();
                switch (playerRng)
                {
                    case < 50:
                        reallyWeakAttack(ref enemyHp);
                        break;
                    case < 90:
                        weakStrongAttack(ref enemyHp);
                        break;
                    case < 96:
                        weakCriticalHit(ref enemyHp);
                        break;
                    case < 101:
                        weakCrazyHit(ref enemyHp);
                        break;
                    case < 102:
                        heal(ref playerHp);
                        break;
                }

                static void reallyWeakAttack(ref float enemyHp)
                {
                    Random rnd = new Random();
                    int weakAttackDamage = rnd.Next(1, 9) + strength;
                    Console.WriteLine($"you did a extremely weak attack with the damage of {rnd.Next(1, 3)}, it was not very effective...?");
                    enemyHp -= weakAttackDamage - enemyDefense;
                }

                static void weakStrongAttack(ref float enemyHp)
                {
                    Random rnd = new Random();
                    int strongAttackDamage = rnd.Next(1, 14) + strength;
                    Console.WriteLine($"you did a weak attack with the damage of {rnd.Next(1, 5)}, it was not very effective...?");
                    enemyHp -= strongAttackDamage - enemyDefense;
                }

                static void weakCriticalHit(ref float enemyHp)
                {
                    Random rnd = new Random();
                    int criticalAttackDamage = rnd.Next(1, 45) + strength;
                    Console.WriteLine($"You did a Critical hit... but you only did {rnd.Next(1, 8)} amount of damage");
                    enemyHp -= criticalAttackDamage - enemyDefense;
                }

                static void weakCrazyHit(ref float enemyHp)
                {
                    Random rnd = new Random();
                    int crazyDamage = rnd.Next(1, 80) + strength;
                    Console.WriteLine($"You tried as hard as you could.... but you only did {rnd.Next(1, 12)} amount of damage");
                    enemyHp -= crazyDamage - enemyDefense;
                }

                static void heal(ref float playerHp)
                {
                    Console.WriteLine($"but still... you are filled with determination...");
                    playerHp = 250;
                }

                Console.ReadLine();

                int enemyRng = rnd.Next(1, 101);
                switch (enemyRng)
                {
                    case < 50:
                        enemyWeakAttack(ref playerHp);
                        break;
                    case < 90:
                        enemyStrongAttack(ref playerHp);
                        break;
                    case < 98:
                        enemyCriticalHit(ref playerHp);
                        break;
                    case < 101:
                        enemyHeal(ref enemyHp);
                        break;
                }

                static void enemyWeakAttack(ref float playerHp)
                {
                    Random rnd = new Random();
                    int weakAttackDamage = rnd.Next(1, 10) + enemyStrength;
                    Console.WriteLine($"You could feel the skin losing your body...");
                    playerHp -= weakAttackDamage - defense;
                }

                static void enemyStrongAttack(ref float playerHp)
                {
                    Random rnd = new Random();
                    int strongAttackDamage = rnd.Next(1, 14) + enemyStrength;
                    Console.WriteLine($"You are losing your senses...");
                    playerHp -= strongAttackDamage - defense;
                }

                static void enemyCriticalHit(ref float playerHp)
                {
                    Random rnd = new Random();
                    int criticalAttackDamage = rnd.Next(1, 60) + enemyStrength;
                    Console.WriteLine($"You feel like you are going to die...");
                    playerHp -= criticalAttackDamage - defense;
                }

                static void enemyHeal(ref float enemyHp)
                {
                    Random rnd = new Random();
                    int healAmount = rnd.Next(1, 100) + enemySpecialHeal;
                    Console.WriteLine($"You wonder what it would feel like to drown...");
                    enemyHp += healAmount;
                }
                Console.ReadLine();
            }

            if (enemyHp <= 0 && playerHp <= 0)
            {
                Console.WriteLine("...");
                Console.ReadLine();
                Console.WriteLine("reset.");
                Console.ReadLine();
                Main();
            }
            else if (enemyHp <= 0)
            {
                Console.WriteLine("...");
                Console.ReadLine();
                Console.WriteLine("you win. Good work, thanks for playing");
                Console.ReadLine();
                bogosort();
            }
            else
            {
                Console.WriteLine("...");
                Console.ReadLine();
                Console.WriteLine("judgement.");
                Console.ReadLine();
                Main();
            }
        }

        static string Prompt(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine() ?? "Unknown";
        }

        static void shortPause()
        {
            Thread.Sleep(500);
        }
    }

    static void bogosort()
    {
        Random skip = new Random();
        int bogosortSkip = skip.Next(0, 1000);
        if (bogosortSkip == 66)
        {
            Console.WriteLine("what?");
            Console.ReadLine();
            BattleSimulator();
        }
        else
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            Console.WriteLine(@"
⠀⠀⠀⠀⠀⠀⢀⣤⠤⠤⠤⠤⠤⠤⠤⠤⠤⠤⢤⣤⣀⣀⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢀⡼⠋⠀⣀⠄⡂⠍⣀⣒⣒⠂⠀⠬⠤⠤⠬⠍⠉⠝⠲⣄⡀⠀⠀
⠀⠀⠀⢀⡾⠁⠀⠊⢔⠕⠈⣀⣀⡀⠈⠆⠀⠀⠀⡍⠁⠀⠁⢂⠀⠈⣷⠀⠀
⠀⠀⣠⣾⠥⠀⠀⣠⢠⣞⣿⣿⣿⣉⠳⣄⠀⠀⣀⣤⣶⣶⣶⡄⠀⠀⣘⢦⡀
⢀⡞⡍⣠⠞⢋⡛⠶⠤⣤⠴⠚⠀⠈⠙⠁⠀⠀⢹⡏⠁⠀⣀⠤⢤⡕⠱⣷
⠘⡇⠇⣯⠤⢾⡙⠲⢤⣀⡀⠤⠀⢲⡖⣂⣀⠀⠀⢙⣶⣄⠈⠉⣸⡄⠠⣠⡿
⠀⠹⣜⡪⠀⠈⢷⣦⣬⣏⠉⠛⠲⣮⣧⣀⣀⣀⠶⠞⢁⣀⣨⢶⢿⣧⠉⡼⠁
⠀⠀⠈⢷⡀⠀⠀⠳⣌⡟⠻⠷⣶⣦⣀⣀⣹⣉⣉⣿⣉⣉⣇⣼⣾⣿⠀⡇⠀
⠀⠀⠀⠈⢳⡄⠀⠀⠘⠳⣄⡀⡼⠈⠉⠛⡿⠿⠿⡿⠿⣿⢿⣿⣿⡇⠀⡇⠀
⠀⠀⠀⠀⠀⠙⢦⣕⠠⣒⠌⡙⠓⠶⠤⣤⣧⣀⣸⣇⣴⣧⠾⠾⠋⠀⠀⡇⠀
⠀⠀⠀⠀⠀⠀⠀⠈⠙⠶⣭⣒⠩⠖⢠⣤⠄⠀⠀⠀⠀⠀⠠⠔⠁⡰⠀⣧⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠲⢤⣀⣀⠉⠉⠀⠀⠀⠀⠀⠁⠀⣠⠏⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠛⠒⠲⠶⠤⠴⠒⠚⠁⠀⠀
");

            List<int> numbers = new List<int>();
            Random rnd = new Random();

            int iteration = 0;
            bool isSorted = false;

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(rnd.Next(0, 101));
            }

            numbers.Add(69);

            while (!isSorted)
            {
                iteration++;

                Console.SetCursorPosition(35, 6);
                Console.Write($"bogosort iteration {iteration}: ");

                foreach (int number in numbers)
                {
                    Console.Write($"{number} ");
                }

                Console.WriteLine();

                shuffle(numbers);
                isSorted = IsSorted(numbers);
            }

            Console.SetCursorPosition(0, 14);
            Console.WriteLine("Sorted!");
            Console.ReadLine();
            BattleSimulator();

        }

        static bool IsSorted(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < list[i - 1])
                    return false;
            }
            return true;
        }

        static void shuffle(List<int> list)
        {
            Random rnd = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);

                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}