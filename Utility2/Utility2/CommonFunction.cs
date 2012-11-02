using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
namespace Utility2
{
    class CommonFunction
    {
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

        /// <summary>
        /// Compress contents to gzip
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static byte[] GZIP(ref byte[] input)
        {
            try
            {
                byte[] compressedData = null;
                MemoryStream oMemoryStream = null;
                System.IO.Compression.GZipStream compressedzipStream = null;
                oMemoryStream = new MemoryStream();
                compressedzipStream = new System.IO.Compression.GZipStream(oMemoryStream, System.IO.Compression.CompressionMode.Compress, false);
                compressedzipStream.Write(input, 0, input.Length);
                compressedzipStream.Close();
                compressedData = oMemoryStream.ToArray();
                compressedzipStream.Dispose();
                compressedzipStream.Close();
                oMemoryStream.Close();

                return compressedData;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }      

        public static bool CopyFiles(string SourceFolder, string DestFolder)
        {
            bool functionReturnValue = false;

            try
            {
                string[] sDirs = null;
                string sFolder = null;
                string[] sFiles = null;
                string sFileName = null;

                SourceFolder = SourceFolder.ToLower().TrimEnd('\\');
                DestFolder = DestFolder.ToLower().TrimEnd('\\');

                if (!System.IO.Directory.Exists(SourceFolder))
                    return functionReturnValue;

                // Subfolders
                sDirs = System.IO.Directory.GetDirectories(SourceFolder);
                string sFullDir = "";
                foreach (string sDir in sDirs)
                {
                    sFullDir = sDir.ToLower();
                    sFullDir = sFullDir.Replace(SourceFolder + "\\", string.Empty);
                    sFullDir = sFullDir.ToLower();
                    if (!CopyFiles(sDir, DestFolder + "\\" + sFullDir))
                        return false;
                }

                sFiles = System.IO.Directory.GetFiles(SourceFolder);
                foreach (string sFile in sFiles)
                {
                    sFileName = sFile.Replace(SourceFolder + "\\", string.Empty);
                    sFileName = sFileName.ToLower();
                    if (!System.IO.Directory.Exists(DestFolder))
                        System.IO.Directory.CreateDirectory(DestFolder);
                    System.IO.File.Copy(sFile, DestFolder + "\\" + sFileName, true);
                }

                return true;
            }
            catch (Exception ex)
            {
             
                return false;
            }
            return functionReturnValue;
        }

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
                ConstructorInfo info = ObjectType.GetConstructor(types);
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

        //public static Type GetTypeFromXML(string xml)
        //{
        //    string typename;
        //    int ilt = xml.IndexOf(">");
        //    int ispace = xml.IndexOf(" ");
        //    if (ispace == -1) ispace = int.MaxValue;
        //    if (ispace > ilt)
        //    {
        //        typename = xml.Substring(1, ilt - 1);
        //    }
        //    else
        //    {
        //        typename = xml.Substring(1, ispace - 1);
        //    }
        //    return (Type)Current.GlobalTypes[typename];
        //}

        public static byte[] GZipMemory(byte[] Buffer)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.Compression.GZipStream GZip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress);
            GZip.Write(Buffer, 0, Buffer.Length);
            GZip.Close();
            byte[] Result = ms.ToArray();
            ms.Close();
            return Result;
        }

        public static byte[] GZipMemory(string Input)
        {
            return GZipMemory(System.Text.Encoding.ASCII.GetBytes(Input));
        }

        public static string GetUrl(string sURL)
        {
            try
            {
                System.Net.HttpWebRequest HttpRequest = null;
                System.Net.HttpWebResponse HttpResponse = null;
                System.IO.Stream httpStream = null;
                System.IO.StreamReader httpStreamReader = null;
                System.Text.Encoding Encoding = null;
                string sHTML = null;
                int iStatusCode = 0;
                string sHost = null;
                string sHostURL = null;

                //Log.Debug(sURL)

                // Lage ny request
                HttpRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(sURL);
                HttpResponse = (System.Net.HttpWebResponse)HttpRequest.GetResponse();
                httpStream = HttpResponse.GetResponseStream();
                if (!string.IsNullOrEmpty(HttpResponse.CharacterSet))
                {
                    Encoding = System.Text.Encoding.GetEncoding(HttpResponse.CharacterSet);
                    // Må ha for å beholde norske bokstaver
                    httpStreamReader = new System.IO.StreamReader(httpStream, Encoding);
                }
                else
                {
                    httpStreamReader = new System.IO.StreamReader(httpStream);
                }
                sHTML = httpStreamReader.ReadToEnd();
                iStatusCode = (int)HttpResponse.StatusCode;
                sHost = HttpResponse.ResponseUri.Host.ToString();
                sHostURL = HttpResponse.ResponseUri.PathAndQuery.ToString();
                HttpResponse.Close();

                // Renske opp
                HttpResponse = null;
                httpStreamReader = null;
                httpStream = null;
                HttpResponse = null;
                HttpRequest = null;

                // Returnere
                return sHTML;
            }
            catch (Exception ex)
            {
                
                return "";
            }
        }

        public static byte[] GetBinUrl(string sURL)
        {
            try
            {
                System.Net.HttpWebRequest HttpRequest = null;
                System.Net.HttpWebResponse HttpResponse = null;
                System.IO.Stream httpStream = null;
                System.IO.BinaryReader httpStreamReader = null;
                System.Text.Encoding Encoding = null;
                int iStatusCode = 0;
                string sHost = null;
                string sHostURL = null;
                byte[] b = null;
                Int32 contentLength = default(Int32);

                //Log.Debug(sURL)

                // Lage ny request
                HttpRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(sURL);
                HttpResponse = (System.Net.HttpWebResponse)HttpRequest.GetResponse();
                httpStream = HttpResponse.GetResponseStream();
                Encoding = System.Text.Encoding.UTF8;
                contentLength = Convert.ToInt32(HttpResponse.ContentLength);
                httpStreamReader = new System.IO.BinaryReader(httpStream, Encoding);
                b = httpStreamReader.ReadBytes(contentLength);
                iStatusCode = (int)HttpResponse.StatusCode;
                sHost = HttpResponse.ResponseUri.Host.ToString();
                sHostURL = HttpResponse.ResponseUri.PathAndQuery.ToString();
                HttpResponse.Close();

                // Renske opp
                HttpResponse = null;
                httpStreamReader = null;
                httpStream = null;
                HttpResponse = null;
                HttpRequest = null;

                // Returnere
                return b;
            }
            catch (Exception ex)
            {
               
                return null;
            }
        }
        public static Object LoadFile(string filepath, Type type)
        {
            Object o = null;
            string sXML = null;
            byte[] bXML = null;

            // Load the security from xml or for xml.gz -----------------------------------------------------------------------------------
            if (filepath.EndsWith(".gz"))
            {
                bXML = System.IO.File.ReadAllBytes(filepath);
                sXML = CommonFunction.UnGZIP(ref bXML);
            }
            else
            {
                sXML = System.IO.File.ReadAllText(filepath);
            }

            // Deserialize object
            o = CommonFunction.DeSerialize(sXML, type);

            return o;

        }
        public static string GetLatestFile(string folder, string wildcard)
        {
            try
            {
                string[] sFiles = null;
                string sFile = string.Empty;
                sFiles = System.IO.Directory.GetFiles(folder, wildcard);
                if (sFiles.GetUpperBound(0)< 0) return string.Empty;
                return sFiles[sFiles.GetUpperBound(0)];
            }
            catch (Exception ex)
            {
               
                return string.Empty;
            }
        }
    }
}
