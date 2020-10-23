using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Navigation;
using PortSIP;
using Ini;



namespace SIPIMSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, SIPCallbackEvents
    {

        public class ContactData
        {
            public string Uri { get; set; }
            public string Status { get; set; }
        }


        private bool _SIPInited = false;
        private bool _SIPLogined = false;

        IniFile _iniFile;


        private PortSIPLib _sdkLib;

        /// <summary>
        /// 
        /// </summary>
        /// 

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        public Window1()
        {
            InitializeComponent();
        }

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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string filePathName = System.IO.Directory.GetCurrentDirectory() + "\\contacts.ini";

            _iniFile = new IniFile(filePathName);

        }


        private void LoadContacts()
        {
            string[] sectionNames = _iniFile.getSectionNames();
            if (sectionNames != null)
            {
                for (int i = 0; i < sectionNames.Length; ++i)
                {
                    int subscribed = int.Parse(_iniFile.readValue(sectionNames[i], "subscribed"));
                    if (subscribed == 0)
                    {
                        continue;
                    }

                    Int32 index = findItem(sectionNames[i]);
                    if (index != -1)
                    {
                        deleteItem(index);
                    }


                    ContactData data = new ContactData();
                    data.Uri = sectionNames[i];
                    data.Status = "Offline";

                    ContactsList.Items.Add(data);
                }


                for (int i = 0; i < sectionNames.Length; ++i)
                {
                    int subscribed = int.Parse(_iniFile.readValue(sectionNames[i], "subscribed"));
                    if (subscribed == 1)
                    {
                        _sdkLib.presenceSubscribe(sectionNames[i], "Hello");
                    }
                }
            }
        }


        private void BtnOnline_Click(object sender, RoutedEventArgs e)
        {
            if (_SIPInited == true)
            {
                MessageBox.Show("You are already logged in.");
                return;
            }


            if (txtUserName.Text.Length <= 0)
            {
                MessageBox.Show("The user name does not allows empty.");
                return;
            }


            if (txtPassword.Text.Length <= 0)
            {
                MessageBox.Show("The password does not allows empty.");
                return;
            }

            if (txtSIPServer.Text.Length <= 0)
            {
                MessageBox.Show("The proxy server does not allows empty.");
                return;
            }

            int SIPServerPort = 0;
            if (txtSIPPort.Text.Length > 0)
            {
                SIPServerPort = int.Parse(txtSIPPort.Text);
                if (SIPServerPort > 65535 || SIPServerPort <= 0)
                {
                    MessageBox.Show("The SIP server port out of range.");

                    return;
                }
            }


            int StunServerPort = 0;
            if (txtStunServer.Text.Length > 0)
            {
                StunServerPort = int.Parse(txtStunPort.Text);
                if (StunServerPort > 65535 || StunServerPort <= 0)
                {
                    MessageBox.Show("The Stun server port out of range.");

                    return;
                }
            }

            Random rd = new Random();
            int LocalSIPPort = rd.Next(1000, 5000) + 4000; // Generate the random port for SIP
            TRANSPORT_TYPE transportType = TRANSPORT_TYPE.TRANSPORT_UDP;

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
            string agent = "PortSIP VoIP SDK";
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
                MessageBox.Show("Failed to initialize.");
                return;
            }

            ListBoxSIPLog.Items.Add("Initialized.");


            _SIPInited = true;


            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string sipDomain = txtUserDomain.Text;
            string SIPServer = txtSIPServer.Text;
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
                                       SIPServer,
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

                MessageBox.Show("setUser failure.");
                return;
            }

            ListBoxSIPLog.Items.Add("Succeeded set user information.");

            // This function should called after setUser for effect
            if ((Boolean)radioP2PMode.IsChecked)
            {
                _sdkLib.setPresenceMode(0); 
            }
            else 
            {
                _sdkLib.setPresenceMode(1); 
            }
           

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

            rt = _sdkLib.registerServer(90, 0);
            if (rt != 0)
            {
                _sdkLib.removeUser();
                _SIPInited = false;
                _sdkLib.unInitialize();

                _sdkLib.releaseCallbackHandlers();
                ListBoxSIPLog.Items.Clear();

                MessageBox.Show("register to server failed.");
            }


            ListBoxSIPLog.Items.Add("Registering...");
        }

        private void BtnOffline_Click(object sender, RoutedEventArgs e)
        {
            Release();
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

                //
                // MUST called after _sdkLib.unInitliaze();
                //
                _sdkLib.releaseCallbackHandlers();
            }

            _SIPLogined = false;
            _SIPInited = false;

            ListBoxSIPLog.Items.Clear();

            for (int i = 0; i < ContactsList.Items.Count; ++i)
            {
                ContactData data = (ContactData)ContactsList.Items.GetItemAt(i);
                ContactsList.Items.Remove(data);
            }
        }


        private void Offline()
        {
            if (_SIPLogined == false)
            {
                return;
            }

            if((Boolean)RadioAgentMode.IsChecked)
            {
                _sdkLib.setPresenceStatus(0, "unpublish");
            }
            else
            {
                for (int i = 0; i < ContactsList.Items.Count; ++i)
                {
                    ContactData data = (ContactData)ContactsList.Items.GetItemAt(i);

                    string SipUri = data.Uri;
                    int subscribeId = int.Parse(_iniFile.readValue(SipUri, "subscribeid"));
                    int acceptSubscribed = int.Parse(_iniFile.readValue(SipUri, "acceptedsubscribed"));


                    if (acceptSubscribed == 1 && subscribeId != -1)
                    {
                        _sdkLib.setPresenceStatus(subscribeId, "Offline");
                    }


                    // set all subscribe id to 0
                    _iniFile.writeValue(SipUri, "subscribeid", "0");
                }
            }

        }


        private void BtnDelContact_Click(object sender, RoutedEventArgs e)
        {
            if (ContactsList.SelectedIndex == -1)
            {
                return;
            }

            ContactData data = (ContactData)ContactsList.SelectedItems[0];
            _iniFile.writeValue(data.Uri, null, "");

            ContactsList.Items.Remove(data);
        }


        private void BtnClearContact_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ContactsList.Items.Count; ++i)
            {
                ContactData data = (ContactData)ContactsList.Items.GetItemAt(i);
                _iniFile.writeValue(data.Uri, null, "");

                ContactsList.Items.Remove(data);
            }
        }


        private Int32 findItem(string uri)
        {
            for (int i = 0; i < ContactsList.Items.Count; ++i)
            {
                ContactData data = (ContactData)ContactsList.Items.GetItemAt(i);
                if (data.Uri == uri)
                {
                    return i;
                }
            }

            return -1;
        }

        private void deleteItem(Int32 index)
        {
            if (index <= -1)
            {
                return;
            }

            ContactData data = (ContactData)ContactsList.Items.GetItemAt(index);
            ContactsList.Items.Remove(data);
        }

        private void deleteItem(string uri)
        {
            Int32 index = findItem(uri);
            if (index == -1)
            {
                return;
            }

            deleteItem(index);
        }


        private void BtnAddContact_Click(object sender, RoutedEventArgs e)
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

            _sdkLib.presenceSubscribe(txtContact.Text, "Hello");

            _iniFile.writeValue(txtContact.Text, "sipuri", txtContact.Text);
            _iniFile.writeValue(txtContact.Text, "subscribed", "1");

            Int32 index = findItem(txtContact.Text);
            if (index != -1)
            {
                deleteItem(index);
            }

            ContactData data = new ContactData();
            data.Uri = txtContact.Text;
            data.Status = "Offline";

            ContactsList.Items.Add(data);
        }


        private void BtnSetStatus_Click(object sender, RoutedEventArgs e)
        {
            if (_SIPLogined == false)
            {
                return;
            }

            if (txtStatus.Text.Length <= 0)
            {
                MessageBox.Show("The status text is empty!");
                return;
            }


            if ((Boolean)RadioAgentMode.IsChecked)
            {
                _sdkLib.setPresenceStatus(0, txtStatus.Text);
            }
            else
            {

                for (int i = 0; i < ContactsList.Items.Count; ++i)
                {
                    ContactData data = (ContactData)ContactsList.Items.GetItemAt(i);
                    Int32 subscribeId = int.Parse(_iniFile.readValue(data.Uri, "subscribeid"));
                    Int32 acceptedSubscribed = int.Parse(_iniFile.readValue(data.Uri, "acceptedsubscribed"));

                    if (acceptedSubscribed == 1)
                    {
                        _sdkLib.setPresenceStatus(subscribeId, txtStatus.Text);
                    }

                }
            }
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
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

            Int32 messageId = _sdkLib.sendOutOfDialogMessage(sendTo, "text", "plain", false, GetBytes(message), GetBytes(message).Length);
            if (messageId <= 0)
            {
                // Failed to send
            } 
            else
            {
                // The message is sending, the rt is message ID, you can save it and use it to identify which message is success or failure
                // in onSendOutOutOfDialogMessageSuccess/onSendOutOutOfDialogMessageFailure events.
            }
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
            // use the Invoke method to modify the control.
            ListBoxSIPLog.Dispatcher.Invoke(new Action(delegate
            {
                ListBoxSIPLog.Items.Add("Registration succeeded");
            }));

            _SIPLogined = true;

            return 0;
        }


        public Int32 onRegisterFailure(Int32 callbackIndex, Int32 callbackObject, String statusText, Int32 statusCode, StringBuilder sipMessage)
        {
            ListBoxSIPLog.Dispatcher.Invoke(new Action(delegate
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


        public Int32 onInviteFailure(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, String reason, Int32 code, StringBuilder sipMessage)
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


            ListBoxSIPLog.Dispatcher.Invoke(new Action(delegate
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


            ListBoxSIPLog.Dispatcher.Invoke(new Action(delegate
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
            string contactUri = from;
            if (from.IndexOf("sip:") == -1)
            {
                contactUri = "sip:";
                contactUri += from;
            }


            string contactNanme = fromDisplayName;
            contactNanme += " <";
            contactNanme += contactUri;
            contactNanme += ">";


            Int32 accepted = int.Parse(_iniFile.readValue(contactUri, "acceptedsubscribed"));
            if (accepted == 0) // We have rejected this contact ago
            {
                _sdkLib.presenceRejectSubscribe(subscribeId);
                return 0;
            }

            if (accepted == 1) // We have accepted this contact ago
            {
                _sdkLib.presenceAcceptSubscribe(subscribeId);
                _sdkLib.setPresenceStatus(subscribeId, "Available");

                Int32 oldId = int.Parse(_iniFile.readValue(contactUri, "subscribeid")); // read the old id
                _iniFile.writeValue(contactUri, "subscribeid", subscribeId.ToString()); // overwrite the old id

                Int32 subscribed = int.Parse(_iniFile.readValue(contactUri, "subscribed"));
                if (subscribed == 1 && oldId <= 0)
                {
                    _sdkLib.presenceSubscribe(contactUri, "Hello");
                }

                return 0;
            }


            ListBoxSIPLog.Dispatcher.Invoke(new Action(delegate
            {
                Window2 dlg = new Window2();
                dlg.setContactName(contactNanme);

                if (dlg.ShowDialog() == true)
                {
                    _iniFile.writeValue(contactUri, "sipuri", contactUri);
                    _iniFile.writeValue(contactUri, "acceptedsubscribed", "1");
                    _iniFile.writeValue(contactUri, "subscribeid", subscribeId.ToString());

                    _sdkLib.presenceAcceptSubscribe(subscribeId);
                    _sdkLib.setPresenceStatus(subscribeId, "Available");

                    Int32 subscribed = int.Parse(_iniFile.readValue(contactUri, "subscribed"));
                    if (subscribed == 1)
                    {
                        _sdkLib.presenceSubscribe(contactUri, "Hello");
                    }
                }
                else
                {
                    _iniFile.writeValue(contactUri, "sipuri", contactUri);
                    _iniFile.writeValue(contactUri, "acceptedsubscribed", "0");

                    _sdkLib.presenceRejectSubscribe(subscribeId);
                    _iniFile.writeValue(contactUri, "subscribeid", "0");
                }

            }));


            return 0;
        }


        public Int32 onPresenceOnline(Int32 callbackIndex,
                                                    Int32 callbackObject,
                                                    String fromDisplayName,
                                                    String from,
                                                    String stateText)
        {
            string contactUri = from;
            if (from.IndexOf("sip:") == -1)
            {
                contactUri = "sip:";
                contactUri += from;
            }

            ListBoxSIPLog.Dispatcher.Invoke(new Action(delegate
            {
                Int32 index = findItem(contactUri);
                if (index != -1)
                {
                    ContactsList.Items.RemoveAt(index);
                }
            }));


            string Text = "Online: ";
            Text += stateText;


            ContactData data = new ContactData();
            data.Uri = contactUri;
            data.Status = Text;


            ListBoxSIPLog.Dispatcher.Invoke(new Action(delegate
            {
                ContactsList.Items.Add(data);
            }));

            return 0;
        }

        public Int32 onPresenceOffline(Int32 callbackIndex, Int32 callbackObject, String fromDisplayName, String from)
        {
            string contactUri = from;
            if (from.IndexOf("sip:") == -1)
            {
                contactUri = "sip:";
                contactUri += from;
            }

            ListBoxSIPLog.Dispatcher.Invoke(new Action(delegate
            {
                Int32 index = findItem(contactUri);
                if (index != -1)
                {
                    ContactsList.Items.RemoveAt(index);
                }

            }));


            string Text = "Offline";


            ContactData data = new ContactData();
            data.Uri = contactUri;
            data.Status = Text;


            ListBoxSIPLog.Dispatcher.Invoke(new Action(delegate
            {
                ContactsList.Items.Add(data);
            }));

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
                MessageBox.Show(text, receivedMsg);
            }
            else if (mimeType == "application" && subMimeType == "vnd.3gpp.sms")
            {
                // The messageData is binary data

                MessageBox.Show(text, "Received a binary message.");
            }
            else if (mimeType == "application" && subMimeType == "vnd.3gpp2.sms")
            {
                // The messageData is binary data

                MessageBox.Show(text, "Received a binary message.");
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
                                                        Int32 sessionId, Int32 messageId,
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

        public Int32 onVideoDecoderCallback(IntPtr callbackObject,
                                Int32 sessionId,
                               Int32 width,
                               Int32 height,
                               Int32 framerate,
                               Int32 bitrate)
        {
            /*
                !!! IMPORTANT !!!

                Don't call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
                other code which will spend long time, you should post a message to main thread(main window) or other thread,
                let the thread to call SDK API functions or other code.
            */
            return 0;
        }
    }
}
