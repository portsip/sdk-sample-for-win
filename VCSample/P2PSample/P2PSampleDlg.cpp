// SIPSampleDlg.cpp : implementation file
//

#include "stdafx.h"
#include "P2PSample.h"
#include "P2PSampleDlg.h"

#include "TransferDlg.h"


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


// CP2PSampleDlg dialog

CP2PSampleDlg * g_MainDlg = NULL;


CP2PSampleDlg::CP2PSampleDlg(CWnd* pParent /*=NULL*/)
			: CDialog(CP2PSampleDlg::IDD, pParent)
			, m_UserName(_T(""))
, m_Password(_T(""))
, m_PhoneNumber(_T(""))
, m_MicrophoneMute(FALSE)
, m_CallSDP(FALSE)
, m_DND(FALSE)
, m_AA(FALSE)
, m_Conference(FALSE)
, m_RecordFilePath(_T(""))
, m_RecordFileName(_T(""))
, m_PlayAudioFilePathName(_T(""))
, m_PCMU(TRUE)
, m_PCMA(TRUE)
, m_G729(TRUE)
, m_ILBC(FALSE)
, m_GSM(FALSE)
, m_AMR(FALSE)
, m_H263(FALSE)
, m_H2631998(FALSE)
, m_H264(TRUE)
, m_SIPLib(NULL)
, m_SIPInitialized(false)
, m_ActiveLine(LINE_BASE)
, m_AEC(FALSE)
, m_AGC(FALSE)
, m_VAD(FALSE)
, m_CNG(FALSE)
, m_AudioStreamCallback(FALSE)
, m_ForwardTo(_T(""))
, m_ForwardCallForBusy(FALSE)
, m_LocalSIPPort(5060)
, m_G722(FALSE)
, m_SPEEX(FALSE)
, m_AMR_WB(FALSE)
, m_SPEEX_WB(FALSE)
, m_G7221(FALSE)
, m_VP8(FALSE)
, m_Prack(FALSE)
, m_ANS(FALSE)
, m_MakeVideoCall(TRUE)
, m_AnswerVideoCall(TRUE)
, m_VP9(FALSE)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

}

void CP2PSampleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT_USERNAME, m_UserName);
	DDX_Text(pDX, IDC_EDIT_PASSWORD, m_Password);
	DDX_Text(pDX, IDC_EDIT_PHONENUMBER, m_PhoneNumber);
	DDX_Control(pDX, IDC_COMBO_LINELIST, m_LineList);
	DDX_Control(pDX, IDC_LIST_LOG, m_LogList);
	DDX_Check(pDX, IDC_CHECK_MICROPHONEMUTE, m_MicrophoneMute);
	DDX_Control(pDX, IDC_SLIDER_SPEAKER, m_SpeakerVolume);
	DDX_Control(pDX, IDC_SLIDER_MICROPHONE, m_MicrophoneVolume);
	DDX_Control(pDX, IDC_COMBO_SPEAKERS, m_SpeakersList);
	DDX_Control(pDX, IDC_COMBO_MICROPHONES, m_MicrophonesList);
	DDX_Control(pDX, IDC_COMBO_CAMERAS, m_CamerasList);
	DDX_Check(pDX, IDC_CHECK2, m_CallSDP);
	DDX_Check(pDX, IDC_CHECK3, m_DND);
	DDX_Check(pDX, IDC_CHECK4, m_AA);
	DDX_Check(pDX, IDC_CHECK5, m_Conference);
	DDX_Text(pDX, IDC_EDIT9, m_RecordFilePath);
	DDX_Text(pDX, IDC_EDIT10, m_RecordFileName);
	DDX_Text(pDX, IDC_EDIT11, m_PlayAudioFilePathName);
	DDX_Check(pDX, IDC_CHECK1, m_PCMU);
	DDX_Check(pDX, IDC_CHECK6, m_PCMA);
	DDX_Check(pDX, IDC_CHECK7, m_G729);
	DDX_Check(pDX, IDC_CHECK8, m_ILBC);
	DDX_Check(pDX, IDC_CHECK9, m_GSM);
	DDX_Check(pDX, IDC_CHECK10, m_AMR);
	DDX_Check(pDX, IDC_CHECK11, m_H263);
	DDX_Check(pDX, IDC_CHECK12, m_H2631998);
	DDX_Check(pDX, IDC_CHECK13, m_H264);
	DDX_Check(pDX, IDC_CHECK14, m_AEC);
	DDX_Check(pDX, IDC_CHECK16, m_AGC);
	DDX_Check(pDX, IDC_CHECK15, m_VAD);
	DDX_Check(pDX, IDC_CHECK17, m_CNG);
	DDX_Check(pDX, IDC_CHECK18, m_AudioStreamCallback);
	DDX_Text(pDX, IDC_EDIT3, m_ForwardTo);
	DDX_Check(pDX, IDC_CHECK20, m_ForwardCallForBusy);
	DDX_Text(pDX, IDC_EDIT2, m_LocalSIPPort);
	DDV_MinMaxInt(pDX, m_LocalSIPPort, 1, 65535);
	DDX_Control(pDX, IDC_CMB_SRTP_MODE, m_cmbSRTPMode);
	DDX_Control(pDX, IDC_CMB_VIDEO_RESOLUTION2, m_cmbVideoResolution);
	DDX_Control(pDX, IDC_SLIDER_VIDEO_QUALITY, m_sliderVideoQuality);
	DDX_Check(pDX, IDC_CHK_CODEC_G722, m_G722);
	DDX_Check(pDX, IDC_CHK_CODEC_SPEEX, m_SPEEX);
	DDX_Check(pDX, IDC_CHK_CODEC_AMRWB, m_AMR_WB);
	DDX_Check(pDX, IDC_CHK_CODEC_SPEEXWB, m_SPEEX_WB);
	DDX_Check(pDX, IDC_CHK_CODEC_G7221, m_G7221);
	DDX_Control(pDX, IDC_STATIC_LOCALVIDEO, m_LocalVideo);
	DDX_Control(pDX, IDC_STATIC_REMOTEVIDEO, m_RemoteVideo);
	DDX_Check(pDX, IDC_CHECK19, m_VP8);
	DDX_Check(pDX, IDC_CHECK21, m_Prack);
	DDX_Check(pDX, IDC_CHECK25, m_ANS);
	DDX_Check(pDX, IDC_CHECK22, m_MakeVideoCall);
	DDX_Check(pDX, IDC_CHECK23, m_AnswerVideoCall);
	DDX_Check(pDX, IDC_CHECK26, m_VP9);
}

