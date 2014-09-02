﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using FanartTv.Types;

namespace FanartTv.Music
{
  /// <summary>
  /// Get Images for Latest Artists
  /// </summary>
  public class Latest
  {
    /// <summary>
    /// List of Images for Latest Artists
    /// </summary>
    public List<LatestArtistData> List { get; set; }

    /// <summary>
    /// Get Images for Latest Artists
    /// </summary>
    public Latest()
    {
        if (String.IsNullOrEmpty(API.cKey))
            List = Info(API.Key);
        else
            List = Info(API.Key, API.cKey);
    }

    /// <summary>
    /// Get Images for Latest Artists
    /// </summary>
    /// <param name="apiKey">Users api_key</param>
    public Latest(string apiKey)
    {
      List = Info(apiKey);
    }

    /// <summary>
    /// Get Images for Latest Artists
    /// </summary>
    /// <param name="apiKey">Users api_key</param>
    /// <param name="clientKey">Users client_key</param>
    public Latest(string apiKey, string clientKey)
    {
        List = Info(apiKey, clientKey);
    }

    /// <summary>
    /// API Result
    /// </summary>
    /// <param name="apiKey">Users api_key</param>
    /// <returns>List of Images for Latest Artists</returns>
    private static List<LatestArtistData> Info(string apiKey)
    {
      try
      {
        List<LatestArtistData> tmp;

        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(Helper.Json.GetJson(API.Server + "music/latest" + "?api_key=" + apiKey))))
        {
          var settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
          var serializer = new DataContractJsonSerializer(typeof(List<LatestArtistData>), settings);
          tmp = (List<LatestArtistData>)serializer.ReadObject(ms);
        }
        return tmp ?? new List<LatestArtistData>();
      }
      catch (Exception)
      {
        return new List<LatestArtistData>();
      }
    }

    /// <summary>
    /// API Result
    /// </summary>
    /// <param name="apiKey">Users api_key</param>
    /// <returns>List of Images for Latest Artists</returns>
    private static List<LatestArtistData> Info(string apiKey, string clientKey)
    {
        try
        {
            List<LatestArtistData> tmp;

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(Helper.Json.GetJson(API.Server + "music/latest" + "?api_key=" + apiKey + "?client_key=" + clientKey))))
            {
                var settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
                var serializer = new DataContractJsonSerializer(typeof(List<LatestArtistData>), settings);
                tmp = (List<LatestArtistData>)serializer.ReadObject(ms);
            }
            return tmp ?? new List<LatestArtistData>();
        }
        catch (Exception)
        {
            return new List<LatestArtistData>();
        }
    }
  }
}
