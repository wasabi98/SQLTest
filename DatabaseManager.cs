using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using Microsoft.VisualBasic;
using SQLTest.Tables;

namespace SQLTest
{
    internal class DatabaseManager
    {
        public List<DataBaseInstance> dbInstances = new List<DataBaseInstance>();
        

        public void Init()
        {
            List<string> Databases = GetDbPaths();
            foreach (string DbPath in Databases)
            {
                SQLiteConnection connection = new SQLiteConnection($"Data Source={DbPath}");
                connection.Open();
                DataBaseInstance instance = new DataBaseInstance();

                SQLiteCommand commandTable;
                SQLiteDataReader readerTable;

                using (SQLiteCommand command = new SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='Lap';", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            commandTable = new SQLiteCommand("SELECT * FROM Lap", connection);
                            readerTable = commandTable.ExecuteReader();


                            if (readerTable.HasRows)
                            {
                                while (readerTable.Read())
                                {
                                    Lap lap = new Lap();

                                    lap.ID = readerTable.GetInt32(0);
                                    lap.SpeedRaceID = readerTable.GetInt32(1);
                                    lap.LaserTime = readerTable.GetInt32(2);
                                    lap.ManualTime = readerTable.GetInt32(3);
                                    lap.SelectedTime = readerTable.GetInt32(4);
                                    lap.IsWarmUp = readerTable.GetInt32(5);

                                    instance.laps.Add(lap);
                                }
                            }
                        }
                    }
                }

                using (SQLiteCommand command = new SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='SkillRace';", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            commandTable = new SQLiteCommand("SELECT * FROM SkillRace", connection);
                            readerTable = commandTable.ExecuteReader();
                            if (readerTable.HasRows)
                            {
                                while (readerTable.Read())
                                {
                                    SkillRace skillRace = new SkillRace();

                                    skillRace.ID = readerTable.GetInt32(0);
                                    skillRace.TeamID = readerTable.GetInt32(1);
                                    skillRace.StartSucceded = readerTable.GetInt32(2);
                                    skillRace.LaneChangeSucceeded = readerTable.GetInt32(3);
                                    skillRace.CheckpointState = readerTable.GetInt32(4);
                                    skillRace.Time = readerTable.GetInt32(5);
                                    skillRace.Points = readerTable.GetInt32(6);
                                    skillRace.isAborted = readerTable.GetInt32(7);
                                    //skillRace.TouchCount = readerTable.GetInt32(8);

                                    instance.skillRaces.Add(skillRace);
                                }
                            }
                        }
                    }
                }

                using (SQLiteCommand command = new SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='SpeedRace';", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            commandTable = new SQLiteCommand("SELECT * FROM SpeedRace", connection);
                            readerTable = commandTable.ExecuteReader();
                            if (readerTable.HasRows)
                            {
                                while (readerTable.Read())
                                {
                                    SpeedRace speedRace = new SpeedRace();

                                    speedRace.ID = readerTable.GetInt32(0);
                                    speedRace.TeamID = readerTable.GetInt32(1);
                                    speedRace.SafetyCarFollowed = readerTable.GetInt32(2);
                                    speedRace.SafetyCarOvertaken = readerTable.GetInt32(3);
                                    speedRace.BestLapTime = readerTable.GetInt32(4);
                                    speedRace.IsAborted = readerTable.GetInt32(5);
                                    speedRace.TouchCount = readerTable.GetInt32(6);
                                    speedRace.AdditionalPoints = readerTable.GetInt32(7);


                                    instance.speedRaces.Add(speedRace);
                                }
                            }
                        }
                    }
                }
                using (SQLiteCommand command = new SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='Team';", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            commandTable = new SQLiteCommand("SELECT * FROM Team", connection);
                            readerTable = commandTable.ExecuteReader();
                            if (readerTable.HasRows)
                            {
                                while (readerTable.Read())
                                {
                                    Team team = new Team();

                                    team.TeamID = readerTable.GetInt32(0);
                                    team.Name = readerTable.GetString(1);
                                    team.IsJunior = readerTable.GetInt32(2);
                                    team.QualificationPoint = readerTable.GetInt32(3);
                                    team.AudienceVoteCount = readerTable.GetInt32(4);


                                    instance.teams.Add(team);
                                }
                            }
                        }
                    }
                }

                using (SQLiteCommand command = new SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='TeamMember';", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            commandTable = new SQLiteCommand("SELECT * FROM TeamMember", connection);
                            readerTable = commandTable.ExecuteReader();
                            if (readerTable.HasRows)
                            {
                                while (readerTable.Read())
                                {
                                    TeamMember teamMember = new TeamMember();

                                    teamMember.ID = readerTable.GetInt32(0);
                                    teamMember.TeamID = readerTable.GetInt32(1);
                                    teamMember.Name = readerTable.GetString(2);


                                    instance.teamMembers.Add(teamMember);
                                }
                            }
                            
                        }
                    }
                }

                connection.Close();
                dbInstances.Add(instance);

            }
            
        }
        private List<string> GetDbPaths()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string extension = ".sqlite";
            List<string> paths = new List<string>();
            foreach (string file in Directory.EnumerateFiles(path, "*" + extension))
            {
                paths.Add(file);
            }
            return paths;
        }
    }
}