BEGIN_MESSAGE_MAP(CP2PSampleDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_MESSAGE(WM_SIPEVENT, OnSIPCallbackEvent)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BUTTON19, &CP2PSampleDlg::OnBnClickedButton19)
	ON_BN_CLICKED(IDC_BUTTON20, &CP2PSampleDlg::OnBnClickedButton20)
	ON_CBN_SELCHANGE(IDC_COMBO_LINELIST, &CP2PSampleDlg::OnCbnSelchangeComboLinelist)
	ON_BN_CLICKED(IDC_BUTTON1, &CP2PSampleDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CP2PSampleDlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON3, &CP2PSampleDlg::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON4, &CP2PSampleDlg::OnBnClickedButton4)
	ON_BN_CLICKED(IDC_BUTTON5, &CP2PSampleDlg::OnBnClickedButton5)
	ON_BN_CLICKED(IDC_BUTTON6, &CP2PSampleDlg::OnBnClickedButton6)
	ON_BN_CLICKED(IDC_BUTTON7, &CP2PSampleDlg::OnBnClickedButton7)
	ON_BN_CLICKED(IDC_BUTTON8, &CP2PSampleDlg::OnBnClickedButton8)
	ON_BN_CLICKED(IDC_BUTTON9, &CP2PSampleDlg::OnBnClickedButton9)
	ON_BN_CLICKED(IDC_BUTTON10, &CP2PSampleDlg::OnBnClickedButton10)
	ON_BN_CLICKED(IDC_BUTTON11, &CP2PSampleDlg::OnBnClickedButton11)
	ON_BN_CLICKED(IDC_BUTTON12, &CP2PSampleDlg::OnBnClickedButton12)
	ON_BN_CLICKED(IDC_BUTTON13, &CP2PSampleDlg::OnBnClickedButton13)
	ON_BN_CLICKED(IDC_BUTTON14, &CP2PSampleDlg::OnBnClickedButton14)
	ON_BN_CLICKED(IDC_BUTTON15, &CP2PSampleDlg::OnBnClickedButton15)
	ON_BN_CLICKED(IDC_BUTTON16, &CP2PSampleDlg::OnBnClickedButton16)
	ON_BN_CLICKED(IDC_BUTTON36, &CP2PSampleDlg::OnBnClickedButton36)
	ON_BN_CLICKED(IDC_BUTTON17, &CP2PSampleDlg::OnBnClickedButton17)
	ON_BN_CLICKED(IDC_BUTTON18, &CP2PSampleDlg::OnBnClickedButton18)
	ON_BN_CLICKED(IDC_CHECK5, &CP2PSampleDlg::OnBnClickedCheck5)
	ON_WM_HSCROLL()
	ON_BN_CLICKED(IDC_BUTTON21, &CP2PSampleDlg::OnBnClickedButton21)
	ON_BN_CLICKED(IDC_BUTTON25, &CP2PSampleDlg::OnBnClickedButton25)
	ON_BN_CLICKED(IDC_BUTTON27, &CP2PSampleDlg::OnBnClickedButton27)
	ON_BN_CLICKED(IDC_BUTTON26, &CP2PSampleDlg::OnBnClickedButton26)
	ON_BN_CLICKED(IDC_BUTTON35, &CP2PSampleDlg::OnBnClickedButton35)
	ON_BN_CLICKED(IDC_CHECK1, &CP2PSampleDlg::OnBnClickedCheck1)
	ON_BN_CLICKED(IDC_CHECK6, &CP2PSampleDlg::OnBnClickedCheck6)
	ON_BN_CLICKED(IDC_CHECK7, &CP2PSampleDlg::OnBnClickedCheck7)
	ON_BN_CLICKED(IDC_CHECK8, &CP2PSampleDlg::OnBnClickedCheck8)
	ON_BN_CLICKED(IDC_CHECK9, &CP2PSampleDlg::OnBnClickedCheck9)
	ON_BN_CLICKED(IDC_CHECK10, &CP2PSampleDlg::OnBnClickedCheck10)
	ON_BN_CLICKED(IDC_CHECK11, &CP2PSampleDlg::OnBnClickedCheck11)
	ON_BN_CLICKED(IDC_CHECK12, &CP2PSampleDlg::OnBnClickedCheck12)
	ON_BN_CLICKED(IDC_CHECK13, &CP2PSampleDlg::OnBnClickedCheck13)
	ON_BN_CLICKED(IDC_CHECK14, &CP2PSampleDlg::OnBnClickedCheck14)
	ON_BN_CLICKED(IDC_BUTTON40, &CP2PSampleDlg::OnBnClickedButton40)
	ON_BN_CLICKED(IDC_BUTTON38, &CP2PSampleDlg::OnBnClickedButton38)
	ON_BN_CLICKED(IDC_BUTTON39, &CP2PSampleDlg::OnBnClickedButton39)
	ON_BN_CLICKED(IDC_BUTTON42, &CP2PSampleDlg::OnBnClickedButton42)
	ON_BN_CLICKED(IDC_BUTTON41, &CP2PSampleDlg::OnBnClickedButton41)
	ON_BN_CLICKED(IDC_BUTTON43, &CP2PSampleDlg::OnBnClickedButton43)
	ON_WM_CLOSE()
	ON_BN_CLICKED(IDC_BUTTON22, &CP2PSampleDlg::OnBnClickedButton22)
	ON_CBN_SELCHANGE(IDC_COMBO_SPEAKERS, &CP2PSampleDlg::OnCbnSelchangeComboSpeakers)
	ON_CBN_SELCHANGE(IDC_COMBO_MICROPHONES, &CP2PSampleDlg::OnCbnSelchangeComboMicrophones)
	ON_CBN_SELCHANGE(IDC_COMBO_CAMERAS, &CP2PSampleDlg::OnCbnSelchangeComboCameras)
	ON_BN_CLICKED(IDC_CHECK16, &CP2PSampleDlg::OnBnClickedCheck16)
	ON_BN_CLICKED(IDC_CHECK15, &CP2PSampleDlg::OnBnClickedCheck15)
	ON_BN_CLICKED(IDC_CHECK17, &CP2PSampleDlg::OnBnClickedCheck17)
	ON_BN_CLICKED(IDC_CHECK18, &CP2PSampleDlg::OnBnClickedCheck18)
	ON_BN_CLICKED(IDC_CHECK_MICROPHONEMUTE, &CP2PSampleDlg::OnBnClickedCheckMicrophonemute)
	ON_BN_CLICKED(IDC_BUTTON30, &CP2PSampleDlg::OnBnClickedButton30)
	ON_BN_CLICKED(IDC_BUTTON31, &CP2PSampleDlg::OnBnClickedButton31)
	ON_BN_CLICKED(IDC_CHK_CODEC_G722, &CP2PSampleDlg::OnBnClickedChkCodecG722)
	ON_BN_CLICKED(IDC_CHK_CODEC_SPEEX, &CP2PSampleDlg::OnBnClickedChkCodecSpeex)
	ON_BN_CLICKED(IDC_CHK_CODEC_AMRWB, &CP2PSampleDlg::OnBnClickedChkCodecAmrwb)
	ON_BN_CLICKED(IDC_CHK_CODEC_SPEEXWB, &CP2PSampleDlg::OnBnClickedChkCodecSpeexwb)
	ON_BN_CLICKED(IDC_CHK_CODEC_G7221, &CP2PSampleDlg::OnBnClickedChkCodecG7221)
	ON_CBN_SELCHANGE(IDC_CMB_SRTP_MODE, &CP2PSampleDlg::OnCbnSelchangeCmbSrtpMode)
	ON_CBN_SELCHANGE(IDC_CMB_VIDEO_RESOLUTION2, &CP2PSampleDlg::OnCbnSelchangeCmbVideoResolution2)
	ON_BN_CLICKED(IDC_CHECK19, &CP2PSampleDlg::OnBnClickedCheck19)
	ON_BN_CLICKED(IDC_CHECK21, &CP2PSampleDlg::OnBnClickedCheck21)
	ON_BN_CLICKED(IDC_CHECK25, &CP2PSampleDlg::OnBnClickedCheck25)
	ON_BN_CLICKED(IDC_CHECK3, &CP2PSampleDlg::OnBnClickedCheck3)
	ON_BN_CLICKED(IDC_CHK_CODEC_OPUS, &CP2PSampleDlg::OnBnClickedChkCodecOpus)
END_MESSAGE_MAP()


// CP2PSampleDlg message handlers


void CP2PSampleDlg::onMessage(void * parameters)
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

BOOL CP2PSampleDlg::OnInitDialog()
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

	time_t t;
	srand((unsigned int)time(&t));

	UpdateData(FALSE);


	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CP2PSampleDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CP2PSampleDlg::OnPaint()
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
HCURSOR CP2PSampleDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


BOOL CP2PSampleDlg::PreTranslateMessage(MSG* pMsg)
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


int CP2PSampleDlg::findSession(long sessionId)
{
	int index = -1;
	for (int i=LINE_BASE; i<MAX_LINES; ++i)
	{
		if (sessionId == m_SessionArray[i].getSessionId())
		{
			index = i;
			break;
		}
	}

	return index;
}

bool CP2PSampleDlg::loadDevices()
{
	int nums = PortSIP_getNumOfPlayoutDevices(m_SIPLib);

	char deviceName[1024] = { 0 };

	for (int i=0; i<nums; ++i)
	{
		PortSIP_getPlayoutDeviceName(m_SIPLib, i, deviceName, 1024);
		m_SpeakersList.AddString(deviceName);
	}

	m_SpeakersList.SetCurSel(0);



	ZeroMemory(deviceName, 1024);
	nums = PortSIP_getNumOfRecordingDevices(m_SIPLib);
	for (int i=0; i<nums; ++i)
	{
		PortSIP_getRecordingDeviceName(m_SIPLib, i, deviceName, 1024);
		m_MicrophonesList.AddString(deviceName);
	}

	m_MicrophonesList.SetCurSel(0);



	char uniqueIdUTF8[1024];
	nums = PortSIP_getNumOfVideoCaptureDevices(m_SIPLib);
	for (int i=0; i<nums; ++i)
	{
		ZeroMemory(uniqueIdUTF8, 1024);
		ZeroMemory(deviceName, 1024);

		PortSIP_getVideoCaptureDeviceName(m_SIPLib, i, uniqueIdUTF8, 1024, deviceName, 1024);
		m_CamerasList.AddString(deviceName);
	}

	m_CamerasList.SetCurSel(0);

	m_SpeakerVolume.SetRange(0, 255);
	m_MicrophoneVolume.SetRange(0, 255);
	m_sliderVideoQuality.SetRange(100, 2000);
	m_sliderVideoQuality.SetPos(300);

	int audioVolume = PortSIP_getMicVolume(m_SIPLib);
	m_MicrophoneVolume.SetPos(audioVolume);

	audioVolume = PortSIP_getSpeakerVolume(m_SIPLib);
	m_SpeakerVolume.SetPos(audioVolume);


	m_LineList.AddString("Line - 1");
	m_LineList.AddString("Line - 2");
	m_LineList.AddString("Line - 3");
	m_LineList.AddString("Line - 4");
	m_LineList.AddString("Line - 5");
	m_LineList.AddString("Line - 6");
	m_LineList.AddString("Line - 7");
	m_LineList.AddString("Line - 8");

	m_LineList.SetCurSel(0);
	m_cmbSRTPMode.SetCurSel(0);
	m_cmbVideoResolution.SetCurSel(1);


	m_PCMU = TRUE;
	m_G729 = TRUE;
	m_G7221 = TRUE;

	m_H264 = TRUE;

	m_AEC = TRUE;

	m_LocalSIPPort = 5060;
	return true;
}




void CP2PSampleDlg::setSRTPType()
{
	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);

	SRTP_POLICY srtpPolicy = SRTP_POLICY_NONE;

	switch (m_cmbSRTPMode.GetCurSel())
	{
	case 0:
		srtpPolicy = SRTP_POLICY_NONE;
		break;
	case 1:
		srtpPolicy = SRTP_POLICY_PREFER;
		break;
	case 2:
		srtpPolicy = SRTP_POLICY_FORCE;
		break;
	}

	PortSIP_setSrtpPolicy(m_SIPLib, srtpPolicy, false);
}


void CP2PSampleDlg::setVideoResolution()
{
	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);

	int width, height;
	getVideoResolution(width, height);
	PortSIP_setVideoResolution(m_SIPLib, width, height);
}

