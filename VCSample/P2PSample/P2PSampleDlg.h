// SIPSampleDlg.h : header file
//

#pragma once


#include "Session.h"
#include "afxwin.h"
#include "afxcmn.h"


struct SIPEvent;



// CP2PSampleDlg dialog
class CP2PSampleDlg : public CDialog, public AbstractCallbackDispatcher
{
	// Construction
public:
	CP2PSampleDlg(CWnd* pParent = NULL);	// standard constructor

	// Dialog Data
	enum { IDD = IDD_P2PSAMPLE_DIALOG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


public:
	virtual BOOL PreTranslateMessage(MSG* pMsg);
	virtual BOOL OnInitDialog();

	virtual void onMessage(void * parameters);

	// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg LRESULT OnSIPCallbackEvent(WPARAM WParam, LPARAM LParam);
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()


public:
	afx_msg void OnBnClickedButton19();
	afx_msg void OnBnClickedButton20();
	afx_msg void OnCbnSelchangeComboLinelist();
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton2();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedButton4();
	afx_msg void OnBnClickedButton5();
	afx_msg void OnBnClickedButton6();
	afx_msg void OnBnClickedButton7();
	afx_msg void OnBnClickedButton8();
	afx_msg void OnBnClickedButton9();
	afx_msg void OnBnClickedButton10();
	afx_msg void OnBnClickedButton11();
	afx_msg void OnBnClickedButton12();
	afx_msg void OnBnClickedButton13();
	afx_msg void OnBnClickedButton14();
	afx_msg void OnBnClickedButton15();
	afx_msg void OnBnClickedButton16();
	afx_msg void OnBnClickedButton36();
	afx_msg void OnBnClickedButton17();
	afx_msg void OnBnClickedButton18();
	afx_msg void OnBnClickedCheck5();
	afx_msg void OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar);
	afx_msg void OnBnClickedButton21();
	afx_msg void OnBnClickedButton25();
	afx_msg void OnBnClickedButton27();
	afx_msg void OnBnClickedButton26();
	afx_msg void OnBnClickedButton35();
	afx_msg void OnBnClickedCheck1();
	afx_msg void OnBnClickedCheck6();
	afx_msg void OnBnClickedCheck7();
	afx_msg void OnBnClickedCheck8();
	afx_msg void OnBnClickedCheck9();
	afx_msg void OnBnClickedCheck10();
	afx_msg void OnBnClickedCheck11();
	afx_msg void OnBnClickedCheck12();
	afx_msg void OnBnClickedCheck13();
	afx_msg void OnBnClickedCheck14();
	afx_msg void OnBnClickedButton40();
	afx_msg void OnBnClickedButton38();
	afx_msg void OnBnClickedButton39();
	afx_msg void OnBnClickedButton42();
	afx_msg void OnBnClickedButton41();
	afx_msg void OnBnClickedButton43();
	afx_msg void OnClose();
	afx_msg void OnBnClickedButton22();
	afx_msg void OnCbnSelchangeComboSpeakers();
	afx_msg void OnCbnSelchangeComboMicrophones();
	afx_msg void OnCbnSelchangeComboCameras();
	afx_msg void OnBnClickedCheck16();
	afx_msg void OnBnClickedCheck15();
	afx_msg void OnBnClickedCheck17();
	afx_msg void OnBnClickedCheck18();
	afx_msg void OnBnClickedCheckMicrophonemute();
	afx_msg void OnBnClickedButton30();
	afx_msg void OnBnClickedButton31();
	afx_msg void OnBnClickedChkCodecG722();
	afx_msg void OnBnClickedChkCodecSpeex();
	afx_msg void OnBnClickedChkCodecAmrwb();
	afx_msg void OnBnClickedChkCodecSpeexwb();
	afx_msg void OnBnClickedChkCodecG7221();
	afx_msg void OnCbnSelchangeCmbSrtpMode();
	afx_msg void OnCbnSelchangeCmbVideoResolution2();
	afx_msg void OnBnClickedCheck19();
	afx_msg void OnBnClickedCheck22();	
	afx_msg void OnBnClickedCheck3();
	afx_msg void OnBnClickedChkCodecOpus();
	afx_msg void OnBnClickedCheck21();
	afx_msg void OnBnClickedCheck25();


public:

	CString m_UserName;
	CString m_Password;

	CString m_PhoneNumber;
	CComboBox m_LineList;
	CListBox m_LogList;
	BOOL m_MicrophoneMute;
	CSliderCtrl m_SpeakerVolume;
	CSliderCtrl m_MicrophoneVolume;
	CComboBox m_SpeakersList;
	CComboBox m_MicrophonesList;
	CComboBox m_CamerasList;
	BOOL m_CallSDP;
	BOOL m_DND;
	BOOL m_AA;
	BOOL m_Conference;
	CString m_RecordFilePath;
	CString m_RecordFileName;
	CString m_PlayAudioFilePathName;
	BOOL m_PCMU;
	BOOL m_PCMA;
	BOOL m_G729;
	BOOL m_ILBC;
	BOOL m_GSM;
	BOOL m_AMR;
	BOOL m_H263;
	BOOL m_H2631998;
	BOOL m_H264;

