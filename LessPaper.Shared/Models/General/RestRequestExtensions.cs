using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RestSharp;

namespace LessPaper.Shared.Models.General
{
    public static class RestRequestExtensions
    {
        public static IRestRequest AddUserId(this IRestRequest restRequest, string userId)
        {
            restRequest.AddQueryParameter("user_id", userId);
            return restRequest;
        }

        public static IRestRequest AddObjectId(this IRestRequest restRequest, string objectId)
        {
            restRequest.AddQueryParameter("object_id", objectId);
            return restRequest;
        }

        public static IRestRequest AddRevisionNr(this IRestRequest restRequest, uint? revisionNr)
        {
            if 
            restRequest.AddParameter("revision_nr", revisionNr, ParameterType.UrlSegment);
            return restRequest;
        }

        public static IRestRequest AddSubDirecotryName(this IRestRequest restRequest, string subDirectoryName)
        {
            restRequest.AddParameter("sub_directory_name", subDirectoryName, ParameterType.GetOrPost);
            return restRequest;
        }


        public static IRestRequest AddDirectoryId(this IRestRequest restRequest, string directoryId)
        {
            restRequest.AddUrlSegment("directory_id", directoryId);
            return restRequest;
        }
    }
}