void CP2PSampleDlg::setVideoQuality()
{
	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);
	PortSIP_setVideoBitrate(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), m_sliderVideoQuality.GetPos());
}


void CP2PSampleDlg::initDefaultAudioCodecs()
{
	if (m_SIPInitialized == false)
	{
		return;
	}

	PortSIP_clearAudioCodec(m_SIPLib);


	// Default we just used PCMU, PCMA, G.729

	PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_PCMU);
	PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_G729);
	PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_PCMA);


	// The DTMF MUST last added
	PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_DTMF);
}



void CP2PSampleDlg::initSettings()
{
	if (m_SIPInitialized == false)
	{
		return;
	}

	PortSIP_enableAEC(m_SIPLib, EC_DEFAULT); // Enable the AEC, if disable, PortSIP_enableAEC(m_SDKCore, false);
	PortSIP_enableCNG(m_SIPLib, true); // Enable the FEC, if disable, PortSIP_enableAEC(m_SDKCore, false);
	PortSIP_enableVAD(m_SIPLib, false); // Disable the VAD, if enable, PortSIP_enableVAD(m_SDKCore, true);
	PortSIP_enableAGC(m_SIPLib, AGC_DEFAULT);
	PortSIP_enableANS(m_SIPLib, NS_DEFAULT);

	updateDND();
	updatePrackSetting();

}

void CP2PSampleDlg::OnBnClickedButton19()
{
	// TODO: Add your control notification handler code here


#define SIPPORT_MIN	5000

	UpdateData(TRUE);

	if (m_SIPInitialized == true)
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

	if (m_LocalSIPPort<=0 || m_LocalSIPPort>65535)
	{
		::MessageBox(GetSafeHwnd(), "The local SIP port is out of range.", "Information", MB_ICONINFORMATION);	
		return;	
	}

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
		PortSIP_unInitialize(m_SIPLib);
		m_LogList.ResetContent();
		m_SIPLib = NULL;
		m_SIPInitialized = false;

		::MessageBox(GetSafeHwnd(), "Failed to get the local IP.", "Information", MB_ICONWARNING);
		return;
	}


	// For P2P call(PC call PC without SIP proxy server, just pass the user domain,
	// SIP proxy server, outbound proxy server, stun server as empty.

	TRANSPORT_TYPE transport = TRANSPORT_UDP;

	char logFilePath[] = "d:\\";
	int rt = 0;
	m_SIPLib = PortSIP_initialize(this,
		transport,
		localIp,
		m_LocalSIPPort,
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
	

	loadDevices();


	rt = PortSIP_setUser(m_SIPLib,
							(LPTSTR)(LPCTSTR)m_UserName,
							NULL, // No use display Name
							(LPTSTR)(LPCTSTR)m_UserName, // Authorization name, usually same as username
							(LPTSTR)(LPCTSTR)m_Password,
							NULL, // Don't use user domain
							NULL, // Don't use proxy server - because this is P2P call
							0,
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

		::MessageBox(GetSafeHwnd(), "PortSIP_setUser failure.", "Information", MB_ICONWARNING);	
		return;		
	}

	m_LogList.InsertString(m_LogList.GetCount(), "Set user succeeded.");


	PortSIP_setLocalVideoWindow(m_SIPLib, m_LocalVideo.GetSafeHwnd());

	setSRTPType();
	setVideoResolution();
	setVideoQuality();

	updateAudioCodecs();
	updateVideoCodecs();

	initSettings();

	m_LogList.InsertString(m_LogList.GetCount(), "Ready.");
}

void CP2PSampleDlg::OnBnClickedButton20()
{
	// TODO: Add your control notification handler code here

	SIPUnRegister();
}

void CP2PSampleDlg::OnCbnSelchangeComboLinelist()
{
	// TODO: Add your control notification handler code here

	UpdateData(TRUE);

	if (m_SIPInitialized == false)
	{
		m_LineList.SetCurSel(0);
		return;
	}

	if (m_ActiveLine == (m_LineList.GetCurSel() + LINE_BASE))
	{
		return;
	}

	if (m_Conference)
	{
		m_ActiveLine = m_LineList.GetCurSel() + LINE_BASE;

		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState()==true && m_SessionArray[m_ActiveLine].getHoldState()==false)
	{
		// Need to hold this line
		int rt = PortSIP_hold(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId());
		PortSIP_setRemoteVideoWindow(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), NULL);
		m_SessionArray[m_ActiveLine].setHoldState(true);

		stringstream log;
		log << "Hold call on line " << m_ActiveLine << "";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());

	}


	m_ActiveLine = m_LineList.GetCurSel() + LINE_BASE;

	if (m_SessionArray[m_ActiveLine].getSessionState()==true && m_SessionArray[m_ActiveLine].getHoldState()==true)
	{
		// Need to unhold this line
		int rt = PortSIP_unHold(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId());
		PortSIP_setRemoteVideoWindow(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), m_RemoteVideo.GetSafeHwnd());
		m_SessionArray[m_ActiveLine].setHoldState(false);

		stringstream log;
		log << "unHold call on line " << m_ActiveLine << "";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());

	}
}




void CP2PSampleDlg::SIPUnRegister()
{
	for (int i=LINE_BASE; i<MAX_LINES; ++i)
	{
		if (m_SessionArray[i].getRecvCallState() == true)
		{
			PortSIP_rejectCall(m_SIPLib, m_SessionArray[i].getSessionId(), 486);
		}
		else if (m_SessionArray[i].getSessionState() == true)
		{
			PortSIP_hangUp(m_SIPLib, m_SessionArray[i].getSessionId());
		}

		m_SessionArray[i].reset();
	}


	if (m_SIPInitialized == true)
	{
		PortSIP_removeUser(m_SIPLib);
		PortSIP_unInitialize(m_SIPLib);
		m_SIPLib = NULL;
	}
	m_SIPInitialized = false;
	m_LogList.ResetContent();
	m_SpeakersList.ResetContent();
	m_MicrophonesList.ResetContent();
	m_CamerasList.ResetContent();
}


void CP2PSampleDlg::updatePrackSetting()
{
	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);

	if (m_Prack)
	{
		PortSIP_enableReliableProvisional(m_SIPLib, true);
	}
	else
	{
		PortSIP_enableReliableProvisional(m_SIPLib, false);
	}
}

void CP2PSampleDlg::getVideoResolution(int& width, int& height)
{
	//QCIF;CIF;VGA;SVGA;XVGA;720P;QVGA;
	switch (m_cmbVideoResolution.GetCurSel())
	{
	case 0://qcif
		width = 176;
		height = 144;
		break;
	case 1://cif
		width = 352;
		height = 288;
		break;
	case 2://VGA
		width = 640;
		height = 480;
		break;
	case 3://svga
		width = 800;
		height = 600;
		break;
	case 4://xvga
		width = 1024;
		height = 768;
		break;
	case 5://q720
		width = 1280;
		height = 720;
		break;
	case 6://QVGA
		width = 320;
		height = 240;
		break;
	default:
		width = 352;
		height = 288;
	}
}


void CP2PSampleDlg::updateDND()
{
	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);

	if (m_DND)
	{
		PortSIP_setDoNotDisturb(m_SIPLib, true);
	}
	else
	{
		PortSIP_setDoNotDisturb(m_SIPLib, false);
	}
}




void CP2PSampleDlg::addPhoneNumber(string number)
{
	CString Text;
	GetDlgItem(IDC_EDIT_PHONENUMBER)->GetWindowText(Text);
	Text += number.c_str();

	GetDlgItem(IDC_EDIT_PHONENUMBER)->SetWindowText(Text);
}




void CP2PSampleDlg::OnBnClickedButton1()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("1");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 1, 160, true);
	}	
}


void CP2PSampleDlg::OnBnClickedButton2()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("2");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 2, 160, true);
	}	
}

void CP2PSampleDlg::OnBnClickedButton3()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("3");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 3, 160, true);
	}	
}

void CP2PSampleDlg::OnBnClickedButton4()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("4");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 4, 160, true);
	}	
}

void CP2PSampleDlg::OnBnClickedButton5()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("5");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 5, 160, true);
	}	
}

void CP2PSampleDlg::OnBnClickedButton6()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("6");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 6, 160, true);
	}	
}

void CP2PSampleDlg::OnBnClickedButton7()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("7");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 7, 160, true);
	}	
}

void CP2PSampleDlg::OnBnClickedButton8()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("8");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 8, 160, true);
	}	
}

void CP2PSampleDlg::OnBnClickedButton9()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("9");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 9, 160, true);
	}	
}

void CP2PSampleDlg::OnBnClickedButton10()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("*");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 10, 160, true);
	}	
}

void CP2PSampleDlg::OnBnClickedButton11()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("0");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 0, 160, true);
	}	
}


