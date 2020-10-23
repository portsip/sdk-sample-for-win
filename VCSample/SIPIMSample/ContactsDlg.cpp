// ContactsDlg.cpp : implementation file
//

#include "stdafx.h"
#include "SIPIMSample.h"
#include "ContactsDlg.h"


// CContactsDlg dialog

IMPLEMENT_DYNAMIC(CContactsDlg, CDialog)

CContactsDlg::CContactsDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CContactsDlg::IDD, pParent)
	, m_StatusLine1(_T(""))

{

}

CContactsDlg::~CContactsDlg()
{
}

void CContactsDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_STATIC_CONTACTNAME, m_StatusLine1);
}


BEGIN_MESSAGE_MAP(CContactsDlg, CDialog)
	ON_BN_CLICKED(IDOK, &CContactsDlg::OnBnClickedOk)
	ON_BN_CLICKED(IDC_BUTTON1, &CContactsDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CContactsDlg::OnBnClickedButton2)
	ON_WM_SHOWWINDOW()
END_MESSAGE_MAP()


// CContactsDlg message handlers

void CContactsDlg::OnBnClickedOk()
{
	// TODO: Add your control notification handler code here


	OnOK();
}

void CContactsDlg::OnBnClickedButton1()
{
	// TODO: Add your control notification handler code here



	OnOK();
}

void CContactsDlg::OnBnClickedButton2()
{
	// TODO: Add your control notification handler code here



	OnCancel();
}




void CContactsDlg::SetContactName(string ContactName)
{
	m_ContactName = ContactName.c_str();
}



void CContactsDlg::SetSubject(string Subject)
{
	m_Subject = Subject.c_str();
}



void CContactsDlg::OnShowWindow(BOOL bShow, UINT nStatus)
{
	CDialog::OnShowWindow(bShow, nStatus);

	// TODO: Add your message handler code here


	m_StatusLine1 = m_ContactName;

	UpdateData(FALSE);
}

BOOL CContactsDlg::PreTranslateMessage(MSG* pMsg)
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
