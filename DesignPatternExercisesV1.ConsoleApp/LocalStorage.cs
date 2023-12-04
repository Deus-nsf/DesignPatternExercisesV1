using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesignPatternExercisesV1.ConsoleApp;


public class LocalStorage
{
	private static LocalStorage? _localStorage = null;
	private static readonly object _padlock = new object();

	private readonly List<Employee> _employees = new();
	public List<Employee> Employees => _employees;


	public static LocalStorage Instance
	{ 
		get 
		{ 
			lock (_padlock) 
				return _localStorage ??= new LocalStorage();
		} 
	}


	public string? CreateEmployee(string? firstName, string? lastName, double salary)
	{
		int id = 1;

		if (_employees.Count > 0)
			id = _employees.Last().Id + 1;

		try
		{
			_employees.Add(new Employee(id, firstName, lastName, salary));
		}
		catch (ArgumentException ex)
		{
			return ex.Message;
        }

		return "Employé crée avec succès !";
	}


	public string? FindEmployeeById(int id)
	{
		Employee? employee = null;

		try
		{ 
			employee = _employees.Where(e => e.Id == id).First();
		}
		catch
		{
			return $"Aucun employé avec l'identifiant {id} n'a été trouvé";
		}

		return employee.ToString();
	}


	public void SaveDatabase()
	{
		string database = JsonSerializer.Serialize<List<Employee>>(_employees);
		File.WriteAllText("database.json", database);
	}


	public void OpenDatabase()
	{
		if (!File.Exists("database.json"))
			return;

		string database = File.ReadAllText("database.json");
		List<Employee>? employees = JsonSerializer.Deserialize<List<Employee>>(database);
		if (employees != null)
			_employees.AddRange(employees);
	}
}