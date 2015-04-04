#include <iostream>

using namespace std;

namespace RPG{
	class Header{
	public:
		string Info;
		short NumActors;
	};
	
	class Actor {
	public:
		void Init();
		int ID;
		string Name;
		string Title;
		string Character_Name;
		int Character_Index;
		bool Transparent;
		int Initial_Level;
		int Final_Level;
		bool Critical_Hit;
		int critical_Hit_Chance;
		string Face_Name;
		int Face_Index;
		bool Two_Swords_Style;
		bool Fix_Equipment;
		bool Auto_Battle;
		bool Super_Guard;
		//Parameters parameters;
		int Exp_Base;
		int Exp_Inflation;
		int Exp_Correction;
		//Equipment initial_equipment;
		int Unarmed_Animation;
		int Class_Id;
		int Battle_x;
		int Battle_y;
		int Battler_Animation;
		//std::vector<Learning> skills;
		bool Rename_skill;
		//std::string skill_name;
		//std::vector<uint8_t> state_ranks;
		//std::vector<uint8_t> attribute_ranks;
		//std::vector<uint32_t> battle_commands;
	};
};