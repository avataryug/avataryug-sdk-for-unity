using Com.Avataryug.Client;
using Com.Avataryug.Handler;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Avataryug
{
    /// <summary>
    /// This ExampleAvatarmanagement Class demonstrates API calling methods with temporary data.
    /// </summary>
    public class ExampleAvatarmanagement : MonoBehaviour
    {
        public Button generateAvatarMeshButton;
        public Button getAvatarPresetsButton;
        public Button getClipsButton;
        public Button getClipsByIDButton;
        public Button getExpressionsBtnButton;
        public Button getExpressionsByIDButton;
        public Button getAllBucketVerticesButton;
        public Button grantAvatarPresetItemsToUserButton;
        public Button renderAvatarImageButton;
        public Button syncAvatarsButton;
        public Button grantAvatarPresetToUserButton;
        public Button getAvatarPresetsByIDButton;

        private void OnEnable()
        {
            if (generateAvatarMeshButton != null)
            {
                generateAvatarMeshButton.onClick.RemoveAllListeners();
                generateAvatarMeshButton.onClick.AddListener(GeneratesAvatarMesh);
            }
            if (getAvatarPresetsButton != null)
            {
                getAvatarPresetsButton.onClick.RemoveAllListeners();
                getAvatarPresetsButton.onClick.AddListener(GetAvatarsPresets);
            }
            if (getClipsButton != null)
            {
                getClipsButton.onClick.RemoveAllListeners();
                getClipsButton.onClick.AddListener(GetClip);
            }
            if (getClipsByIDButton != null)
            {
                getClipsByIDButton.onClick.RemoveAllListeners();
                getClipsByIDButton.onClick.AddListener(GetClipByID);
            }
            if (getExpressionsBtnButton != null)
            {
                getExpressionsBtnButton.onClick.RemoveAllListeners();
                getExpressionsBtnButton.onClick.AddListener(GetExpression);
            }
            if (getExpressionsByIDButton != null)
            {
                getExpressionsByIDButton.onClick.RemoveAllListeners();
                getExpressionsByIDButton.onClick.AddListener(GetExpressionsByID);
            }
            if (getAllBucketVerticesButton != null)
            {
                getAllBucketVerticesButton.onClick.RemoveAllListeners();
                getAllBucketVerticesButton.onClick.AddListener(GetAllBucketsVertices);
            }
            if (grantAvatarPresetItemsToUserButton != null)
            {
                grantAvatarPresetItemsToUserButton.onClick.RemoveAllListeners();
                grantAvatarPresetItemsToUserButton.onClick.AddListener(GrantAvatarPresetItemToUser);
            }
            if (renderAvatarImageButton != null)
            {
                renderAvatarImageButton.onClick.RemoveAllListeners();
                renderAvatarImageButton.onClick.AddListener(RenderAvatarsImage);
            }
            if (syncAvatarsButton != null)
            {
                syncAvatarsButton.onClick.RemoveAllListeners();
                syncAvatarsButton.onClick.AddListener(SyncAvatar);
            }
            if (grantAvatarPresetToUserButton != null)
            {
                grantAvatarPresetToUserButton.onClick.RemoveAllListeners();
                grantAvatarPresetToUserButton.onClick.AddListener(GrantAvatarPresetsToUser);
            }
            if (getAvatarPresetsByIDButton != null)
            {
                getAvatarPresetsByIDButton.onClick.RemoveAllListeners();
                getAvatarPresetsByIDButton.onClick.AddListener(GetAvatarsPresetsByID);
            }
        }

        /// <summary>
        /// Generates the 3D mesh as per the configuration in the Config panel
        /// </summary>
        private void GeneratesAvatarMesh()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GenerateAvatarMesh Button Click---->>>");
            var auth = new AvatarManagementHandler(new GenerateAvatarMesh()
            {
                AvatarID = "AvatarID1010",
                Platform = "Android"
            });
            auth.GenerateAvatarMesh((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GenerateAvatarMesh-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GenerateAvatarMesh-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get all avatar presets
        /// </summary>
        private void GetAvatarsPresets()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetAvatarPresets Button Click---->>>");
            var auth = new AvatarManagementHandler(new GetAvatarPresets()
            {
                Status = 1,
                Gender = 3
            });
            auth.GetAvatarPresets((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetAvatarPresets-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetAvatarPresets-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get all the clips by Active status
        /// </summary>
        private void GetClip()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetClip Button Click---->>>");
            var auth = new AvatarManagementHandler(new GetClips()
            {
                Status = 1
            });
            auth.GetClips((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetClips-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetClips-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get the specified clip's details by providing ClipID
        /// </summary>
        private void GetClipByID()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetClipsByID Button Click---->>>");
            var auth = new AvatarManagementHandler(new GetClipsByID()
            {
                clipID = "031a4f38-d53e-498f-94d3-53c19c6deae9"
            });
            auth.GetClipsByID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetClipsByID-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetClipsByID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get all the active expressions
        /// </summary>
        private void GetExpression()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetExpressions Button Click---->>>");
            var auth = new AvatarManagementHandler(new GetExpressions()
            {
                Status = 1
            });
            auth.GetExpressions((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetExpressions-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetExpressions-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get the specified expression details by providing ExpressionID
        /// </summary>
        private void GetExpressionsByID()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetExpressionByID Button Click---->>>");
            var auth = new AvatarManagementHandler(new GetExpressionByID()
            {
                expressionID = "7c0af41a-c43c-45ff-b61e-2605b079f074"
            });
            auth.GetExpressionByID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetExpressionByID-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetExpressionByID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get vertices for all buckets
        /// </summary>
        private void GetAllBucketsVertices()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetAllBucketVertices Button Click---->>>");
            var auth = new AvatarManagementHandler(new GetAllBucketVertices()
            {
                platform = "unity"
            });
            auth.GetAllBucketVertices((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetAllBucketVertices-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetAllBucketVertices-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Grant Avatar Preset Items To User
        /// </summary>
        private void GrantAvatarPresetItemToUser()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GrantAvatarPresetItemsToUser Button Click---->>>");
            var auth = new AvatarManagementHandler(new GrantAvatarPresetItemsToUser()
            {
                itemId = new System.Collections.Generic.List<string>() { "0474376d-d886-4681-a08a-2c6adbca248e" }
            });
            auth.GrantAvatarPresetItemsToUser((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GrantAvatarPresetItemsToUser-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GrantAvatarPresetItemsToUser-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Render Avatar Image
        /// </summary>
        private void RenderAvatarsImage()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On RenderAvatarImage Button Click---->>>");
            var auth = new AvatarManagementHandler(new RenderAvatarImage()
            {
                AvatarID = "154ffe8a-d890-4a5f-bf8b-8ef6000b89ce",
                Platform = "Android"
            });
            auth.RenderAvatarImage((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("RenderAvatarImage-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("RenderAvatarImage-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Creates missing avatars into the mentioned platform for the user
        /// </summary>
        private void SyncAvatar()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On SyncAvatars Button Click---->>>");
            var auth = new AvatarManagementHandler(new SyncAvatars()
            {
                Platform = "Android",
                Mesh = true,
                Image = true

            });
            auth.SyncAvatars((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("SyncAvatars-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("SyncAvatars-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Grant Avatar Preset To User
        /// </summary>
        private void GrantAvatarPresetsToUser()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GrantAvatarPresetToUser Button Click---->>>");
            var auth = new AvatarManagementHandler(new GrantAvatarPresetToUser()
            {
                AvatarData = "",

            });
            auth.GrantAvatarPresetToUser((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GrantAvatarPresetToUser-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GrantAvatarPresetToUser-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Retrive Avatar preset by ID
        /// </summary>
        private void GetAvatarsPresetsByID()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetAvatarPresetsByID Button Click---->>>");
            var auth = new AvatarManagementHandler(new GetAvatarPresetsByID()
            {
                avatarPresetID = "db9e8538-9e50-4328-b8a7-0922a5e0e8d2"
            });
            auth.GetAvatarPresetsByID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetAvatarPresetsByID-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetAvatarPresetsByID-->>" + error.ToJson());
                }
            });
        }
    }
}