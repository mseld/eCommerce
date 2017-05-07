using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;


namespace IM.Web.Helpers
{
    public class XmlHelper
    {
        public static T Load<T>(Stream stream)
        {
            try
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(stream);
            }
            catch (Exception ex)
            {
                return default(T);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

        }

        public static T Load<T>(string path)
        {
            TextReader textReader = null;
            try
            {
                textReader = new StreamReader(path);
                return (T)new XmlSerializer(typeof(T)).Deserialize(textReader);
            }
            catch (Exception ex)
            {
                return default(T);
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();
            }

        }

        public static bool Save<T>(T obj, string path)
        {
            TextWriter textWriter = null;
            try
            {
                textWriter = new StreamWriter(path);
                new XmlSerializer(typeof(T)).Serialize(textWriter, obj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }
        }
    }
}