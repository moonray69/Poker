using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Poker.Models;

namespace Poker
{
    public class Serialization
    {
        private static string FILE_NAME = "userData.json";
        public static bool checkUser(string username,List<Player> players)
        {
            return players.Any(player => player.Nickname.Equals(username));
        }
        public static bool SaveData(Player playerData)
        {
            List<Player> jsonData = getAllPlayers();
            string fileName = Path.Combine(Environment.CurrentDirectory, FILE_NAME);
            if (checkUser(playerData.Nickname,jsonData))
            {
                return false;
            }
           
            jsonData.Add(playerData);

            string jsonOutput = JsonSerializer.Serialize(jsonData, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(fileName, jsonOutput);
            return true;
        }
        //? = це означає , що може бути нал
        public static Player ? findPlayer(string username, string password) 
        {
            List<Player> players = getAllPlayers();
            return players.Find(p => p.Nickname.Equals(username) && p.Password.Equals(password));
        }

        public static List<Player> getAllPlayers() 
        {
            string fileName = Path.Combine(Environment.CurrentDirectory, FILE_NAME);

            List<Player> jsonData = new List<Player>();
            if (File.Exists(fileName))
            {
                string existingData = File.ReadAllText(fileName);
                jsonData = JsonSerializer.Deserialize<List<Player>>(existingData) ?? new List<Player>();
            }
            return jsonData;
        }
    }
}
