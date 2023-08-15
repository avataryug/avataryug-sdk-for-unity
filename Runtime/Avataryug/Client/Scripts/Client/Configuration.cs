using System;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;

namespace Com.Avataryug.Client
{
    /// <summary>
    /// Represents a set of configuration settings
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// To configure the base URL, assign the desired value to the "BaseUrl" variable.
        /// </summary>
        public static void SetApi()
        {
            string id = "";
            if (!string.IsNullOrEmpty(projectid))
            {
                id = projectid;
            }
            else if (!string.IsNullOrEmpty(ProjectId))
            {
                id = ProjectId;
            }
            DefaultApiClient = new ApiClient("https://" + id + ".avataryugapi.com/client");
        }

        /// <summary>
        /// Set UserID
        /// </summary>
        /// <param name="id"></param>
        public static void SetUserID(string id)
        {
            userIds = id;
        }

        /// <summary>
        /// Set Project ID
        /// </summary>
        /// <param name="id"></param>
        public static void SetProjectID(string id)
        {
            projectid = ProjectId = id;
        }

        //To retrieve or assign the Project ID, use the getter and setter methods for the "ProjectId" property.
        public static string ProjectId
        {
            get
            {
                var settingsList = Resources.LoadAll<AvatarProjectSettings>("AvatarProjectSettings");
                if (settingsList.Length == 0)
                {
                    Debug.LogError("No Project Setting File Found!");
                    return null;
                }

                if (settingsList.Length != 1)
                {
                    Debug.LogWarning("Multiple of no Project Setting");
                }

                return settingsList[0].ProjectId;
            }
            set
            {
                var settingsList = Resources.LoadAll<AvatarProjectSettings>("AvatarProjectSettings");
                if (settingsList.Length != 1)
                {
                    Debug.LogWarning("Multiple of no Project Setting");
                }
                settingsList[0].ProjectId = value;
                settingsList[0].Save();
            }
        }

        /// The "AvatarProjectSettings" class is used for loading the asset project setting data
        public static AvatarProjectSettings avatarProjectSettings
        {
            get
            {
                var settingsList = Resources.LoadAll<AvatarProjectSettings>("AvatarProjectSettings");
                return settingsList[0];
            }
        }

        // To retrieve and modify the value of the secret key, access the static variable "SecretKey" through the appropriate getter and setter methods.
        public static string SecretKey
        {
            get
            {
                var settingsList = Resources.LoadAll<AvatarProjectSettings>("AvatarProjectSettings");
                if (settingsList.Length != 1)
                {
                    Debug.LogWarning("Multiple of no Project Setting");
                }

                return settingsList[0].SecretKey;
            }
            set
            {
                var settingsList = Resources.LoadAll<AvatarProjectSettings>("AvatarProjectSettings");
                if (settingsList.Length != 1)
                {
                    Debug.LogWarning("Multiple of no Project Setting");
                }
                settingsList[0].SecretKey = value;
                settingsList[0].Save();
            }
        }

        // To retrieve and modify the value of the secret key, access the static variable "IVSecretKey" through the appropriate getter and setter methods.
        public static string IVSecretKey
        {
            get
            {
                var settingsList = Resources.LoadAll<AvatarProjectSettings>("AvatarProjectSettings");
                if (settingsList.Length != 1)
                {
                    Debug.LogWarning("Multiple of no Project Setting");
                }

                return settingsList[0].IVSecretKey;
            }
            set
            {
                var settingsList = Resources.LoadAll<AvatarProjectSettings>("AvatarProjectSettings");
                if (settingsList.Length != 1)
                {
                    Debug.LogWarning("Multiple of no Project Setting");
                }
                settingsList[0].IVSecretKey = value;
                settingsList[0].Save();
            }
        }


        // To check if the Project ID is set, you can verify the value of the Project ID variable or property.
        public static bool ProjectIdPresent
        {
            get
            {
                string id = "";
                if (!string.IsNullOrEmpty(projectid))
                {
                    id = projectid;
                }
                else
                {
                    var settingsList = Resources.LoadAll<AvatarProjectSettings>("AvatarProjectSettings");
                    if (settingsList.Length != 1)
                    {
                        Debug.LogWarning("Multiple of no Project Setting");
                    }
                    id = settingsList[0].ProjectId;
                }
                return !string.IsNullOrEmpty(id);
            }
        }

        //To set user id 
        public static string userIds;

        //The variable "projectId" is utilized to determine whether the project ID has been set or not.
        private static string projectid;

        /// <summary>
        /// Version of the package.
        /// </summary>
        /// <value>Version of the package.</value>
        public const string Version = "1.0.0";

        /// <summary>
        /// Gets or sets the default API client for making HTTP calls.
        /// </summary>
        /// <value>The API client.</value>
        public static ApiClient DefaultApiClient = new ApiClient();

        /// <summary>
        /// Gets or sets the username (HTTP basic authentication).
        /// </summary>
        /// <value>The username.</value>
        public static String Username { get; set; }

        /// <summary>
        /// Gets or sets the password (HTTP basic authentication).
        /// </summary>
        /// <value>The password.</value>
        public static String Password { get; set; }

        /// <summary>
        /// Gets or sets the access token (Bearer/OAuth authentication).
        /// </summary>
        /// <value>The access token.</value>
        public static String AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// </summary>
        /// <value>The API key.</value>
        public static Dictionary<String, String> ApiKey = new Dictionary<String, String>();

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        /// </summary>
        /// <value>The prefix of the API key.</value>
        public static Dictionary<String, String> ApiKeyPrefix = new Dictionary<String, String>();

        /// <summary>
        /// To retrieve the path of the temporary folder
        /// </summary>
        private static string _tempFolderPath = Path.GetTempPath();

        /// <summary>
        /// Gets or sets the temporary folder path to store the files downloaded from the server.
        /// </summary>
        /// <value>Folder path.</value>
        public static String TempFolderPath
        {
            get { return _tempFolderPath; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    _tempFolderPath = value;
                    return;
                }

                // Create the directory if it does not exist
                if (!Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }

                // check if the path contains directory separator at the end
                if (value[value.Length - 1] == Path.DirectorySeparatorChar)
                {
                    _tempFolderPath = value;
                }
                else
                {
                    _tempFolderPath = value + Path.DirectorySeparatorChar;
                }
            }
        }

        //Date Format
        private const string ISO8601_DATETIME_FORMAT = "o";

        //Date Format
        private static string _dateTimeFormat = ISO8601_DATETIME_FORMAT;

        /// <summary>
        /// Gets or sets the date time format used when serializing in the ApiClient
        /// By default, it's set to ISO 8601 - "o", for others see:
        /// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        /// and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        /// No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public static String DateTimeFormat
        {
            get
            {
                return _dateTimeFormat;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }

        /// <summary>
        /// Returns a string with essential information for debugging.
        /// </summary>
        public static String ToDebugReport()
        {
            String report = "C# SDK (Com.Avataryug) Debug Report:\n";
            report += "    OS: " + Environment.OSVersion + "\n";
            report += "    .NET Framework Version: " + Assembly
                     .GetExecutingAssembly()
                     .GetReferencedAssemblies()
                     .Where(x => x.Name == "System.Core").First().Version.ToString() + "\n";
            report += "    Version of the API: 1.0\n";
            report += "    SDK Package Version: 1.0.0\n";

            return report;
        }
    }
}
