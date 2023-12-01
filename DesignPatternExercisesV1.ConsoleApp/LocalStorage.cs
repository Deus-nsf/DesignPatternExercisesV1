using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternExercisesV1.ConsoleApp;


internal class LocalStorage
{
	private static LocalStorage? _localStorage = null;
	private static readonly object _padlock = new object();
	private readonly List<Employee> _employees = new();

	public static LocalStorage Instance
	{ 
		get 
		{ 
			lock (_padlock) 
				return _localStorage ??= new LocalStorage();
		} 
	}





}
