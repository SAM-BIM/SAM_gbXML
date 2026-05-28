// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System;

namespace SAM.Core.gbXML
{
    /// <summary>
    /// This class contains various static methods for querying information about objects.
    /// </summary>
    public static partial class Query
    {
        /// <summary>
        /// Generates a unique identifier for a given object.
        /// </summary>
        /// <param name="jSAMObject">The object to generate an ID for.</param>
        /// <param name="type">The type of the object.</param>
        /// <returns>A unique identifier for the given object.</returns>
        public static string Id(this IJSAMObject jSAMObject, Type type)
        {
            // Check if input parameters are valid
            if (jSAMObject == null || type == null)
                return null;

            // Use the object's stable Guid if it carries one (ISAMObject or any
            // other IGuidObject — e.g. LinkedFace3D), otherwise fall back to a fresh Guid.
            Guid guid = jSAMObject is IGuidObject guidObject ? guidObject.Guid : System.Guid.NewGuid();

            // Format and return the identifier
            return string.Format("{0}_{1}", type.Name, guid.ToString("N"));
        }

        /// <summary>
        /// Generates a valid ID from the given text by removing any spaces, forward slashes, and single quotes.
        /// </summary>
        /// <param name="text">The text to generate an ID from.</param>
        /// <returns>A valid ID generated from the given text.</returns>
        public static string Id(this string text)
        {
            // Check if input parameter is valid
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            // Remove any spaces, forward slashes, and single quotes from the input text
            string result = text;
            result = result.Replace(" ", "");
            result = result.Replace("/", "");
            result = result.Replace("\'", "");

            // Return the cleaned-up text as the identifier
            return result;
        }
    }
}
