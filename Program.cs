using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

class Program
{
    static void Main(string[] args)
    {
        var filesPath = "/home/cedric/Bureau/AprentissageC#/Data/data/2017";
        var files = Directory.GetFiles(filesPath, "*.csv");
        var allData = new List<MyData>();

        foreach (var file in files)
        {
            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                allData.AddRange(csv.GetRecords<MyData>());
            }
        }

        var processedData = allData.Select(d => new { d.Date, d.Service, d.nbCustomer, d.TotalPrice }).ToList();

        var customersPerDay = processedData
            .GroupBy(d => d.Date)
            .Select(group => new { Date = group.Key, TotalCustomers = group.Sum(d => d.nbCustomer) })
            .ToList();

        var customersPerMonth = processedData
            .GroupBy(d => Convert.ToDateTime(d.Date).Month)
            .Select(group => new { Month = group.Key, TotalCustomers = group.Sum(d => d.nbCustomer) })
            .ToList();

        ExportToCsv(customersPerDay, "customersPerDay.csv");
        ExportToCsv(customersPerMonth, "customersPerMonth.csv");
    }

    static void ExportToCsv<T>(IEnumerable<T> records, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(records);
        }
    }
}

public class MyData
{
    public string Date { get; set; } = string.Empty;
    public string Service { get; set; } = string.Empty;
    public int nbTable { get; set; }
    public int nbCustomer { get; set; }
    public double TotalPrice { get; set; }
}
