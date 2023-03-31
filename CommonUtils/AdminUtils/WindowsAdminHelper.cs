#region License
// author:         Wu, Gary
// created:        5:22 PM
// description:
#endregion

namespace CommonUtils.AdminUtils;

public class WindowsAdminHelper
{
	public static string GetCurrentUser()
	{
		return Environment.UserName;
	}

	public static string GetDesktopPath()
	{
		return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
	}
}