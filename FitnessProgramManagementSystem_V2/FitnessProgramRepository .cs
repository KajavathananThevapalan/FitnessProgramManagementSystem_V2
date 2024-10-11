using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sqlclient;
using Microsoft.Data.SqlClient;

namespace FitnessProgramManagementSystem_V2
{
    internal class FitnessProgramRepository
    {

        static string ConnectionString = "(server= (localdb)\\MSSQLLocalDB,DATABASE=FitnessPrograms)";

        public FitnessProgramRepository _FitnessProgramRepository
        public FitnessProgramRepository() {

            _FitnessProgramRepository = new FitnessProgramRepository();
        }

        public void CreateFitnessProgram(FitnessProgram fitnessProgram)
        {
            fitnessProgram.Title = CapitalizeTitle(fitnessProgram.Title);

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO FitnessPrograms (Title,Duration,Price) VALUES (@Title , @Duration , @Price)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", fitnessProgram.Title);
                    cmd.Parameters.AddWithValue("@Duration", fitnessProgram.Duration);
                    cmd.Parameters.AddWithValue("@Price", fitnessProgram.Price);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("FitnessPrograms Added Successfully");
                }
            };

        }

        public List<FitnessProgram> GetAllFitnessPrograms()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from FitnessPrograms ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var FitnessProgramList = new List<FitnessProgram>();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var FitnessProgram = new FitnessProgram();
                        FitnessProgram.Title = reader["Title"].ToString();
                        FitnessProgram.Duration = reader["Duration"].ToString();
                        FitnessProgram.Price = (decimal)reader["Price"];
                        FitnessProgram.FitnessProgramId = (int)reader["FitnessProgramId"];
                        FitnessProgramList.Add(FitnessProgram);
                    }
                    return FitnessProgramList;
                }
            }
        }

        public string GetFitnessProgramByID(int FitnessProgramId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "select * from FitnessPrograms Where FitnessProgramId = @FitnessProgramId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FitnessProgramId", FitnessProgramId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        return ($"FitnessProgram ID :{reader["FitnessProgramId"]} , Title : {reader["Title"]}, Duration : {reader["Duration"]}, Price : {reader["Price"]}");
                    }
                    return null;
                }
            }
        }

        public void UpdateFitnessProgram(FitnessProgram fitnessProgram)
        {
            fitnessProgram.Title = CapitalizeTitle(fitnessProgram.Title);
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE FitnessPrograms set Title = @Title , Duration = @Duration , Price = @Price where FitnessProgramId = @FitnessProgramId;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FitnessProgramId", fitnessProgram.FitnessProgramId);
                    cmd.Parameters.AddWithValue("@Title", fitnessProgram.Title);
                    cmd.Parameters.AddWithValue("@Duration", fitnessProgram.Duration);
                    cmd.Parameters.AddWithValue("@Price", fitnessProgram.Price);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine(" Updated Succesfully...");
                    }
                    else
                    {
                        Console.WriteLine("Course not Found...");
                    }
                }
            }
        }


        public void DeleteFitnessProgram(int FitnessProgramId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "delete from FitnessPrograms where FitnessProgramId = @FitnessProgramId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FitnessProgramId", FitnessProgramId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Bike deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Error deleting Bike");
                    }
                }
            }
        }



        private string CapitalizeTitle(string Title)
        {
            if (string.IsNullOrEmpty(Title))
                return Title;

            // Capitalize the first letter of each word
            var words = Title.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            return Title = string.Join(" ", words);
        }
    }
}
    }
}
