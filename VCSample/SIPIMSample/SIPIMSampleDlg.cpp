// SIPIMSampleDlg.cpp : implementation file
//

#include "stdafx.h"
#include "SIPIMSample.h"
#include "SIPIMSampleDlg.h"
#include "ContactsDlg.h"

#include "Ini.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CSIPIMSampleDlg dialog


CSIPIMSampleDlg * g_MainDlg = NULL;




CSIPIMSampleDlg::CSIPIMSampleDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSIPIMSampleDlg::IDD, pParent)
	, m_UserName(_T(""))
	, m_Password(_T(""))
	, m_SIPSever(_T(""))
	, m_SIPSeverPort(5060)
	, m_StunServer(_T(""))
	, m_UserDomain(_T(""))
	, m_SIPLib(NULL)
	, m_SIPInitialized(false)
	, m_SIPRegistered(false)
	, m_StunServerPort(0)
	, m_MyStatusText(_T(""))
	, m_AddContactName(_T(""))
	, m_SendMessage(_T(""))
	, m_SendTo(_T(""))
	, m_DisplayName(_T(""))
	, m_AuthName(_T(""))
	, m_PresenceMode(1)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CSIPIMSampleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT_USERNAME, m_UserName);
	DDX_Text(pDX, IDC_EDIT_PASSWORD, m_Password);
	DDX_Text(pDX, IDC_EDIT_SIPSERVER, m_SIPSever);
	DDX_Text(pDX, IDC_EDIT_SIPSERVERPORT, m_SIPSeverPort);
	DDX_Text(pDX, IDC_EDIT_STUNSERVER, m_StunServer);
	DDX_Text(pDX, IDC_EDIT_USERDOMAIN, m_UserDomain);
	DDX_Text(pDX, IDC_EDIT_STUNSERVERPORT, m_StunServerPort);
	DDX_Control(pDX, IDC_LIST1, m_LogList);
	DDX_Text(pDX, IDC_EDIT4, m_MyStatusText);
	DDX_Text(pDX, IDC_EDIT1, m_AddContactName);
	DDX_Text(pDX, IDC_EDIT2, m_SendMessage);
	DDX_Text(pDX, IDC_EDIT3, m_SendTo);
	DDX_Control(pDX, IDC_LIST3, m_ContactsList);
	DDX_Text(pDX, IDC_EDIT5, m_DisplayName);
	DDX_Text(pDX, IDC_EDIT6, m_AuthName);
	DDX_Radio(pDX, IDC_RADIO1, m_PresenceMode);
}

BEGIN_MESSAGE_MAP(CSIPIMSampleDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_CLOSE()
	ON_MESSAGE(WM_SIPEVENT, OnSIPCallbackEvent)
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BUTTON19, &CSIPIMSampleDlg::OnBnClickedButton19)
	ON_BN_CLICKED(IDC_BUTTON20, &CSIPIMSampleDlg::OnBnClickedButton20)
	ON_BN_CLICKED(IDC_BUTTON3, &CSIPIMSampleDlg::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON1, &CSIPIMSampleDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CSIPIMSampleDlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON4, &CSIPIMSampleDlg::OnBnClickedButton4)
	ON_BN_CLICKED(IDC_BUTTON5, &CSIPIMSampleDlg::OnBnClickedButton5)
END_MESSAGE_MAP()


// CSIPIMSampleDlg message handlers

void CSIPIMSampleDlg::onMessage(void * parameters)
{
	if (!parameters)
	{
		return;
	}


	if (!this->PostMessage(WM_SIPEVENT, (WPARAM)parameters, 0))
	{
		PortSIP_delCallbackParameters(parameters);
	}
}


BOOL CSIPIMSampleDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	g_MainDlg = this;


	Init();




	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CSIPIMSampleDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CSIPIMSampleDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CSIPIMSampleDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


BOOL CSIPIMSampleDlg::PreTranslateMessage(MSG* pMsg)
{
	// TODO: Add your specialized code here and/or call the base class

	if (pMsg->message == WM_KEYDOWN)
	{
		if ((pMsg->wParam == VK_RETURN) || (pMsg->wParam == VK_ESCAPE))
		{
			return TRUE;
		}
	}

	return CDialog::PreTranslateMessage(pMsg);
}

