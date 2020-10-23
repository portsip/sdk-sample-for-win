// SIPIMSampleDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include "Profile.h"
#include "afxcmn.h"

struct SIPEvent;


// CSIPIMSampleDlg dialog
class CSIPIMSampleDlg : public CDialog, public AbstractCallbackDispatcher
{
// Construction
public:
	CSIPIMSampleDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_SIPIMSAMPLE_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

	void onMessage(void * parameters);

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg LRESULT OnSIPCallbackEvent(WPARAM WParam, LPARAM LParam);
	DECLARE_MESSAGE_MAP()





public:
	virtual BOOL PreTranslateMessage(MSG* pMsg);


public:
	afx_msg void OnBnClickedButton19();
	afx_msg void OnBnClickedButton20();
	afx_msg void OnClose();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton2();
	afx_msg void OnBnClickedButton4();
	afx_msg void OnBnClickedButton5();



private:

	BOOL InitWinSock();
	void LoadContacts();

	void Init();
	void Offline();

	void Release();

	string GetLocalPath();

	void OnPresenceOffline(ICallbackParameters * parameters);
	void OnPresenceOnline(ICallbackParameters * parameters);
	void OnPresenceRecvSubscribe(ICallbackParameters * parameters);
	void OnSendOutOfDialogMessageFailure(ICallbackParameters * parameters);
	void OnSendOutOfDialogMessageSuccess(ICallbackParameters * parameters);
	void OnRecvOutOfDialogMessage(ICallbackParameters * parameters);


public:


	CString m_UserName;
	CString m_Password;
	CString m_SIPSever;
	int m_SIPSeverPort;
	CString m_StunServer;
	CString m_UserDomain;
	int m_StunServerPort;
	CListBox m_LogList;
	CListCtrl m_ContactsList;


	CString m_MyStatusText;
	CString m_AddContactName;
	CString m_SendMessage;
	CString m_SendTo;
	CString m_DisplayName;
	CString m_AuthName;


public:

	HANDLE m_SIPLib;
	bool m_SIPInitialized;
	bool m_SIPRegistered;
	Profile m_Contacts;

/*
  We are store the contacts information into an INI file.
  Each contact has a section in INI file likes below,
  the section name is contacts SIP uri.

  the section has these keys:
  1: sipuri - this key use for save contact's sip uri, same as section name.
  2: blocked - if rejected a subscribe request then set this key value to 1.
  3: subscribed - If we subscribed a contact, then set this key value to 1; If this key value is 0,
	 means we do not subscribe him yet.
  4: acceptedsubscribed - When received a subscribe request, if accepted it, then set this key value 
	 to 1, otherwise set it to 0; 
  5: subscribedid - When received a subscribe request, it has an id: subscribeId, need to save this id.
     When we update own status, need to use this id to notify contacts.



	[sip:test@sip.portsip.com:5060]
	sipuri=sip:test@sip.portsip.com:5060
	blocked=0
	subscribed=1
	acceptedsubscribed=0
	subscribeid=0
*/



int m_PresenceMode;
};



extern CSIPIMSampleDlg * g_MainDlg;