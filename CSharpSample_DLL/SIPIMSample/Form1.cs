using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PortSIP;
using PORTSIP.Config;



namespace SIPIMSample
{
    public partial class Form1 : Form, SIPCallbackEvents
    {

        private bool _SIPInited = false;
        private bool _SIPLogined = false;
        private XmlConfig _xmlContact;

        private PortSIPLib _sdkLib;


        private byte[] GetBytes(string str)
        {
            return System.Text.Encoding.Default.GetBytes(str);
        }

        private string GetString(byte[] bytes)
        {
           return System.Text.Encoding.Default.GetString(bytes);
        }

        private string getLocalIP()
        {
            StringBuilder localIP = new StringBuilder();
            localIP.Length = 64;
            int nics = _sdkLib.getNICNums();
            for (int i = 0; i < nics; ++i)
            {
                _sdkLib.getLocalIpAddress(i, localIP, 64);
                if (localIP.ToString().IndexOf(":") == -1)
                {
                    // No ":" in the IP then it's the IPv4 address, we use it in our sample
                    break;
                }
                else
                {
                    // the ":" is occurs in the IP then this is the IPv6 address.
                    // In our sample we don't use the IPv6.
                }

            }

            return localIP.ToString();
        }


        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ContactsList.Columns.Clear();
            ContactsList.Columns.Add("SIP Url", 180, HorizontalAlignment.Left);
            ContactsList.Columns.Add("Status", 120, HorizontalAlignment.Left);
            ContactsList.Columns.Add("Subscribed", 70, HorizontalAlignment.Left);
            ContactsList.Columns.Add("AcceptSubscribed", 70, HorizontalAlignment.Left);
            ContactsList.Columns.Add("SubscribeID", 0, HorizontalAlignment.Left);



            string path = System.IO.Directory.GetCurrentDirectory() + "\\SIPIMContacts.xml";

            _xmlContact = new XmlConfig(path);

            _xmlContact.ReadContacts(ref ContactsList);
        }



        private void Offline()
        {

            if (_SIPLogined == false)
            {
                return;
            }

            if (!radioButton1.Checked)
            {
                _sdkLib.setPresenceStatus(0, "unpublish");
            }
            else 
            {
                for (int i = 0; i < ContactsList.Items.Count; ++i)
                {
                    string SipUri = ContactsList.Items[i].SubItems[0].Text;
                    int subscribeId = int.Parse(ContactsList.Items[i].SubItems[4].Text);

                    if (ContactsList.Items[i].SubItems[3].Text == "Accepted" && subscribeId != -1)
                    {
                        _sdkLib.setPresenceStatus(subscribeId, "Offline");
                    }
                }

                _xmlContact.WriteContacts(ref ContactsList);
            }


        }


        private void Release()
        {
            if (_SIPInited == false)
            {
                return;
            }

            if (_SIPLogined == true)
            {
                Offline();
                _sdkLib.unRegisterServer();
                //waiting unregister server success.
                System.Threading.Thread.Sleep(3000);
            }

            if (_SIPInited == true)
            {
                _sdkLib.removeUser();
                _sdkLib.unInitialize();
                _sdkLib.releaseCallbackHandlers();
            }

            _SIPLogined = false;
            _SIPInited = false;

            ListBoxSIPLog.Items.Clear();
        }