void CSIPIMSampleDlg::OnBnClickedButton19()
{
	// TODO: Add your control notification handler code here



#define SIPPORT_MIN	5000

	UpdateData(TRUE);

	m_LogList.ResetContent();


	if (m_SIPInitialized==true || m_SIPRegistered==true)
	{
		::MessageBox(GetSafeHwnd(), "You already Logged in!", "Information", MB_ICONINFORMATION);	
		return;		
	}

	if (m_UserName.IsEmpty())
	{
		::MessageBox(GetSafeHwnd(), "Please enter user name!", "Information", MB_ICONINFORMATION);	
		return;	
	}

	if (m_Password.IsEmpty())
	{
		::MessageBox(GetSafeHwnd(), "Please enter password!", "Information", MB_ICONINFORMATION);	
		return;	
	}

	if (m_SIPSever.IsEmpty())
	{
		::MessageBox(GetSafeHwnd(), "Please enter SIP server!", "Information", MB_ICONINFORMATION);	
		return;	
	}

	if (m_SIPSeverPort <= 0)
	{
		::MessageBox(GetSafeHwnd(), "Please enter SIP server port!", "Information", MB_ICONINFORMATION);	
		return;	
	}


	//  Default we don't use outbound server, set the outboundServer as NULL and the port as 0
	char * outboundServer = NULL;
	int outboundServerPort = 0;

	char logFilePath[] = "d:\\";
	int rt = 0;


	srand(GetTickCount());
	int localSIPPort = SIPPORT_MIN + rand() % 5000;

	TRANSPORT_TYPE transport = TRANSPORT_UDP;

	char localIp[32] = { 0 };
	int nics = PortSIP_getNICNums();
	for (int i = 0; i < nics; ++i)
	{
		PortSIP_getLocalIpAddress(i, localIp, 32);
		if (!strstr(localIp, ":"))
		{
			break;
		}
	}

	if (strlen(localIp) == 0)
	{
		m_LogList.ResetContent();
		m_SIPLib = NULL;
		m_SIPInitialized = false;

		::MessageBox(GetSafeHwnd(), "Failed to get the local IP.", "Information", MB_ICONWARNING);
		return;
	}

	m_SIPLib = PortSIP_initialize(this,
		transport,
		// Use 0.0.0.0 for local IP then the SDK will choose an available local IP automatically.
		// You also can specify a certain local IP to instead of "0.0.0.0", more details please read the SDK User Manual
		"0.0.0.0",
		localSIPPort,
		PORTSIP_LOG_NONE,
		logFilePath,
		8,
		"PortSIP VoIP SDK",
		0,
		0,
		"/",
		"",
		 false,
		&rt);

	if (!m_SIPLib)
	{
		::MessageBox(GetSafeHwnd(), "PortSIP_initialize failure.", "Information", MB_ICONWARNING);	
		return;		
	}

	m_LogList.InsertString(m_LogList.GetCount(), "Initialized the SDK.");
	m_SIPInitialized = true;

	rt = PortSIP_setLicenseKey(m_SIPLib, "PORTSIP_TEST_LICENSE");
	if (rt == ECoreTrialVersionLicenseKey)
	{
		::MessageBox(GetSafeHwnd(), "This sample was built base on evaluation PortSIP VoIP SDK, which allows only three minutes conversation. The conversation will be cut off automatically after three minutes, then you can't hearing anything. Feel free contact us at: sales@portsip.com to purchase the official version.", "Information", MB_ICONINFORMATION);
	}
	else if (rt == ECoreWrongLicenseKey)
	{
		::MessageBox(GetSafeHwnd(), "The wrong license key was detected, please check with sales@portsip.com or support@portsip.com", "Information", MB_ICONINFORMATION);
	}

	rt = PortSIP_setUser(m_SIPLib,
		(LPTSTR)(LPCTSTR)m_UserName,
		(LPTSTR)(LPCTSTR)m_DisplayName, 
		(LPTSTR)(LPCTSTR)m_UserName, // Authorization name, usually same as username
		(LPTSTR)(LPCTSTR)m_Password,
		(LPTSTR)(LPCTSTR)m_UserDomain, 
		(LPTSTR)(LPCTSTR)m_SIPSever,
		m_SIPSeverPort,
		NULL, // Don't use STUN server
		0,
		NULL, // No outbound server
		0);
	if (rt != 0)
	{
		PortSIP_unInitialize(m_SIPLib);
		m_LogList.ResetContent();
		m_SIPLib = NULL;
		m_SIPInitialized = false;

		::MessageBox(GetSafeHwnd(), "PortSIP_setUser failure", "Information", MB_ICONWARNING);	
		return;		
	}

	m_LogList.InsertString(m_LogList.GetCount(), "Set user succeeded.");
	PortSIP_setLicenseKey(m_SIPLib, "PORTSIP_TEST_LICENSE");

	// This function must set after PortSIP_setUser function
	PortSIP_setPresenceMode(m_SIPLib, m_PresenceMode);

	rt = PortSIP_registerServer(m_SIPLib, 120, 3);
	if (rt != 0)
	{
		PortSIP_removeUser(m_SIPLib);
		PortSIP_unInitialize(m_SIPLib);
		m_SIPLib = NULL;
		m_SIPInitialized = false;

		::MessageBox(GetSafeHwnd(), "Failed to register to SIP server.", "Information", MB_ICONWARNING);
		m_LogList.ResetContent();

		return;
	}

	m_LogList.InsertString(m_LogList.GetCount(), "Register....");
}


