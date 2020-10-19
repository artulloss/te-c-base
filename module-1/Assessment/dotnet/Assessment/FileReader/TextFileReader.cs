using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assessment.FileReader
{
    public class TextFileReader : IFileReader
    {
        public bool HasBeenRead { get; private set; }
        private readonly List<string> _lines = new List<string>();
        public async void ReadFile(string path) {
            try {
                using (StreamReader streamReader = new StreamReader(path)) { // Async read the lines
                    while (!streamReader.EndOfStream) {
                        _lines.Add(await streamReader.ReadLineAsync());
                    }
                    Console.WriteLine("Completed Reading"); // TODO REMOVE
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        public string GetResultAsString(string lineDelimiter) {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var line in _lines) {
                stringBuilder.Append(line);
                stringBuilder.Append(lineDelimiter);
            }
            return stringBuilder.ToString();
        }

        public string[] GetResult() {
            return _lines.ToArray();
        }
    }
}