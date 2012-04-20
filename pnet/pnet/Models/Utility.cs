using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace pnet.Models
{
    public class Utility
    {
        public static string Serialize(object oObject, bool Indent = false)
        {
            System.Xml.Serialization.XmlSerializer oXmlSerializer = null;
            System.Text.StringBuilder oStringBuilder = null;
            System.Xml.XmlWriter oXmlWriter = null;
            string sXML = null;
            System.Xml.XmlWriterSettings oXmlWriterSettings = null;
            System.Xml.Serialization.XmlSerializerNamespaces oXmlSerializerNamespaces = null;

            // -----------------------------------------------------------------------------------------------------------------------
            // Lage XML
            // -----------------------------------------------------------------------------------------------------------------------
            oStringBuilder = new System.Text.StringBuilder();
            oXmlSerializer = new System.Xml.Serialization.XmlSerializer(oObject.GetType());
            oXmlWriterSettings = new System.Xml.XmlWriterSettings();
            oXmlWriterSettings.OmitXmlDeclaration = true;
            oXmlWriterSettings.Indent = Indent;
            oXmlWriter = System.Xml.XmlWriter.Create(new System.IO.StringWriter(oStringBuilder), oXmlWriterSettings);
            oXmlSerializerNamespaces = new System.Xml.Serialization.XmlSerializerNamespaces();
            oXmlSerializerNamespaces.Add(string.Empty, string.Empty);
            oXmlSerializer.Serialize(oXmlWriter, oObject, oXmlSerializerNamespaces);
            oXmlWriter.Close();
            sXML = oStringBuilder.ToString();

            return sXML;
        }

        public static object DeSerialize(string sXML, Type ObjectType)
        {
            System.IO.StringReader oStringReader = null;
            System.Xml.Serialization.XmlSerializer oXmlSerializer = null;
            object oObject = null;

            // -----------------------------------------------------------------------------------------------------------------------
            // Hvis mangler info, lage tom
            // -----------------------------------------------------------------------------------------------------------------------
            if (sXML == string.Empty)
            {
                Type[] types = new Type[-1 + 1];
                System.Reflection.ConstructorInfo info = ObjectType.GetConstructor(types);
                object targetObject = info.Invoke(null);
                if (targetObject == null)
                    return null;
                return targetObject;
            }

            // -----------------------------------------------------------------------------------------------------------------------
            // Gjøre om fra XML til objekt
            // -----------------------------------------------------------------------------------------------------------------------
            oStringReader = new System.IO.StringReader(sXML);
            oXmlSerializer = new System.Xml.Serialization.XmlSerializer(ObjectType);
            oObject = oXmlSerializer.Deserialize(oStringReader);

            return oObject;
        }

        public static string UnGZIP(ref byte[] input)
        {
            System.IO.MemoryStream oMemoryStream = null;
            System.IO.Compression.GZipStream oGZipStream = null;
            int iLength = 0;
            byte[] byteArray = new byte[100001];
            System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();

            oMemoryStream = new System.IO.MemoryStream(input);
            oGZipStream = new System.IO.Compression.GZipStream(oMemoryStream, System.IO.Compression.CompressionMode.Decompress);
            oMemoryStream.Flush();
            oGZipStream.Flush();
            do
            {
                iLength = oGZipStream.Read(byteArray, 0, byteArray.Length);
                if (iLength < 1)
                    break; // TODO: might not be correct. Was : Exit Do
                oStringBuilder.Append(System.Text.Encoding.UTF8.GetString(byteArray, 0, iLength));
            } while (true);
            oGZipStream.Close();
            oMemoryStream.Close();
            oGZipStream.Dispose();
            oMemoryStream.Dispose();
            return oStringBuilder.ToString();
        }

        /// <summary>
        /// Compress contents to gzip
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static byte[] GZIP(ref string s)
        {
            byte[] buffer = null;
            byte[] compressedData = null;
            MemoryStream oMemoryStream = null;
            System.IO.Compression.GZipStream compressedzipStream = null;
            oMemoryStream = new MemoryStream();
            buffer = System.Text.Encoding.UTF8.GetBytes(s);
            compressedzipStream = new System.IO.Compression.GZipStream(oMemoryStream, System.IO.Compression.CompressionMode.Compress, true);
            compressedzipStream.Write(buffer, 0, buffer.Length);
            compressedzipStream.Dispose();
            compressedzipStream.Close();
            compressedData = oMemoryStream.ToArray();
            oMemoryStream.Close();
            return compressedData;
        }
    }
}