BOOL CSIPIMSampleDlg::InitWinSock()
{
	WSADATA       wsd;
	INT			  nRet;

	nRet = WSAStartup(MAKEWORD(2,2), &wsd);
	if (nRet != 0)
	{
		::MessageBoxA(GetSafeHwnd(), "Initialize Winsock is failure.", "Sample", MB_ICONINFORMATION);

		return FALSE;
	}

	return TRUE;
}



LRESULT CSIPIMSampleDlg::OnSIPCallbackEvent(WPARAM WParam, LPARAM LParam)
{
	ICallbackParameters * parameters = (ICallbackParameters *)WParam;

	if (!parameters)
	{	
		return S_FALSE;
	}

	switch(parameters->getEventType())
	{
	case SIP_UNKNOWN:
		break;


	case SIP_REGISTER_SUCCESS:
		{
			m_LogList.InsertString(m_LogList.GetCount(), "Logged in");
			UpdateData(FALSE);

			m_SIPRegistered = true;
			LoadContacts();
		}
		break;

	case SIP_REGISTER_FAILURE:

		::MessageBoxA(GetSafeHwnd(),"Registration Failure.", "PortSIP", MB_ICONINFORMATION);
		m_LogList.InsertString(m_LogList.GetCount(), "Failed to Login to server.");

		UpdateData(FALSE);

		break;


	case SIP_PRESENCE_OFFLINE:
		OnPresenceOffline(parameters);
		break;

	case SIP_PRESENCE_ONLINE:
		OnPresenceOnline(parameters);
		break;


	case SIP_PRESENCE_RECV_SUBSCRIBE:
		OnPresenceRecvSubscribe(parameters);
		break;


	case SIP_RECV_OUTOFDIALOG_MESSAGE:
		OnRecvOutOfDialogMessage(parameters);
		break;


	case SIP_SEND_OUTOFDIALOG_MESSAGE_SUCCESS:
		OnSendOutOfDialogMessageFailure(parameters);
		break;

	case SIP_SEND_OUTOFDIALOG_MESSAGE_FAILURE:
		OnSendOutOfDialogMessageSuccess(parameters);
		break;
	}


	PortSIP_delCallbackParameters(parameters);
	parameters = NULL;

	return S_OK;
}



