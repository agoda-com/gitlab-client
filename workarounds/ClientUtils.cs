/*
 * GitLab API
 *
 * An OpenAPI definition for the GitLab REST API. Few API resources or endpoints are currently included. The intent is to expand this to match the entire Markdown documentation of the API: <https://docs.gitlab.com/ee/api/>. Contributions are welcome.  When viewing this on gitlab.com, you can test API calls directly from the browser against the `gitlab.com` instance, if you are logged in. The feature uses the current [GitLab session cookie](https://docs.gitlab.com/ee/api/index.html#session-cookie), so each request is made using your account.  Instructions for using this tool can be found in [Interactive API Documentation](https://docs.gitlab.com/ee/api/openapi/openapi_interactive.html) 
 *
 * The version of the OpenAPI document: v4
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Agoda.Gitlab.Client.Model;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Agoda.Gitlab.Client.Test")]

namespace Agoda.Gitlab.Client.Client
{
    /// <summary>
    /// Utility functions providing some benefit to API client consumers.
    /// </summary>
    public static class ClientUtils
    {

        /// <summary>
        /// A delegate for events.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void EventHandler<T>(object sender, T e) where T : EventArgs;

        /// <summary>
        /// An enum of headers
        /// </summary>
        public enum ApiKeyHeader
        {
            /// <summary>
            /// The Private-Token header
            /// </summary>
            PrivateToken
        }

        /// <summary>
        /// Converte an ApiKeyHeader to a string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"></exception>
        public static string ApiKeyHeaderToString(ApiKeyHeader value)
        {
            switch(value)
            {
                case ApiKeyHeader.PrivateToken:
                    return "Private-Token";
                default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(nameof(value), (int)value, typeof(ApiKeyHeader));
            }
        }

        /// <summary>
        /// Returns true when deserialization succeeds.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryDeserialize<T>(string json, JsonSerializerOptions options, out T result)
        {
            try
            {
                result = JsonSerializer.Deserialize<T>(json, options);
                return result != null;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Returns true when deserialization succeeds.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryDeserialize<T>(ref Utf8JsonReader reader, JsonSerializerOptions options, out T result)
        {
            try
            {
                result = JsonSerializer.Deserialize<T>(ref reader, options);
                return result != null;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Sanitize filename by removing the path
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns>Filename</returns>
        public static string SanitizeFilename(string filename)
        {
            Match match = Regex.Match(filename, @".*[/\\](.*)$");
            return match.Success ? match.Groups[1].Value : filename;
        }

        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with Configuration.DateTime.
        /// If parameter is a list, join the list with ",".
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <param name="format">The DateTime serialization format.</param>
        /// <returns>Formatted string.</returns>
        public static string ParameterToString(object obj, string format = ISO8601_DATETIME_FORMAT)
        {
            if (obj is DateTime dateTime)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return dateTime.ToString(format);
            if (obj is DateTimeOffset dateTimeOffset)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return dateTimeOffset.ToString(format);
            if (obj is bool boolean)
                return boolean
                    ? "true"
                    : "false";
            if (obj is APIEntitiesBulkImport.StatusEnum aPIEntitiesBulkImportStatusEnum)
                return APIEntitiesBulkImport.StatusEnumToJsonValue(aPIEntitiesBulkImportStatusEnum);
            if (obj is APIEntitiesBulkImports.EntityTypeEnum aPIEntitiesBulkImportsEntityTypeEnum)
                return APIEntitiesBulkImports.EntityTypeEnumToJsonValue(aPIEntitiesBulkImportsEntityTypeEnum);
            if (obj is APIEntitiesBulkImports.StatusEnum aPIEntitiesBulkImportsStatusEnum)
                return APIEntitiesBulkImports.StatusEnumToJsonValue(aPIEntitiesBulkImportsStatusEnum);
            if (obj is PostApiV4AdminCiVariablesRequest.VariableTypeEnum postApiV4AdminCiVariablesRequestVariableTypeEnum)
                return PostApiV4AdminCiVariablesRequest.VariableTypeEnumToJsonValue(postApiV4AdminCiVariablesRequestVariableTypeEnum);
            if (obj is PostApiV4AdminClustersAddRequest.PlatformKubernetesAttributesAuthorizationTypeEnum postApiV4AdminClustersAddRequestPlatformKubernetesAttributesAuthorizationTypeEnum)
                return PostApiV4AdminClustersAddRequest.PlatformKubernetesAttributesAuthorizationTypeEnumToJsonValue(postApiV4AdminClustersAddRequestPlatformKubernetesAttributesAuthorizationTypeEnum);
            if (obj is PostApiV4BroadcastMessagesRequest.BroadcastTypeEnum postApiV4BroadcastMessagesRequestBroadcastTypeEnum)
                return PostApiV4BroadcastMessagesRequest.BroadcastTypeEnumToJsonValue(postApiV4BroadcastMessagesRequestBroadcastTypeEnum);
            if (obj is PostApiV4BroadcastMessagesRequest.TargetAccessLevelsEnum postApiV4BroadcastMessagesRequestTargetAccessLevelsEnum)
                return PostApiV4BroadcastMessagesRequest.TargetAccessLevelsEnumToJsonValue(postApiV4BroadcastMessagesRequestTargetAccessLevelsEnum).ToString();
            if (obj is PutApiV4AdminBatchedBackgroundMigrationsIdResumeRequest.DatabaseEnum putApiV4AdminBatchedBackgroundMigrationsIdResumeRequestDatabaseEnum)
                return PutApiV4AdminBatchedBackgroundMigrationsIdResumeRequest.DatabaseEnumToJsonValue(putApiV4AdminBatchedBackgroundMigrationsIdResumeRequestDatabaseEnum);
            if (obj is PutApiV4AdminCiVariablesKeyRequest.VariableTypeEnum putApiV4AdminCiVariablesKeyRequestVariableTypeEnum)
                return PutApiV4AdminCiVariablesKeyRequest.VariableTypeEnumToJsonValue(putApiV4AdminCiVariablesKeyRequestVariableTypeEnum);
            if (obj is PutApiV4ApplicationPlanLimitsRequest.PlanNameEnum putApiV4ApplicationPlanLimitsRequestPlanNameEnum)
                return PutApiV4ApplicationPlanLimitsRequest.PlanNameEnumToJsonValue(putApiV4ApplicationPlanLimitsRequestPlanNameEnum);
            if (obj is PutApiV4BroadcastMessagesIdRequest.BroadcastTypeEnum putApiV4BroadcastMessagesIdRequestBroadcastTypeEnum)
                return PutApiV4BroadcastMessagesIdRequest.BroadcastTypeEnumToJsonValue(putApiV4BroadcastMessagesIdRequestBroadcastTypeEnum);
            if (obj is PutApiV4BroadcastMessagesIdRequest.TargetAccessLevelsEnum putApiV4BroadcastMessagesIdRequestTargetAccessLevelsEnum)
                return PutApiV4BroadcastMessagesIdRequest.TargetAccessLevelsEnumToJsonValue(putApiV4BroadcastMessagesIdRequestTargetAccessLevelsEnum).ToString();
            if (obj is ICollection collection)
            {
                List<string> entries = new List<string>();
                foreach (var entry in collection)
                    entries.Add(ParameterToString(entry));
                return string.Join(",", entries);
            }

            return Convert.ToString(obj, System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// URL encode a string
        /// Credit/Ref: https://github.com/restsharp/RestSharp/blob/master/RestSharp/Extensions/StringExtensions.cs#L50
        /// </summary>
        /// <param name="input">string to be URL encoded</param>
        /// <returns>Byte array</returns>
        public static string UrlEncode(string input)
        {
            const int maxLength = 32766;

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (input.Length <= maxLength)
            {
                return Uri.EscapeDataString(input);
            }

            StringBuilder sb = new StringBuilder(input.Length * 2);
            int index = 0;

            while (index < input.Length)
            {
                int length = Math.Min(input.Length - index, maxLength);
                string subString = input.Substring(index, length);

                sb.Append(Uri.EscapeDataString(subString));
                index += subString.Length;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Encode string in base64 format.
        /// </summary>
        /// <param name="text">string to be encoded.</param>
        /// <returns>Encoded string.</returns>
        public static string Base64Encode(string text)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Convert stream to byte array
        /// </summary>
        /// <param name="inputStream">Input stream to be converted</param>
        /// <returns>Byte array</returns>
        public static byte[] ReadAsBytes(Stream inputStream)
        {
            using (var ms = new MemoryStream())
            {
                inputStream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Select the Content-Type header's value from the given content-type array:
        /// if JSON type exists in the given array, use it;
        /// otherwise use the first one defined in 'consumes'
        /// </summary>
        /// <param name="contentTypes">The Content-Type array to select from.</param>
        /// <returns>The Content-Type header to use.</returns>
        public static string SelectHeaderContentType(string[] contentTypes)
        {
            if (contentTypes.Length == 0)
                return null;

            foreach (var contentType in contentTypes)
            {
                if (IsJsonMime(contentType))
                    return contentType;
            }

            return contentTypes[0]; // use the first content type specified in 'consumes'
        }

        /// <summary>
        /// Select the Accept header's value from the given accepts array:
        /// if JSON exists in the given array, use it;
        /// otherwise use all of them (joining into a string)
        /// </summary>
        /// <param name="accepts">The accepts array to select from.</param>
        /// <returns>The Accept header to use.</returns>
        public static string SelectHeaderAccept(string[] accepts)
        {
            if (accepts.Length == 0)
                return null;

            if (accepts.Contains("application/json", StringComparer.OrdinalIgnoreCase))
                return "application/json";

            return string.Join(",", accepts);
        }

        /// <summary>
        /// Provides a case-insensitive check that a provided content type is a known JSON-like content type.
        /// </summary>
        public static readonly Regex JsonRegex = new Regex("(?i)^(application/json|[^;/ \t]+/[^;/ \t]+[+]json)[ \t]*(;.*)?$");

        /// <summary>
        /// Check if the given MIME is a JSON MIME.
        /// JSON MIME examples:
        ///    application/json
        ///    application/json; charset=UTF8
        ///    APPLICATION/JSON
        ///    application/vnd.company+json
        /// </summary>
        /// <param name="mime">MIME</param>
        /// <returns>Returns True if MIME type is json.</returns>
        public static bool IsJsonMime(string mime)
        {
            if (string.IsNullOrWhiteSpace(mime)) return false;

            return JsonRegex.IsMatch(mime) || mime.Equals("application/json-patch+json");
        }

        /// <summary>
        /// The base path of the API
        /// </summary>
        public const string BASE_ADDRESS = "https://www.gitlab.com/api";

        /// <summary>
        /// The scheme of the API
        /// </summary>
        public const string SCHEME = "https";

        /// <summary>
        /// The context path of the API
        /// </summary>
        public const string CONTEXT_PATH = "/api";

        /// <summary>
        /// The host of the API
        /// </summary>
        public const string HOST = "www.gitlab.com";

        /// <summary>
        /// The format to use for DateTime serialization
        /// </summary>
        public const string ISO8601_DATETIME_FORMAT = "o";
    }
}
