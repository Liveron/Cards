namespace Tests.FakeFileSystem
{
    public static class FakeFileSystemHelper
    {
        const string FAKE_FILE_SYSTEM_DIR_NAME = "FakeFileSystem";
        const string FAKE_FILES_DIR_NAME = "FakeFiles";

        const string SCRUB_EMPTY_FILE_NAME = "ScrubEmptyFile.json";
        public static string GetScrubEmptyFilePath()
        {
            return Path.Combine(
                Directory.GetCurrentDirectory(), 
                FAKE_FILE_SYSTEM_DIR_NAME, 
                FAKE_FILES_DIR_NAME, 
                SCRUB_EMPTY_FILE_NAME);
        }
    }
}
