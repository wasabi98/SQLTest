using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace SQLTest;

class SQLTest
{
    static void Main(string[] args)
    {
        DatabaseManager dbManager = new DatabaseManager();
        dbManager.Init();
        
    }
}