void CP2PSampleDlg::OnBnClickedButton12()
{
	// TODO: Add your control notification handler code here

	addPhoneNumber("#");

	if (m_SIPInitialized == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_sendDtmf(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), DTMF_RFC2833, 11, 160, true);
	}	
}
void CP2PSampleDlg::OnBnClickedButton13()
{
	// TODO: Add your control notification handler code here

	UpdateData(TRUE);

	if (m_SIPInitialized == false)
	{
		return;
	}

	if (m_PhoneNumber.IsEmpty())
	{
		::MessageBox(GetSafeHwnd(), "The phone number is empty.", "Information", MB_ICONWARNING);	
		return;
	}

	if (m_SessionArray[m_ActiveLine].getSessionState()==true || m_SessionArray[m_ActiveLine].getRecvCallState()==true)
	{
		::MessageBox(GetSafeHwnd(), "Current line is busy, please switch a line", "Information", MB_ICONINFORMATION);
		return;
	}


	updateAudioCodecs();
	updateVideoCodecs();

	if (PortSIP_isAudioCodecEmpty(m_SIPLib) == true)
	{
		initDefaultAudioCodecs();
	}

	string to = (LPTSTR)(LPCTSTR)m_PhoneNumber;
	if (to.find("sip:")==string::npos || to.find("@")==string::npos)
	{
		::MessageBox(GetSafeHwnd(), "For make P2P call without SIP proxy server, the call phone number must likes: sip:12345@192.168.1.111:5060", "Information", MB_ICONINFORMATION);
		return;		
	}
	


	bool hasSDP = true;  // Usually to make the 3PCC, you need to make an invite without SDP
	if (m_CallSDP)
	{
		hasSDP = false;
	}

	PortSIP_setAudioDeviceId(m_SIPLib, m_SpeakersList.GetCurSel(), m_MicrophonesList.GetCurSel());


	// The callee MUST likes sip:number@sip.portsip.com
	int errorCode = 0;
	bool videlCall = false;
	if (m_MakeVideoCall)
	{
		videlCall = true;
	}
	long sessionId = PortSIP_call(m_SIPLib, to.c_str(), hasSDP, videlCall);
	if (sessionId <= 0)
	{
		::MessageBox(GetSafeHwnd(), "PortSIP_call failure.", "Information", MB_ICONINFORMATION);
		return;		
	}

	PortSIP_setRemoteVideoWindow(m_SIPLib, sessionId, m_RemoteVideo.GetSafeHwnd());

	m_SessionArray[m_ActiveLine].setSessionId(sessionId);
	m_SessionArray[m_ActiveLine].setSessionState(true);


	stringstream text;
	text << "Calling on line " << m_ActiveLine << "";

	m_LogList.InsertString(m_LogList.GetCount(), text.str().c_str());	
}

void CP2PSampleDlg::OnBnClickedButton14()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);

	if (m_SessionArray[m_ActiveLine].getSessionState() == true)
	{
		PortSIP_hangUp(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId());
		m_SessionArray[m_ActiveLine].reset();

		stringstream log;
		log << "Hang up call on line " << m_ActiveLine << "";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());	
	}
	else if (m_SessionArray[m_ActiveLine].getRecvCallState() == true)
	{
		PortSIP_rejectCall(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), 486);
		m_SessionArray[m_ActiveLine].reset();

		stringstream log;
		log << "Rejected call on line " << m_ActiveLine << "";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());	
	}
}

void CP2PSampleDlg::OnBnClickedButton15()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);

	if (m_SessionArray[m_ActiveLine].getRecvCallState() == true)
	{
		PortSIP_rejectCall(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), 486);
		m_SessionArray[m_ActiveLine].reset();

		stringstream log;
		log << "Rejected call on line " << m_ActiveLine << "";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());	
	}
}

void CP2PSampleDlg::OnBnClickedButton16()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);

	if (m_SessionArray[m_ActiveLine].getSessionState() == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getHoldState() == true)
	{
		return;
	}

	int rt = PortSIP_hold(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId());
	if (rt == 0 )
	{
		m_SessionArray[m_ActiveLine].setHoldState(true);

		stringstream log;
		log << "Hold the call on line " << m_ActiveLine << "";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
	}
	else
	{
		m_SessionArray[m_ActiveLine].setHoldState(false);

		stringstream log;
		log << "Hold the call on line " << m_ActiveLine << " failed.";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
	}


}

void CP2PSampleDlg::OnBnClickedButton36()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		return;
	}

	if (m_SessionArray[m_ActiveLine].getSessionState() == false)
	{
		return;
	}


	if (m_SessionArray[m_ActiveLine].getHoldState() == false)
	{
		return;
	}

	UpdateData(TRUE);

	int rt = PortSIP_unHold(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId());
	if (rt == 0)
	{
		m_SessionArray[m_ActiveLine].setHoldState(false);

		stringstream log;
		log << "UnHold the call on line " << m_ActiveLine << "";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
	}
	else
	{
		m_SessionArray[m_ActiveLine].setHoldState(false);

		stringstream log;
		log << "UnHold the call on line " << m_ActiveLine << " failed.";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
	}

}

void CP2PSampleDlg::OnBnClickedButton17()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);

	if (m_SessionArray[m_ActiveLine].getSessionState() == false)
	{
		::MessageBox(GetSafeHwnd(), "Need to make the call established first", "Information", MB_ICONINFORMATION);
		return;
	}

	CTransferDlg Dlg;
	if (Dlg.DoModal() == IDOK)
	{
		if (Dlg.getTransferNumber().IsEmpty())
		{
			::MessageBox(GetSafeHwnd(), "Transfer failed, transfer number is empty", "Information", MB_ICONINFORMATION);
			return;
		}
	}
	else
	{
		::MessageBox(GetSafeHwnd(), "Transfer failed, you have canceled the transfer", "Information", MB_ICONINFORMATION);
		return;
	}



	int rt = PortSIP_refer(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), (LPTSTR)(LPCTSTR)Dlg.getTransferNumber());
	if (rt != 0)
	{
		::MessageBox(GetSafeHwnd(), "PortSIP_refer failed", "Transfer", MB_ICONINFORMATION);
		return;
	}


	stringstream log;
	log << "Transfer the call on line " << m_ActiveLine << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}

void CP2PSampleDlg::OnBnClickedButton18()
{
	// TODO: Add your control notification handler code here


	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);

	if (m_SessionArray[m_ActiveLine].getRecvCallState() == false)
	{
		::MessageBox(GetSafeHwnd(), "Current line does not has incoming call, please switch a line.", "Information", MB_ICONINFORMATION);
		return;
	}

	m_SessionArray[m_ActiveLine].setSessionState(true);
	m_SessionArray[m_ActiveLine].setRecvCallState(false);

	PortSIP_setRemoteVideoWindow(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), m_RemoteVideo.GetSafeHwnd());

	bool answerVideoCall = false;
	if (m_AnswerVideoCall)
	{
		answerVideoCall = true;
	}
	int rt = PortSIP_answerCall(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), answerVideoCall);
	if (rt == 0)
	{
		stringstream log;
		log << "Answered the call on line " << m_ActiveLine << "";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());

		joinConference(m_ActiveLine);
	}
	else
	{
		m_SessionArray[m_ActiveLine].reset();

		stringstream log;
		log << "Answer call failed on line " << m_ActiveLine << "";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());	
	}
}


void CP2PSampleDlg::OnBnClickedCheck5()
{
	// TODO: Add your control notification handler code here


	UpdateData(TRUE);

	if (m_SIPInitialized == false)
	{
		m_Conference = FALSE;
		UpdateData(FALSE);

		::MessageBox(GetSafeHwnd(), "The SDK does not initialized.", "Information", MB_ICONWARNING);
		return;
	}

	if (m_Conference)
	{
		int width, height;
		getVideoResolution(width, height);

		int rt = PortSIP_createVideoConference(m_SIPLib, m_RemoteVideo.GetSafeHwnd(), width, height, false);
		if (rt != 0)
		{
			m_LogList.InsertString(m_LogList.GetCount(), "Conference failed");
			m_Conference = FALSE;
			UpdateData(FALSE);
		}
		else
		{
			m_LogList.InsertString(m_LogList.GetCount(), "Make conference succeeded");
			for (int i=LINE_BASE; i<MAX_LINES; ++i)
			{
				if (m_SessionArray[i].getHoldState() == true)
				{
					joinConference(i);
				}
			}
		}
	}
	else
	{
		// Must place all calls in HOLD after the conference is stopped.
		int sessionIds[MAX_LINES];
		for (int i=LINE_BASE; i<MAX_LINES; ++i)
		{
			sessionIds[i] = 0;
		}

		for (int i=LINE_BASE; i<MAX_LINES; ++i)
		{
			if (m_SessionArray[i].getSessionState()==true && m_SessionArray[i].getHoldState()==false)
			{
				// Hold the line 
				PortSIP_hold(m_SIPLib, m_SessionArray[i].getSessionId());

				m_SessionArray[i].setHoldState(true);
			}

			m_LogList.InsertString(m_LogList.GetCount(), "Taken off Conference");
		}

		PortSIP_destroyConference(m_SIPLib);
		m_ConferenceId = 0;
	}

}

void CP2PSampleDlg::OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar)
{
	// TODO: Add your message handler code here and/or call default

	if (m_SIPLib && m_SIPInitialized==true)
	{
		CSliderCtrl * sliderMicroPhone = (CSliderCtrl *)GetDlgItem(IDC_SLIDER_MICROPHONE);
		CSliderCtrl * sliderSpeaker = (CSliderCtrl *)GetDlgItem(IDC_SLIDER_SPEAKER);


		if (sliderMicroPhone == (CSliderCtrl *)pScrollBar)
		{
			PortSIP_setMicVolume(m_SIPLib, sliderMicroPhone->GetPos());
		}
		else if (sliderSpeaker == ((CSliderCtrl *)pScrollBar))
		{
			PortSIP_setSpeakerVolume(m_SIPLib, sliderSpeaker->GetPos());
		}
	}

	CSliderCtrl * sliderVideoQuality = (CSliderCtrl *)GetDlgItem(IDC_SLIDER_VIDEO_QUALITY);
	if(sliderVideoQuality == (CSliderCtrl *)pScrollBar)
	{
		setVideoQuality();
	}

	CDialog::OnHScroll(nSBCode, nPos, pScrollBar);
}



