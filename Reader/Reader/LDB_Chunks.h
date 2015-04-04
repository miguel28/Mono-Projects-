/* !!!! GENERATED FILE - DO NOT EDIT !!!! */

/////////////////////////////////////////////////////////////////////////////
// This file is part of EasyRPG.
//
// EasyRPG is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// EasyRPG is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with EasyRPG Player. If not, see <http://www.gnu.org/licenses/>.
/////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////
/// LDB Reader namespace
////////////////////////////////////////////////////////////
namespace LDB_Reader {
	//struct ChunkActor {
		enum Index {
			name					= 0x01, // String
			title					= 0x02, // String
			character_name			= 0x03, // String
			character_index			= 0x04, // Integer
			transparent				= 0x05, // Flag
			initial_level			= 0x07, // Integer
			final_level				= 0x08, // Integer
			critical_hit			= 0x09, // Flag
			critical_hit_chance		= 0x0A, // Integer
			face_name				= 0x0F, // String
			face_index				= 0x10, // Integer
			two_swords_style		= 0x15, // Flag
			fix_equipment			= 0x16, // Flag
			auto_battle				= 0x17, // Flag
			super_guard				= 0x18, // Flag
			parameters				= 0x1F, // Array x 6 - Short
			exp_base				= 0x29, // Integer
			exp_inflation			= 0x2A, // Integer
			exp_correction			= 0x2B, // Integer
			initial_equipment		= 0x33, // Integer x 5
			unarmed_animation		= 0x38, // Integer
			class_id				= 0x39, // Integer - RPG2003
			battle_x				= 0x3B, // Integer - RPG2003
			battle_y				= 0x3C, // Integer - RPG2003
			battler_animation		= 0x3E, // Integer - RPG2003
			skills					= 0x3F, // Array - RPG::Learning
			rename_skill			= 0x42, // Flag
			skill_name				= 0x43, // String
			state_ranks_size		= 0x47, // Integer
			state_ranks				= 0x48, // Array - Short
			attribute_ranks_size	= 0x49, // Integer
			attribute_ranks			= 0x4A, // Array - Short
			battle_commands			= 0x50  // Array - RPG::BattleCommand - RPG2003
		};
	//};
};