void CSIPIMSampleDlg::Release()
{
	
	if (m_SIPRegistered == true)
	{
		Offline();
		PortSIP_unRegisterServer(m_SIPLib);

		//waiting unregister server success.
		Sleep(3000);
		PortSIP_removeUser(m_SIPLib);
	}

	if (m_SIPInitialized == true)
	{
		PortSIP_unInitialize(m_SIPLib);
		m_SIPLib = NULL;
	}


	m_SIPRegistered = false;
	m_SIPInitialized = false;

	m_LogList.ResetContent();

	m_ContactsList.DeleteAllItems();

	UpdateData(FALSE);
	
	string FileName = GetLocalPath();
	FileName += "contacts.ini";

	Profile ContactsProfile(FileName);


	CStringArray Contacts;
	ContactsProfile.GetSectionNames(Contacts);

	for (int i=0; i<Contacts.GetCount(); ++i)
	{
		string SipUri = (LPTSTR)(LPCTSTR)Contacts.GetAt(i);

		ContactsProfile.SetSubscribeId(SipUri, 0);
	}
}



void CSIPIMSampleDlg::OnBnClickedButton20()
{
	// TODO: Add your control notification handler code here


	Release();
}




void CSIPIMSampleDlg::LoadContacts()
{
	string FileName = GetLocalPath();
	FileName += "contacts.ini";

	Profile ContactsProfile(FileName);

	CStringArray Contacts;
	ContactsProfile.GetSectionNames(Contacts);

	for (int i=0; i<Contacts.GetCount(); ++i)
	{
		string SipUri = (LPTSTR)(LPCTSTR)Contacts.GetAt(i);

		bool blocked = ContactsProfile.GetBlocked(SipUri);
		bool subscribed = ContactsProfile.GetSubscribed(SipUri);

		ContactsProfile.SetSubscribeId(SipUri, 0);


		if (subscribed == false)
		{
			continue;
		}

		string Text = "Offline";
		if (blocked == true)
		{
			Text = "Blocked";
		}

		LVFINDINFO Info;

		Info.flags = LVFI_PARTIAL|LVFI_STRING;
		Info.psz = SipUri.c_str();

		int Index = m_ContactsList.FindItem(&Info);
		if (Index != -1)
		{
			m_ContactsList.DeleteItem(Index);
		}


		m_ContactsList.InsertItem(LVIF_TEXT, 0, SipUri.c_str(), LVIS_SELECTED, LVIS_SELECTED, 0, 0);
		m_ContactsList.SetItemText(0, 1, Text.c_str());	

	}


	for (int i=0; i<Contacts.GetCount(); ++i)
	{
		string SipUri = (LPTSTR)(LPCTSTR)Contacts.GetAt(i);
		bool subscribed = ContactsProfile.GetSubscribed(SipUri);

		if (subscribed == true)
		{
			PortSIP_presenceSubscribe(m_SIPLib, SipUri.c_str(), "Hello");
		}
	}

}



void CSIPIMSampleDlg::OnPresenceOffline(ICallbackParameters * parameters)
{
	const char* caller = parameters->getCaller();

	string FromContact;
	if (!strstr(caller, "sip:"))
	{
		FromContact = "sip:";
	}
	FromContact += caller;


	string FileName = GetLocalPath();
	FileName += "contacts.ini";
	
	Profile ContactsProfile(FileName);
	ContactsProfile.SetSubscribeId(FromContact, 0);


	// Get the display name
	const char* displayName = parameters->getCallerDisplayName();


	LVFINDINFO Info;

	Info.flags = LVFI_PARTIAL|LVFI_STRING;
	Info.psz = FromContact.c_str();

	int Index = m_ContactsList.FindItem(&Info);
	if (Index != -1)
	{
		m_ContactsList.DeleteItem(Index);
	}


	string Text = "Offline";

	m_ContactsList.InsertItem(LVIF_TEXT, 0, FromContact.c_str(), LVIS_SELECTED, LVIS_SELECTED, 0, 0);
	m_ContactsList.SetItemText(0, 1, Text.c_str());	
}




void CSIPIMSampleDlg::OnPresenceOnline(ICallbackParameters * parameters)
{
	const char* caller = parameters->getCaller();

	string FromContact;
	if (!strstr(caller, "sip:"))
	{
		FromContact = "sip:";
	}
	FromContact += caller;


	const char* statusText = parameters->getStatusText();


	// Get the display name
	const char* displayName = parameters->getCallerDisplayName();


	LVFINDINFO Info;

	Info.flags = LVFI_PARTIAL|LVFI_STRING;
	Info.psz = FromContact.c_str();

	int Index = m_ContactsList.FindItem(&Info);
	if (Index != -1)
	{
		m_ContactsList.DeleteItem(Index);
	}

	string Text = "Online: ";
	Text += statusText;

	m_ContactsList.InsertItem(LVIF_TEXT, 0, FromContact.c_str(), LVIS_SELECTED, LVIS_SELECTED, 0, 0);
	m_ContactsList.SetItemText(0, 1, Text.c_str());	

}



