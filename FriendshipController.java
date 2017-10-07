package com.msd.todolist.controller;

import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.msd.todolist.pojo.UserFriendship;
import com.msd.todolist.service.FriendshipService;

@RestController
public class FriendshipController {

	@Autowired
	FriendshipService friendshipService;
	
	@RequestMapping(value="/listUserFriend",method=RequestMethod.POST, headers={"Content-Type=application/json"})
	public Map<String, Object> listUserFriend(@RequestBody UserFriendship userFriends) throws Exception{
		return friendshipService.listUserFriend(userFriends);
	}
}