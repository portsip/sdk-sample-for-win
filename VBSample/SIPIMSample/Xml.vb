'
'  We are store the contacts information into a XML file.
'  Each contact has a section in XML file likes below,
'
'  the section has these Nodes:
'  1: sipuri - this node use for save contact's sip uri.
'  2: subscribed - If we subscribed a contact, then set this node value to subscribed; If this node value is empty,
'	 means we do not subscribe him yet.
'  3: acceptedsubscribed - When received a subscribe request, if accepted it, then set this node value 
'	 to accepted, otherwise set it to Blocked; 
'
'
'<?xml version="1.0" encoding="utf-8"?>
'<Configuration>
'    <Section1>
'        <sipuri>sip:cccc3@sip.portsip.com:5060</sipuri>        
'        <subscribed>subscribed</subscribed>
'	<acceptedSubscribed>Accepted</acceptedSubscribed>
'    </Section1>
'    <Section2>
'        <sipuri>sip:cccc4@sip.portsip.com:5060</sipuri> 
'	<subscribed>subscribed</subscribed>       
'        <acceptedSubscribed>Blocked</acceptedSubscribed>
'    </Section2>
'
'</Configuration>
'



Imports System.Xml
Imports System.Diagnostics
Imports System.Windows.Forms

Namespace PortSIP.Config
    Class XmlConfig
        Private m_xmlPath As String
        Private isConfig As Boolean
        Private xmlDocument As XmlDocument


        Public Sub New(ByVal xmlPath As String)
            Me.xmlDocument = New XmlDocument()
            Me.XmlPath = xmlPath
        End Sub

        Public Sub New()

            Me.xmlDocument = New XmlDocument()
        End Sub
        Public Sub SetPath(ByVal xPath As String)
            'this.XmlPath = xPath;
        End Sub


        Public WriteOnly Property XmlPath() As String
            Set(ByVal value As String)
                m_xmlPath = Value
                isConfig = OnXmlPathChange()
            End Set
        End Property


        Public Function ReadContacts(ByRef list As ListView) As Boolean
            'nCount = xmlDocument.SelectSingleNode("Configuration").ChildNodes.Count;
            ' xmlDocument.SelectSingleNode("Configuration")
            ' /*

            Dim xn As XmlNode = xmlDocument.SelectSingleNode("Configuration")
            If Not isConfig Then
                Return False
            End If
            Dim xnl As XmlNodeList = xn.ChildNodes

            For Each xnf As XmlNode In xnl
                Dim xe As XmlElement = DirectCast(xnf, XmlElement)
                Dim xnf1 As XmlNodeList = xe.ChildNodes
                Dim nodeList As XmlNodeList = xe.GetElementsByTagName("sipuri")
                If nodeList.Count = 1 Then
                    'Debug.Print(nodeList.Item(0).InnerText);
                    Dim Li As New ListViewItem()
                    Li.Text = nodeList.Item(0).InnerText
                    Li.SubItems.Add("offLine")
                    Dim subscribedList As XmlNodeList = xe.GetElementsByTagName("subscribed")
                    If subscribedList.Count >= 1 Then
                        Li.SubItems.Add(subscribedList.Item(0).InnerText)
                    Else
                        Li.SubItems.Add("")
                    End If
                    Dim acceptSubscribedList As XmlNodeList = xe.GetElementsByTagName("acceptedSubscribed")
                    If acceptSubscribedList.Count >= 1 Then
                        Li.SubItems.Add(acceptSubscribedList.Item(0).InnerText)
                    Else
                        Li.SubItems.Add("")
                    End If
                    Li.SubItems.Add("-1")

                    list.Items.Add(Li)
                End If
            Next
            Return True
            '* */
        End Function

        Public Function WriteContacts(ByRef list As ListView) As Boolean
            xmlDocument.RemoveAll()
            Dim xn As XmlElement = xmlDocument.CreateElement("Configuration")

            'XmlNode xn = xmlDocument.RemoveAll().SelectSingleNode("Configuration");
            'xn.RemoveAll();

            For i As Integer = 0 To list.Items.Count - 1
                Dim SipUri As String = list.Items(i).SubItems(0).Text
                Dim Subscribed As String = list.Items(i).SubItems(2).Text
                Dim AcceptSubscribed As String = list.Items(i).SubItems(3).Text

                Dim sessionName As String = "Section" & (i + 1).ToString()

                Dim SessionNode As XmlElement = xmlDocument.CreateElement(sessionName)

                Dim sipuriNode As XmlElement = xmlDocument.CreateElement("sipuri")
                sipuriNode.InnerText = SipUri
                SessionNode.AppendChild(sipuriNode)

                Dim subscribedNode As XmlElement = xmlDocument.CreateElement("subscribed")
                subscribedNode.InnerText = Subscribed
                SessionNode.AppendChild(subscribedNode)

                Dim AcceptsubscribedNode As XmlElement = xmlDocument.CreateElement("acceptedSubscribed")
                AcceptsubscribedNode.InnerText = AcceptSubscribed
                SessionNode.AppendChild(AcceptsubscribedNode)

                SessionNode.AppendChild(subscribedNode)

                xn.AppendChild(SessionNode)
            Next
            xmlDocument.AppendChild(xn)
            Try
                xmlDocument.Save(m_xmlPath)
            Catch e As Exception
                '显示错误信息
                Debug.Print(e.Message)
            End Try

            Return True
        End Function

        Public Function ReadConfig(ByVal section As String, ByVal key As String, ByRef value As String) As Boolean
            Dim isRead As Boolean = False
            Try
                If isConfig Then
                    value = xmlDocument.SelectSingleNode("Configuration").SelectSingleNode(section).SelectSingleNode(key).InnerText
                    isRead = True
                End If
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            Return isRead
        End Function

        Public Function WriteConfig(ByVal section As String, ByVal key As String, ByVal value As String) As Boolean
            Dim isWrited As Boolean = False
            Try
                If isConfig Then
                    xmlDocument.SelectSingleNode("Configuration").SelectSingleNode(section).SelectSingleNode(key).InnerText = value
                    xmlDocument.Save(m_xmlPath)
                    isWrited = True
                End If
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            Return isWrited
        End Function

#Region ""
        Private Function OnXmlPathChange() As Boolean
            Dim isLoaded As Boolean = False
            Try
                xmlDocument.Load(m_xmlPath)
                isLoaded = True
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            Return isLoaded
        End Function
#End Region
    End Class

End Namespace
