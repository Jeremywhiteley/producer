﻿/* This file was generated by Settings Studio
 *
 * Copyright © 2015 Colby Williams. All Rights Reserved.
 */
using System;

namespace SettingsStudio
{
	public static partial class Settings
	{

		#region Visible Settings


		public static string VersionNumber
		{
			get => StringForKey (SettingsKeys.VersionNumber);
#if __ANDROID__
			set => SetSetting (SettingsKeys.VersionNumber, value);
#endif
		}


		public static string BuildNumber
		{
			get => StringForKey (SettingsKeys.BuildNumber);
#if __ANDROID__
			set => SetSetting (SettingsKeys.BuildNumber, value);
#endif
		}


		public static string GitHash => StringForKey (SettingsKeys.GitCommitHash);


		public static bool TestProducer
		{
#if DEBUG
			get => BoolForKey (SettingsKeys.TestProducer);
#else
			get => false;
#endif
			set => SetSetting (SettingsKeys.TestProducer, value);
		}


		public static bool UseLocalFunctions
		{
			get => BoolForKey (SettingsKeys.UseLocalFunctions);
			set => SetSetting (SettingsKeys.UseLocalFunctions, value);
		}


		public static string LocalFunctionsUrl
		{
			get => StringForKey (SettingsKeys.LocalFunctionsUrl);
			set => SetSetting (SettingsKeys.LocalFunctionsUrl, value ?? string.Empty);
		}


		public static string RemoteFunctionsUrl
		{
			get => StringForKey (SettingsKeys.RemoteFunctionsUrl);
			set => SetSetting (SettingsKeys.RemoteFunctionsUrl, value ?? string.Empty);
		}


		static Uri _functionsUrl;

		public static Uri FunctionsUrl
		{
			get
			{
				if (_functionsUrl == null)
				{
					var urlString = UseLocalFunctions ? LocalFunctionsUrl : RemoteFunctionsUrl ?? throw new Exception ("No Functions Url");

					if (!urlString.StartsWith ("http", StringComparison.Ordinal) && urlString.EndsWith (".azurewebsites.net", StringComparison.Ordinal))
					{
						var uriBuilder = new UriBuilder ("https", urlString);

						_functionsUrl = uriBuilder.Uri;
					}
				}
				return _functionsUrl;
			}
		}


		public static bool UseLocalDocumentDb
		{
			get => BoolForKey (SettingsKeys.UseLocalDocumentDb);
			set => SetSetting (SettingsKeys.UseLocalDocumentDb, value);
		}


		public static string LocalDocumentDbUrl
		{
			get => StringForKey (SettingsKeys.LocalDocumentDbUrl);
			set => SetSetting (SettingsKeys.LocalDocumentDbUrl, value ?? string.Empty);
		}


		public static string RemoteDocumentDbUrl
		{
			get => StringForKey (SettingsKeys.RemoteDocumentDbUrl);
			set => SetSetting (SettingsKeys.RemoteDocumentDbUrl, value ?? string.Empty);
		}


		static Uri _documentDbUrl;

		public static Uri DocumentDbUrl
		{
			get
			{
				if (_documentDbUrl == null)
				{
					var urlString = (UseLocalDocumentDb ? LocalDocumentDbUrl : RemoteDocumentDbUrl) ?? throw new Exception ("No DocumentDB Url");

					if (!urlString.StartsWith ("http", StringComparison.Ordinal) && (UseLocalDocumentDb || urlString.EndsWith (".documents.azure.com", StringComparison.Ordinal)))
					{
						var uriBuilder = new UriBuilder (UseLocalDocumentDb ? "http" : "https", urlString, UseLocalDocumentDb ? 8081 : 443);

						_documentDbUrl = uriBuilder.Uri;
					}
				}
				return _documentDbUrl;
			}
		}


		public static string EmbeddedSocialKey
		{
			get => StringForKey (SettingsKeys.EmbeddedSocialKey);
			set => SetSetting (SettingsKeys.EmbeddedSocialKey, value ?? string.Empty);
		}


		public static string UserReferenceKey
		{
			get => StringForKey (SettingsKeys.UserReferenceKey);
			set => SetSetting (SettingsKeys.UserReferenceKey, value ?? "anonymous");
		}


		#endregion


		#region Hidden Settings


		public static string AvContentListSelectedFilter
		{
			get => StringForKey (SettingsKeys.AvContentListSelectedFilter);
			set => SetSetting (SettingsKeys.AvContentListSelectedFilter, value);
		}


		public static int ProducerListSelectedRole
		{
			get => Int32ForKey (SettingsKeys.ProducerListSelectedRole);
			set => SetSetting (SettingsKeys.ProducerListSelectedRole, value);
		}


		public static string LastAvContentDescription
		{
			get => StringForKey (SettingsKeys.LastAvContentDescription);
			set => SetSetting (SettingsKeys.LastAvContentDescription, value);
		}


		#endregion
	}
}
