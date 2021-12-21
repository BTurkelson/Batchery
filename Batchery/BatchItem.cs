using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Batchery
{
	public class BatchItem
	{
		public string FilePath { get; set; }
		public string DisplayName { get; set; }
		public string Arguments { get; set; }
		public string WorkingDirectory { get; set; }
		public int Iterations { get; set; }
		public bool AbortOnNonZeroExitCode { get; set; }
		public string Editor { get; set; }
		public string FileToEdit { get; set; }
		public bool IsChecked { get; set; }

		public BatchItem(string baseFilePath)
		{
			FilePath = baseFilePath;
			DisplayName = System.IO.Path.GetFileNameWithoutExtension(FilePath);
			Arguments = "";
			WorkingDirectory = System.IO.Path.GetDirectoryName(FilePath);
			Iterations = 1;
			AbortOnNonZeroExitCode = true;

			if (IsTextFile(FilePath))
            {
				// This is hacky, yes. TODO - Fix default editor config.
				if (System.IO.File.Exists("C:\\Program Files\\Notepad++\\notepad++.exe"))
				{
					Editor = "C:\\Program Files\\Notepad++\\notepad++.exe";
				}
				else
				{
					Editor = "Notepad.exe";
				}

				FileToEdit = FilePath;
			}
		}

		[JsonConstructor]
		public BatchItem()
		{
			// No impl; only used during deserialization and the public setters will be used to populate the data structure during deserialization.
		}

		public static string SerializeArray(BatchItem[] source)
		{
			return JsonSerializer.Serialize<BatchItem[]>(source);
		}

		public static BatchItem[] DeserializeArray(string source)
		{
			BatchItem[] batchItems = JsonSerializer.Deserialize<BatchItem[]>(source);

			// Quick sanity check.
			foreach (BatchItem item in batchItems)
			{
				if (item.Iterations <= 0)
				{
					item.Iterations = 1;
				}
			}

			return batchItems;
		}

		public static bool IsTextFile(string path)
        {
			// This is not infallible; just a guess by looking at the file, really.
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
			if (fileInfo.Exists == false)
			{
				return false;
			}
			else if (fileInfo.Length > (1024 * 1024))
			{
				// Text files aren't usually > 1mb.
				return false;
			}
			else
			{
				// If there are two consecutive nulls in the file, it's probably not text.
				byte[] content = System.IO.File.ReadAllBytes(path);
				for (int i = 1; i < content.Length; i++)
				{
					if (content[i] == 0x00 && content[i - 1] == 0x00)
					{
						return false;
					}
				}
			}
			return true;
        }
	}
}
