#region License
// author:         Wu, Gary
// created:        5:22 PM
// description:
#endregion

using System.Windows.Forms;
using CommonUtils.AdminUtils;

namespace CommonUtils.FileUtils;

public class FileHelper
{
	public static string? SelectFolder(string title, string? defaultFolder)
	{
		var dialog = new FolderBrowserDialog();
		dialog.Description = title;
		dialog.SelectedPath = defaultFolder ?? WindowsAdminHelper.GetDesktopPath();

		var result = dialog.ShowDialog();

		if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
		{
			return dialog.SelectedPath;
		}
		return null;
	}
}
