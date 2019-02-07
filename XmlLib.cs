using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XmlLibrary
{
    public static class XmlLib
    {
        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sObject">The s object.</param>
        /// <returns></returns>
        /// =====================================================================================
        /// Modification : Initial : 07/02/2019 | N.WILCKE(SESA474351)      
        /// =====================================================================================
        public static string Serialize<T>(T sObject)
        {
            try
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
                var xml = string.Empty;

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xsSubmit.Serialize(writer, sObject);
                        xml = sww.ToString();
                    }
                }

                return xml;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Converts xml to specified file name in specified fodler.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="path">The path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// =====================================================================================
        /// Modification : Initial : 07/02/2019 | N.WILCKE(SESA474351)      
        /// =====================================================================================
        [Obsolete("This method is no longer maintained. Prefer to use SerializeToFile")]
        public static void ToFile(string xml, string path, string fileName)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(xml);
                xdoc.Save(path + fileName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Serializes to file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sObject">The s object.</param>
        /// <param name="path">The path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// =====================================================================================
        /// Modification : Initial : 07/02/2019 | N.WILCKE(SESA474351)      
        /// =====================================================================================
        public static void SerializeToFile<T>(T sObject, string path, string fileName)
        {
            try
            {
                #region Serialize
                XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
                var xml = string.Empty;

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xsSubmit.Serialize(writer, sObject);
                        xml = sww.ToString();
                    }
                } 
                #endregion

                #region Save to file
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(xml);
                xdoc.Save(path + fileName); 
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deserializes xml from file to specified object type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        /// =====================================================================================
        /// Modification : Initial : 07/02/2019 | N.WILCKE(SESA474351)      
        /// =====================================================================================
        public static T DeserializeFromFile<T>(string path, string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var file = File.OpenText(path + fileName))
                {
                    var data = (T)serializer.Deserialize(file);
                    return data;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deserializes the specified XML to object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        /// =====================================================================================
        /// Modification : Initial : 07/02/2019 | N.WILCKE(SESA474351)      
        /// =====================================================================================
        public static T Deserialize<T>(string xml)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                using (TextReader reader = new StringReader(xml))
                {
                    var data = (T)serializer.Deserialize(reader);
                    return data;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
