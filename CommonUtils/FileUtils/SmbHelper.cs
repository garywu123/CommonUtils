#region License
// author:         Wu, Gary
// created:        5:24 PM
// description:
#endregion

using SMBLibrary.Client;
using SMBLibrary;
using System.Net;

namespace CommonUtils.FileUtils;

public class SmbHelper
{

	public static async Task<SMB2Client?> TryLoginToSmbServerAsync(
		string serverAddress, string? domain, string username, string password)
	{
		var client = new SMB2Client();
		var isConnected = await Task.Run(() => client.Connect(
				IPAddress.Parse(serverAddress), SMBTransportType.DirectTCPTransport
			)
		);

		if (!isConnected)
		{
			throw new InvalidOperationException("Unable to connect with SMB server. Make sure the target device is online.");
		}
		else
		{
			var status = client.Login(domain ?? string.Empty, username, password);

			if (status != NTStatus.STATUS_SUCCESS)
			{
				return null;
			}
		}
		throw new NotImplementedException();
	}

	// public static async Task CopyFilesFromSMBSharedFolderAsync(string serverAddress, string shareName, string username, string password, string localFolderPath)
	// {
	// 	var client = new SMB2Client();
	// 	bool isConnected = client.Connect(serverAddress, SMBTransportType.DirectTCPTransport);
	// 	if (!isConnected)
	// 	{
	// 		Console.WriteLine("Failed to connect to the server");
	// 		return;
	// 	}
	//
	// 	NTStatus nts = client.Login(SMBLibrary.Authentication.GSSProvider.AuthenticationMethod.NTLMv2, username, password);
	// 	if (nts != NTStatus.STATUS_SUCCESS)
	// 	{
	// 		Console.WriteLine("Login failed");
	// 		return;
	// 	}
	//
	// 	SMB2FileStore fileStore = client.TreeConnect(shareName, out nts);
	// 	if (nts != NTStatus.STATUS_SUCCESS)
	// 	{
	// 		Console.WriteLine("Failed to access the shared folder");
	// 		return;
	// 	}
	//
	// 	IEnumerable<FileInformation> files;
	// 	nts = fileStore.QueryDirectory(out files, string.Empty, FileInformationClass.FileDirectoryInformation);
	//
	// 	if (nts != NTStatus.STATUS_SUCCESS)
	// 	{
	// 		Console.WriteLine("Failed to retrieve file list");
	// 		return;
	// 	}
	//
	// 	foreach (FileInformation fileInfo in files)
	// 	{
	// 		string remoteFileName = ((FileDirectoryInformation)fileInfo).FileName;
	// 		string localFilePath  = Path.Combine(localFolderPath, remoteFileName);
	//
	// 		using (var localFileStream = new FileStream(localFilePath, FileMode.Create, FileAccess.Write))
	// 		{
	// 			using (var remoteFileStream = fileStore.OpenFile(remoteFileName, FileAccess.Read))
	// 			{
	// 				await remoteFileStream.CopyToAsync(localFileStream);
	// 			}
	// 		}
	// 	}
	//
	// 	client.Logoff();
	// 	client.Disconnect();
	// }


}