        private void BtnOnline_Click(object sender, EventArgs e)
        {
            if (_SIPInited == true)
            {
                MessageBox.Show("You are already logged in.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (txtUserName.Text.Length <= 0)
            {
                MessageBox.Show("The user name does not allows empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (txtPassword.Text.Length <= 0)
            {
                MessageBox.Show("The password does not allows empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtSIPServer.Text.Length <= 0)
            {
                MessageBox.Show("The proxy server does not allows empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int SIPServerPort = 0;
            if (txtSIPPort.Text.Length > 0)
            {
                SIPServerPort = int.Parse(txtSIPPort.Text);
                if (SIPServerPort > 65535 || SIPServerPort <= 0)
                {
                    MessageBox.Show("The SIP server port out of range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }


            int StunServerPort = 0;
            if (txtStunServer.Text.Length > 0)
            {
                StunServerPort = int.Parse(txtStunPort.Text);
                if (StunServerPort > 65535 || StunServerPort <= 0)
                {
                    MessageBox.Show("The Stun server port out of range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }


            Random rd = new Random();
            int LocalSIPPort = rd.Next(1000, 5000) + 4000; // Generate the random port for SIP

            TRANSPORT_TYPE transportType = TRANSPORT_TYPE.TRANSPORT_UDP; // Default we use the UDP transport

      //
            // Create the class instance of PortSIP VoIP SDK, you can create more than one instances and 
            // each instance register to a SIP server to support multiples accounts & providers.
            // for example:
            /*
            _sdkLib1 = new PortSIPLib(1, 1, this);
            _sdkLib2 = new PortSIPLib(2, 2, this);
            _sdkLib3 = new PortSIPLib(3, 3, this);
            */


            _sdkLib = new PortSIPLib(0, 0, this);

            //
            // Create and set the SIP callback handers, this MUST called before
            // _sdkLib.initialize();
            //
            _sdkLib.createCallbackHandlers();

            string logFilePath = "d:\\"; // The log file path, you can change it - the folder MUST exists
            string agent = "PortSIP VoIP SDK ";
            string stunServer = txtStunServer.Text;

            // Initialize the SDK
            int rt = _sdkLib.initialize(transportType,
                // Use 0.0.0.0 for local IP then the SDK will choose an available local IP automatically.
                // You also can specify a certain local IP to instead of "0.0.0.0", more details please read the SDK User Manual
                            "0.0.0.0",
                            LocalSIPPort,
                PORTSIP_LOG_LEVEL.PORTSIP_LOG_NONE,
                             logFilePath,
                             8,
                             agent,
                             0,
                             0, 
                             "/",
                             "", 
                             false);

            if (rt != 0)
            {
                _sdkLib.releaseCallbackHandlers();
                MessageBox.Show("Failed to initialized.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ListBoxSIPLog.Items.Add("Initialized.");
            _SIPInited = true;

            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string sipDomain = txtUserDomain.Text;
            string sipServer = txtSIPServer.Text;
            string displayName = txtDisplayName.Text;
            string authName = txtAuthName.Text;

            int outboundServerPort = 0;
            string outboundServer = "";



            // Set the SIP user information
            rt = _sdkLib.setUser(userName,
                                       displayName,
                                       authName,
                                       password,
                                       sipDomain,
                                       sipServer,
                                       SIPServerPort,
                                       stunServer,
                                       StunServerPort,
                                       outboundServer,
                                       outboundServerPort);
            if (rt != 0)
            {
                _sdkLib.unInitialize();
                _sdkLib.releaseCallbackHandlers();

                _SIPInited = false;

                ListBoxSIPLog.Items.Clear();

                MessageBox.Show("setUser failure.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (radioButton1.Checked)
            {
                _sdkLib.setPresenceMode(0);
            }
            else if (radioButton2.Checked)
            {
                _sdkLib.setPresenceMode(1);
            }

            ListBoxSIPLog.Items.Add("Succeeded set user information.");

            string licenseKey = "PORTSIP_TEST_LICENSE";
            rt = _sdkLib.setLicenseKey(licenseKey);
            if (rt == PortSIP_Errors.ECoreTrialVersionLicenseKey)
            {
                MessageBox.Show("This sample was built base on evaluation PortSIP VoIP SDK, which allows only three minutes conversation. The conversation will be cut off automatically after three minutes, then you can't hearing anything. Feel free contact us at: sales@portsip.com to purchase the official version.");
            }
            else if (rt == PortSIP_Errors.ECoreWrongLicenseKey)
            {
                MessageBox.Show("The wrong license key was detected, please check with sales@portsip.com or support@portsip.com");
            }

            rt = _sdkLib.registerServer(120, 0);
            if (rt != 0)
            {
                _sdkLib.removeUser();
                _SIPInited = false;
                _sdkLib.unInitialize();

                _sdkLib.releaseCallbackHandlers();

                ListBoxSIPLog.Items.Clear();

                MessageBox.Show("register to server failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            ListBoxSIPLog.Items.Add("Registering...");
        }

        private void BtnOffline_Click(object sender, EventArgs e)
        {
            if (_SIPInited == false)
            {
                return;
            }

            Release();
        }

        private void BtnDelContact_Click(object sender, EventArgs e)
        {
            if (ContactsList.SelectedItems.Count > 0)
            {
                ContactsList.Items.RemoveAt(ContactsList.SelectedItems[0].Index);
            }

            _xmlContact.WriteContacts(ref ContactsList);
        }

        private void BtnClearContact_Click(object sender, EventArgs e)
        {
            ContactsList.Items.Clear();
            _xmlContact.WriteContacts(ref ContactsList);
        }

        private void UpdateContact()
        {
            string statusText = txtStatus.Text;

            for (int i = 0; i < ContactsList.Items.Count; ++i)
            {
                string SipUri = ContactsList.Items[i].SubItems[0].Text;
                string subject = "Hello";
                int subscribeId = int.Parse(ContactsList.Items[i].SubItems[4].Text);
                if (ContactsList.Items[i].SubItems[2].Text == "subscribed")
                {
                    _sdkLib.presenceSubscribe(SipUri, subject);
                }

                if (ContactsList.Items[i].SubItems[3].Text == "Accepted" && subscribeId != -1 && radioButton1.Checked)
                {
                    _sdkLib.setPresenceStatus(subscribeId, statusText);
                }
            }

            if (!radioButton1.Checked)
            {
                _sdkLib.setPresenceStatus(0, statusText);
            }
        }

        private void BtnUpdateContact_Click(object sender, EventArgs e)
        {
            UpdateContact();
        }

        private void BtnAddContact_Click(object sender, EventArgs e)
        {
            if (_SIPLogined == false)
            {
                return;
            }
            if (txtContact.Text.Length <= 0)
            {
                return;
            }

            if (txtContact.Text.IndexOf("sip:") == -1 || txtContact.Text.IndexOf('@') == -1)
            {
                MessageBox.Show("The contact name must likes: sip:username@sip.portsip.com");
                return;
            }

            string Contact = txtContact.Text;
            string subject = "Hello";
            _sdkLib.presenceSubscribe(Contact, subject);


            for (int i = 0; i < ContactsList.Items.Count; ++i)
            {
                string SipUri = ContactsList.Items[i].SubItems[0].Text;
                if (SipUri == Contact)
                {
                    ContactsList.Items[i].SubItems[2].Text = "subscribed";
                    return;
                }
            }

            ListViewItem Li = new ListViewItem();
            Li.Text = Contact;
            Li.SubItems.Add("offLine");
            Li.SubItems.Add("subscribed");
            Li.SubItems.Add("");
            Li.SubItems.Add("0");
            ContactsList.Items.Add(Li);
            _xmlContact.WriteContacts(ref ContactsList); 
        }

        private void BtnSetStatus_Click(object sender, EventArgs e)
        {
            if (_SIPLogined == false)
            {
                return;
            }

            string statusText = txtStatus.Text;

            if (radioButton1.Checked)
            {
                for (int i = 0; i < ContactsList.Items.Count; ++i)
                {
                    string SipUri = ContactsList.Items[i].SubItems[0].Text;
                    int subscribeId = int.Parse(ContactsList.Items[i].SubItems[4].Text);

                    if (ContactsList.Items[i].SubItems[3].Text == "Accepted" && subscribeId != -1)
                    {
                        _sdkLib.setPresenceStatus(subscribeId, statusText);
                    }
                }
            }
            else 
            {
                _sdkLib.setPresenceStatus(0, statusText);
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (_SIPLogined == false)
            {
                return;
            }

            if (txtMessage.Text.Length <= 0 || txtSendto.Text.Length <= 0)
            {
                return;
            }
            string sendTo = txtSendto.Text;
            string message = txtMessage.Text;

            long rt = _sdkLib.sendOutOfDialogMessage(sendTo, "text", "plain", false, GetBytes(message), GetBytes(message).Length);
            if (rt <= 0)
            {

            }
            else
            {
                // The message is sending, the rt is message ID, you can save it and use it to identify which message is success or failure
                // in onSendOutOutOfDialogMessageSuccess/onSendOutOutOfDialogMessageFailure events.
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://portsip.com/portsip-pbx");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:sales@portsip.com");
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        ///  With below all onXXX functions, you MUST use the Invoke/BeginInvoke method if you want
        ///  modify any control on the Forms.
        ///  More details please visit: http://msdn.microsoft.com/en-us/library/ms171728.aspx
        ///  The Invoke method is recommended.
        ///  
        ///  if you don't like Invoke/BeginInvoke method, then  you can add this line to Form_Load:
        ///  Control.CheckForIllegalCrossThreadCalls = false;
        ///  This requires .NET 2.0 or higher
        /// 
        /// </summary>
        /// 

        public Int32 onRegisterSuccess(Int32 callbackIndex, Int32 callbackObject, String statusText, Int32 statusCode, StringBuilder sipMessage)
        {
            // Use the Invoke method to modify the control.
            ListBoxSIPLog.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add("Registration succeeded");
            }));

            _SIPLogined = true;

            return 0;
        }


        public Int32 onRegisterFailure(Int32 callbackIndex, Int32 callbackObject, String statusText, Int32 statusCode, StringBuilder sipMessage)
        {
            ListBoxSIPLog.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add("Registration failure");
            }));

            _SIPLogined = false;

            return 0;
        }

        public Int32 onInviteIncoming(Int32 callbackIndex,
                                                Int32 callbackObject,
                                                Int32 sessionId,
                                                String callerDisplayName,
                                                String caller,
                                                String calleeDisplayName,
                                                String callee,
                                                String audioCodecNames,
                                                String videoCodecNames,
                                                Boolean existsAudio,
                                                Boolean existsVideo,
                                                StringBuilder sipMessage)
        {
  

            return 0;

        }

        public Int32 onInviteTrying(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId)
        {
     
            return 0;
        }


        public Int32 onInviteSessionProgress(Int32 callbackIndex,
                                            Int32 callbackObject,
                                            Int32 sessionId,
                                             String audioCodecNames,
                                             String videoCodecNames,
                                             Boolean existsEarlyMedia,
                                             Boolean existsAudio,
                                             Boolean existsVideo,
                                             StringBuilder sipMessage)
        {

            return 0;
        }

        public Int32 onInviteRinging(Int32 callbackIndex,
                                            Int32 callbackObject,
                                            Int32 sessionId,
                                            String statusText,
                                            Int32 statusCode,
                                            StringBuilder sipMessage)
        {
    
            return 0;
        }


        public Int32 onInviteAnswered(Int32 callbackIndex,
                                             Int32 callbackObject,
                                             Int32 sessionId,
                                             String callerDisplayName,
                                             String caller,
                                             String calleeDisplayName,
                                             String callee,
                                             String audioCodecNames,
                                             String videoCodecNames,
                                             Boolean existsAudio,
                                             Boolean existsVideo,
                                             StringBuilder sipMessage)
        {
    
            return 0;
        }


        public Int32 onInviteFailure(Int32 callbackIndex, 
                                    Int32 callbackObject, 
                                    Int32 sessionId, 
                                    String reason, 
                                    Int32 code,
                                    StringBuilder sipMessage)
        {

            return 0;
        }


        public Int32 onInviteUpdated(Int32 callbackIndex,
                                             Int32 callbackObject,
                                             Int32 sessionId,
                                             String audioCodecNames,
                                             String videoCodecNames,
                                             Boolean existsAudio,
                                             Boolean existsVideo,
                                             StringBuilder sipMessage)
        {
   

            return 0;
        }


        public Int32 onInviteConnected(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId)
        {

            return 0;
        }


        public Int32 onInviteBeginingForward(Int32 callbackIndex, Int32 callbackObject, String forwardTo)
        {

            return 0;
        }


        public Int32 onInviteClosed(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId)
        {


            return 0;
        }

        public Int32 onDialogStateUpdated(Int32 callbackIndex,
                         Int32 callbackObject,
                         String BLFMonitoredUri,
                         String BLFDialogState,
                         String BLFDialogId,
                         String BLFDialogDirection)
        {


            return 0;
        }


        public Int32 onRemoteHold(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId)
        {

            return 0;
        }


        public Int32 onRemoteUnHold(Int32 callbackIndex,
                                             Int32 callbackObject,
                                             Int32 sessionId,
                                             String audioCodecNames,
                                             String videoCodecNames,
                                             Boolean existsAudio,
                                             Boolean existsVideo)
        {

            return 0;
        }


        public Int32 onReceivedRefer(Int32 callbackIndex,
                                                    Int32 callbackObject,
                                                    Int32 sessionId,
                                                    Int32 referId,
                                                    String to,
                                                    String from,
                                                    StringBuilder referSipMessage)
        {

            return 0;
        }


        public Int32 onReferAccepted(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId)
        {
            return 0;
        }



        public Int32 onReferRejected(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, String reason, Int32 code)
        {
   
            return 0;
        }


        public Int32 onTransferTrying(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId)
        {
            return 0;
        }

        public Int32 onTransferRinging(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId)
        {
            return 0;
        }



        public Int32 onACTVTransferSuccess(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId)
        {
            return 0;
        }


        public Int32 onACTVTransferFailure(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, String reason, Int32 code)
        {
            return 0;
        }

        public Int32 onReceivedSignaling(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, StringBuilder signaling)
        {
            // This event will be fired when the SDK received a SIP message
            // you can use signaling to access the SIP message.

            return 0;
        }


        public Int32 onSendingSignaling(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, StringBuilder signaling)
        {
            // This event will be fired when the SDK sent a SIP message
            // you can use signaling to access the SIP message.

            return 0;
        }




        public Int32 onWaitingVoiceMessage(Int32 callbackIndex,
                                                    Int32 callbackObject,
                                                  String messageAccount,
                                                  Int32 urgentNewMessageCount,
                                                  Int32 urgentOldMessageCount,
                                                  Int32 newMessageCount,
                                                  Int32 oldMessageCount)
        {

            string Text = messageAccount;
            Text += " has voice message.";


            ListBoxSIPLog.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add(Text);
            }));

            // You can use these parameters to check the voice message count

            //  urgentNewMessageCount;
            //  urgentOldMessageCount;
            //  newMessageCount;
            //  oldMessageCount;

            return 0;
        }


        public Int32 onWaitingFaxMessage(Int32 callbackIndex,
                                                       Int32 callbackObject,
                                                  String messageAccount,
                                                  Int32 urgentNewMessageCount,
                                                  Int32 urgentOldMessageCount,
                                                  Int32 newMessageCount,
                                                  Int32 oldMessageCount)
        {
            string Text = messageAccount;
            Text += " has FAX message.";


            ListBoxSIPLog.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add(Text);
            }));


            // You can use these parameters to check the FAX message count

            //  urgentNewMessageCount;
            //  urgentOldMessageCount;
            //  newMessageCount;
            //  oldMessageCount;

            return 0;
        }


        public Int32 onRecvDtmfTone(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, Int32 tone)
        {
      
            return 0;
        }


        public Int32 onPresenceRecvSubscribe(Int32 callbackIndex,
                                                    Int32 callbackObject,
                                                    Int32 subscribeId,
                                                    String fromDisplayName,
                                                    String from,
                                                    String subject)
        {
            string fromSipUri = from;
            if (from.IndexOf("sip:") == -1)
            {
                fromSipUri = "sip:";
                fromSipUri += from;
            }


            for (int i = 0; i < ContactsList.Items.Count; ++i)
            {
                string SipUri = ContactsList.Items[i].SubItems[0].Text;

                if (SipUri == fromSipUri)
                {
                    if (ContactsList.Items[i].SubItems[3].Text == "Blocked")
                    {
                        _sdkLib.presenceRejectSubscribe(subscribeId);
                    }
                    else if (ContactsList.Items[i].SubItems[3].Text == "Accepted")
                    {
                        int nOldSubscribID = int.Parse(ContactsList.Items[i].SubItems[4].Text);
                        ContactsList.Items[i].SubItems[4].Text = subscribeId.ToString();
                        _sdkLib.presenceAcceptSubscribe(subscribeId);
                        string status = "Available";

                        if (radioButton1.Checked)
                        {
                            _sdkLib.setPresenceStatus(subscribeId, status);
                        }
                        else
                        {
                            _sdkLib.setPresenceStatus(0, status);
                        }
                       
                        
                        ContactsList.Items[i].SubItems[3].Text = "Accepted";

                        if (ContactsList.Items[i].SubItems[2].Text == "subscribed" && nOldSubscribID >= 0)
                        {
                            _sdkLib.presenceSubscribe(fromSipUri, subject);
                        }
                    }
                    else
                    {
                        Form2 AddContactsDlg1 = new Form2();

                        AddContactsDlg1.SetContactName(from);

                        AddContactsDlg1.ShowDialog();

                        if (AddContactsDlg1.GetAccept() == true)
                        {
                            _sdkLib.presenceAcceptSubscribe(subscribeId);
                            ContactsList.Items[i].SubItems[4].Text = subscribeId.ToString();
                            ContactsList.Items[i].SubItems[3].Text = "Accepted";
                            string status = "Available";

                            if (radioButton1.Checked)
                            {
                                _sdkLib.setPresenceStatus(subscribeId, status);
                            }
                            else
                            {
                                _sdkLib.setPresenceStatus(0, status);
                            }
                            
                            _sdkLib.presenceSubscribe(fromSipUri, subject);

                            _xmlContact.WriteContacts(ref ContactsList);
                        }
                        else
                        {
                            ContactsList.Items[i].SubItems[3].Text = "Blocked";
                            ContactsList.Items[i].SubItems[4].Text = "0";

                            _sdkLib.presenceRejectSubscribe(subscribeId);
                            _xmlContact.WriteContacts(ref ContactsList);
                        }
                    }


                    return 0;
                }
            }


            Form2 AddContactsDlg = new Form2();

            string fromContact = fromDisplayName;
            fromContact += " <";
            fromContact += fromSipUri;
            fromContact += ">";
            AddContactsDlg.SetContactName(fromContact);
            AddContactsDlg.ShowDialog();

            if (AddContactsDlg.GetAccept() == true)
            {
                ListViewItem Li = new ListViewItem();
                Li.Text = fromSipUri;
                Li.SubItems.Add("onLine");
                Li.SubItems.Add("");
                Li.SubItems.Add("Accepted");
                Li.SubItems.Add(subscribeId.ToString());
                ContactsList.Items.Add(Li);

                _sdkLib.presenceAcceptSubscribe(subscribeId);
                string status = "Available";
                if (radioButton1.Checked)
                {
                    _sdkLib.setPresenceStatus(subscribeId, status);
                }
                else
                {
                    _sdkLib.setPresenceStatus(0, status);
                }

                _sdkLib.presenceSubscribe(fromSipUri, subject);
            }
            else
            {
                ListViewItem Li = new ListViewItem();
                Li.Text = fromSipUri;
                Li.SubItems.Add("offLine");
                Li.SubItems.Add("");
                Li.SubItems.Add("Blocked");
                Li.SubItems.Add("0");
                ContactsList.Items.Add(Li);

                _sdkLib.presenceRejectSubscribe(subscribeId);
            }
            _xmlContact.WriteContacts(ref ContactsList);

            return 0;
        }


        public Int32 onPresenceOnline(Int32 callbackIndex,
                                                    Int32 callbackObject,
                                                    String fromDisplayName,
                                                    String from,
                                                    String stateText)
        {
            string fromSipUri = from;
            if (from.IndexOf("sip:") == -1)
            {
                fromSipUri = "sip:";
                fromSipUri += from;
            }

            for (int i = 0; i < ContactsList.Items.Count; ++i)
            {
                string SipUri = ContactsList.Items[i].SubItems[0].Text;
                if (SipUri == fromSipUri)
                {
                    ContactsList.Items[i].SubItems[1].Text = "onLine:" + stateText;
                }
            }

            return 0;
        }

        public Int32 onPresenceOffline(Int32 callbackIndex, Int32 callbackObject, String fromDisplayName, String from)
        {
            string fromSipUri = from;
            if (from.IndexOf("sip:") == -1)
            {
                fromSipUri = "sip:";
                fromSipUri += from;
            }
            

            for (int i = 0; i < ContactsList.Items.Count; ++i)
            {
                string SipUri = ContactsList.Items[i].SubItems[0].Text;
                if (SipUri == fromSipUri)
                {
                    ContactsList.Items[i].SubItems[2].Text = "Offline";
                    ContactsList.Items[i].SubItems[4].Text = "0";
                }
            }

            return 0;
        }


        public Int32 onRecvOptions(Int32 callbackIndex, Int32 callbackObject, StringBuilder optionsMessage)
        {
            //       string text = "Received an OPTIONS message: ";
            //       text += optionsMessage.ToString();
            //     MessageBox.Show(text, "Received an OPTIONS message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return 0;
        }

        public Int32 onRecvInfo(Int32 callbackIndex, Int32 callbackObject, StringBuilder infoMessage)
        {
    //        string text = "Received a INFO message: ";
   //         text += infoMessage.ToString();

     //       MessageBox.Show(text, "Received a INFO message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return 0;
        }

        public Int32 onRecvNotifyOfSubscription(Int32 callbackIndex,
                Int32 callbackObject,
                Int32 subscribeId,
                StringBuilder notifyMsg,
                byte[] contentData,
                Int32 contentLenght)
        {

            return 0;
        }

        public Int32 onSubscriptionFailure(Int32 callbackIndex, Int32 callbackObject, Int32 subscribeId, Int32 statusCode)
        {
            return 0;
        }

        public Int32 onSubscriptionTerminated(Int32 callbackIndex, Int32 callbackObject, Int32 subscribeId)
        {
            return 0;
        }


        public Int32 onRecvMessage(Int32 callbackIndex,
                                                 Int32 callbackObject,
                                                 Int32 sessionId,
                                                 String mimeType,
                                                 String subMimeType,
                                                 byte[] messageData,
                                                 Int32 messageDataLength)
        {
       

            return 0;
        }


        public Int32 onRecvOutOfDialogMessage(Int32 callbackIndex,
                                                 Int32 callbackObject,
                                                 String fromDisplayName,
                                                 String from,
                                                 String toDisplayName,
                                                 String to,
                                                 String mimeType,
                                                 String subMimeType,
                                                 byte[] messageData,
                                                 Int32 messageDataLength)
        {
            string text = "Received a message(out of dialog) from ";
            text += from;

            if (mimeType == "text" && subMimeType == "plain")
            {
                string receivedMsg = GetString(messageData);
                MessageBox.Show(receivedMsg, text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (mimeType == "application" && subMimeType == "vnd.3gpp.sms")
            {
                // The messageData is binary data

                MessageBox.Show(text, "Received a binary message.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (mimeType == "application" && subMimeType == "vnd.3gpp2.sms")
            {
                // The messageData is binary data

                MessageBox.Show(text, "Received a binary message.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return 0;
        }

        public Int32 onSendMessageSuccess(Int32 callbackIndex,
                                                           Int32 callbackObject,
                                                           Int32 sessionId, Int32 messageId)
        {
            return 0;
        }


        public Int32 onSendMessageFailure(Int32 callbackIndex,
                                                        Int32 callbackObject,
                                                        Int32 sessionId,
                                                        Int32 messageId,
                                                        String reason,
                                                        Int32 code)
        {

            return 0;
        }



        public Int32 onSendOutOfDialogMessageSuccess(Int32 callbackIndex,
                                                        Int32 callbackObject,
                                                        Int32 messageId,
                                                        String fromDisplayName,
                                                        String from,
                                                        String toDisplayName,
                                                        String to)
        {

            // Use messageId to identify which message is success.
            return 0;
        }

        public Int32 onSendOutOfDialogMessageFailure(Int32 callbackIndex,
                                                        Int32 callbackObject,
                                                        Int32 messageId,
                                                        String fromDisplayName,
                                                        String from,
                                                        String toDisplayName,
                                                        String to,
                                                        String reason,
                                                        Int32 code)
        {
            // Use messageId to identify which message is failure.
            return 0;
        }


        public Int32 onPlayAudioFileFinished(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, String fileName)
        {
      
            return 0;
        }

        public Int32 onPlayVideoFileFinished(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId)
        {
    

            return 0;
        }


        public Int32 onReceivedRtpPacket(IntPtr callbackObject,
                                  Int32 sessionId,
                                  Boolean isAudio,
                                  byte[] RTPPacket,
                                  Int32 packetSize)
        {
            /*
                !!! IMPORTANT !!!

                Don't call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
                other code which will spend long time, you should post a message to main thread(main window) or other thread,
                let the thread to call SDK API functions or other code.

            */

            return 0;
        }

        public Int32 onSendingRtpPacket(IntPtr callbackObject,
                                  Int32 sessionId,
                                  Boolean isAudio,
                                  byte[] RTPPacket,
                                  Int32 packetSize)
        {

            /*
                !!! IMPORTANT !!!

                Don't call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
                other code which will spend long time, you should post a message to main thread(main window) or other thread,
                let the thread to call SDK API functions or other code.

            */
            return 0;
        }


        public Int32 onAudioRawCallback(IntPtr callbackObject,
                                               Int32 sessionId,
                                               Int32 callbackType,
                                               [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] data,
                                               Int32 dataLength,
                                               Int32 samplingFreqHz)
        {

            /*
                !!! IMPORTANT !!!

                Don't call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
                other code which will spend long time, you should post a message to main thread(main window) or other thread,
                let the thread to call SDK API functions or other code.

            */

            // The data parameter is audio stream as PCM format, 16bit, Mono.
            // the dataLength parameter is audio steam data length.



            //
            // IMPORTANT: the data length is stored in dataLength parameter!!!
            //

            AUDIOSTREAM_CALLBACK_MODE type = (AUDIOSTREAM_CALLBACK_MODE)callbackType;

            if (type == AUDIOSTREAM_CALLBACK_MODE.AUDIOSTREAM_LOCAL_PER_CHANNEL)
            {
                // The callback data is from local record device of each session, use the sessionId to identifying the session.
            }
            else if (type == AUDIOSTREAM_CALLBACK_MODE.AUDIOSTREAM_REMOTE_PER_CHANNEL)
            {
                // The callback data is received from remote side of each session, use the sessionId to identifying the session.
            }


            return 0;
        }


        public Int32 onVideoRawCallback(IntPtr callbackObject,
                                               Int32 sessionId,
                                               Int32 callbackType,
                                               Int32 width,
                                               Int32 height,
                                               [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] data,
                                               Int32 dataLength)
        {
            /*
                !!! IMPORTANT !!!

                Don't call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
                other code which will spend long time, you should post a message to main thread(main window) or other thread,
                let the thread to call SDK API functions or other code.

                The video data format is YUV420, YV12.
            */

            //
            // IMPORTANT: the data length is stored in dataLength parameter!!!
            //

            VIDEOSTREAM_CALLBACK_MODE type = (VIDEOSTREAM_CALLBACK_MODE)callbackType;

            if (type == VIDEOSTREAM_CALLBACK_MODE.VIDEOSTREAM_LOCAL)
            {

            }
            else if (type == VIDEOSTREAM_CALLBACK_MODE.VIDEOSTREAM_REMOTE)
            {

            }


            return 0;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {

        }

    }
}
