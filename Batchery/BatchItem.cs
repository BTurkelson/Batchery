using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class BatchItem
{
	public string FilePath { get; set; }
	public string DisplayName { get; set; }
	public string Arguments { get; set; }
	public string WorkingDirectory { get; set; }
	public int NumRuns { get; set; }
	public bool AbortOnNonZeroExitCode { get; set; }
	public bool IsChecked { get; set; }

	public BatchItem(string baseFilePath)
	{
		FilePath = baseFilePath;
		DisplayName = System.IO.Path.GetFileNameWithoutExtension(FilePath);
		Arguments = "";
		WorkingDirectory = System.IO.Path.GetDirectoryName(FilePath);
		NumRuns = 1;
		AbortOnNonZeroExitCode = true;
	}

	[JsonConstructor]
	public BatchItem()
    {
		// No impl, as the public setters will be used to populate the data structure during deserialization.
    }

	public static string SerializeArray(BatchItem[] source)
    {
		return JsonSerializer.Serialize<BatchItem[]>(source);
	}

	public static BatchItem[] DeserializeArray(string source)
    {
		return JsonSerializer.Deserialize<BatchItem[]>(source);
	}
}
