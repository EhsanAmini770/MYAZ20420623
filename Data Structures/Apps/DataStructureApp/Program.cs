using System.Data.SQLite;
using SortingAlgorithms;

string filePath = "Employee.db";
string connectionString = $"Data Source={filePath};Version=3;";





// Establish a connection to the database
using (SQLiteConnection connection = new SQLiteConnection(connectionString))
{
    connection.Open();

    string query = "SELECT * FROM Employees;";

    using (SQLiteCommand command = new SQLiteCommand(query, connection))
    {
        using (SQLiteDataReader reader = command.ExecuteReader())
        {
            // Load the data into a list
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                decimal salary = Convert.ToDecimal(reader["Salary"]);
                string title = reader["Title"].ToString();

                employees.Add(new Employee(id, firstName, lastName, salary, title));
            }

            // Display menu for sorting options

            Console.WriteLine("2. Insertion Sort");

            Console.WriteLine();

            Console.WriteLine("Enter the number corresponding to the sorting algorithm:");
            int algorithmChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the field to sort by (1. Id, 2. First Name, 3. Salary):");
            int fieldChoice = Convert.ToInt32(Console.ReadLine());

            switch (fieldChoice)
            {
                case 1: // Sort by Id
                    BubbleSort.Sort(employees.Select(e => e.FirstName).ToArray());
                    break;

                case 2: // Sort by First Name
                    InsertionSort.Sort(employees.Select(e => e.FirstName).ToArray());

                    break;
                case 3: // Sort by Salary
                    InsertionSort.Sort(employees.Select(e => e.Salary).ToArray());

                    break;

                default:
                    Console.WriteLine("Invalid field choice. Exiting the program.");
                    return;
            }
        }
    }
    connection.Close();
}
