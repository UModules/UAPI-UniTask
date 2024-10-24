using Cysharp.Threading.Tasks;
using UAPIModule.SharedTypes;
using UnityEngine;

namespace UAPIModule.Sample
{
    public class APISample : MonoBehaviour
    {
        // GET Request
        [ContextMenu("GET Request")]
        private void OnGetRequest()
        {
            Debug.Log("Sending GET request...");
            var config = GetConfig("/get", HTTPRequestMethod.GET);

            UniTask.Void(async () =>
            {
                var response = await APIClient.SendRequest<GetResponse>(config, RequestScreenConfig.GetDefaultScreen());

                if (response.isSuccessful)
                {
                    Debug.Log($"GET Response: Origin - {response.data.origin}, URL - {response.data.url}");
                }
                else
                {
                    Debug.LogError("GET request failed: " + response.errorMessage);
                }
            });
        }

        // POST Request
        [ContextMenu("POST Request")]
        private void OnPostRequest()
        {
            Debug.Log("Sending POST request...");
            var config = GetConfig("/post", HTTPRequestMethod.POST);

            UniTask.Void(async () =>
            {
                var response = await APIClient.SendRequest<PostResponse>(config, RequestScreenConfig.GetDefaultScreen());

                if (response.isSuccessful)
                {
                    Debug.Log($"POST Response: Form Name - {response.data.form.name}");
                }
                else
                {
                    Debug.LogError("POST request failed: " + response.errorMessage);
                }
            });
        }

        // PUT Request
        [ContextMenu("PUT Request")]
        private void OnPutRequest()
        {
            Debug.Log("Sending PUT request...");
            var config = GetConfig("/put", HTTPRequestMethod.PUT);

            UniTask.Void(async () =>
            {
                var response = await APIClient.SendRequest<PutResponse>(config, RequestScreenConfig.GetDefaultScreen());

                if (response.isSuccessful)
                {
                    Debug.Log($"PUT Response: Data - {response.data.data}");
                }
                else
                {
                    Debug.LogError("PUT request failed: " + response.errorMessage);
                }
            });
        }

        // DELETE Request
        [ContextMenu("DELETE Request")]
        private void OnDeleteRequest()
        {
            Debug.Log("Sending DELETE request...");
            var config = GetConfig("/delete", HTTPRequestMethod.DELETE);

            UniTask.Void(async () =>
            {
                var response = await APIClient.SendRequest<DeleteResponse>(config, RequestScreenConfig.GetDefaultScreen());

                if (response.isSuccessful)
                {
                    Debug.Log($"DELETE Response: Origin - {response.data.origin}");
                }
                else
                {
                    Debug.LogError("DELETE request failed: " + response.errorMessage);
                }
            });
        }

        // HEAD Request
        [ContextMenu("HEAD Request")]
        private void OnHeadRequest()
        {
            Debug.Log("Sending HEAD request...");
            var config = GetConfig("/headers", HTTPRequestMethod.HEAD);

            UniTask.Void(async () =>
            {
                var response = await APIClient.SendRequest(config, RequestScreenConfig.GetDefaultScreen());

                if (response.isSuccessful)
                {
                    Debug.Log($"HEAD Request: Headers Received - {response.ToString()}");
                }
                else
                {
                    Debug.LogError("HEAD request failed: " + response.errorMessage);
                }
            });
        }

        // PATCH Request
        [ContextMenu("PATCH Request")]
        private void OnPatchRequest()
        {
            Debug.Log("Sending PATCH request...");
            var config = GetConfig("/patch", HTTPRequestMethod.PATCH);

            UniTask.Void(async () =>
            {
                var response = await APIClient.SendRequest<PatchResponse>(config, RequestScreenConfig.GetDefaultScreen());

                if (response.isSuccessful)
                {
                    Debug.Log($"PATCH Response: JSON Data - {response.data.json.name}");
                }
                else
                {
                    Debug.LogError("PATCH request failed: " + response.errorMessage);
                }
            });
        }

        private APIRequestConfig GetConfig(string endpoint, HTTPRequestMethod methodType)
        {
            return APIRequestConfig.GetWithoutToken(baseURL: "https://httpbin.org",
                                                    endpoint: endpoint,
                                                    methodType: methodType,
                                                    headers: null,
                                                    bodies: null,
                                                    timeout: 10000);

        }

        // Response classes for each type of request
        [System.Serializable]
        public class GetResponse
        {
            public string origin;
            public string url;
        }

        [System.Serializable]
        public class PostResponse
        {
            public Form form;
            [System.Serializable]
            public class Form
            {
                public string name;
            }
        }

        [System.Serializable]
        public class PutResponse
        {
            public string data;
        }

        [System.Serializable]
        public class DeleteResponse
        {
            public string origin;
        }

        [System.Serializable]
        public class PatchResponse
        {
            public Json json;
            [System.Serializable]
            public class Json
            {
                public string name;
            }
        }

        // Create GUI buttons for testing
        private void OnGUI()
        {
            if (GUILayout.Button("Send GET Request"))
            {
                OnGetRequest();
            }
            if (GUILayout.Button("Send POST Request"))
            {
                OnPostRequest();
            }
            if (GUILayout.Button("Send PUT Request"))
            {
                OnPutRequest();
            }
            if (GUILayout.Button("Send DELETE Request"))
            {
                OnDeleteRequest();
            }
            if (GUILayout.Button("Send HEAD Request"))
            {
                OnHeadRequest();
            }
            if (GUILayout.Button("Send PATCH Request"))
            {
                OnPatchRequest();
            }
        }
    }
}