void CP2PSampleDlg::OnBnClickedButton21()
{
	// TODO: Add your control notification handler code here

	m_LogList.ResetContent();
}



void CP2PSampleDlg::OnBnClickedButton25()
{
	// TODO: Add your control notification handler code here

	char uniqueIdUTF8[1024] = { 0 };
	char deviceName[1024] = { 0 };

	PortSIP_getVideoCaptureDeviceName(m_SIPLib, m_CamerasList.GetCurSel(), uniqueIdUTF8, 1024, deviceName, 1024);
	PortSIP_showVideoCaptureSettingsDialogBox(m_SIPLib,
											  uniqueIdUTF8,
											  strlen(uniqueIdUTF8),
											  "Camera settings",
											  GetSafeHwnd(),
											  200,
											  200);
}

void CP2PSampleDlg::OnBnClickedButton27()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		return;
	}



	CString Text;

	GetDlgItem(IDC_BUTTON27)->GetWindowText(Text);

	if (Text == "Local Video")
	{
		PortSIP_displayLocalVideo(m_SIPLib, true, true);
		GetDlgItem(IDC_BUTTON27)->SetWindowText("Stop Local");
	}
	else 
	{
		PortSIP_displayLocalVideo(m_SIPLib, false, false);
		GetDlgItem(IDC_BUTTON27)->SetWindowText("Local Video");
	}
}

void CP2PSampleDlg::OnBnClickedButton26()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		return;
	}

	if (m_SessionArray[m_ActiveLine].getSessionState() == false && m_SessionArray[m_ActiveLine].getRecvCallState() == false)
	{
		return;
	}

	PortSIP_sendVideo(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), true);
}

void CP2PSampleDlg::OnBnClickedButton35()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		return;
	}

	if (m_SessionArray[m_ActiveLine].getSessionState() == false)
	{
		return;
	}


	PortSIP_sendVideo(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), false);

}




void CP2PSampleDlg::updateAudioCodecs()
{
	if (m_SIPInitialized == false)
	{
		return;
	}

	PortSIP_clearAudioCodec(m_SIPLib);


	UpdateData(TRUE);

	if (m_PCMU)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_PCMU);
	}

	if (m_PCMA)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_PCMA);
	}
	if (m_G729)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_G729);
	}
	if (m_ILBC)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_ILBC);
	}
	if (m_GSM)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_GSM);
	}
	if (m_AMR)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_AMR);
	}
	if (m_G722)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_G722);
	}
	if (m_SPEEX)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_SPEEX);
	}
	if (m_AMR_WB)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_AMRWB);
	}
	if (m_SPEEX_WB)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_SPEEXWB);
	}
	if (m_G7221)
	{
		PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_G7221);
	}


	PortSIP_addAudioCodec(m_SIPLib, AUDIOCODEC_DTMF);
}



void CP2PSampleDlg::updateVideoCodecs()
{
	if (m_SIPInitialized == false)
	{
		return;
	}

	PortSIP_clearVideoCodec(m_SIPLib);


	UpdateData(TRUE);

	if (m_H263)
	{
		PortSIP_addVideoCodec(m_SIPLib, VIDEO_CODEC_H263);
	}

	if (m_H2631998)
	{
		PortSIP_addVideoCodec(m_SIPLib, VIDEO_CODEC_H263_1998);
	}

	if (m_H264)
	{
		PortSIP_addVideoCodec(m_SIPLib, VIDEO_CODEC_H264);
	}

	if (m_VP8)
	{
		PortSIP_addVideoCodec(m_SIPLib, VIDEO_CODEC_VP8);
	}

	if (m_VP9)
	{
		PortSIP_addVideoCodec(m_SIPLib, VIDEO_CODEC_VP9);
	}
}



bool CP2PSampleDlg::joinConference(int index)
{
	if (m_SIPInitialized == false)
	{
		return false;
	}

	UpdateData(TRUE);
	if (!m_Conference)
	{
		return false;
	}

	int rt = PortSIP_joinToConference(m_SIPLib, m_SessionArray[index].getSessionId());

	// We need to unhold the line in conference
	if (m_SessionArray[index].getSessionState())
	{
		PortSIP_unHold(m_SIPLib, m_SessionArray[index].getSessionId());
		m_SessionArray[index].setHoldState(false);
	}

	return true;
}



void CP2PSampleDlg::OnBnClickedCheck1()
{
	// TODO: Add your control notification handler code here

	updateAudioCodecs();
}


void CP2PSampleDlg::OnBnClickedCheck6()
{
	// TODO: Add your control notification handler code here

	updateAudioCodecs();
}

void CP2PSampleDlg::OnBnClickedCheck7()
{
	// TODO: Add your control notification handler code here

	updateAudioCodecs();
}

void CP2PSampleDlg::OnBnClickedCheck8()
{
	// TODO: Add your control notification handler code here

	updateAudioCodecs();

}

void CP2PSampleDlg::OnBnClickedCheck9()
{
	// TODO: Add your control notification handler code here

	updateAudioCodecs();
}

void CP2PSampleDlg::OnBnClickedCheck10()
{
	// TODO: Add your control notification handler code here

	updateAudioCodecs();
}

void CP2PSampleDlg::OnBnClickedChkCodecG722()
{
	updateAudioCodecs();
}

void CP2PSampleDlg::OnBnClickedChkCodecSpeex()
{
	updateAudioCodecs();
}

void CP2PSampleDlg::OnBnClickedChkCodecAmrwb()
{
	updateAudioCodecs();
}

void CP2PSampleDlg::OnBnClickedChkCodecSpeexwb()
{
		updateAudioCodecs();
}

void CP2PSampleDlg::OnBnClickedChkCodecOpus()
{
	// TODO: Add your control notification handler code here

	updateAudioCodecs();
}




void CP2PSampleDlg::OnBnClickedChkCodecG7221()
{
	updateAudioCodecs();
}

void CP2PSampleDlg::OnBnClickedCheck11()
{
	// TODO: Add your control notification handler code here

	updateVideoCodecs();
}

void CP2PSampleDlg::OnBnClickedCheck12()
{
	// TODO: Add your control notification handler code here

	updateVideoCodecs();
}

void CP2PSampleDlg::OnBnClickedCheck13()
{
	// TODO: Add your control notification handler code here

	updateVideoCodecs();
}

void CP2PSampleDlg::OnBnClickedCheck19()
{
	// TODO: Add your control notification handler code here

	updateVideoCodecs();
}


void CP2PSampleDlg::OnBnClickedCheck14()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}

	UpdateData(TRUE);

	if (m_AEC)
	{
		PortSIP_enableAEC(m_SIPLib, EC_DEFAULT);
	}
	else
	{
		PortSIP_enableAEC(m_SIPLib, EC_NONE);
	}	
}

void CP2PSampleDlg::OnBnClickedButton40()
{
	// TODO: Add your control notification handler code here

	char szPath[MAX_PATH];
	BROWSEINFO br;
	ITEMIDLIST *pItem;
	br.hwndOwner = this->GetSafeHwnd();
	br.iImage = 0;
	br.pszDisplayName = 0;
	br.lParam = 0;
	br.lpfn = 0;
	br.lpszTitle = "Please select a folder:";
	br.pidlRoot = 0;
	br.ulFlags = BIF_RETURNONLYFSDIRS;
	pItem = SHBrowseForFolder(&br);

	if (SHGetPathFromIDList(pItem, szPath))
	{
		m_RecordFilePath = szPath;
		UpdateData(FALSE);
	}
}



void CP2PSampleDlg::OnBnClickedButton38()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}


	UpdateData(TRUE);
	if (m_RecordFilePath.IsEmpty() || m_RecordFileName.IsEmpty())
	{
		::MessageBox(GetSafeHwnd(), "The file path or file name is empty.", "Information", MB_ICONINFORMATION);
		return;
	}

	AUDIO_FILE_FORMAT fileFormat = FILEFORMAT_WAVE;

	// Start recording
	if (PortSIP_startRecord(m_SIPLib, 
						m_SessionArray[m_ActiveLine].getSessionId(),
						(LPTSTR)(LPCTSTR)m_RecordFilePath, 
						(LPTSTR)(LPCTSTR)m_RecordFileName, 
						true, 
						fileFormat, 
						RECORD_BOTH,
						VIDEO_CODEC_H264,
						RECORD_RECV) != 0)
	{
		::MessageBox(GetSafeHwnd(), "Failed to start record conversation.", "Information", MB_ICONINFORMATION);
		return;
	}

	::MessageBox(GetSafeHwnd(), "Start record conversation.", "Information", MB_ICONINFORMATION);

}

void CP2PSampleDlg::OnBnClickedButton39()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}


	PortSIP_stopRecord(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId());

	::MessageBox(GetSafeHwnd(), "Stop record conversation.", "Information", MB_ICONINFORMATION);
}

void CP2PSampleDlg::OnBnClickedButton42()
{
	// TODO: Add your control notification handler code here

	string playFilePath = "c:\\";

	CString Filter("WAV Files (*.wav)|*.wav||");
	CFileDialog FileDlg(TRUE, NULL, NULL, NULL, Filter);	


	FileDlg.m_ofn.lpstrInitialDir = playFilePath.c_str();

	if (FileDlg.DoModal() == IDOK)
	{
		m_PlayAudioFilePathName = FileDlg.GetPathName();
		UpdateData(FALSE);
	}
}

