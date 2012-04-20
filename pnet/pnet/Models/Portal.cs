using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace pnet.Models
{
    public class Portal
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Product> Products = new List<Product>();

        /// <summary>The pathway to this portals root</summary>
        public string MapPath()
        {
            return HttpRuntime.AppDomainAppPath;// +"Partners\\" + PartnerID + "\\" + PortalID + "\\";
        }

        /// <summary>The pathway to this portal files folder</summary>
        public string MapPathData()
        {
            return MapPath() + "data\\";
        }

        /// <summary>The pathway to this portal files folder</summary>
        public string MapPathFiles()
        {
            return MapPath() + "files\\";
        }

        /// <summary>The pathway to this portal videos folder</summary>
        public string MapPathVideos()
        {
            return MapPath() + "videos\\";
        }

        /// <summary>The pathway to this portal skins folder</summary>
        public string MapPathCache()
        {
            return MapPath() + "cache\\";
        }

        /// <summary>The pathway to this portal skins folder</summary>
        public string MapPathSkins()
        {
            return MapPath() + "skins\\";
        }

        /// <summary>The pathway to this portal fonts folder</summary>
        public string MapPathFonts()
        {
            return MapPath() + "fonts\\";
        }

        /// <summary>The pathway to this portal SearchIndex folder</summary>
        public string MapPathSearchIndex()
        {
            return MapPath() + "SearchIndex\\";
        }

        public void Save(string message)
        {
            string sXML = null;
            string sPath = null;
            Portal oClone = null;
            byte[] bXML = null;
            string sFilename = null;

            // Does folder exist? ------------------------------------------------------------------------------------------------------------
            sPath = MapPathData();
            if (!System.IO.Directory.Exists(sPath)) System.IO.Directory.CreateDirectory(sPath);

            // Serialize ---------------------------------------------------------------------------------------------------------------------
            sXML = Utility.Serialize(this, true);

            // Compress ----------------------------------------------------------------------------------------------------------------------
            bXML = Utility.GZIP(ref sXML);

            // Clean up the string -----------------------------------------------------------------------------------------------------------
            sFilename = System.Text.RegularExpressions.Regex.Replace(message, @"[^A-Za-z0-9\- ]", String.Empty);

            // Save to file ------------------------------------------------------------------------------------------------------------------
            //System.IO.File.WriteAllText(sPath & "P " & Format(Date.Now, TimeStamp) & " " & System.Text.RegularExpressions.Regex.Replace(sReason, "[^A-Za-z0-9\- /]", String.Empty) & ".dndata", sXML)
            System.IO.File.WriteAllBytes(sPath + "P " + System.DateTime.Now.ToString("yyyy.MM.dd HH-mm-ss") + " " + sFilename + ".dndata.gz", bXML);

            // Make a clone (Thread safe) ----------------------------------------------------------------------------------------------------
            oClone = this.Clone();

            // Save clone in portal hashtable ------------------------------------------------------------------------------------------------
            //lock (Destinet.Business.Handlers.Factory.Portals)
            //{
            //    Destinet.Business.Handlers.Factory.Portals[PortalID] = oClone;
            //}
        }

        public Portal Clone()
        {
            Portal o = new Portal();
            o.ID = this.ID;
            o.Name = this.Name;
            o.Products = this.Products;
            return o;
        }
    }

    [Serializable()]
    public class Product
    {
        public int ID;

        public string Name;

        public Product(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}