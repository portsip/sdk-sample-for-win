/*
  We are store the contacts information into a XML file.
  Each contact has a section in XML file likes below,

  the section has these Nodes:
  1: sipuri - this node use for save contact's sip uri.
  2: subscribed - If we subscribed a contact, then set this node value to subscribed; If this node value is empty,
	 means we do not subscribe him yet.
  3: acceptedsubscribed - When received a subscribe request, if accepted it, then set this node value 
	 to accepted, otherwise set it to Blocked; 


<?xml version="1.0" encoding="utf-8"?>
<Configuration>
    <Section1>
        <sipuri>sip:cccc3@sip.portsip.com:5060</sipuri>        
        <subscribed>subscribed</subscribed>
	<acceptedSubscribed>Accepted</acceptedSubscribed>
    </Section1>
    <Section2>
        <sipuri>sip:cccc4@sip.portsip.com:5060</sipuri> 
	<subscribed>subscribed</subscribed>       
        <acceptedSubscribed>Blocked</acceptedSubscribed>
    </Section2>

</Configuration>
*/


using System;
using System.Xml;
using System.Diagnostics;
using System.Windows.Forms;

namespace PORTSIP.Config
{
    class XmlConfig
    {
        private string xmlPath;
        private bool isConfig;
        private XmlDocument xmlDocument;


        public XmlConfig(string xmlPath)
        {
            this.xmlDocument = new XmlDocument();
            this.XmlPath = xmlPath;
        }

        public XmlConfig()
        {
            this.xmlDocument = new XmlDocument();

        }
        public void SetPath(string xPath)
        {
            //this.XmlPath = xPath;
        }


        public string XmlPath
        {
            set
            {
                xmlPath = value;
                isConfig = OnXmlPathChange();
            }
        }


        public bool ReadContacts(ref  ListView list)
        {
            //nCount = xmlDocument.SelectSingleNode("Configuration").ChildNodes.Count;
            // xmlDocument.SelectSingleNode("Configuration")
            // /*

            XmlNode xn = xmlDocument.SelectSingleNode("Configuration");
            if (!isConfig)
            {
                return false;
            }
            XmlNodeList xnl = xn.ChildNodes;

            foreach (XmlNode xnf in xnl)
            {
                XmlElement xe = (XmlElement)xnf;
                XmlNodeList xnf1 = xe.ChildNodes;
                XmlNodeList nodeList = xe.GetElementsByTagName("sipuri");
                if (nodeList.Count == 1)
                {
                    //Debug.Print(nodeList.Item(0).InnerText);
                    ListViewItem Li = new ListViewItem();
                    Li.Text = nodeList.Item(0).InnerText;
                    Li.SubItems.Add("offLine");
                    XmlNodeList subscribedList = xe.GetElementsByTagName("subscribed");
                    if (subscribedList.Count >= 1)
                    {
                        Li.SubItems.Add(subscribedList.Item(0).InnerText);
                    }
                    else
                    {
                        Li.SubItems.Add("");
                    }
                    XmlNodeList acceptSubscribedList = xe.GetElementsByTagName("acceptedSubscribed");
                    if (acceptSubscribedList.Count >= 1)
                    {
                        Li.SubItems.Add(acceptSubscribedList.Item(0).InnerText);
                    }
                    else
                    {
                        Li.SubItems.Add("");
                    }
                    Li.SubItems.Add("-1");

                    list.Items.Add(Li);
                }
            }
            return true;
            //* */
        }

        public bool WriteContacts(ref  ListView list)
        {
            xmlDocument.RemoveAll();
            XmlElement xn = xmlDocument.CreateElement("Configuration");

            //XmlNode xn = xmlDocument.RemoveAll().SelectSingleNode("Configuration");
            //xn.RemoveAll();

            for (int i = 0; i < list.Items.Count; ++i)
            {
                string SipUri = list.Items[i].SubItems[0].Text;
                string Subscribed = list.Items[i].SubItems[2].Text;
                string AcceptSubscribed = list.Items[i].SubItems[3].Text;

                string sessionName = "Section" + (i + 1).ToString();

                XmlElement SessionNode = xmlDocument.CreateElement(sessionName);

                XmlElement sipuriNode = xmlDocument.CreateElement("sipuri");
                sipuriNode.InnerText = SipUri;
                SessionNode.AppendChild(sipuriNode);

                XmlElement subscribedNode = xmlDocument.CreateElement("subscribed");
                subscribedNode.InnerText = Subscribed;
                SessionNode.AppendChild(subscribedNode);

                XmlElement AcceptsubscribedNode = xmlDocument.CreateElement("acceptedSubscribed");
                AcceptsubscribedNode.InnerText = AcceptSubscribed;
                SessionNode.AppendChild(AcceptsubscribedNode);

                SessionNode.AppendChild(subscribedNode);

                xn.AppendChild(SessionNode);
            }
            xmlDocument.AppendChild(xn);
            try
            {
                xmlDocument.Save(xmlPath);
            }
            catch (Exception e)
            {
                //显示错误信息
                Debug.Print(e.Message);
            }

            return true;
        }

        public bool ReadConfig(string section, string key, ref string value)
        {
            bool isRead = false;
            try
            {
                if (isConfig)
                {
                    value = xmlDocument.SelectSingleNode("Configuration").SelectSingleNode(section).SelectSingleNode(key).InnerText;
                    isRead = true;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return isRead;
        }

        public bool WriteConfig(string section, string key, string value)
        {
            bool isWrited = false;
            try
            {
                if (isConfig)
                {
                    xmlDocument.SelectSingleNode("Configuration").SelectSingleNode(section).SelectSingleNode(key).InnerText = value;
                    xmlDocument.Save(xmlPath);
                    isWrited = true;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return isWrited;
        }

        #region
        private bool OnXmlPathChange()
        {
            bool isLoaded = false;
            try
            {
                xmlDocument.Load(xmlPath);
                isLoaded = true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return isLoaded;
        }
        #endregion
    }

}