using System.Data;
using System.Data.SqlClient;

namespace Lek09_ADO
{
    class Program
    {
        static void Exercise3()
        {
            string q = "SELECT * FROM Persons";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SQLString))
            {
                SqlCommand query = new SqlCommand(q, connection);
                connection.Open();
                SqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;

                    int id = (int)record[0];
                    string name = (string)record[1];
                    int age = (int)record[2];
                    int weight = (int)record[3];
                    int score = (int)record[4];

                    System.Console.WriteLine($"{id}: {name}\t({age}),\t{weight} kg,\t{score} points.");
                }

                reader.Close();
            }
        }

        static void Exercise4()
        {
            string qPets = "SELECT * FROM Pets";
            string qPeople = "SELECT * FROM Persons";
            string qJoin = "SELECT pp.Name as personName, pp.ID as personID, pt.Name as petName, pt.ID as petID FROM Persons pp JOIN Pets pt ON pt.owner_id = pp.ID";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SQLString))
            {
                connection.Open();

                // 1
                System.Console.WriteLine("\nAll pets:");

                SqlCommand query = new SqlCommand(qPets, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(query);
                DataTable dataPets = new DataTable();
                adapter.Fill(dataPets);

                foreach (DataRow row in dataPets.Rows)
                {
                    System.Console.WriteLine($"{row["ID"]}: {row["Name"]}");
                }

                adapter.Dispose();

                // 2
                System.Console.WriteLine("\nPeople with pets:");

                query = new SqlCommand(qPeople, connection);
                adapter = new SqlDataAdapter(query);
                DataTable dataPeople = new DataTable();
                adapter.Fill(dataPeople);

                foreach (DataRow person in dataPeople.Rows)
                {
                    foreach (DataRow pet in dataPets.Rows)
                    {
                        if (pet["owner_id"].Equals(person["ID"]))
                            System.Console.WriteLine($"{person["Name"]} is a pet owner.");
                    }
                }

                adapter.Dispose();

                // 3
                System.Console.WriteLine("\nPet-people aquired via inner-join:");

                query = new SqlCommand(qJoin, connection);
                adapter = new SqlDataAdapter(query);
                DataTable dataPetPeople = new DataTable();
                adapter.Fill(dataPetPeople);

                foreach (DataRow petPerson in dataPetPeople.Rows)
                {
                    System.Console.WriteLine($"{petPerson["personName"]} ({petPerson["personID"]}) owns {petPerson["petName"]} ({petPerson["petID"]}).");
                }

                adapter.Dispose();
            }
        }

        static void Exercise5()
        {
            // 😅
            string q = "SELECT pp.Name, pp.Score FROM Persons pp JOIN Pets pt ON pp.ID = pt.owner_id " +
                "WHERE pp.Score = (SELECT MAX(Score) FROM Persons JOIN Pets ON Persons.ID = Pets.owner_id)";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SQLString))
            {
                connection.Open();
                SqlCommand query = new SqlCommand(q, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(query);
                DataTable petPeople = new DataTable();
                adapter.Fill(petPeople);

                // All the people who has Score = MAX(Score).
                foreach (DataRow row in petPeople.Rows)
                {
                    System.Console.WriteLine($"{row["Name"]} ({row["Score"]})");
                }
                //var highscore = from p in petPeople.AsEnumerable() where p["Score"] = petPeople.AsEnumerable().Max() select p.Name
            }
        }

        static void Exercise6()
        {
            int newWeight = 24;

            string query = $"UPDATE Pets SET Weight = @Weight WHERE Name = 'Garfield'";
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SQLString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("Weight", SqlDbType.Int).Value = newWeight;
                cmd.ExecuteNonQuery();
                System.Console.WriteLine($"Set Garfields weight to: {newWeight}.\n");
            }
        }

        static void Main(string[] args)
        {
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();

            System.Console.ReadLine();
        }
    }
}
