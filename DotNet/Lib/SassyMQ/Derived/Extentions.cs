﻿using System;
using System.Windows.Forms;
using SassyMQ.Lib.RabbitMQ.Payload;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections.Generic;
using RabbitMQ.Client.Events;

namespace SassyMQ.Lib.RabbitMQ
{
    public static class ExtensionMethods
    {

        public static bool IsPing(this BasicDeliverEventArgs bdea)
        {
            return (bdea.RoutingKey.SafeToString().ToLower().Contains(".ping"));
        }

        public static String SafeToString(this object value)
        {
            if (ReferenceEquals(value, null)) return String.Empty;
            else return value.ToString();
        }

        public static void HandleInvoke<T>(this Form form, object sender, InvokeEventArgs<T> e)
            where T : StandardPayload<T>, new()
        {
            if (ReferenceEquals(form, null)) e.MethodDelegate.Invoke(sender, e.PayloadEventArgs);
            else form.Invoke(new EventHandler<PayloadEventArgs<T>>(e.MethodDelegate), sender, e.PayloadEventArgs);
        }

        public static String GuidToKey(this Guid guid)
        {
            return guid.ToString().ToLower().Trim("{}".ToCharArray()).Replace("-", "");
        }

        public static String GuidToLongKey(this Guid guid)
        {
            return String.Format("{0}{1}", guid.GuidToKey(), Guid.NewGuid().GuidToKey());
        }

        public static String HashPrivateKey(this String privateKey)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(privateKey);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public static List<String> GetAllFiles(this DirectoryInfo di)
        {
            List<String> files = new List<String>();

            foreach (var f in di.GetFiles())
            {
                files.Add(f.FullName);
            }
            foreach (var d in di.GetDirectories())
            {
                files.AddRange(d.GetAllFiles());
            }

            return files;
        }

    }
}


namespace CoreLibrary.SassyMQS
{
    public class CEPlaceholder { }
}