using ExcelDataReader;
using System.Data;

namespace ConvertExcelToObjects
{
    public class ExcelDataReaderWrapper
    {
        public void ReadFile(string filename)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            List < Dictionary<string, string> > objects = new(); // create dynamic set
            Dictionary<string, string> data = new(); // these should be created dynamically inside the inner loop below, with only the columns added as fields that actually hold a value for a particular record
            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read)) // maybe there is a way to use this (or another) library without so much manual work, but I am not familiar with it
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    foreach (DataTable table in result.Tables)
                    {
                        bool firstRow = true;
                        foreach (DataRow row in table.Rows)
                        {
                            if (firstRow) // get column headers (I don't want to check this every time though)
                            {
                                firstRow = false;

                            }
                            foreach (var cell in row.ItemArray) // then store the values of each row under the corresponding header
                            {
                                Console.Write($"{cell} ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
