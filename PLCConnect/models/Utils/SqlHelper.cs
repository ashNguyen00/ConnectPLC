using Microsoft.Data.Sqlite;
using System;
using System.Data;

public class SQLiteHelper
{
    private SqliteConnection connection;

    public SQLiteHelper(string dbPath)
    {
        connection = new SqliteConnection($"Data Source={dbPath}");
        connection.Open();
    }

    public void Close()
    {
        connection?.Close();
    }

    // check table
    public bool TableExists(string tableName)
    {
        string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name=$name";

        using (var cmd = new SqliteCommand(sql, connection))
        {

            cmd.Parameters.AddWithValue("$name", tableName);
            return cmd.ExecuteScalar() != null;
        }
    }

    // check column
    public bool ColumnExists(string tableName, string columnName)
    {
        if (!TableExists(tableName))
            throw new Exception($"Table '{tableName}' not found");

        string sql = $"PRAGMA table_info({tableName})";

        using (var cmd = new SqliteCommand(sql, connection))
        {
            using (var reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    if (reader["name"].ToString() == columnName)
                        return true;
                }
            } 
        }

        return false;
    }

    // create table
    public void CreateTable(string tableName, string columns)
    {
        if (TableExists(tableName))
            throw new Exception($"Table '{tableName}' already exists");

        string sql = $"CREATE TABLE {tableName} ({columns})";

        using (var cmd = new SqliteCommand(sql, connection))
        {

            cmd.ExecuteNonQuery();
        }
    }

    // add column
    public void AddColumn(string tableName, string columnDefinition)
    {
        string columnName = columnDefinition.Split(' ')[0];

        if (!TableExists(tableName))
            throw new Exception($"Table '{tableName}' not found");

        if (ColumnExists(tableName, columnName))
            throw new Exception($"Column '{columnName}' already exists");

        string sql = $"ALTER TABLE {tableName} ADD COLUMN {columnDefinition}";

        using (var cmd = new SqliteCommand(sql, connection))
        {
            cmd.ExecuteNonQuery();
        }
    }

    // insert
    public void Insert(string tableName, string columns, string values)
    {
        if (!TableExists(tableName))
            throw new Exception($"Table '{tableName}' not found");

        string sql = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

        using (var cmd = new SqliteCommand(sql, connection))
        {
            cmd.ExecuteNonQuery();

        } 
    }

    // update
    public int Update(string tableName, string setClause, string condition)
    {
        string sql = $"UPDATE {tableName} SET {setClause} WHERE {condition}";

        using (var cmd = new SqliteCommand(sql, connection))
        {

            return cmd.ExecuteNonQuery();
        }
    }

    // delete
    public int Delete(string tableName, string condition)
    {
        string sql = $"DELETE FROM {tableName} WHERE {condition}";

        using (var cmd = new SqliteCommand(sql, connection))
        {
            return cmd.ExecuteNonQuery();

        }
    }

    // query -> DataTable
    public DataTable Query(string sql)
    {
        using (var cmd = new SqliteCommand(sql, connection))
        {

            using (var reader = cmd.ExecuteReader())
            {
                DataTable table = new DataTable();
                table.Load(reader);

                return table;
            }
        }
    }
}