	BOOL m_AudioStreamCallback;
	BOOL m_AEC;
	BOOL m_AGC;
	BOOL m_CNG;
	BOOL m_VAD;
	CString m_ForwardTo;
	BOOL m_ForwardCallForBusy;
	int m_ConferenceId;

private:

	int findSession(long sessionId);

	bool loadDevices();

	void initDefaultAudioCodecs();
	void setSRTPType();
	void setVideoResolution();
	void setVideoQuality();

	void initSettings();

	void addPhoneNumber(string number);
	void SIPUnRegister();

	void updateAudioCodecs();
	void updateVideoCodecs();

	bool joinConference(int sessionId);
	void updatePrackSetting();

	void getVideoResolution(int& width, int& height);

	void updateDND();

	void onSIPCallIncoming(ICallbackParameters * parameters);
	void onSIPCallTrying(ICallbackParameters * parameters);
	void onSIPCallRinging(ICallbackParameters * parameters);
	void onSIPCallSessionProgress(ICallbackParameters * parameters);
	void onSIPCallAnswered(ICallbackParameters * parameters);
	void onSIPCallFailure(ICallbackParameters * parameters);
	void onSIPCallClosed(ICallbackParameters * parameters);
	void onSIPCallRemoteHold(ICallbackParameters * parameters);
	void onSIPCallRemoteUnhold(ICallbackParameters * parameters);
	void onSIPTransferTrying(ICallbackParameters * parameters);
	void onSIPTransferRinging(ICallbackParameters * parameters);
	void onSIPACTVTrasferFailure(ICallbackParameters * parameters);
	void onSIPACTVTransferSuccess(ICallbackParameters * parameters);	
	void onSIPInviteUpdated(ICallbackParameters * parameters);
	void onSIPInviteConnected(ICallbackParameters * parameters);
	void onSIPReceivedDtmfTone(ICallbackParameters * parameters);
	void onSIPCallForwarding(ICallbackParameters * parameters);
	void onSIPReceivedRefer(ICallbackParameters * parameters);
	void onSIPReferAccepted(ICallbackParameters * parameters);
	void onSIPReferRejected(ICallbackParameters * parameters);
	void onSIPRecvOptions(ICallbackParameters * parameters);
	void onSIPRecvInfo(ICallbackParameters * parameters);
	void onSIPRecvNotifyOfSubscription(ICallbackParameters * parameter);
	void onSIPSubscriptionFailure(ICallbackParameters * parameter);
	void onSIPSubscriptionTerminated(ICallbackParameters * parameter);
	void onSIPRecvMesage(ICallbackParameters * parameters);
	void onSIPRecvOutOfDialogMessage(ICallbackParameters * parameters);
	void onSIPSendMessageSuccess(ICallbackParameters * parameters);
	void onSIPSendMessageFailure(ICallbackParameters * parameters);
	void onSIPSendOutOfDialogMessageSuccess(ICallbackParameters * parameters);
	void onSIPSendOutOfDialogMessageFailure(ICallbackParameters * parameters);
	void onSIPPlayAudioFileFinished(ICallbackParameters * parameters);
	void onSIPPlayVideoFileFinished(ICallbackParameters * parameters);

	static int audioRawCallback(void * obj, 
		long sessionId, 
		AUDIOSTREAM_CALLBACK_MODE type,
		unsigned char * data, 
		int dataLength,
		int samplingFreqHz);

	static int videoRawCallback(void * obj, 
		long sessionId,
		VIDEOSTREAM_CALLBACK_MODE type, 
		int width, 
		int height, 
		unsigned char * data, 
		int dataLength);


	static long receivedRTPPacket(void *obj, long sessionId, bool isAudio, unsigned char * RTPPacket, int packetSize);
	static long sendingRTPPacket(void *obj, long sessionId, bool isAudio, unsigned char * RTPPacket, int packetSize);


private:
	HANDLE m_SIPLib;
	Session m_SessionArray[MAX_LINES];
	bool m_SIPInitialized;
	int m_ActiveLine;

public:

	int m_LocalSIPPort;
	CComboBox m_cmbSRTPMode;
	CComboBox m_cmbVideoResolution;
	CSliderCtrl m_sliderVideoQuality;
	BOOL m_G722;
	BOOL m_SPEEX;
	BOOL m_AMR_WB;
	BOOL m_SPEEX_WB;
	BOOL m_G7221;

	CStatic m_LocalVideo;
	CStatic m_RemoteVideo;

	BOOL m_VP8;
	BOOL m_Prack;
	BOOL m_ANS;
	BOOL m_MakeVideoCall;
	BOOL m_AnswerVideoCall;

	BOOL m_VP9;
};
