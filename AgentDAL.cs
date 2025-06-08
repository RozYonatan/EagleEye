using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AgentsDB;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

public class AgentDAL
{
    private string connectionString =
        "server=localhost;" +
        "user=root;" +
        "password=;" +
        "database=eagleeyedb;" +
        "port=3306;"
        ;

    public void AddAgent(Agent agent)
    {
        MySqlConnection conn = new MySqlConnection(connectionString);

        conn.Open();

        string query = @"INSERT INTO agents (codeName, realName, location, status, missionsCompleted)
                  VALUES (@codeName, @realName, @location, @status, @missionsCompleted)";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@codeName", agent.codeName);
        cmd.Parameters.AddWithValue("@realName", agent.realName);
        cmd.Parameters.AddWithValue("@location", agent.location);
        cmd.Parameters.AddWithValue("@status", agent.status);
        cmd.Parameters.AddWithValue("@missionsCompleted", agent.missionsCompleted);
        cmd.ExecuteNonQuery();
        conn.Close();
    }


    public List<Agent> GetAllAgents()
    {
        List<Agent> agents = new List<Agent>();

        MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();

        string query = "SELECT * FROM agents";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Agent agent = new Agent(
                reader.GetString("codeName"),
                reader.GetString("realName"),
                reader.GetString("location"),
                reader.GetString("status"),
                reader.GetInt32("missionsCompleted"));
            agent.id = reader.GetInt32("id");


            agents.Add(agent);
        }

        reader.Close();
        conn.Close();

        return agents;
    }


    public void UpdateAgentLocation(int agentId, string newLocation)
    {
        MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        string query = "UPDATE agents SET location = @location WHERE id = @id";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@location", newLocation);
        cmd.Parameters.AddWithValue("@id", agentId);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void DeleteAgent(int agentId)
    {
        MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        string query = "DELETE FROM agents WHERE id = @id";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", agentId);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

}