void CSIPIMSampleDlg::OnPresenceRecvSubscribe(ICallbackParameters * parameters)
{
	const char* caller = parameters->getCaller();

	string FromContact;
	if (!strstr(caller, "sip:"))
	{
		FromContact = "sip:";
	}
	FromContact += caller;


	// Get display name
	const char* displayName = parameters->getCallerDisplayName();

	string from = displayName;
	from += " <";
	from += FromContact;
	from += ">";

	CContactsDlg Dlg;
	Dlg.SetContactName(from);

	string FileName = GetLocalPath();
	FileName += "contacts.ini";

	Profile ContactsProfile(FileName);


	if (ContactsProfile.IsSectionExists(FromContact)==true && ContactsProfile.GetBlocked(FromContact)==true)
	{
		PortSIP_presenceRejectSubscribe(m_SIPLib, parameters->getSubscribeId());
		return;
	}

	if (m_PresenceMode == 0)
	{
		// P2P presence mode
		if (ContactsProfile.GetAcceptedSubscribed(FromContact))
		{
			PortSIP_presenceAcceptSubscribe(m_SIPLib, parameters->getSubscribeId());
			PortSIP_setPresenceStatus(m_SIPLib, parameters->getSubscribeId(), "Available");

			long id = ContactsProfile.GetSubscribeId(FromContact);
			ContactsProfile.SetSubscribeId(FromContact, parameters->getSubscribeId());

			if (ContactsProfile.GetSubscribed(FromContact) == true && id <= 0)
			{
				// The contact subscribed me, accept it and also subscribe the contact's presence
				PortSIP_presenceSubscribe(m_SIPLib, FromContact.c_str(), "Hello");
			}

			return;
		}
	}
	else
	{
		if (ContactsProfile.GetAcceptedSubscribed(FromContact))
		{
			// Presence agent mode
			PortSIP_presenceAcceptSubscribe(m_SIPLib, parameters->getSubscribeId());
			PortSIP_setPresenceStatus(m_SIPLib, 0, "Available");

			long id = ContactsProfile.GetSubscribeId(FromContact);
			ContactsProfile.SetSubscribeId(FromContact, parameters->getSubscribeId());

			if (ContactsProfile.GetSubscribed(FromContact) == true && id <= 0)
			{
				// The contact subscribed me, accept it and also subscribe the contact's presence
				PortSIP_presenceSubscribe(m_SIPLib, FromContact.c_str(), "Hello");
			}

			return;
		}
	}


	if (Dlg.DoModal() != IDOK)
	{
		ContactsProfile.SetSipUri(FromContact, FromContact);

		ContactsProfile.SetAcceptedSubscribed(FromContact, false);
		ContactsProfile.SetBlocked(FromContact, true);


		PortSIP_presenceRejectSubscribe(m_SIPLib, parameters->getSubscribeId());

		ContactsProfile.SetSubscribeId(FromContact, 0);
	}
	else 
	{
		ContactsProfile.SetSipUri(FromContact, FromContact);

		ContactsProfile.SetAcceptedSubscribed(FromContact, true);
		ContactsProfile.SetBlocked(FromContact, false);
		ContactsProfile.SetSubscribeId(FromContact, parameters->getSubscribeId());

		PortSIP_presenceAcceptSubscribe(m_SIPLib, parameters->getSubscribeId());

		if (m_PresenceMode == 0)
		{
			PortSIP_setPresenceStatus(m_SIPLib, parameters->getSubscribeId(), "Available");
		}
		else
		{
			PortSIP_setPresenceStatus(m_SIPLib, 0, "Available");
		}


		if (ContactsProfile.GetSubscribed(FromContact) == true)
		{
			PortSIP_presenceSubscribe(m_SIPLib, FromContact.c_str(), "Hello");
		}	

	}
}


