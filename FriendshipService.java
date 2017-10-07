package com.msd.todolist.service;

import java.util.Map;

import com.msd.todolist.pojo.UserFriendship;

public interface FriendshipService {

	public Map<String, Object> listUserFriend(UserFriendship userFriends);
}