void CP2PSampleDlg::OnBnClickedButton41()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}

	UpdateData(TRUE);
	PortSIP_playAudioFileToRemote(m_SIPLib, 
									m_SessionArray[m_ActiveLine].getSessionId(),
									(LPTSTR)(LPCTSTR)m_PlayAudioFilePathName, 
									16000,
									false);
}

void CP2PSampleDlg::OnBnClickedButton43()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}

	PortSIP_stopPlayAudioFileToRemote(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId());
}




void CP2PSampleDlg::OnBnClickedButton22()
{
	// TODO: Add your control notification handler code here


	if (m_SIPInitialized == false)
	{
		return;
	}

	UpdateData(TRUE);

	if (m_SessionArray[m_ActiveLine].getSessionState() == false)
	{
		::MessageBox(GetSafeHwnd(), "Need to make the call established first", "Information", MB_ICONINFORMATION);
		return;
	}

	CTransferDlg Dlg;
	int replaceLine = 0;

	if (Dlg.DoModal() == IDOK)
	{
		if (Dlg.getTransferNumber().IsEmpty())
		{
			::MessageBox(GetSafeHwnd(), "Transfer failed, transfer number is empty", "Information", MB_ICONINFORMATION);
			return;
		}

		replaceLine = Dlg.GetReplaceLine();
		if (replaceLine<=0 || replaceLine>=MAX_LINES)
		{
			::MessageBox(GetSafeHwnd(), "The replace line out of range", "Information", MB_ICONINFORMATION);
			return;
		}

		if (m_SessionArray[replaceLine].getSessionState() == false)
		{
			::MessageBox(GetSafeHwnd(), "The replace line does not established yet", "Information", MB_ICONINFORMATION);
			return;
		}
	}
	else
	{
		::MessageBox(GetSafeHwnd(), "Transfer failed, you have canceled the transfer", "Information", MB_ICONINFORMATION);
		return;
	}


	int rt = PortSIP_attendedRefer(m_SIPLib, m_SessionArray[m_ActiveLine].getSessionId(), m_SessionArray[replaceLine].getSessionId(), (LPTSTR)(LPCTSTR)Dlg.getTransferNumber());
	if (rt != 0)
	{
		::MessageBox(GetSafeHwnd(), "PortSIP_attendedRefer failed", "Transfer", MB_ICONINFORMATION);
		return;
	}


	stringstream log;
	log << "Attended refer on line " << m_ActiveLine << "";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}




LRESULT CP2PSampleDlg::OnSIPCallbackEvent(WPARAM WParam, LPARAM LParam)
{
	ICallbackParameters * parameter = (ICallbackParameters *)WParam;

	switch(parameter->getEventType())
	{
	case SIP_UNKNOWN:
		break;

		// For P2P mode, no register required.
	case SIP_REGISTER_SUCCESS:
		{
			
		}
		break;

	case SIP_REGISTER_FAILURE:
		{

		}
		break;

	case SIP_INVITE_INCOMING:
		onSIPCallIncoming(parameter);
		break;

	case SIP_INVITE_TRYING:
		onSIPCallTrying(parameter);
		break;

	case SIP_INVITE_SESSION_PROGRESS:
		onSIPCallSessionProgress(parameter);
		break;

	case SIP_INVITE_RINGING:
		onSIPCallRinging(parameter);
		break;

	case SIP_INVITE_ANSWERED:
		onSIPCallAnswered(parameter);
		break;

	case SIP_INVITE_FAILURE:
		onSIPCallFailure(parameter);
		break;

	case SIP_INVITE_UPDATED:
		onSIPInviteUpdated(parameter);
		break;


	case SIP_INVITE_CONNECTED:
		onSIPInviteConnected(parameter);
		break;

	case SIP_INVITE_BEGINING_FORWARD:
		onSIPCallForwarding(parameter);
		break;

	case SIP_INVITE_CLOSED:
		onSIPCallClosed(parameter);
		break;


	case SIP_REMOTE_HOLD:
		onSIPCallRemoteHold(parameter);
		break;

	case SIP_REMOTE_UNHOLD:
		onSIPCallRemoteUnhold(parameter);
		break;

	case SIP_RECEIVED_REFER:
		onSIPReceivedRefer(parameter);
		break;


	case SIP_REFER_ACCEPTED:
		onSIPReferAccepted(parameter);
		break;


	case SIP_REFER_REJECTED:
		onSIPReferRejected(parameter);
		break;


	case SIP_TRANSFER_TRYING:
		onSIPTransferTrying(parameter);
		break;


	case SIP_TRANSFER_RINGING:
		onSIPTransferRinging(parameter);
		break;

	case SIP_ACTV_TRANSFER_SUCCESS:
		onSIPACTVTransferSuccess(parameter);
		break;

	case SIP_ACTV_TRANSFER_FAILURE:
		onSIPACTVTrasferFailure(parameter);
		break;

	case SIP_RECEIVED_SIGNALING:
		{
			const char* data = parameter->getSignaling();
		}
		break;

	case SIP_SENDING_SIGNALING:
		{
			const char* data = parameter->getSignaling();
		}
		break;



	case SIP_WAITING_VOICEMESSAGE:
		{
			const char* messageAcount = parameter->getWaitingMessageAccount();
			int urgentNewMessageCount = parameter->getUrgentNewWaitingMessageCount();
			int urgentOldMessageCount = parameter->getUrgentOldWaitingMessageCount();
			int newMessageCount = parameter->getNewWaitingMessageCount();
			int oldMessageCount = parameter->getOldWaitingMessageCount();

			CString Text = "Has voice messages, message account: ";
			Text += messageAcount;
			Text += "";

			m_LogList.InsertString(m_LogList.GetCount(), Text);
		}
		break;


	case SIP_WAITING_FAXMESSAGE:
		{
			const char* messageAcount = parameter->getWaitingMessageAccount();
			int urgentNewFaxCount = parameter->getUrgentNewWaitingMessageCount();
			int urgentOldFaxCount = parameter->getUrgentOldWaitingMessageCount();
			int newFaxCount = parameter->getNewWaitingMessageCount();
			int oldFaxCount = parameter->getOldWaitingMessageCount();

			CString Text = "Has FAX messages, message account: ";
			Text += messageAcount;
			Text += "";

			m_LogList.InsertString(m_LogList.GetCount(), Text);
		}


	case SIP_RECV_DTMFTONE:
		onSIPReceivedDtmfTone(parameter);
		break;

	case SIP_PRESENCE_RECV_SUBSCRIBE:

	case SIP_PRESENCE_ONLINE:
		break;


	case SIP_PRESENCE_OFFLINE:
		break;


	case SIP_RECV_OPTIONS:
		onSIPRecvOptions(parameter);
		break;

	case SIP_RECV_INFO:
		onSIPRecvInfo(parameter);
		break;

	case SIP_RECV_NOTIFY_OF_SUBSCRIPTION:
		onSIPRecvNotifyOfSubscription(parameter);

		break;

	case SIP_SUBSCRIPTION_TERMINATED:

		onSIPSubscriptionTerminated(parameter);
		break;

	case SIP_SUBSCRIPTION_FAILURE:
		onSIPSubscriptionFailure(parameter);
		break;


	case SIP_RECV_MESSAGE:
		onSIPRecvMesage(parameter);
		break;

	case SIP_RECV_OUTOFDIALOG_MESSAGE:
		onSIPRecvOutOfDialogMessage(parameter);
		break;

	case SIP_SEND_MESSAGE_SUCCESS:
		onSIPSendMessageSuccess(parameter);
		break;


	case SIP_SEND_MESSAGE_FAILURE:
		onSIPSendMessageFailure(parameter);
		break;

	case SIP_SEND_OUTOFDIALOG_MESSAGE_SUCCESS:
		onSIPSendOutOfDialogMessageSuccess(parameter);
		break;


	case SIP_SEND_OUTOFDIALOG_MESSAGE_FAILURE:
		onSIPSendOutOfDialogMessageFailure(parameter);
		break;

	case SIP_PLAY_AUDIO_FILE_FINISHED:

		break;


	case SIP_PLAY_VIDEO_FILE_FINISHED:

		break;

	}

	PortSIP_delCallbackParameters(parameter);
	parameter = NULL;

	return S_OK;
}




