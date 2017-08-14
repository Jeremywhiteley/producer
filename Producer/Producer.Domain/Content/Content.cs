﻿using System;

using Newtonsoft.Json;

namespace Producer.Domain
{
	public class Content : Entity
	{
		public string Name { get; set; }

		public string DisplayName { get; set; }

		public string ProducerId { get; set; }

		public string Description { get; set; }

		public string RemoteAssetUri { get; set; }

		public UserRoles PublishedTo { get; set; } = UserRoles.Producer;

		public DateTimeOffset? PublishedAt { get; set; }

#if __MOBILE__

		[JsonIgnore]
		public bool Published => PublishedAt.HasValue && !string.IsNullOrEmpty (ProducerId);

		[JsonIgnore]
		public bool HasRemoteAssetUri => !string.IsNullOrWhiteSpace (RemoteAssetUri);

		[JsonIgnore]
		public bool Local => !string.IsNullOrWhiteSpace (LocalAssetUri);

		[JsonIgnore]
		public string LocalAssetUri
		{
			get { return SettingsStudio.Settings.StringForKey (Id); }
			set { SettingsStudio.Settings.SetSetting (Id, value ?? string.Empty); }
		}

#endif
	}
}