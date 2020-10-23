# Welcome to PortSIP VoIP SDK For Windows

Create your SIP-based application for multiple platforms (iOS, Android, Windows, Mac OS and Linux) with our SDK.

The rewarding PortSIP VoIP SDK is a powerful and versatile set of tools that dramatically accelerate SIP application development. It includes a suite of stacks, SDKs, and some Sample projects, with each of them enables developers to combine all the necessary components to create an ideal development environment for every application's specific needs.

The PortSIP VoIP SDK complies with IETF and 3GPP standards, and is IMS-compliant (3GPP/3GPP2, TISPAN and PacketCable 2.0).
These high performance SDKs provide unified API layers for full user control and flexibility.


## Getting Started

You can download PortSIP VoIP SDK Sample projects at our [Website](https://www.portsip.com/download-portsip-voip-sdk/).
 Samples include demos for VC++, C#, VB.NET, Delphi XE, XCode (for iOS and Mac OS), Eclipse (Java for Android) with the sample project source code provided (with SDK source code exclusive). The sample projects demonstrate how to create a powerful SIP application with our SDK easily and quickly.

## Contents

 The sample package for downloading contains almost all of materials for PortSIP SDK: documentation,
 Dynamic/Static libraries, sources, headers, datasheet, and everything else a SDK user might need!


## SDK User Manual

 To be started with, it is recommended to read the documentation of PortSIP VoIP SDK, [SDK User Manual page](https://www.portsip.com/voip-sdk-user-manual/), which gives a brief description of each API function.


## Website

Some general interest or often changing PortSIP SDK information will be posted on the [PortSIP website](https://www.portsip.com) in real time. The release contains links to the site, so while browsing you may see occasional broken links  if you are not connected to the Internet. To be sure everything needed for using the PortSIP VoIP SDK has been contained within the release.

## Support

Please send email to our <a href="mailto:support@portsip.com">Support team</a> if you need any help.

## Frequently Asked Questions
### 1. What is the difference between PortSIP VoIP SDK and PortSIP VoIP SDK?
  The <a href="https://www.portsip.com/portsip-uc-sdk/" target="_blank">PortSIP VoIP SDK</a> is free, but was limited to works with <a href="https://www.portsip.com/portsip-pbx/" target="_blank">PortSIP PBX</a>; The <a href="https://www.portsip.com/portsip-pbx/" target="_blank">PortSIP VoIP SDK</a> is not free that can works with any 3rd SIP based PBX. The UC SDK also have a lot of unique features than the VoIP SDK which provided by <a href="https://www.portsip.com/portsip-pbx/" target="_blank">PortSIP PBX</a>.

### 2. Where can I download the PortSIP VoIP SDK for test?
  All sample projects of the %PortSIP VoIP SDK can be found and downloaded at:
  <a href="https://www.portsip.com/download-portsip-uc-sdk/" target="_blank">https://www.portsip.com/download-portsip-uc-sdk/</a> <br />

### 3. How can I compile the sample project?

  1. Download the sample project from PortSIP website.
  2. Extract the .zip file.
  3. Open the project with your IDE:
 C#, VB.NET, VC++: Visual Studio 2008 or higher.
  4. Compile the sample project directly. The trial version SDK allows a 2-3 minutes conversation. 

### 4. How can I create a new project with PortSIP VoIP SDK?


#### C#/VB.NET:

      1) Download the Sample project and extract it for C#/VB.NET.
      2) Create a new "Windows application" project.
      3) Copy the PortSIP_sdk.dll to project output directory: bin\release and bin\debug.
      4) Copy the "PortSIP" folder to project folder and add into Solution.
      5) Inherit the interface "SIPCallbackEvents" to process the callback events.
      6) Right-click the project, choose "Properties". Click "Build" tab, and then check the "Allow unsafe code" checkbox.

      For more details please read the Sample project source code.

#### VC++:

      1) Download and extract the sample project.
      2) Create a new "MFC Application" project.
      3) Copy the PortSIP_sdk.dll to project output directories.
      4) Copy the "include/PortSIPLib" folder to project folder and add the ".hxx" files into project.
      5) Copy the "lib" folder to project folder and link "PortSIP_sdk.lib" into project.

      For more details please read the Sample project source code.

### 5. How can I test the P2P call (without SIP server)? 

1. Download and extract the SDK sample project ZIP file, compile and run the "P2PSample" project.
2. Run the P2Psample on two devices. For example, run it on device A and device B, and IP address for
A is 192.168.1.10, IP address for B is 192.168.1.11.
3. Enter a user name and password on A. For example, user name 111, and password aaa (you can enter
anything for the password as the SDK will ignore it). Enter a user name and password on B, for example:
user name 222, password aaa.
4. Click the "Initialize" button on A and B. If the default port 5060 is already in use, the P2PSample
will prompt "Initialize failure". In case of this, please click the "Uninitialize" button and change
the local port, and click the "Initialize" button again.
5. The log box will appear "Initialized." if the SDK is successfully initialized.
6. To make call from A to B, enter: sip:222@192.168.1.11 and click "Dial" button; while to make call
from B to A, enter: sip:111@192.168.1.10.

### 6. Is the SDK thread safe?
Yes, the SDK is thread safe. You can call any of the API functions without the need to consider the multiple threads.
Note: the SDK allows to call API functions in callback events directly - except for the "onAudioRawCallback", "onVideoRawCallback", "onReceivedRtpPacket", "onSendingRtpPacket" callbacks.

### 7. Does the SDK support native 64-bit?
Yes, both 32-bit and 64-bit are supported for SDK.