void CP2PSampleDlg::onSIPCallIncoming(ICallbackParameters * parameters)
{
	UpdateData(TRUE);

	int index = -1;
	for (int i=LINE_BASE; i<MAX_LINES; ++i)
	{
		if (m_SessionArray[i].getSessionState()==false && m_SessionArray[i].getRecvCallState()==false)
		{
			m_SessionArray[i].setRecvCallState(true);
			index = i;
			break;
		}
	}

	if (index == -1)
	{
		PortSIP_rejectCall(m_SIPLib, parameters->getSessionId(), 486);
		return;
	}

	if (parameters->getExistsAudio())
	{
		// This incoming call has audio
		// If more than one codecs using, then they are separated with "#",
		// for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.

		const char* audioCodecs = parameters->getAudioCodecs();
	}


	// Checking does this call has video
	if (parameters->getExistsVideo() == true)
	{
		// This incoming call has video
		// If more than one codecs using, then they are separated with "#",
		// for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.

		const char* videoCodecs = parameters->getVideoCodecs();
	}

	// Search in all lines, ignore the auto answer if have a line is established.
	bool needIgnoreAutoAnswer = false;
	for (int i=LINE_BASE; i<MAX_LINES; ++i)
	{
		if (m_SessionArray[i].getSessionState() == true)
		{
			needIgnoreAutoAnswer = true; // Need to ignore the auto answer
			break;
		}
	}

	m_SessionArray[index].setSessionId(parameters->getSessionId());

	if (parameters->getExistsVideo() == true)
	{
		PortSIP_setRemoteVideoWindow(m_SIPLib, m_SessionArray[index].getSessionId(), m_RemoteVideo.GetSafeHwnd());
	}


	if (needIgnoreAutoAnswer==false && m_AA)
	{
		m_SessionArray[index].setSessionState(true);
		m_SessionArray[index].setRecvCallState(false);

		bool answerVideoCall = false;
		if (m_AnswerVideoCall)
		{
			answerVideoCall = true;
		}
		int rt = PortSIP_answerCall(m_SIPLib, parameters->getSessionId(), answerVideoCall);
		if (rt == 0)
		{
			stringstream log;
			log << "Answered the call on line " << index << " by Auto Answer";
			m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
		}
		else
		{
			m_SessionArray[index].reset();

			stringstream log;
			log << "Failed to answer call on line " << index << " by Auto Answer";
			m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());	
		}

		return;
	}


	const char* caller = parameters->getCaller();

	stringstream log;
	log << "Incoming call from " << caller << " on line " << index <<"";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPCallTrying(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream text;
	text << "Call is trying on line " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), text.str().c_str());	
}



void CP2PSampleDlg::onSIPCallSessionProgress(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	if (parameters->getExistsEarlyMedia())
	{
		// Checking does this call has video
		if (parameters->getExistsVideo())
		{
			// This incoming call has video
			// If more than one codecs using, then they are separated with "#",
			// for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
			const char* videoCodecs = parameters->getVideoCodecs();
		}

		if (parameters->getExistsAudio())
		{
			// If more than one codecs using, then they are separated with "#",
			// for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.

			const char* audioCodecs = parameters->getAudioCodecs();
		}
	}

	m_SessionArray[index].setExistEarlyMedia(parameters->getExistsEarlyMedia());

	stringstream log;
	log << "Call session progress on line  " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}

void CP2PSampleDlg::onSIPCallRinging(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	if (!m_SessionArray[index].getExistEarlyMedia())
	{
		//No early media, you must play the local WAVE file for ringing tone
	}

	stringstream log;
	log << "Call ringing on line " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}



void CP2PSampleDlg::onSIPCallAnswered(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	// If more than one codecs using, then they are separated with "#",
	// for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
	// Checking does this call has video
	if (parameters->getExistsVideo())
	{
		const char* videoCodecs = parameters->getVideoCodecs();
	}

	if (parameters->getExistsAudio())
	{
		// Audio codecs name
		const char* audioCodecs = parameters->getAudioCodecs();
	}

	m_SessionArray[index].setSessionState(true);

	stringstream log;
	log << "Call Established on line " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());

	// If this is the refer call then need set it to normal
	if (m_SessionArray[index].isReferCall())
	{
		m_SessionArray[index].setReferCall(false, 0);
	}

	joinConference(index);
}


void CP2PSampleDlg::onSIPCallFailure(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	int statusCode = parameters->getStatusCode();
	const char* statusText = parameters->getStatusText();

	stringstream log;
	log << "Failed to call on line " << index << ": " << statusText << " " << statusCode << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());

	if (m_SessionArray[index].isReferCall())
	{
		// Take off the origin call from HOLD if the refer call is failure
		long originIndex = -1;
		for (int i=LINE_BASE; i<MAX_LINES; ++i)
		{
			// Looking for the origin call
			if (m_SessionArray[i].getSessionId() == m_SessionArray[index].getOriginCallSessionId())
			{
				originIndex = i;
				break;
			}
		}

		if (originIndex != -1)
		{
			stringstream log;
			log << "Call failure on line " << index << ": " << statusText << " " << statusCode << "";
			m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());

			// Now take off the origin call
			PortSIP_unHold(m_SIPLib, m_SessionArray[index].getOriginCallSessionId());
			m_SessionArray[originIndex].setHoldState(false);

			// Switch the currently line to origin call line
			m_ActiveLine = originIndex;
			m_LineList.SetCurSel(m_ActiveLine-1);

			log.str("");
			log << "Current line is: " << m_ActiveLine;
			m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
		}
	}

	m_SessionArray[index].reset();
}


void CP2PSampleDlg::onSIPInviteUpdated(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	// Checking does this call has video
	if (parameters->getExistsVideo())
	{
		const char* videoCodecs = parameters->getVideoCodecs();
	}
	if (parameters->getExistsAudio())
	{
		const char* audioCodecs = parameters->getAudioCodecs();
	}

	stringstream log;
	log << "The call has been updated on line " << index << "";

	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPInviteConnected(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}
	stringstream log;
	log << "The call is connected on line " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPCallForwarding(ICallbackParameters * parameters)
{
	const char* forwardTo = parameters->getForwardTo();

	stringstream text;
	text << "Call has been forward to: " << forwardTo;
	m_LogList.InsertString(m_LogList.GetCount(), text.str().c_str());	
}



void CP2PSampleDlg::onSIPCallClosed(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	log << "Call closed by remote on line " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
	m_SessionArray[index].reset();
}



void CP2PSampleDlg::onSIPCallRemoteHold(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	log << "Placed on hold by remote on line " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPCallRemoteUnhold(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	log << "Take off hold by remote on line " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPReceivedRefer(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		PortSIP_rejectRefer(m_SIPLib, parameters->getReferId());
		return;
	}

	const char* referTo = parameters->getReferTo();
	const char* signaling = parameters->getSignaling();

	stringstream log;
	log << "Received the refer on line " << index << ", refer to " << referTo;
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());

	// Accept the REFER automatically
	long referSessionId = PortSIP_acceptRefer(m_SIPLib, parameters->getReferId(), signaling);
	if (referSessionId <= 0)
	{
		log.str("");
		log << "Failed to accept the refer.";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
	}
	else
	{
		PortSIP_hangUp(m_SIPLib, m_SessionArray[index].getSessionId());
		m_SessionArray[index].reset();


		m_SessionArray[index].setSessionId(referSessionId);
		m_SessionArray[index].setSessionState(true);

		log.str("");
		log << "Accepted the refer";
		m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
	}
}


void CP2PSampleDlg::onSIPReferAccepted(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	log << "Line " << index << ", the REFER was accepted.";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPReferRejected(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	log << "LINE " << index << ", the REFER was rejected.";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}



void CP2PSampleDlg::onSIPTransferTrying(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	const char* referTo = parameters->getForwardTo();

	stringstream log;
	log << "Transfer trying on line " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPTransferRinging(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	log << "Transfer ringing on line " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPACTVTransferSuccess(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	PortSIP_hangUp(m_SIPLib, m_SessionArray[index].getSessionId());
	m_SessionArray[index].reset();

	stringstream log;
	log << "Transfer succeeded on line "<< index << ", close the call";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}




void CP2PSampleDlg::onSIPACTVTrasferFailure(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	log << "Failed to transfer on line " << index << "";
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());

	const char* reason = parameters->getStatusText();// error reason
	int code = parameters->getStatusCode(); // error code

}



void CP2PSampleDlg::onSIPReceivedDtmfTone(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	int tone = parameters->getDTMFTone();

	log << "Received DTMF tone: ";
	if (tone == 10)
	{
		log << "*";
	}
	else if (tone == 11)
	{
		log << "#";
	}
	else if (tone == 12)
	{
		log << "A";
	}
	else if (tone == 13)
	{
		log << "B";
	}
	else if (tone == 14)
	{
		log << "C";
	}
	else if (tone == 15)
	{
		log << "D";
	}
	else if (tone == 16)
	{
		log << "FLASH";
	}
	else 
	{
		log << tone;
	}

	log << " on line " << index;
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());

}



void CP2PSampleDlg::onSIPRecvOptions(ICallbackParameters * parameters)
{
	const char* data = parameters->getSignaling();

	stringstream Text;
	Text << "Received an OPTIONS message: ";
	Text << data;
}

void CP2PSampleDlg::onSIPRecvInfo(ICallbackParameters * parameters)
{	
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	const char* data = parameters->getSignaling();

	stringstream Text;
	Text << "Received a INFO message on line " << index << ": ";
	Text << data;

	::MessageBoxA(GetSafeHwnd(), Text.str().c_str(), "Received a INFO message", MB_ICONINFORMATION);
}


void CP2PSampleDlg::onSIPRecvNotifyOfSubscription(ICallbackParameters * parameter)
{
	const char * sipMsg = parameter->getSignaling();
	const unsigned char * contentData = parameter->getMessageData();
	int contentDataSize = parameter->getMessageDataLength();
}


void CP2PSampleDlg::onSIPSubscriptionFailure(ICallbackParameters * parameter)
{
	stringstream Text;
	Text << "Failed to send the SUBSCRIBE id = " << parameter->getSubscribeId();
}

void CP2PSampleDlg::onSIPSubscriptionTerminated(ICallbackParameters * parameter)
{
	stringstream Text;
	Text << "The subscription has been terminated: id = " << parameter->getSubscribeId();

}


void CP2PSampleDlg::onSIPRecvMesage(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	const char* mimeType = parameters->getMimeType();
	const char* subMimeType = parameters->getSubMimeType();

	const unsigned char * data = parameters->getMessageData();
	int len = parameters->getMessageDataLength();

	if (strstr(mimeType, "text") && strstr(subMimeType, "plain"))
	{
		stringstream Text;
		Text << "Received a MESSAGE message on line " << index << ": ";
		Text << data;
		::MessageBoxA(GetSafeHwnd(), Text.str().c_str(), "Received a MESSAGE message", MB_ICONINFORMATION);
	}
	else if (strstr(mimeType, "application") && (strstr(subMimeType, "vnd.3gpp.sms") || strstr(subMimeType, "vnd.3gpp2.sms")))
	{
		stringstream Text;
		Text << "Received a binary MESSAGE message on line " << index;
		::MessageBoxA(GetSafeHwnd(), Text.str().c_str(), "Received a MESSAGE message", MB_ICONINFORMATION);
	}
}


void CP2PSampleDlg::onSIPRecvOutOfDialogMessage(ICallbackParameters * parameters)
{
	const char* mimeType = parameters->getMimeType();
	const char* subMimeType = parameters->getSubMimeType();

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


void CP2PSampleDlg::onSIPSendMessageSuccess(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	log << "Send message succeed on line " << index;
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPSendMessageFailure(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	log << "Send message failure on line " << index;
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPSendOutOfDialogMessageSuccess(ICallbackParameters * parameters)
{
	m_LogList.InsertString(m_LogList.GetCount(), "Send out of dialog message succeed.");
}


void CP2PSampleDlg::onSIPSendOutOfDialogMessageFailure(ICallbackParameters * parameters)
{
	m_LogList.InsertString(m_LogList.GetCount(), "Send out of dialog message failure.");
}


void CP2PSampleDlg::onSIPPlayAudioFileFinished(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	const char* audioFileName = parameters->getPlayedAudioFileName();

	stringstream log;
	log << "Play audio file: " << audioFileName << " is finished on line " << index;
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::onSIPPlayVideoFileFinished(ICallbackParameters * parameters)
{
	int index = findSession(parameters->getSessionId());
	if (index == -1)
	{
		return;
	}

	stringstream log;
	log << "Play video file is finished on line " << index;
	m_LogList.InsertString(m_LogList.GetCount(), log.str().c_str());
}


void CP2PSampleDlg::OnClose()
{
	// TODO: Add your message handler code here and/or call default

	SIPUnRegister();
	CDialog::OnClose();
}

void CP2PSampleDlg::OnCbnSelchangeComboSpeakers()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == true)
	{
		PortSIP_setAudioDeviceId(m_SIPLib, m_MicrophonesList.GetCurSel(), m_SpeakersList.GetCurSel());
	}
}

void CP2PSampleDlg::OnCbnSelchangeComboMicrophones()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == true)
	{
		PortSIP_setAudioDeviceId(m_SIPLib, m_MicrophonesList.GetCurSel(), m_SpeakersList.GetCurSel());
	}
}

void CP2PSampleDlg::OnCbnSelchangeComboCameras()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == true)
	{
		PortSIP_setVideoDeviceId(m_SIPLib, m_CamerasList.GetCurSel());
	}
}