void CSIPIMSampleDlg::OnSendOutOfDialogMessageFailure(ICallbackParameters * parameters)
{

}


void CSIPIMSampleDlg::OnSendOutOfDialogMessageSuccess(ICallbackParameters * parameters)
{

}



void CSIPIMSampleDlg::OnRecvOutOfDialogMessage(ICallbackParameters * parameters)
{
	const char* mimeType = parameters->getMimeType();
	const char* subMimeType = parameters->getSubMimeType();

	const char* sender = parameters->getCaller();

	// Get display name
	const char* displayName = parameters->getCallerDisplayName();

	const unsigned char * data = parameters->getMessageData();
	int len = parameters->getMessageDataLength();

	if (strstr(mimeType, "text") && strstr(subMimeType, "plain"))
	{
		stringstream Text;
		Text << "Received a MESSAGE message out of dialog: ";
		Text << data;
		::MessageBoxA(GetSafeHwnd(), Text.str().c_str(), "Received a out of dialog MESSAGE message", MB_ICONINFORMATION);
	}
	else if (strstr(mimeType, "application") && (strstr(subMimeType, "vnd.3gpp.sms") || strstr(subMimeType, "vnd.3gpp2.sms")))
	{
		stringstream Text;
		Text << "Received a binary MESSAGE message out of dialog.";
		::MessageBoxA(GetSafeHwnd(), Text.str().c_str(), "Received a MESSAGE message", MB_ICONINFORMATION);
	}

}



void CSIPIMSampleDlg::Init()
{
	InitWinSock();

	m_ContactsList.SetExtendedStyle(LVS_EX_GRIDLINES | LVS_EX_FULLROWSELECT | LVS_EX_SUBITEMIMAGES);


	m_ContactsList.InsertColumn(0, "SIP Uri", LVCFMT_LEFT, 180, 10);
	m_ContactsList.InsertColumn(1, "Status", LVCFMT_LEFT, 120, 10);
}


void CSIPIMSampleDlg::Offline()
{
	// TODO: Add your control notification handler code here

	if (m_SIPRegistered == false)
	{
		return;
	}


	string FileName = GetLocalPath();
	FileName += "contacts.ini";

	Profile ContactsProfile(FileName);

	CStringArray Contacts;
	ContactsProfile.GetSectionNames(Contacts);


	UpdateData(TRUE);


	if (m_PresenceMode != 0)
	{
		// Presence Agent
		PortSIP_setPresenceStatus(m_SIPLib, 0, "unpublish");
	}
	else
	{
		for (int i = 0; i < Contacts.GetCount(); ++i)
		{
			string SipUri = (LPTSTR)(LPCTSTR)Contacts.GetAt(i);
			long subscribeId = ContactsProfile.GetSubscribeId(SipUri);

			if (ContactsProfile.GetAcceptedSubscribed(SipUri))
			{
				PortSIP_setPresenceStatus(m_SIPLib, subscribeId, "Offline");
			}
		}
	}
}

void CSIPIMSampleDlg::OnClose()
{
	// TODO: Add your message handler code here and/or call default


	Release();

	CDialog::OnClose();
}



void CSIPIMSampleDlg::OnBnClickedButton3()
{
	// TODO: Add your control notification handler code here


	if (m_SIPRegistered == false)
	{
		return;
	}


	string FileName = GetLocalPath();
	FileName += "contacts.ini";

	Profile ContactsProfile(FileName);

	CStringArray Contacts;
	ContactsProfile.GetSectionNames(Contacts);



	UpdateData(TRUE);
	
	if (m_MyStatusText.IsEmpty())
	{
		::MessageBoxA(GetSafeHwnd(), "The status text is empty.", "PortSIP", MB_ICONINFORMATION);
		return;
	}


	string StatusText = (LPTSTR)(LPCTSTR)m_MyStatusText;

	if (m_PresenceMode != 0)
	{
		int rt = PortSIP_setPresenceStatus(m_SIPLib, 0, StatusText.c_str());
	}
	else
	{
		for (int i = 0; i < Contacts.GetCount(); ++i)
		{
			string SipUri = (LPTSTR)(LPCTSTR)Contacts.GetAt(i);
			long subscribeId = ContactsProfile.GetSubscribeId(SipUri);

			if (ContactsProfile.GetAcceptedSubscribed(SipUri))
			{
				PortSIP_setPresenceStatus(m_SIPLib, subscribeId, StatusText.c_str());
			}
		}
	}
}



