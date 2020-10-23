
#include "stdafx.h"
#include "Ini.h"
#include "profile.h"


Profile::Profile()
{

}



Profile::Profile(const string & FileName)
		:m_IniFile(FileName.c_str())
{

}



Profile::~Profile()
{

}



void Profile::Attach(const string & FileName)
{
	if (FileName.empty() == true)
	{
		return;
	}

	m_IniFile.SetPathName(FileName.c_str());
}



int Profile::GetSectionNames(CStringArray & SectionNames)
{

	m_IniFile.GetSectionNames(&SectionNames);

	return (int)SectionNames.GetCount();
}


void Profile::DeleteSection(const string & SectionName)
{
	if (SectionName.empty() == true)
	{
		return;
	}

	m_IniFile.DeleteSection(SectionName.c_str());
}



bool Profile::IsSectionExists(const string & SectionName)
{
	if (m_IniFile.IsSectionExist(SectionName.c_str()))
	{
		return true;
	}

	return false;	
}



