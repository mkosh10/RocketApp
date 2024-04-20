using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketLibrary;
using static RocketLibrary.RocketApiModel;

namespace RocketLibrary
{
    public class SqliteDataAccess
    {
        public static List<RocketDbModel> LoadRockets()
        {
            /* Opens the connection and guarantees that if the connection is successful or not  
             * it will close properly the connection to the DB */

            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var outputFromDb = connection.Query<RocketDbModel>("select * from Rocket", new DynamicParameters());
                return outputFromDb.ToList(); 
            }
        }

        public static void SaveRocket(RocketDbModel rocket)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlstring = "INSERT INTO Rocket (id, name, launch_date_time, provider_name, last_updated, img_url, status, is_updated) VALUES (@id, @name, @launch_date_time, @provider_name, @last_updated, @img_url, @status, @is_updated)";
                connection.Execute(sqlstring, rocket);
            }
        }
        public static bool CheckIfRocketExistsInDb(RocketDbModel rocket)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlCheckExistence = "SELECT COUNT(*) FROM Rocket WHERE id = @id";
                int count = connection.QueryFirstOrDefault<int>(sqlCheckExistence, new { id = rocket.id });
                if(count == 0)
                {
           
                    return false;
                } else
                { 
                    return true;
                }
            }
        } 
        public static void UpdateRocketLaunch(RocketDbModel rocket)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string SelectLaunchDateFromDb = "SELECT launch_date_time FROM Rocket WHERE id = @RocketId";
                DateTime DateTimeFromDb = connection.QueryFirstOrDefault<DateTime>(SelectLaunchDateFromDb, new { RocketId = rocket.id });

                if (rocket.launch_date_time!= DateTimeFromDb)
                {
                    string sqlString = "UPDATE Rocket SET launch_date_time = @NewDate, is_updated = 1 WHERE id = @RocketId";
                    connection.Execute(sqlString, new { NewDate = rocket.launch_date_time, RocketId = rocket.id });
                }
            }
        }
        
        public static void UpdateRocketStatus(RocketDbModel rocket)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                if(rocket.status == "Launch Failure")
                {
                    string sqlString = "UPDATE Rocket SET status = @NewStatus, is_updated = 1 WHERE id = @RocketId";
                    connection.Execute(sqlString, new { NewStatus = rocket.status, RocketId = rocket.id });
                }
            }
        }
        
        public static void DeleteRocket(RocketDbModel rocket)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlstring = "DELETE FROM Rocket WHERE id = @rocketId";
                string rocketId = rocket.id;
                connection.Execute(sqlstring, rocketId);
            }
        }
        
        public static void ResetAllRocketsAsNotUpdated()
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlstring = "UPDATE Rocket SET is_updated = 0";
                connection.Execute(sqlstring);
            }
        }


        private static string LoadConnectionString(string id = "DefaultDbConnectionString")
        {
            // connect to connection string which is in App.config in NewRocketApp
            return ConfigurationManager.ConnectionStrings[id].ConnectionString; 
        }
    }
}
