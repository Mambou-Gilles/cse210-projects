using System;
using System.Collections.Generic;
using System.IO;

class ActivityLog
{
    private Dictionary<string, int> _log;
    private string _logFilePath;

    public ActivityLog(string logFilePath)
    {
        _logFilePath = logFilePath;
        _log = LoadLog();
    }

    // Increment the count for a given activity
    public void IncrementActivity(string activityName)
    {
        if (_log.ContainsKey(activityName))
        {
            _log[activityName]++;
        }
        else
        {
            _log[activityName] = 1;
        }
        SaveLog();
    }

    // Display the log
    public void DisplayLog()
    {
        
        if (_log.Count == 0)
        {
            Console.WriteLine("Activity Log is empty.");
        }
        else
        {
            Console.WriteLine("Activity Log:");
            foreach (var entry in _log)
            {
                if (entry.Value >= 2)
                {
                    Console.WriteLine($"- {entry.Key}: {entry.Value} times");
                }
                else {
                    Console.WriteLine($"- {entry.Key}: {entry.Value} time");
                }
                
            }
        }
    }

    public void ClearLog()
    {
        _log.Clear();
        SaveLog();
    }

    // Load the log from a file
    private Dictionary<string, int> LoadLog()
    {
        var log = new Dictionary<string, int>();

        if (File.Exists(_logFilePath))
        {
            string[] lines = File.ReadAllLines(_logFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                {
                    log[parts[0]] = count;
                }
            }
        }

        return log;
    }

    // Save the log to a file
    private void SaveLog()
    {
        using (StreamWriter writer = new StreamWriter(_logFilePath))
        {
            foreach (var entry in _log)
            {
                writer.WriteLine($"{entry.Key}|{entry.Value}");
            }
        }
    }
}
