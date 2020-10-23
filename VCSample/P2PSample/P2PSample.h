// P2PSample.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CP2PSampleApp:
// See P2PSample.cpp for the implementation of this class
//

class CP2PSampleApp : public CWinApp
{
public:
	CP2PSampleApp();

// Overrides
	public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CP2PSampleApp theApp;