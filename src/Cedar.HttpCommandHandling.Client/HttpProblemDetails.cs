﻿namespace Cedar.HttpCommandHandling
{
    using System;
    using System.Net.Http.Headers;

    public class HttpProblemDetails
    {
        internal static readonly MediaTypeHeaderValue MediaTypeHeaderValue 
            = new MediaTypeHeaderValue("application/problem+json"){ CharSet = "utf-8" };
        internal static readonly MediaTypeWithQualityHeaderValue MediaTypeWithQualityHeaderValue
            = new MediaTypeWithQualityHeaderValue(MediaTypeHeaderValue.MediaType, 1.0);

        private string _type;
        private string _instance;

        /// <summary>
        ///  The HTTP status code
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        ///     An absolute URI that identifies the problem type. When
        ///     dereferenced, it SHOULD provide human-readable documentation for the
        ///     problem type (e.g., using HTML). When this member is not present,
        ///     its value is assumed to be "about:blank".
        /// </summary>
        public string Type
        {
            get { return _type; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && !Uri.IsWellFormedUriString(value, UriKind.Absolute))
                {
                    throw new InvalidOperationException("Uri must be absolute.");
                }
                _type = value;
            }
        }

        /// <summary>
        ///     A short, human-readable summary of the problem type.  It SHOULD NOT
        ///     change from occurrence to occurrence of the problem, except for
        ///     purposes of localisation.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     An human readable explanation specific to this occurrence of the problem.
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        ///     An absolute URI that identifies the specific occurrence of the problem.
        ///     It may or may not yield further information if dereferenced.
        /// </summary>
        public string Instance
        {
            get { return _instance; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && !Uri.IsWellFormedUriString(value, UriKind.Absolute))
                {
                    throw new InvalidOperationException("Uri must be absolute.");
                }
                _instance = value;
            }
        }
    }
}