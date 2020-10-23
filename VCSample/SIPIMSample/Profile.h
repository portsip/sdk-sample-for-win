
#ifndef __PROFILE_H
#define __PROFILE_H

#include "Ini.h"

class Profile
{
public:
	Profile(const string & FileName);
	Profile();

	virtual ~Profile();


public:
	void Attach(const string & FileName);

	int GetSectionNames(CStringArray & SectionNames);
	
	void DeleteSection(const string & SectionName);

	bool IsSectionExists(const string & SectionName);



public:


#define CONTACT_SIPURI				"sipuri"
#define CONTACT_BLOCKED				"blocked"
#define CONTACT_SUBSCRIBED			"subscribed"
#define CONTACT_ACCEPTEDSUBSCRIBED	"acceptedsubscribed"
#define CONTACT_SUBSCRIBEID			"subscribeid"



	void SetSipUri(const string & SectionName, const string & SipUri)
	{
		m_IniFile.WriteString(SectionName.c_str(), CONTACT_SIPURI, SipUri.c_str());
	}

	string GetSipUri(const string & SectionName)
	{
		char buffer[1024] = { 0 };
		m_IniFile.GetString(SectionName.c_str(), CONTACT_SIPURI, buffer, 1024);

		string uri = buffer;

		return uri;
	}

	void SetBlocked(const string & SectionName, bool state)
	{
		BOOL Status = TRUE;
		if (state == false)
		{
			Status = FALSE;
		}

		m_IniFile.WriteBool(SectionName.c_str(), CONTACT_BLOCKED, Status);
	}


	bool GetBlocked(const string & SectionName)
	{
		if (m_IniFile.GetBool(SectionName.c_str(), CONTACT_BLOCKED, FALSE))
		{
			return TRUE;
		}

		return FALSE;
	}



	void SetSubscribed(const string & SectionName, bool state)
	{
		BOOL Status = TRUE;
		if (state == false)
		{
			Status = FALSE;
		}

		m_IniFile.WriteBool(SectionName.c_str(), CONTACT_SUBSCRIBED, Status);
	}



	bool GetSubscribed(const string & SectionName)
	{
		if (m_IniFile.GetBool(SectionName.c_str(), CONTACT_SUBSCRIBED, FALSE))
		{
			return true;
		}

		return false;
	}



	void SetAcceptedSubscribed(const string & SectionName, bool state)
	{
		BOOL Status = TRUE;
		if (state == false)
		{
			Status = FALSE;
		}

		m_IniFile.WriteBool(SectionName.c_str(), CONTACT_ACCEPTEDSUBSCRIBED, Status);
	}


	bool GetAcceptedSubscribed(const string & SectionName)
	{
		if (m_IniFile.GetBool(SectionName.c_str(), CONTACT_ACCEPTEDSUBSCRIBED, FALSE))
		{
			return TRUE;
		}

		return FALSE;
	}


	void SetSubscribeId(const string & SectionName, long subscribeId)
	{
		char Id[32] = { 0 };
		_ltoa(subscribeId, Id, 10);
		m_IniFile.WriteString(SectionName.c_str(), CONTACT_SUBSCRIBEID, Id);
	}

	LONG GetSubscribeId(const string & SectionName)
	{
		char buffer[32] = { 0 };

		m_IniFile.GetString(SectionName.c_str(), CONTACT_SUBSCRIBEID, buffer, 32);

		return atol(buffer);
	}




protected:



private:

	CIni m_IniFile;

};




#endif
