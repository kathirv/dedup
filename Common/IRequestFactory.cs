﻿using RestSharp;

namespace Dedup.Common
{
    public interface IRequestFactory
    {
        /// <summary>
        /// Returns new REST client instance.
        /// </summary>
        IRestClient CreateClient();

        /// <summary>
        /// Returns new REST request instance.
        /// </summary>
        IRestRequest CreateRequest();
    }
}
