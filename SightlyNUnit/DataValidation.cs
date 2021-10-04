using System;
using System.Data;
using ExcelDataReader;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using JsonDiffPatchDotNet;
using System.Linq;

namespace SightlyNUnit
{
    class DataValidation
    {

        public bool ValidateData()
        {
            // Text encoding setting for .NET 3
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Initialize Comparison Results Variables
            bool stringCompare = new bool();
            bool jsonCompare = new bool();

            // Get file path of latest Excel file download
            DirectoryInfo info = new DirectoryInfo(@"C:\Users\Tyler\Downloads");
            FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
            string lastFile = files.Last().ToString();
            lastFile = lastFile.Replace(@"\", @"\\");
            Debug.WriteLine(lastFile + "\n");

            // Open Excel file path with ExcelDataReader
            FileStream stream = File.Open(lastFile, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            // Create DataSet object with ExcelDataReader.Dataset
            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    // Use Excel Row Headers in Json
                    UseHeaderRow = true,
                    ReadHeaderRow = rowReader =>
                    {
                        // Skip the first 4 lines of the Report, Look for Header on Row 5
                        for (int i=0; i<4; i++ )
                        {
                            rowReader.Read();
                        }
                    }
                }
            });
            excelReader.Close();

            // Convert DataSet to JSON string
            string jsonStringDownload = string.Empty;
            jsonStringDownload = JsonConvert.SerializeObject(result);
            Debug.Write(jsonStringDownload + "\n");

            // Read Validation Data JSON file to string
            StreamReader r = new StreamReader("C:\\Users\\Tyler\\Documents\\Sightly\\Sightly.json");
            string jsonStringValidation = r.ReadToEnd();
            Debug.Write(jsonStringValidation + "\n");

            // Compare Downloaded Report to Validation data using String comparison
            if (String.Equals(jsonStringDownload, jsonStringValidation))
            {
                stringCompare = true;
                Debug.Write("string data valid" + "\n");
            }
            else
            {
                stringCompare = false;
                Debug.Write("string data not valid" + "\n");
            }

            // Convert JSON strings to Json objects
            dynamic jsonDownload = JsonConvert.DeserializeObject(jsonStringDownload);
            dynamic jsonValidation = JsonConvert.DeserializeObject(jsonStringValidation);

            // Compare the two json objects
            if (JToken.DeepEquals(jsonDownload, jsonValidation))
            {
                jsonCompare = true;
                Debug.Write("valid json comparison" + "\n");
            }
            else
            {
                jsonCompare = false;
                Debug.Write("invalid json comparison" + "\n");
            }

            // Use JsonDiffPatch to identify differences
            var jdp = new JsonDiffPatch();
            JToken diffResult = jdp.Diff(jsonStringDownload, jsonStringValidation);
            Debug.Write(diffResult);

            if (stringCompare == true && jsonCompare == true)
            {
                return true;
            }
            else
                return false;
        }

    }
}
