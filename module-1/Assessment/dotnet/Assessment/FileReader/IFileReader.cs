namespace Assessment.FileReader
{
    public interface IFileReader
    {
        /// <summary>
        /// Reads the file
        /// </summary>
        /// <param name="path">The path of the file</param>
        void ReadFile(string path);
        /// <summary>
        /// Gets the Result as a string
        /// </summary>
        /// <param name="lineDelimiter">Delimiter separating each line</param>
        /// <returns></returns>
        string GetResultAsString(string lineDelimiter);
        /// <summary>
        /// Gets the resulting lines of the file
        /// </summary>
        /// <returns>Returns an array of lines</returns>
        string[] GetResult();
    }
}