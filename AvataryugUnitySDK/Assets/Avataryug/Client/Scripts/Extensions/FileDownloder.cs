using System;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.IO;

namespace Com.Avataryug
{
    /// <summary>
    /// The "FileDownloader" class is responsible for downloading files from a given URL
    /// as byte data and providing the ability to extract or process that data.
    /// It facilitates network requests, retrieves the file as byte data,
    /// and offers functionality for extracting specific information or manipulating the downloaded file's contents.
    /// </summary>
    public class FileDownloder
    {
        public static async Task<byte[]> GetGlbByte(string path)
        {
            byte[] imgdata = File.ReadAllBytes(path);
            await Task.Delay(1);
            return imgdata;
        }
        /// <summary>
        /// The "GetByteData" is used to download byte data from a specified URL.
        /// It takes parameters such as the URL,
        /// callback actions for handling the downloaded data and errors,
        /// and potentially a parameter for tracking the progress of the download.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="_result"></param>
        /// <param name="_error"></param>
        /// <param name="downloadProgress"></param>
        public static void GetByteData(string url, Action<byte[]> _result, Action<Exception> _error, Action<DownloadProgressChangedEventArgs> downloadProgress = null)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadProgressChanged += (s, p) => { downloadProgress?.Invoke(p); };
                webClient.DownloadDataCompleted += (s, e) =>
                {
                    if (e.Error != null)
                    {
                        _error?.Invoke(e.Error);
                    }
                    else
                    {
                        _result?.Invoke(e.Result);
                    }
                };
                webClient.DownloadDataAsync(new Uri(url));
            }
            catch (Exception ex)
            {
                _error?.Invoke(ex);
            }
        }

        /// <summary>
        /// The "GetNetworkTexture" is used to download byte data from a specified URL.
        /// It takes parameters such as the URL,
        /// callback actions for handling the downloaded data and errors,
        /// and potentially a parameter for tracking the progress of the download.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="_result"></param>
        /// <param name="_error"></param>
        /// <param name="progress"></param>
        public static async void GetNetworkTexture(string url, Action<Texture2D> _result, Action<Exception> _error = null, Action<float> progress = null)
        {
            try
            {
                UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
                var operation = www.SendWebRequest();
                while (!operation.isDone)
                {
                    progress?.Invoke(operation.progress);
                    await Task.Yield();
                }
                if (www.result != UnityWebRequest.Result.Success)
                    Debug.LogError($"Failed: {www.error}" + url);

                var texResult = DownloadHandlerTexture.GetContent(www);
                _result.Invoke(texResult);
                progress?.Invoke(operation.progress);
            }
            catch (Exception ex)
            {
                _error?.Invoke(ex);
            }
        }
    }

    /// <summary>
    /// The "FileHandler" class provides various methods for handling files.
    /// It includes methods such as
    /// "CheckFileExistence" to check if a file exists at a given URL,
    /// "LoadFile" to load a file from a specified location,
    /// "LoadByteFileContents" to read and retrieve the contents of a file,
    /// "SaveFile" to save a file to a specified location, and
    /// "ExtractFileName" to extract the name of a file from a given path or URL.
    /// These methods offer functionality related to file handling and manipulation within the context of the "FileHandler" class.
    /// </summary>
    public class FileHandler
    {
        /// <summary>
        /// Used to check if a file exists at a given URL.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool CheckFileExistence(string url)
        {
            string fileName = ExtractFileNameFromURL(url);
            string filePath = Path.Combine(Application.persistentDataPath, fileName);
            return File.Exists(filePath);
        }

        /// <summary>
        /// This is used to load a file from a specified location.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] LoadFile(string url)
        {
            string fileName = ExtractFileNameFromURL(url);
            return LoadByteFileContents(fileName);
        }

        /// <summary>
        /// This is used to read and retrieve the contents of a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static byte[] LoadByteFileContents(string fileName)
        {
            string filePath = Path.Combine(Application.persistentDataPath, fileName);
            if (File.Exists(filePath))
            {
                try
                {
                    byte[] fileContents = File.ReadAllBytes(filePath);
                    return fileContents;
                }
                catch (IOException ex)
                {
                    Debug.LogError("Failed to read the file: " + ex.Message);
                }
            }
            else
            {
                Debug.LogWarning("File not found: " + filePath);
            }
            return null;
        }

        /// <summary>
        /// This is used to extract the name of a file from a given path or URL.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static string ExtractFileNameFromURL(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
            {
                string fileName = Path.GetFileName(uri.LocalPath);
                return fileName;
            }
            return string.Empty;
        }

        /// <summary>
        /// This is used to save a file to a specified location.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="url"></param>
        /// <param name="oncomplete"></param>
        public static void SaveFile(byte[] data, string url, Action oncomplete)
        {
            string fileName = ExtractFileNameFromURL(url);
            string filePath = Path.Combine(Application.persistentDataPath, fileName);
            try
            {
                File.WriteAllBytes(filePath, data);
                oncomplete?.Invoke();
            }
            catch (IOException ex)
            {
                Debug.LogError("Failed to save data: " + ex.Message);
            }
        }
    }
}