void CSIPIMSampleDlg::OnBnClickedButton1()
{
	// TODO: Add your control notification handler code here

	if (m_SIPRegistered == false)
	{
		return;
	}


	UpdateData(TRUE);
	if (m_AddContactName.IsEmpty())
	{
		return;
	}

	if (m_AddContactName.FindOneOf("sip:")==-1 || m_AddContactName.FindOneOf("@")==-1 )
	{
		::MessageBoxA(GetSafeHwnd(), "The contact name must likes: sip:username@sip.portsip.com",  "PortSIP", MB_ICONINFORMATION);
		return;
	}


	string contactName = (LPTSTR)(LPCTSTR)m_AddContactName;
	PortSIP_presenceSubscribe(m_SIPLib, contactName.c_str(), "Hello");

	string FileName = GetLocalPath();
	FileName += "contacts.ini";

	Profile ContactsProfile(FileName);

	ContactsProfile.SetSipUri(contactName, contactName);
	ContactsProfile.SetSubscribed(contactName, true);


	string Text = "Offline";
	
	LVFINDINFO Info;

	Info.flags = LVFI_PARTIAL|LVFI_STRING;
	Info.psz = contactName.c_str();

	int Index = m_ContactsList.FindItem(&Info);
	if (Index != -1)
	{
		m_ContactsList.DeleteItem(Index);
	}


	m_ContactsList.InsertItem(LVIF_TEXT, 0, contactName.c_str(), LVIS_SELECTED, LVIS_SELECTED, 0, 0);
	m_ContactsList.SetItemText(0, 1, Text.c_str());	
}



void CSIPIMSampleDlg::OnBnClickedButton2()
{
	// TODO: Add your control notification handler code here

	if (m_SIPRegistered == false)
	{
		return;
	}


	UpdateData(TRUE);

	if (m_SendTo.IsEmpty() || m_SendMessage.IsEmpty())
	{
		return;
	}

	if (m_SendTo.FindOneOf("sip:")==-1 || m_SendTo.FindOneOf("@")==-1)
	{
		return;
	}


	string sendTo = (LPTSTR)(LPCTSTR)m_SendTo;
	string message = (LPTSTR)(LPCTSTR)m_SendMessage;

	PortSIP_sendOutOfDialogMessage(m_SIPLib, sendTo.c_str(), "text", "plain", false, (const unsigned char *)message.c_str(), message.length());

}



string CSIPIMSampleDlg::GetLocalPath()
{
	char buff[MAX_PATH] = { 0 };
	GetModuleFileNameA(NULL, buff, MAX_PATH);
	PathRemoveFileSpecA(buff);

	string path = buff;
	path += "\\";

	return path;
}


void CSIPIMSampleDlg::OnBnClickedButton4()
{
	// TODO: Add your control notification handler code here


	int item = m_ContactsList.GetNextItem(-1, LVNI_SELECTED);
	CString SipUri = m_ContactsList.GetItemText(item, 0);

	string uri = (LPTSTR)(LPCTSTR)SipUri;


	m_ContactsList.DeleteItem(item);


	string FileName = GetLocalPath();
	FileName += "contacts.ini";

	Profile ContactsProfile(FileName);
	ContactsProfile.DeleteSection(uri);
}



void CSIPIMSampleDlg::OnBnClickedButton5()
{
	// TODO: Add your control notification handler code here

	string FileName = GetLocalPath();
	FileName += "contacts.ini";

	Profile ContactsProfile(FileName);


	while (1)
	{
		int item = m_ContactsList.GetNextItem(-1, LVNI_ALL);
		if (item == -1)
		{
			break;
		}

		CString SipUri = m_ContactsList.GetItemText(item, 0);

		string uri = (LPTSTR)(LPCTSTR)SipUri;


		m_ContactsList.DeleteItem(item);
		ContactsProfile.DeleteSection(uri);
	}
}
