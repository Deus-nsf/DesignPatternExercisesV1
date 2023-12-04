using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternExercisesV1.ConsoleApp;

public class Employee
{
	private double _salary;

	public int Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public double Salary
	{
		get => _salary;
		set 
		{
			if (value <= 0)
				throw new ArgumentException("Erreur sur le salaire : ne peut être égal ou inférieur à 0");

			_salary = value;
		}
	}

	public Employee(int id, string? firstName, string? lastName, double salary)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		Salary = salary;
	}


	public override string ToString()
	{
		return 
			$"Identifiant : {Id}" +
			$"\nPrénom : {FirstName}" +
			$"\nNom : {LastName}" +
			$"\nSalaire : {Salary}\n";
	}
}