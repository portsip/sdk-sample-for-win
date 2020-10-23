#pragma once


// CContactsDlg dialog

class CContactsDlg : public CDialog
{
	DECLARE_DYNAMIC(CContactsDlg)

public:
	CContactsDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~CContactsDlg();


public:
	void SetContactName(string ContactName);
	void SetSubject(string Subject);


// Dialog Data
	enum { IDD = IDD_DIALOG1 };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()


private:
	CString m_ContactName;
	CString m_Subject;

	CString m_StatusLine1;


public:
	afx_msg void OnBnClickedOk();
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton2();
	afx_msg void OnShowWindow(BOOL bShow, UINT nStatus);
	
	virtual BOOL PreTranslateMessage(MSG* pMsg);




};