void CP2PSampleDlg::OnBnClickedCheck16()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}


	UpdateData(TRUE);

	if (m_AGC)
	{
		PortSIP_enableAGC(m_SIPLib, AGC_DEFAULT);
	}
	else
	{
		PortSIP_enableAGC(m_SIPLib, AGC_NONE);
	}
}

void CP2PSampleDlg::OnBnClickedCheck15()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}

	UpdateData(TRUE);

	if (m_VAD)
	{
		PortSIP_enableVAD(m_SIPLib, true);
	}
	else
	{
		PortSIP_enableVAD(m_SIPLib, false);
	}
}

void CP2PSampleDlg::OnBnClickedCheck25()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}


	UpdateData(TRUE);

	if (m_ANS)
	{
		PortSIP_enableANS(m_SIPLib, NS_DEFAULT);
	}
	else
	{
		PortSIP_enableANS(m_SIPLib, NS_NONE);
	}
}


void CP2PSampleDlg::OnBnClickedCheck17()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}


	UpdateData(TRUE);

	if (m_CNG)
	{
		PortSIP_enableCNG(m_SIPLib, true);
	}
	else
	{
		PortSIP_enableCNG(m_SIPLib, false);
	}
}



int CP2PSampleDlg::audioRawCallback(void * obj, 
									 long sessionId, 
									 AUDIOSTREAM_CALLBACK_MODE type,
									 unsigned char * data, 
									 int dataLength,
									 int samplingFreqHz)
{
	CP2PSampleDlg * pthis = (CP2PSampleDlg *)obj;

/*
	!!! IMPORTANT !!!

	Don¡¯t call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
	other code which will spend long time, you should post a message to main thread(main window) or other thread,
	let the thread to call SDK API functions or other code.

*/

	// The data parameter is audio stream as PCM format, 16bit, Mono.
	// the dataLength parameter is audio steam data length.



	if (type == AUDIOSTREAM_LOCAL_PER_CHANNEL)
	{
		// The callback data is from local record device of each session, use the sessionId to identifying the session.
	}
	else if (type == AUDIOSTREAM_REMOTE_PER_CHANNEL)
	{
		// The callback data is received from remote side of each session, use the sessionId to identifying the session.
	}


	return 0;
}


int CP2PSampleDlg::videoRawCallback(void * obj, 
									 long sessionId,
									 VIDEOSTREAM_CALLBACK_MODE type, 
									 int width, 
									 int height, 
									 unsigned char * data, 
									 int dataLength)
{
	CP2PSampleDlg * pthis = (CP2PSampleDlg *)obj;


/*
	!!! IMPORTANT !!!

	Don¡¯t call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
	other code which will spend long time, you should post a message to main thread(main window) or other thread,
	let the thread to call SDK API functions or other code.

	The video data format is YUV420.
*/



	int index = LINE_BASE;


	if (type == VIDEOSTREAM_LOCAL)
	{

	}
	else if (type == VIDEOSTREAM_REMOTE)
	{

	}

	return 0;
}


long CP2PSampleDlg::receivedRTPPacket(void *obj, long sessionId, bool isAudio, unsigned char * RTPPacket, int packetSize)
{
/*
	!!! IMPORTANT !!!

	Don¡¯t call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
	other code which will spend long time, you should post a message to main thread(main window) or other thread,
	let the thread to call SDK API functions or other code.

*/

	return 0;
}


long CP2PSampleDlg::sendingRTPPacket(void *obj, long sessionId, bool isAudio, unsigned char * RTPPacket, int packetSize)
{
/*
	!!! IMPORTANT !!!

	Don¡¯t call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
	other code which will spend long time, you should post a message to main thread(main window) or other thread,
	let the thread to call SDK API functions or other code.

*/

	return 0;
}



void CP2PSampleDlg::OnBnClickedCheck18()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}

	UpdateData(TRUE);

	if (m_AudioStreamCallback)
	{
		PortSIP_enableAudioStreamCallback(m_SIPLib, 
											m_SessionArray[m_ActiveLine].getSessionId(),
											true, 
											AUDIOSTREAM_REMOTE_PER_CHANNEL,
											this,
											audioRawCallback);
	}
	else
	{
		// Disable audio stream callback
		PortSIP_enableAudioStreamCallback(m_SIPLib, 
										  m_SessionArray[m_ActiveLine].getSessionId(),
										  false,
										  AUDIOSTREAM_NONE,
										  this, 
										  audioRawCallback);
	}
}

void CP2PSampleDlg::OnBnClickedCheckMicrophonemute()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}

	UpdateData(TRUE);

	if (m_MicrophoneMute)
	{
		PortSIP_muteMicrophone(m_SIPLib, true);
	}
	else
	{
		PortSIP_muteMicrophone(m_SIPLib, false);
	}

}

void CP2PSampleDlg::OnBnClickedButton30()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}

	UpdateData(TRUE);

	if (m_ForwardTo.Find("sip:")==-1 || m_ForwardTo.Find("@")==-1)
	{
		::MessageBoxA(GetSafeHwnd(), "The forward address must likes sip:xxxx@sip.portsip.com:5060", "Forward", MB_ICONINFORMATION);
		UpdateData(FALSE);

		return;
	}


	if (m_ForwardCallForBusy)
	{
		PortSIP_enableCallForward(m_SIPLib, true, (LPTSTR)(LPCTSTR)m_ForwardTo);
	}
	else
	{
		PortSIP_enableCallForward(m_SIPLib, false, (LPTSTR)(LPCTSTR)m_ForwardTo);
	}

	::MessageBoxA(GetSafeHwnd(), "The call forward is enabled.", "Forward", MB_ICONINFORMATION);

}


void CP2PSampleDlg::OnBnClickedButton31()
{
	// TODO: Add your control notification handler code here

	if (m_SIPInitialized == false)
	{
		::MessageBox(GetSafeHwnd(), "Please initialize the SDK first.", "Information", MB_ICONINFORMATION);
		return;
	}


	PortSIP_disableCallForward(m_SIPLib);

	::MessageBoxA(GetSafeHwnd(), "The call forward is disabled.", "Forward", MB_ICONINFORMATION);
}


void CP2PSampleDlg::OnCbnSelchangeCmbSrtpMode()
{
	setSRTPType();
}

void CP2PSampleDlg::OnCbnSelchangeCmbVideoResolution2()
{
	setVideoResolution();
}


void CP2PSampleDlg::OnBnClickedCheck21()
{
	// TODO: Add your control notification handler code here

	updatePrackSetting();
}


void CP2PSampleDlg::OnBnClickedCheck3()
{
	// TODO: Add your control notification handler code here

	updateDND();
}

