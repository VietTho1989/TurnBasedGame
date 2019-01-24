/*
* Copyright (C) 2015 Sergio Nunes da Silva Junior 
*
* C++ Nine Men's Morris Agent using alpha-beta prunning algorithm
* Assignment of Artificial Intelligence Course - 2/2015
*
* This program is free software; you can redistribute it and/or modify it
* under the terms of the GNU General Public License as published by the Free
* Software Foundation; either version 2 of the License.
*
* This program is distributed in the hope that it will be useful, but WITHOUT
* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
* FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
* more details.
*
* author: Sergio Nunes da Silva Junior
* contact: sergio.nunes@dcc.ufmg.com.br
* Universidade Federal de Minas Gerais (UFMG) - Brazil
*/

#ifndef SPOT_H
#define SPOT_H

#include <string>
#include <iostream>

enum SpotStatus
{
	SS_Empty,
	SS_Black,
	SS_White
};

struct Spot
{
public:
	SpotStatus status;
	Spot *up, *lf, *rt, *dn;
	std::string id;
	int pos;
	
	Spot()
	{
		up = lf = rt = dn = nullptr;
		status = SS_Empty;
	}

	~Spot()
	{}

	void setUp(Spot* upper)
	{
		up = upper;
		upper->dn = this;
	}
	
	void setDown(Spot* downer)
	{
		dn = downer;
		downer->up = this;
	}

	void setLeft(Spot* lefter)
	{
		lf = lefter;
		lefter->rt = this;
	}

	void setRight(Spot* righter)
	{
		rt = righter;
		righter->lf = this;
	}

	void copy(Spot* to)
	{
		to->id = this->id;
		to->status = this->status;
	}


	friend std::ostream& operator<<(std::ostream& o, Spot *s)
	{
		switch (s->status)
		{
		case SS_Empty:	o << " ";	break;
		case SS_White:	o << "W";	break;
		case SS_Black:	o << "B";	break;
		}
		return o;
	}
};

#endif
