using System.Data;
using System.Data.SqlClient;
using NorrisTrip.Collector.Web.Domain.Entity;
using NorrisTrip.Collector.Web.Domain.Repository;

namespace NorrisTrip.Collector.Web.Infra.Repository
{
    public class BehaviorRepository : IBehaviorRepository
    {
        private const string _create = "INSERT INTO BEHAVIORDATA (Name,IP,Referrer,Url,UserAgent,Created,DataBag) VALUES (@Name,@IP,@Referrer,@Url,@UserAgent,@Created,@DataBag)";

        private readonly string _connectionString;
        

        public BehaviorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(BehaviorData behavior)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                var command = connection.CreateCommand();
                command.CommandText = _create;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Name", behavior.Name);
                command.Parameters.AddWithValue("@Created", behavior.Created);
                command.Parameters.AddWithValue("@IP", behavior.IP);
                command.Parameters.AddWithValue("@Referrer", behavior.Referrer);
                command.Parameters.AddWithValue("@Url", behavior.Url);
                command.Parameters.AddWithValue("@UserAgent", behavior.UserAgent);
                command.Parameters.AddWithValue("@DataBag", Newtonsoft.Json.JsonConvert.SerializeObject(behavior.DataBag));
                command.ExecuteNonQuery();
            }

        }
    }
}