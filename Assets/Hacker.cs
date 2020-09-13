using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    string level;
    enum Screen { MainMenu, Password, WinScreen };
    Screen CurrentScreen = Screen.MainMenu;
    string password;
    string[] levelOnePasswords = { "Money", "Vault", "Loan", "Credit", "Interest" };
    string[] levelTwoPasswords = { "Defense", "Security", "Soldier", "Army", "Weaponry" };
    string[] levelThreePasswords = { "Tsunami", "Forest Fire", "Cyclone", "Blizzard", "Avalanche" };
    // Start is called before the first frame update
    void Start()
    {
        showMainMenu();
    }
    void showMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Game Menu");
        Terminal.WriteLine("Press a to hack into the Bank");
        // Money, Vault, Loan, Credit, Interest
        Terminal.WriteLine("Press b to hack into the Military");
        // Defense, Security, Soldier, Army, Weaponry
        Terminal.WriteLine("Press c to save the world from natural disasters");
        // Tsunami, Forest Fire, Cyclone, Blizzard, Avalanche
        Terminal.WriteLine("Enter your option:");
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            showMainMenu();
        }
        else if (CurrentScreen == Screen.MainMenu)
        {
            runMenu(input);
        }
        else if (CurrentScreen == Screen.Password)
        {
            checkPassword(input);
        }
    }
    void startGame()
    {
        CurrentScreen = Screen.Password;
        Terminal.WriteLine("you have chosen " + level);
        Terminal.WriteLine("Enter Password, hint: " + password.Anagram());
    }
    void runMenu(string input)
    {

        if (!(input == "a" || input == "b" || input == "c"))
        {
            Terminal.WriteLine("Please enter valid option {a, b, c, menu}");
        }
        else
        {
            level = input;
            if (level == "a")
            {
                password = levelOnePasswords[Random.Range(0, levelOnePasswords.Length)];
            }
            else if (level == "b")
            {
                password = levelTwoPasswords[Random.Range(0, levelTwoPasswords.Length)];
            }
            else
            {
                password = levelThreePasswords[Random.Range(0, levelThreePasswords.Length)];
            }
            startGame();
        }
    }
    void checkPassword(string input)
    {
        if (input == password)
        {
            CurrentScreen = Screen.WinScreen;
            Terminal.ClearScreen();
            runWinArt();
        }
        else
        {
            Terminal.WriteLine("Wrong Password, Try Again :(");
        }
    }
    void runWinArt()
    {
        switch (level)
        {
            case "a":
                {
                    Terminal.WriteLine(@"Succesfully hacked the bank!:)
|#######====================#######|
|#(1)*     NEVERLAND CASH     *(1)#|
|#**          /===\   ********  **#|
|*# {G}      |  () |             #*|
|#*  ******  | /v\ |    O N E    *#|
|#(1)         \===/            (1)#|
|##=========ONE DOLLAR===========##|
------------------------------------
                ");
                    Terminal.WriteLine("Type menu to return to main menu");
                    break;
                }
            case "b":
                {
                    Terminal.WriteLine(@"Successfully hacked the military
       .---.
      /_____\
      ( '.' )
       \_-_/
    .-   V //-.
   / ,   |// , \
  / /|Ll //Ll|\ \
 / / |__//   | \ \
 \ \ |_//____| / /
  \/\__/ |   \/\/
                    ");
                    Terminal.WriteLine("Type menu to return to main menu");
                    break;
                }
            case "c":
                {
                    Terminal.WriteLine("you saved the world from a disaster, yay!");
                    Terminal.WriteLine("Type menu to return to main menu");
                    break;
                }
        }
    }
}
