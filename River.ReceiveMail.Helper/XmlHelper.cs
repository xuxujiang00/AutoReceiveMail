using River.ReceiveMail.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace River.ReceiveMail.Helper
{
    public class XmlHelper
    {
        /// <summary>
        /// 转换xml数据为帐号实体
        /// </summary>
        /// <returns></returns>
        public static IList<AccountModel> ConverToAccountModel(string pathStr)
        {
            pathStr = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathStr);

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(pathStr);
            }
            catch
            {
                throw new ArgumentException("xml加载失败,请检查帐号xml路径是否正确");
            }
            IList<AccountModel> entity = new List<AccountModel>();
            try
            {
                XmlNode nodes = doc.ChildNodes[0];
                foreach (XmlNode node in nodes)
                {
                    AccountModel model = new AccountModel();
                    foreach (XmlNode item in node.ChildNodes)
                    {
                        if (item.Name == "Pop3Server")
                            model.Pop3Server = item.InnerXml;
                        if (item.Name == "Pop3Port")
                            model.Pop3Port = int.Parse(item.InnerXml);
                        if (item.Name == "Pop3UserSsl")
                            model.Pop3UserSsl = item.InnerXml == "0" ? false : true;
                        if (item.Name == "UserName")
                            model.UserName = item.InnerXml;
                        if (item.Name == "PassWord")
                            model.PassWord = item.InnerXml;
                    }
                    //model._POP3Client = new LumiSoft.Net.POP3.Client.POP3_Client();
                    //model._POP3Client.Connect(model.Pop3Server, model.Pop3Port, model.Pop3UserSsl);
                    //model._POP3Client.Authenticate(model.UserName, model.PassWord, false);

                    entity.Add(model);
                }
            }
            catch
            {
                throw new ArgumentException("xml解析出错,请检查数据格式");
            }
            return entity;
        }
    }
}
