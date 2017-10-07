package com.msd.todolist.mapper;

import java.sql.ResultSet;
import java.sql.SQLException;

import org.springframework.jdbc.core.RowMapper;

import com.msd.todolist.pojo.UserFriendship;

public class UserFriendshipMapper implements RowMapper<UserFriendship>{

	@Override
	public UserFriendship mapRow(ResultSet rs, int rowNumber) throws SQLException {
		UserFriendship userFriendship = null;
		if(rs != null) {
			userFriendship = new UserFriendship();
			userFriendship.setUserFriendshipId(rs.getInt("user_friendship_id"));
			userFriendship.setUserNameInitiator(rs.getString("user_name_initiator"));
			userFriendship.setUserNameFriend(rs.getString("user_name_friend"));
			userFriendship.setFriendshipStatus(rs.getString("friend_status"));
			userFriendship.setCreatedBy(rs.getString("created_by"));
			userFriendship.setModifiedBy(rs.getString("modified_by"));
			userFriendship.setCreatedDate(rs.getTimestamp("created_date"));
			userFriendship.setModifiedDate(rs.getTimestamp("modified_date"));

		}
		return userFriendship;
	}

}