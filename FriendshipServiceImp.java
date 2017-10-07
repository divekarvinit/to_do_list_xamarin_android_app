package com.msd.todolist.service.impl;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.Timestamp;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.PreparedStatementCreator;
import org.springframework.jdbc.support.GeneratedKeyHolder;
import org.springframework.jdbc.support.KeyHolder;
import org.springframework.stereotype.Service;

import com.msd.todolist.mapper.UserFriendshipMapper;
import com.msd.todolist.pojo.UserFriendship;
import com.msd.todolist.service.FriendshipService;

@Service
public class FriendshipServiceImpl implements FriendshipService {

	@Autowired
	JdbcTemplate jdbcTemplate;
	
	@Override
	public Map<String, Object> listUserFriend(UserFriendship userFriends) {
		boolean isRecordValid = true;
		HashMap<String, Object> returnMap = new HashMap<String, Object>();
		
	private UserFriendship getUserFriendshipStatus(String user_name_initiator) {
	String queryForUserFriendshipStatus = "SELECT * FROM user_friendship where user_name_initiator AND friendship_status = 'FRIENDS'";
	List<UserFriendship> userFriendsList = jdbcTemplate.query(queryForUserFriendshipStatus,new Object[] {user_name_initiator}, new UserFriendshipMapper());
	if ( userFriendsList.isEmpty() ){
		return null;
	}
	return userFriendsList.get(0);
	}

