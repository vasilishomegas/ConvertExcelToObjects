namespace ConvertExcelToObjects
{
    public class ExcelParser : IParser
    {
        public ExcelParser() { }
        public ExcelParser(string xml) { }
        public void ParseFile(string filename) {
            var wrapper = new ExcelDataReaderWrapper(); // I want to inject this library/wrapper as a dependency
            wrapper.ReadFile(filename);
        }
    }
}
