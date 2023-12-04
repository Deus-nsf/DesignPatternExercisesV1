

using DesignPatternExercisesV1.ConsoleApp;
using static DesignPatternExercisesV1.ConsoleApp.UserInterface;

LocalStorage.Instance.OpenDatabase();
Console.WriteLine("\nBienvenue dans la gestion d'employés.\n");

bool exit = false;
while (exit == false)
{
	DisplayWelcomeMessage();
	string? choice = Console.ReadLine();

	switch (choice)
	{
		case "1":
			DisplayAddEmployee();
			break;
		case "2":
			DisplayEmployeeList();
			break;
		case "3":
			DisplayEmployeeById();
			break;
		case "q":
		case "Q":
            Console.WriteLine("\n\nSortie du programme...");
            exit = true;
			break;
		default:
            Console.WriteLine("\n\nVotre choix ne correspond pas à une des possibilités, veuillez recommencer...");
            break;
	}
}

LocalStorage.Instance.SaveDatabase();