package com.msd.todolist.pojo;

import java.util.Date;

import com.fasterxml.jackson.annotation.JsonFormat;

public class UserFriendship {

	private int userFriendshipId;
	private String userNameInitiator;
	private String userNameFriend;
	private String friendshipStatus;
	
	@JsonFormat(pattern = "yyyy-MM-dd HH:mm:ss")
	
	private String createdBy;
	private String modifiedBy;
	
	@JsonFormat(pattern = "yyyy-MM-dd HH:mm:ss")
	private Date createdDate;
	
	@JsonFormat(pattern = "yyyy-MM-dd HH:mm:ss")
	private Date modifiedDate;
	
	
	public UserFriendship() {
		super();
		// TODO Auto-generated constructor stub
	}
	public UserFriendship(int userFriendshipId, String userNameInitiator, String userNameFriend, String friendshipStatus,
			String createdBy, String modifiedBy, Date createdDate, Date modifiedDate) {
		super();
		this.userFriendshipId = userFriendshipId;
		this.userNameInitiator = userNameInitiator;
		this.userNameFriend = userNameFriend;
		this.friendshipStatus = friendshipStatus;
		this.createdBy = createdBy;
		this.modifiedBy = modifiedBy;
		this.createdDate = createdDate;
		this.modifiedDate = modifiedDate;
	}
	public int getUserFriendshipId() {
		return userFriendshipId;
	}
	public void setUserFriendshipId(String userFriendshipId) {
		this.userFriendshipId = userFriendshipId;
	}
	public String getUserNameInitiator() {
		return userNameInitiator;
	}
	public void setUserNameInitiator(String userNameInitiator) {
		this.userNameInitiator = userNameInitiator;
	}
	public String getUserNameFriend () {
		return userNameFriend;
	}
	public void setUserNameFriend (String userNameFriend ) {
		this.userNameFriend = userNameFriend;
	}
	public String getFriendshipStatus() {
		return friendshipStatus;
	}
	public void setFriendshipStatus(String friendshipStatus) {
		this.friendshipStatus = friendshipStatus;
	}
	public String getCreatedBy() {
		return createdBy;
	}
	public void setCreatedBy(String createdBy) {
		this.createdBy = createdBy;
	}
	public String getModifiedBy() {
		return modifiedBy;
	}
	public void setModifiedBy(String modifiedBy) {
		this.modifiedBy = modifiedBy;
	}
	public Date getCreatedDate() {
		return createdDate;
	}
	public void setCreatedDate(Date createdDate) {
		this.createdDate = createdDate;
	}
	public Date getModifiedDate() {
		return modifiedDate;
	}
	public void setModifiedDate(Date modifiedDate) {
		this.modifiedDate = modifiedDate;
	}
	
}
