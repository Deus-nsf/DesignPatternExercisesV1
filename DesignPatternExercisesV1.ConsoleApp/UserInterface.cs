using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternExercisesV1.ConsoleApp;


internal static class UserInterface
{
	public static void DisplayWelcomeMessage()
	{
		Console.Write(
			"\nFaites un choix parmi les différentes fonctionnalités (touche entrée pour valider) :\n\n" +
			"1 - Ajouter un employé en rentrant ses informations.\n" +
			"2 - Afficher la liste des employés\n" +
			"3 - Afficher un employé en rentrant son Id\n" +
			"Q - Quitter le programme\n\n" +
			"Votre choix : ");
	}


	public static void DisplayAddEmployee()
	{
		Console.WriteLine("Interface d'ajout d'un employé (prénom, nom, salaire)...\n");

		Console.Write("Veuillez rentrer le prénom : ");
		string? firstName = Console.ReadLine();

		Console.Write("Veuillez rentrer le nom : ");
		string? lastName = Console.ReadLine();

		Console.Write("Veuillez rentrer le salaire : ");
		double salary;
		if(!double.TryParse(Console.ReadLine(), out salary))
		{
			Console.WriteLine("Format de salaire non valide");
			Console.WriteLine("Echec de création d'un employé.");
			return;
		}

		Console.WriteLine("\nCreation d'un employé en cours...");
		string? creationMessage = LocalStorage.Instance.CreateEmployee(firstName, lastName, salary);
		Console.WriteLine(creationMessage);
	}


	public static void DisplayEmployeeList()
	{
		Console.WriteLine("Liste des employés :\n");
		LocalStorage.Instance.Employees.ForEach(Console.WriteLine);
	}


	public static void DisplayEmployeeById()
	{
        Console.WriteLine("Affichage d'un employé par identifiant...\n");

		Console.Write("Veuillez rentrer l'identifiant de l'employé : ");
		int id;
		if(!int.TryParse(Console.ReadLine(), out id))
		{
			Console.WriteLine("Format d'identifiant non valide");
			return;
		}

		string? searchMessage = LocalStorage.Instance.FindEmployeeById(id);
		Console.WriteLine(searchMessage);
    }
}