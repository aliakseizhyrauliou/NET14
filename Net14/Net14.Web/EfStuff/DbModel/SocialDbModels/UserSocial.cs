﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSocial;


namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class UserSocial : BaseModel
    {
        public string UserPhoto { get; set; } = "/images/Social/User.jpg";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual List<PostSocial> Posts { get; set; }
        public virtual List<GroupSocial> Groups { get; set; }
        public virtual List<UserFriend> Friends { get; set; } = new List<UserFriend>();
        public virtual ICollection<UserFriendRequest> FriendRequestSent { get; set; } = new List<UserFriendRequest>();
        public virtual ICollection<UserFriendRequest> FriendRequestReceived { get; set; } = new List<UserFriendRequest>();



    }
}
